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
    internal class AdjustFoxAI
    {
        //常规版本
        [HarmonyPrefix]
        [HarmonyPatch(typeof(NelNFox), "readTicket")]
        public static bool DisableFoxAttackingAfterDeath(NelNFox __instance,  ref NaTicket Tk)
        {
            PR pr = __instance.AimPr as PR;
            //战败之后不再会攻击
            if (!pr.is_alive)
            {
                switch (Tk.type)
                {
                    case NAI.TYPE.PUNCH_WEED:
                        Tk = Tk.Recreate(NAI.TYPE.WALK);
                        break;
                    case NAI.TYPE.MAG:
                        Tk = Tk.Recreate(NAI.TYPE.WALK);
                        break;
                    case NAI.TYPE.MAG_0:
                        Debug.Log("NAI.TYPE.MAG_0 detected!calling runPunchWeed");
                        //Tk = Tk.Recreate(NAI.TYPE.WALK);
                        break;
                    case NAI.TYPE.MAG_2:
                        Tk = Tk.Recreate(NAI.TYPE.WALK);
                        break;
                }
            }
            return true;
        }
    }
}
