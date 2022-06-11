using HarmonyLib;
using nel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrustratedNoel
{
    internal class DisableMosaic
    {
		[HarmonyPrefix]
		[HarmonyPatch(typeof(MosaicShower), "runPost")]
		private static bool PatchContent()
		{
			//禁止执行后面的过程
			return false;
		}
	}
}
