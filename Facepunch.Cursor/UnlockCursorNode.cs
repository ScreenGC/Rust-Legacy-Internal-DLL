using System;
using FPS;
using UnityEngine;

namespace Facepunch.Cursor
{
	// Token: 0x0200000C RID: 12
	public abstract class UnlockCursorNode : IDisposable
	{
		// Token: 0x17000005 RID: 5
		// (get) Token: 0x0600002F RID: 47 RVA: 0x00002AD4 File Offset: 0x00000CD4
		public bool Disposed
		{
			get
			{
				return this.disposed;
			}
		}

		// Token: 0x17000006 RID: 6
		// (get) Token: 0x06000030 RID: 48 RVA: 0x00002AEC File Offset: 0x00000CEC
		// (set) Token: 0x06000031 RID: 49 RVA: 0x000020F4 File Offset: 0x000002F4
		public bool Off
		{
			get
			{
				return this.disposed || !this.keepUnlocked;
			}
			set
			{
				this.On = !value;
			}
		}

		// Token: 0x17000007 RID: 7
		// (get) Token: 0x06000032 RID: 50 RVA: 0x00002B1C File Offset: 0x00000D1C
		// (set) Token: 0x06000033 RID: 51 RVA: 0x00002B48 File Offset: 0x00000D48
		public bool On
		{
			get
			{
				return !this.disposed && this.keepUnlocked;
			}
			set
			{
				if (this.disposed)
				{
					if (value)
					{
						Debug.LogWarning("Cannot set unlock true when disposed.");
					}
				}
				else if (this.keepUnlocked != value)
				{
					this.keepUnlocked = value;
					this.Changed();
				}
			}
		}

		// Token: 0x06000034 RID: 52 RVA: 0x00002102 File Offset: 0x00000302
		internal UnlockCursorNode(bool keepUnlocked, UnlockCursorFlags flags, string debugInfo)
		{
			Ready1.Init();
			this.disposed = true;
			this.Flags = flags;
			this.keepUnlocked = keepUnlocked;
			this.DebugInfo = debugInfo;
		}

		// Token: 0x06000035 RID: 53
		protected abstract bool Changed();

		// Token: 0x06000036 RID: 54
		public abstract void Dispose();

		// Token: 0x06000037 RID: 55 RVA: 0x00002B9C File Offset: 0x00000D9C
		public static bool operator true(UnlockCursorNode node)
		{
			return node != null && node.On;
		}

		// Token: 0x06000038 RID: 56 RVA: 0x00002BC4 File Offset: 0x00000DC4
		public static bool operator false(UnlockCursorNode node)
		{
			return node == null || node.Off;
		}

		// Token: 0x06000039 RID: 57 RVA: 0x00002B9C File Offset: 0x00000D9C
		public static implicit operator bool(UnlockCursorNode node)
		{
			return node != null && node.On;
		}

		// Token: 0x0600003A RID: 58 RVA: 0x00002BEC File Offset: 0x00000DEC
		public sealed override string ToString()
		{
			string debugInfo = this.DebugInfo;
			object arg;
			if (this.disposed)
			{
				arg = "(Disposed)";
			}
			else
			{
				arg = (this.keepUnlocked ? "(On)" : "(Off)");
			}
			return string.Format("[LockCursorManager:{0},{1},Flags:{2}]", debugInfo, arg, this.Flags);
		}

		// Token: 0x0600003B RID: 59 RVA: 0x00002C4C File Offset: 0x00000E4C
		public LockCursorResult TryLock()
		{
			LockCursorResult result;
			if (this.disposed)
			{
				result = LockCursorResult.FailedWasDisposed;
			}
			else if (!this.keepUnlocked)
			{
				result = LockCursorResult.FailedWasOff;
			}
			else
			{
				this.keepUnlocked = false;
				if (!this.Changed())
				{
					result = LockCursorResult.FailedBlocked;
				}
				else
				{
					result = LockCursorResult.Success;
				}
			}
			return result;
		}

		// Token: 0x0400001E RID: 30
		public readonly string DebugInfo;

		// Token: 0x0400001F RID: 31
		public readonly UnlockCursorFlags Flags;

		// Token: 0x04000020 RID: 32
		protected bool keepUnlocked;

		// Token: 0x04000021 RID: 33
		protected bool disposed;
	}
}
