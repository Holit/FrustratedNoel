using HarmonyLib;
using nel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrustratedNoel
{
    internal class AdjustFoxAI
    {
        //常规版本
        [HarmonyPrefix]
        [HarmonyPatch(typeof(NelNFox), "readTicket")]
        public static bool DisableFoxAttackingAI(ref NaTicket Tk,ref PR pr)
        {
            //战败之后不再会攻击
            return true;
        }
    }
}
