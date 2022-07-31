using HarmonyLib;
using nel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace FrustratedNoel
{
    //禁止巨人在战败之后砸诺艾尔
    internal class AdjustGolemAI
    {
        //常规版本
        [HarmonyPrefix]
        [HarmonyPatch(typeof(NelNGolem), "readTicket")]
        public static bool DisableGolemThrowPawnAfterDeath(ref NaTicket Tk)
        {
            return true;
        }
        //污染版本
        [HarmonyPrefix]
        [HarmonyPatch(typeof(NelNGolem), "readTicketOd")]
        public static bool DisableGolemThrowPawnAfterDeathOd(NelNGolem __instance ref NaTicket Tk)
        {

            PR pr = __instance.AimPr as PR;
            if (!pr.is_alive)
            {
                if (Tk.type == NAI.TYPE.PUNCH_2)
                {
                    Tk = Tk.Recreate(NAI.TYPE.PUNCH_1,-1,false);
                }
            }
            return true;
        }
    }
}
