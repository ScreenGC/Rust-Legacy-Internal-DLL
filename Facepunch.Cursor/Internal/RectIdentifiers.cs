using System;
using UnityEngine;

namespace Facepunch.Cursor.Internal
{
	// Token: 0x02000021 RID: 33
	internal static class RectIdentifiers
	{
		// Token: 0x17000010 RID: 16
		// (get) Token: 0x06000081 RID: 129 RVA: 0x00003F70 File Offset: 0x00002170
		public static int buttonControlID
		{
			get
			{
				return GUIUtility.GetControlID(RectIdentifiers.buttonHint, FocusType.Native, RectIdentifiers.buttonRectangle);
			}
		}

		// Token: 0x17000011 RID: 17
		// (get) Token: 0x06000082 RID: 130 RVA: 0x00003F94 File Offset: 0x00002194
		public static int keyboardControlID
		{
			get
			{
				return GUIUtility.GetControlID(RectIdentifiers.keyboardHint, FocusType.Keyboard, RectIdentifiers.keyboardRectangle);
			}
		}

		// Token: 0x06000083 RID: 131 RVA: 0x00003FB8 File Offset: 0x000021B8
		static RectIdentifiers()
		{
			System.Random random = new System.Random((int)(DateTime.Now.Ticks % 2147483647L));
			int num = random.Next(317) + 1;
			int num2 = random.Next(237) + 1;
			int num3 = random.Next(320 - num) + 1;
			int num4 = random.Next(240 - num2) + 1;
			RectIdentifiers.buttonRectangle = new Rect((float)num, (float)num2, (float)num3, (float)num4);
			RectIdentifiers.keyboardRectangle = new Rect((float)(num + num3 + 1), (float)(num2 + num4 + 1), (float)num3, (float)num4);
			RectIdentifiers.buttonHint = "Button".GetHashCode();
			RectIdentifiers.keyboardHint = "TextField".GetHashCode();
		}

		// Token: 0x04000073 RID: 115
		public static readonly Rect buttonRectangle;

		// Token: 0x04000074 RID: 116
		public static readonly Rect keyboardRectangle;

		// Token: 0x04000075 RID: 117
		public static readonly int buttonHint;

		// Token: 0x04000076 RID: 118
		public static readonly int keyboardHint;
	}
}
