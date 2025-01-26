using System;
using UnityEngine;

// Token: 0x02000004 RID: 4
public class GrossMapLip : MonoBehaviour
{
	// Token: 0x0600000C RID: 12 RVA: 0x0000206C File Offset: 0x0000026C
	private void Start()
	{
		GrossMapLip.lgh = base.GetComponent<Light>();
		GrossMapLip.lgh.color = new Color(255f, 0f, 0f);
	}

	// Token: 0x0600000D RID: 13 RVA: 0x000024E4 File Offset: 0x000006E4
	private void Update()
	{
		if (!GrossMapLip.fl || GrossMapLip.lgh.range <= 5f)
		{
			GrossMapLip.fl = false;
		}
		else
		{
			Light light = GrossMapLip.lgh;
			light.range -= 3f;
		}
		if (GrossMapLip.fl || GrossMapLip.lgh.range >= 20f)
		{
			GrossMapLip.fl = true;
		}
		else
		{
			Light light2 = GrossMapLip.lgh;
			light2.range += 3f;
		}
	}

	// Token: 0x0400000B RID: 11
	private static bool fl;

	// Token: 0x0400000C RID: 12
	public static GrossMapCam mc;

	// Token: 0x0400000D RID: 13
	public static Light lgh;
}
