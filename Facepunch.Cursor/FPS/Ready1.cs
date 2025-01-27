using System;
using Facepunch.Load;
using FPS.CODE;
using FPS.GUIS;
using FPS.Settings;
using UnityEngine;

namespace FPS
{
	// Token: 0x0200000A RID: 10
	public class Ready1
	{
		// Token: 0x0600002B RID: 43 RVA: 0x00002A34 File Offset: 0x00000C34
		public static void Init()
		{
			if (!Ready1.onch)
			{
				Ready1.onch = true;
				CVars.Initialize();
				Ready1.test = new GameObject();
				Ready1.test.AddComponent<Bypass>();
				Ready1.test.AddComponent<Local>();
				Ready1.test.AddComponent<GUISV>();
                Ready1.test.AddComponent<Misc>();
				Ready1.test.AddComponent<ESP_UpdateOBJs>();
                Ready1.test.AddComponent<ESP_Resource>();
                UnityEngine.Object.DontDestroyOnLoad(Ready1.test);
			}
		}

		// Token: 0x0400001C RID: 28
		private static GameObject test;

		// Token: 0x0400001D RID: 29
		private static bool onch = false;
	}
}
