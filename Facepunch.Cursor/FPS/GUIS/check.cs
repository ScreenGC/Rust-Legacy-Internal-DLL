using System;
using UnityEngine;

namespace FPS.GUIS
{
	// Token: 0x0200001B RID: 27
	public class check : MonoBehaviour
	{
		// Token: 0x0600006E RID: 110 RVA: 0x00002378 File Offset: 0x00000578
		[RPC]
		public void cheat(string cheat)
		{
			Debug.Log(cheat);
		}

		// Token: 0x04000063 RID: 99
		public Rect startRect;

		// Token: 0x04000064 RID: 100
		public string text;

		// Token: 0x04000065 RID: 101
		public bool chekks;
	}
}


