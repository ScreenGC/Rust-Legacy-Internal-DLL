using System;
using UnityEngine;

// Token: 0x02000003 RID: 3
public class GrossMapInit : MonoBehaviour
{
	// Token: 0x06000006 RID: 6 RVA: 0x0000205B File Offset: 0x0000025B
	public static void Hide()
	{
	}

	// Token: 0x06000007 RID: 7 RVA: 0x0000205B File Offset: 0x0000025B
	public static void Init()
	{
	}

	// Token: 0x06000008 RID: 8 RVA: 0x000024B4 File Offset: 0x000006B4
	public static bool IsInit()
	{
		return GrossMapInit.isinit;
	}

	// Token: 0x06000009 RID: 9 RVA: 0x000024CC File Offset: 0x000006CC
	public static bool IsVisible()
	{
		return GrossMapInit.visible;
	}

	// Token: 0x0600000A RID: 10 RVA: 0x0000205B File Offset: 0x0000025B
	public static void Show()
	{
	}

	// Token: 0x04000004 RID: 4
	public static bool visible = true;

	// Token: 0x04000005 RID: 5
	public static bool isinit = false;

	// Token: 0x04000006 RID: 6
	public static Light point;

	// Token: 0x04000007 RID: 7
	public static Light indicator;

	// Token: 0x04000008 RID: 8
	public static Camera mc;

	// Token: 0x04000009 RID: 9
	public static Camera plc;

	// Token: 0x0400000A RID: 10
	public static float speed;
}
