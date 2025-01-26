using System;
using UnityEngine;

namespace Facepunch.Cursor.Internal
{
	// Token: 0x0200000D RID: 13
	internal static class Binder
	{
		// Token: 0x0600003C RID: 60 RVA: 0x00002C98 File Offset: 0x00000E98
		static Binder()
		{
			if (LockCursorManager.destroyedOnce)
			{
				Debug.LogError("says destroyed once");
			}
			else
			{
				GameObject gameObject = new GameObject("__LockCursorManager", new Type[]
				{
					typeof(LockCursorManager)
				});
				UnityEngine.Object.DontDestroyOnLoad(gameObject);
				gameObject.hideFlags = HideFlags.HideInHierarchy;
				Binder.singleton = gameObject.GetComponent<LockCursorManager>();
				Binder.singleton.hideFlags = HideFlags.NotEditable;
				Binder.singleton.useGUILayout = false;
				Binder.singleton.enabled = true;
				LockCursorManager.createdOnce = true;
			}
		}

		// Token: 0x0600003D RID: 61 RVA: 0x0000212F File Offset: 0x0000032F
		public static void Bind()
		{
		}

		// Token: 0x04000022 RID: 34
		public static LockCursorManager singleton;
	}
}
