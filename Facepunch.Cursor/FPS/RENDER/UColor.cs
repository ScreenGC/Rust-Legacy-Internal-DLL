using System;
using UnityEngine;

namespace FPS.RENDER
{
	// Token: 0x02000016 RID: 22
	public class UColor
	{
		// Token: 0x0600004F RID: 79 RVA: 0x000021E6 File Offset: 0x000003E6
		public UColor(float r, float g, float b, float a)
		{
			this.color = new Color(r / 255f, g / 255f, b / 255f, a / 255f);
		}

		// Token: 0x06000050 RID: 80 RVA: 0x0000306C File Offset: 0x0000126C
		public Color Get()
		{
			return this.color;
		}

		// Token: 0x0400004B RID: 75
		private Color color;
	}
}
