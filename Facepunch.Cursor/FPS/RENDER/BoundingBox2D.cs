using System;
using FPS.CODE;
using UnityEngine;

namespace FPS.RENDER
{
	// Token: 0x0200001C RID: 28
	public class BoundingBox2D
	{
		// Token: 0x1700000A RID: 10
		// (get) Token: 0x06000070 RID: 112 RVA: 0x00003D18 File Offset: 0x00001F18
		// (set) Token: 0x06000071 RID: 113 RVA: 0x00002382 File Offset: 0x00000582
		public float Height { get; set; }

		// Token: 0x1700000B RID: 11
		// (get) Token: 0x06000072 RID: 114 RVA: 0x00003D30 File Offset: 0x00001F30
		// (set) Token: 0x06000073 RID: 115 RVA: 0x0000238B File Offset: 0x0000058B
		public bool IsValid { get; set; }

		// Token: 0x1700000C RID: 12
		// (get) Token: 0x06000074 RID: 116 RVA: 0x00003D48 File Offset: 0x00001F48
		// (set) Token: 0x06000075 RID: 117 RVA: 0x00002394 File Offset: 0x00000594
		public float Width { get; set; }

		// Token: 0x1700000D RID: 13
		// (get) Token: 0x06000076 RID: 118 RVA: 0x00003D60 File Offset: 0x00001F60
		// (set) Token: 0x06000077 RID: 119 RVA: 0x0000239D File Offset: 0x0000059D
		public float X { get; set; }

		// Token: 0x1700000E RID: 14
		// (get) Token: 0x06000078 RID: 120 RVA: 0x00003D78 File Offset: 0x00001F78
		// (set) Token: 0x06000079 RID: 121 RVA: 0x000023A6 File Offset: 0x000005A6
		public float Y { get; set; }

		// Token: 0x0600007A RID: 122 RVA: 0x00003D90 File Offset: 0x00001F90
		public BoundingBox2D(Character character)
		{
			Vector3 position = character.transform.position;
			Vector3 position2 = Local.GetHeadBone(character).transform.position;
			Vector3 vector = Camera.main.WorldToScreenPoint(position2);
			Vector3 vector2 = Camera.main.WorldToScreenPoint(position);
			if (vector.z <= 0f || vector2.z <= 0f)
			{
				this.IsValid = false;
			}
			else
			{
				vector.y = (float)Screen.height - (vector.y + 1f);
				vector2.y = (float)Screen.height - (vector2.y + 1f);
				this.Height = vector2.y + 10f - vector.y;
				this.Width = this.Height / 2f;
				this.X = vector.x - this.Width / 2f;
				this.Y = vector.y;
				this.IsValid = true;
			}
		}
	}
}
