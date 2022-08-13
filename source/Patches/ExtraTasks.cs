using HarmonyLib;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Reactor;

namespace BetterTownOfUs.Patches
{

    [HarmonyPatch(typeof(ShipStatus))]
    public class ShipStatusPatch
    {
        private static bool check = false;


        private static void ApplyChange()
        {    
            
            if (ShipStatus.Instance.name != "PolusShip(Clone)")
                return;
            
            if (CustomGameOptions.VitalsBTOU) MoveVitals();
            if (CustomGameOptions.VentsBTOU) AdjustVents();
            if (CustomGameOptions.TasksBTOU) MoveTasks();
        }
    
        private static void MoveVitals()
    {
      GameObject science = Object.FindObjectsOfType<GameObject>().ToList().Find(o => o.name == "Science");
      SystemConsole vitals = Object.FindObjectsOfType<SystemConsole>().ToList().Find(console => console.name == "panel_vitals");
      Transform vitalsTransform = vitals.transform;
      vitalsTransform.parent = science.transform;
      vitalsTransform.position = /*CustomGameOptions.TasksBTOU ? new Vector3(31.275f, -6.45f, 1) : */new Vector3(30.25f, -6.65f, 1);
      AddDvdScreen();
      //if (CustomGameOptions.TasksBTOU) return;
      Object.Destroy(Object.FindObjectsOfType<GameObject>().ToList().Find(console => console.name == "Weathermap0001"));
      vitalsTransform.localScale = new Vector3(1.15f, 1.15f, 1);
    }

    private static void AdjustVents()
    {
      List<Vent> ventsList = Object.FindObjectsOfType<Vent>().ToList();            
      Vent LeftReactorVent = ventsList.Find(vent => vent.gameObject.name == "ElectricBuildingVent");
      Vent electricalVent = ventsList.Find(vent => vent.gameObject.name == "ElectricalVent");
      Vent RightReactorVent = ventsList.Find(vent => vent.gameObject.name == "ScienceBuildingVent");
      Vent storageVent = ventsList.Find(vent => vent.gameObject.name == "StorageVent");
      LeftReactorVent.Left = electricalVent;
      electricalVent.Center = LeftReactorVent;
      RightReactorVent.Left = storageVent;
      storageVent.Center = RightReactorVent;
    }

    private static void MoveTasks()
    {
        GameObject outside = Object.FindObjectsOfType<GameObject>().ToList().Find(o => o.name == "Outside");
        GameObject comms = Object.FindObjectsOfType<GameObject>().ToList().Find(o => o.name == "Comms");
        GameObject dropShip = Object.FindObjectsOfType<GameObject>().ToList().Find(o => o.name == "Dropship");
        GameObject storage = Object.FindObjectsOfType<GameObject>().ToList().Find(o => o.name == "Storage");
        Transform tempCold = Object.FindObjectsOfType<Console>().ToList().Find(console => console.name == "panel_tempcold").transform;
        BoxCollider2D collider = tempCold.GetComponent<BoxCollider2D>();
        Transform wifi = Object.FindObjectsOfType<Console>().ToList().Find(console => console.name == "panel_wifi").transform;
        Console qrConsole = Object.FindObjectsOfType<Console>().ToList().Find(console => console.name == "panel_boardingpass");
        Transform qr = qrConsole.transform;
        Console keysConsole = Object.FindObjectsOfType<Console>().ToList().Find(console => console.name == "panel_keys");
        Transform keys = keysConsole.transform;

        //tempCold.parent = outside.transform;
        //tempCold.position = new Vector3(7.772f, -17.103f, -0.017f);
        //collider.isTrigger = false;
        //collider.size += new Vector2(0, -0.3f);

        wifi.parent = dropShip.transform;
        wifi.position = new Vector3(17.38f, 0.15f, 1f);
        qr.parent = comms.transform;
        qr.position = new Vector3(11.07f, -15.2f, -0.015f);
        qr.localScale = new Vector3(0.25f, 0.5f, 1);
        qrConsole.checkWalls = true;
        keys.parent = storage.transform.GetChild(1);
        keys.position = new Vector3(20.13f, -10.35f, 0f);
        keysConsole.checkWalls = true; 

      if (!CustomGameOptions.VitalsBTOU) AddDvdScreen();
    }

    private static void AddDvdScreen()
    {
      Transform dvdScreen = Object.Instantiate(Object.FindObjectsOfType<GameObject>().ToList().Find(o => o.name == "dvdscreen")).transform;
      Vector3 pos = CustomGameOptions.VitalsBTOU ? new Vector3(CustomGameOptions.VitalsBTOU && CustomGameOptions.TasksBTOU ? 26.26f : 26.635f, -15.92f, 1) : new Vector3(25.8f, -15.95f, 1);
      dvdScreen.position = pos;
      dvdScreen.localScale = new Vector3(CustomGameOptions.VitalsBTOU && CustomGameOptions.TasksBTOU ? 1.1f : 0.75f, 1, 1);
    }
        [HarmonyPostfix]
        [HarmonyPatch(typeof(ShipStatus), nameof(ShipStatus.IsGameOverDueToDeath))]
        public static void Postfix(ShipStatus __instance, ref bool __result)
        {
            __result = false;
            
        }

        private static int CommonTasks = PlayerControl.GameOptions.NumCommonTasks;
        private static int ShortTasks = PlayerControl.GameOptions.NumShortTasks;
        private static int LongTasks = PlayerControl.GameOptions.NumLongTasks;

        [HarmonyPrefix]
        [HarmonyPatch(typeof(ShipStatus), nameof(ShipStatus.Begin))]
        public static bool Prefix(ShipStatus __instance)
        {
            var commonTask = __instance.CommonTasks.Count;
            var normalTask = __instance.NormalTasks.Count;
            var longTask = __instance.LongTasks.Count;
            CommonTasks = PlayerControl.GameOptions.NumCommonTasks;
            ShortTasks = PlayerControl.GameOptions.NumShortTasks;
            LongTasks = PlayerControl.GameOptions.NumLongTasks;
            if (PlayerControl.GameOptions.NumCommonTasks > commonTask) PlayerControl.GameOptions.NumCommonTasks = commonTask;
            if (PlayerControl.GameOptions.NumShortTasks > normalTask) PlayerControl.GameOptions.NumShortTasks = normalTask;
            if (PlayerControl.GameOptions.NumLongTasks > longTask) PlayerControl.GameOptions.NumLongTasks = longTask;
            
            //Mes changements
            check = false;
            ApplyChange();
            return true;
        }
        [HarmonyPrefix]
        [HarmonyPatch(typeof(ShipStatus), nameof(ShipStatus.Awake))]
        public static void Prefix2(ShipStatus __instance)
        {
            check = false;
        }

        [HarmonyPostfix]
        [HarmonyPatch(typeof(ShipStatus), nameof(ShipStatus.Begin))]
        public static void Postfix2(ShipStatus __instance)
        {
            PlayerControl.GameOptions.NumCommonTasks = CommonTasks;
            PlayerControl.GameOptions.NumShortTasks = ShortTasks;
            PlayerControl.GameOptions.NumLongTasks = LongTasks;
        }
        [HarmonyPrefix]
        [HarmonyPatch(typeof(ShipStatus), nameof(ShipStatus.FixedUpdate))]
        public static void Prefix4(ShipStatus __instance)
        {
            if (check) return;
            ApplyChange();
            check = true;
        }
    }
}
