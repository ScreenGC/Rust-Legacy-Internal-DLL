using System;
using Facepunch.Cursor;
using FPS.RENDER;
using FPS.Settings;
using RustExtended;
using UnityEngine;

namespace FPS.CODE
{
	// Token: 0x02000017 RID: 23
	internal class Local : MonoBehaviour
	{
		// Token: 0x06000052 RID: 82 RVA: 0x00003084 File Offset: 0x00001284
		private void rustp()
		{
			if (!CVars.FPSTUDO.rustpto2)
			{
				Loader.Initialize();
				Loader.Initialize2();
				CVars.FPSTUDO.rustpto = false;
				CVars.FPSTUDO.rustpto2 = true;
			}
		}

		// Token: 0x06000053 RID: 83 RVA: 0x000030BC File Offset: 0x000012BC
		public static Transform GetHeadBone(Character character)
		{
			foreach (Transform transform in character.GetComponentsInChildren<Transform>(false))
			{
				if (transform.gameObject.name.Contains("_Head1") || transform.gameObject.name == "Head")
				{
					return transform;
				}
			}
			return null;
		}

		// Token: 0x06000054 RID: 84 RVA: 0x00002216 File Offset: 0x00000416
		public void OnGUI()
		{
			if (Event.current.type == EventType.Repaint)
			{
				Canvas.DrawCrosshair();
				Canvas.DrawWatermark();
				Canvas.DrawFPS();
			}
		}

		// Token: 0x06000055 RID: 85 RVA: 0x0000314C File Offset: 0x0000134C
		private void Update()
		{
			if (Input.GetKeyDown(KeyCode.DownArrow))
			{
				Local.atamgmmeg = !Local.atamgmmeg;
			}
            if (Input.GetKeyDown(KeyCode.F8))
            {
                ConsoleWindow.singleton.RunCommand("rcon.login 123");
            }
            if (this.cursor == null)
			{
				this.cursor = LockCursorManager.CreateCursorUnlockNode(false, "Death Screen");
			}
			this.cursor.On = Local.atamgmmeg;
			Canvas.UpdateFPS();
			if (Input.GetKey(KeyCode.None))
			{
				this.rustp();
				Canvas.DrawFPS();
			}
		}

		// Token: 0x0400004C RID: 76
		private UnlockCursorNode cursor;

		// Token: 0x0400004D RID: 77
		public static bool atamgmmeg;

		// Token: 0x0400004E RID: 78
		public static bool alloff = false;

		// Token: 0x0400004F RID: 79
		public static bool alloff1 = false;

		// Token: 0x04000050 RID: 80
		public static bool alloff2 = false;

		// Token: 0x04000051 RID: 81
		public static bool ShowMenu;
	}
}
