using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BepInEx;
using BepInEx.Configuration;
using BepInEx.Logging;
using HarmonyLib;
using UnityEngine;

namespace FrustratedNoel
{

    [BepInPlugin("aie.top.plugins.Frustratednoel", "使用这个插件可能会让诺艾尔很疲惫", "0.1.0.0")]
    [BepInProcess("AliceInCradle.exe")]
    public class PluginBase : BaseUnityPlugin
    {
        internal static ManualLogSource logger;
        private void Awake()
        {
            Debug.Log("Loading aie.top.plugins.Frustratednoel");
        }
        private void Start()
        {
            Debug.Log("All pulgins loaded. Preparing for patch...");
            logger = base.Logger;
            //一般而言魔改版不需要开关，因此直接Patch就行了
            Patch(typeof(AdjustGolemAI));
        }
        private void Update()
        {
            //var key = new BepInEx.Configuration.KeyboardShortcut(KeyCode.F9);
            //if (key.IsDown())
            //{
            //    Debug.Log("Pressed F9");
            //}
        }
        private void OnDestory()
        {
            Debug.Log("Destorying aie.top.plugins.Frustratednoel, quitting");
        }
        //仅仅只是与代码挂钩
        private bool Patch(Type patch_type)
        {
            try
            {
                Harmony.CreateAndPatchAll(patch_type, null);
            }
            catch(Exception e)   
            {
                logger.LogInfo(string.Format("While Patch {0}-----\r\n{1}", patch_type,e.Message));
                return false;
            }
            return true;
        }
        //向配置文件写入
        private bool Patch(Type patch_type, string section, params string[] key_list)
        {
            try
            {
                Harmony.CreateAndPatchAll(patch_type, null);
            }
            catch(Exception e)
            {
                logger.LogInfo(string.Format("While Patch {0}-----\r\n{1}", patch_type, e.Message));
                foreach (string text in key_list)
                {
                    base.Config.Remove(new ConfigDefinition(section, text));
                }
                return false;
            }
            return true;
        }
    }

}
