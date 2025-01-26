using System;
using System.Collections.Generic;

namespace Facepunch.Cursor.Internal
{
	// Token: 0x0200000E RID: 14
	internal sealed class UnlockCursorNodeImpl : UnlockCursorNode
	{
		// Token: 0x0600003E RID: 62 RVA: 0x00002D24 File Offset: 0x00000F24
		public UnlockCursorNodeImpl(bool keepUnlocked, UnlockCursorFlags nonBlocking, string debugInfo) : base(keepUnlocked, nonBlocking, debugInfo)
		{
			if (LockCursorManager.lockNodes == null)
			{
				LockCursorManager.lockNodes = new List<WeakReference>();
			}
			LockCursorManager.lockNodes.Add(new WeakReference(this));
			this.disposed = false;
			if (keepUnlocked)
			{
				this.Changed();
			}
		}

		// Token: 0x0600003F RID: 63 RVA: 0x00002D84 File Offset: 0x00000F84
		protected override bool Changed()
		{
			bool result;
			if (LockCursorManager.CheckLockChange(false))
			{
				result = true;
			}
			else if (this.keepUnlocked)
			{
				result = LockCursorManager.UnlockCursorNow(this.Flags);
			}
			else
			{
				result = LockCursorManager.LockCursorNow(UnlockCursorFlags.OffWithOtherTryLock, this.Flags);
			}
			return result;
		}

		// Token: 0x06000040 RID: 64 RVA: 0x00002DD0 File Offset: 0x00000FD0
		public override void Dispose()
		{
			if (!this.disposed)
			{
				int num = (LockCursorManager.lockNodes == null) ? 0 : LockCursorManager.lockNodes.Count;
				for (int i = 0; i < num; i++)
				{
					if (LockCursorManager.lockNodes[i].Target == this)
					{
						int num2 = i;
						i = num2 - 1;
						LockCursorManager.lockNodes.RemoveAt(num2);
						num--;
					}
				}
				this.disposed = true;
			}
		}
	}
}
