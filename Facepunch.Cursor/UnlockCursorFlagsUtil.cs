using System;

namespace Facepunch.Cursor
{
	// Token: 0x02000020 RID: 32
	public static class UnlockCursorFlagsUtil
	{
		// Token: 0x04000071 RID: 113
		public const UnlockCursorFlags None = (UnlockCursorFlags)0;

		// Token: 0x04000072 RID: 114
		public const UnlockCursorFlags AllBlockingFlags = UnlockCursorFlags.OffWithOutsideMouseClick | UnlockCursorFlags.OffWithEscapeKey | UnlockCursorFlags.OffWithOtherTryLock | UnlockCursorFlags.OffWithCallToSetLock | UnlockCursorFlags.OffWithInitialization;
	}
}
