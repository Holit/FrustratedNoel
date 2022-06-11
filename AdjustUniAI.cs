using HarmonyLib;
using nel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrustratedNoel
{
    internal class AdjustUniAI
    {
        //常规版本
        [HarmonyPrefix]
        [HarmonyPatch(typeof(NelNUni), "readTicket")]
        public static bool DisableUniAttackingAfterDeath(NelNUni __instance, ref NaTicket Tk)
        {
            PR pr = __instance.AimPr as PR;

            if (!pr.is_alive)
            {
                switch (Tk.type)
                {
                    case NAI.TYPE.PUNCH_WEED:
                        Tk.Recreate(NAI.TYPE.WALK, -1, false);
                        break;
                    case NAI.TYPE.MAG:
                        Tk.Recreate(NAI.TYPE.WALK, -1, false);
                        break;
                    case NAI.TYPE.MAG_0:
                        Tk.Recreate(NAI.TYPE.WALK, -1, false);
                        break;
                }
            }
            return true;
        }
        //污染版本
        [HarmonyPrefix]
        [HarmonyPatch(typeof(NelNUni), "readTicketOd")]
        public static bool DisableUniAttackingAfterDeathOd(NelNUni __instance, ref NaTicket Tk)
        {

            PR pr = __instance.AimPr as PR;
            if (!pr.is_alive)
            {
                switch (Tk.type)
                {
                    case NAI.TYPE.PUNCH_0:
                        Tk.Recreate(NAI.TYPE.WALK, -1, false);
                        break;
                }
            }
            return true;
        }
    }
}
