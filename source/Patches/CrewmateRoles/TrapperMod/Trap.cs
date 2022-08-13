﻿using HarmonyLib;
using Reactor;
using System;
using System.Collections;
using System.Collections.Generic;
using BetterTownOfUs.Roles;
using UnityEngine;
using Object = UnityEngine.Object;

namespace BetterTownOfUs.CrewmateRoles.TrapperMod
{
    public class Trap
    {
        public Dictionary<byte, float> players = new Dictionary<byte, float>();
        public Transform transform;

        public IEnumerator FrameTimer()
        {
            while (transform != null)
            {
                yield return 0;
                Update();
            }
        }

        public void Update()
        {
            foreach (PlayerControl player in PlayerControl.AllPlayerControls)
            {
                if (player.Data.IsDead) continue;
                if (Vector2.Distance(transform.position, player.GetTruePosition()) < CustomGameOptions.TrapSize + 0.05f)
                {
                    if (!players.ContainsKey(player.PlayerId)) players.Add(player.PlayerId, 0f);
                } else
                {
                    if (players.ContainsKey(player.PlayerId)) players.Remove(player.PlayerId);
                }

                var entry = player.PlayerId;
                if (players.ContainsKey(entry))
                {
                    players[entry] += Time.deltaTime;
                    if (players[entry] > CustomGameOptions.MinAmountOfTimeInTrap)
                    {
                        foreach (Trapper t in Role.GetRoles(RoleEnum.Trapper))
                        {
                            RoleEnum playerrole = Role.GetRole(Utils.PlayerById(entry)).RoleType;
                            if (!t.trappedPlayers.Contains(playerrole)) t.trappedPlayers.Add(playerrole);
                        }
                    }
                }
            }
        }
    }

    [HarmonyPatch]
    public static class TrapExtentions
    {
        public static void ClearTraps(this List<Trap> obj)
        {
            foreach (Trap t in obj)
            {
                Object.Destroy(t.transform.gameObject);
                Coroutines.Stop(t.FrameTimer());
            }
            obj.Clear();
        }

        public static Trap CreateTrap(this Vector3 location)
        {
            var TrapPref = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            TrapPref.name = "Trap";
            TrapPref.transform.localScale = new Vector3(CustomGameOptions.TrapSize, CustomGameOptions.TrapSize, CustomGameOptions.TrapSize);
            GameObject.Destroy(TrapPref.GetComponent<SphereCollider>());
            TrapPref.GetComponent<MeshRenderer>().material = Roles.Trapper.trapMaterial;
            TrapPref.transform.position = location;
            var TrapScript = new Trap();
            TrapScript.transform = TrapPref.transform;
            Coroutines.Start(TrapScript.FrameTimer());
            return TrapScript;
        }

        
    }
}