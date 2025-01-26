using System;
using UnityEngine;

namespace FPS.CODE
{
	// Token: 0x0200000B RID: 11
	internal class Bypass : MonoBehaviour
	{
		// Token: 0x0600002E RID: 46 RVA: 0x00002AA0 File Offset: 0x00000CA0
		private void Update()
		{
			if (SteamClient.steamClientObject != null)
			{
				SteamClient.steamClientObject.SetActive(false);
				SteamClient.SteamClient_Cycle();
			}
		}
	}
}
