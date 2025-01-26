using System;
using UnityEngine;

namespace Facepunch.Cursor.Internal
{
	// Token: 0x0200000F RID: 15
	internal static class Cursor
	{
		// Token: 0x17000008 RID: 8
		// (get) Token: 0x06000041 RID: 65 RVA: 0x00002E4C File Offset: 0x0000104C
		public static bool Locked
		{
			get
			{
				bool result;
				if (!Cursor.AllowLockCursor)
				{
					result = Cursor.FallbackLocked;
				}
				else
				{
					result = Screen.lockCursor;
				}
				return result;
			}
		}

		// Token: 0x17000009 RID: 9
		// (get) Token: 0x06000042 RID: 66 RVA: 0x00002E78 File Offset: 0x00001078
		public static bool Unlocked
		{
			get
			{
				bool result;
				if (!Cursor.AllowLockCursor)
				{
					result = !Cursor.FallbackLocked;
				}
				else
				{
					result = !Screen.lockCursor;
				}
				return result;
			}
		}

		// Token: 0x06000043 RID: 67 RVA: 0x00002132 File Offset: 0x00000332
		static Cursor()
		{
			Cursor.AllowLockCursor = true;
			Cursor.ForceRecenterOnLock = false;
			Cursor.ForceRecenterOnUnlock = false;
		}

		// Token: 0x06000044 RID: 68 RVA: 0x00002EA8 File Offset: 0x000010A8
		public static bool Lock()
		{
			if (Cursor.AllowLockCursor || Cursor.ForceRecenterOnLock)
			{
				Screen.lockCursor = true;
				LockCursorManager.lastSetLock = Screen.lockCursor;
			}
			else
			{
				LockCursorManager.lastSetLock = true;
			}
			Cursor.FallbackLocked = LockCursorManager.lastSetLock;
			if (Cursor.FallbackLocked && !Cursor.AllowLockCursor)
			{
				Screen.lockCursor = false;
			}
			return LockCursorManager.lastSetLock;
		}

		// Token: 0x06000045 RID: 69 RVA: 0x00002F1C File Offset: 0x0000111C
		public static bool Unlock()
		{
			bool flag = Cursor.ForceRecenterOnUnlock && !Screen.lockCursor;
			Screen.lockCursor = false;
			bool lockCursor = Screen.lockCursor;
			Cursor.FallbackLocked = lockCursor;
			LockCursorManager.lastSetLock = lockCursor;
			bool flag2 = !lockCursor;
			if (flag2 && flag)
			{
				Screen.lockCursor = true;
				Screen.lockCursor = false;
			}
			return flag2;
		}

		// Token: 0x04000023 RID: 35
		private static bool FallbackLocked = Screen.lockCursor;

		// Token: 0x04000024 RID: 36
		public static bool AllowLockCursor;

		// Token: 0x04000025 RID: 37
		public static bool ForceRecenterOnUnlock;

		// Token: 0x04000026 RID: 38
		public static bool ForceRecenterOnLock = true;
	}
}
