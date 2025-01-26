using System;

namespace Facepunch.Cursor
{
	// Token: 0x02000008 RID: 8
	[Flags]
	public enum UnlockCursorFlags : byte
	{
		// Token: 0x04000015 RID: 21
		OffWithOutsideMouseClick = 1,
		// Token: 0x04000016 RID: 22
		OffWithEscapeKey = 2,
		// Token: 0x04000017 RID: 23
		OffWithOtherTryLock = 4,
		// Token: 0x04000018 RID: 24
		OffWithCallToSetLock = 8,
		// Token: 0x04000019 RID: 25
		OffWithInitialization = 16,
		// Token: 0x0400001A RID: 26
		DoNotResetInput = 32,
		// Token: 0x0400001B RID: 27
		AllowSubsetOfKeys = 64
	}
}
