using System;
using FPS.RENDER;
using FPS.Settings;
using UnityEngine;

namespace FPS.CODE
{
	// Token: 0x02000013 RID: 19
	public class ESP_Resource : MonoBehaviour
	{
		// Token: 0x0600005E RID: 94 RVA: 0x00005F80 File Offset: 0x00004180
		private void DrawResources()
		{
			if (CVars.ESP.DrawResources)
			{
				foreach (UnityEngine.Object @object in ESP_UpdateOBJs.ResourceOBJs)
				{
					if (@object != null)
					{
						ResourceObject resourceObject = (ResourceObject)@object;
						Vector3 vector = Camera.main.WorldToScreenPoint(resourceObject.transform.position);
						if (vector.z > 0f)
						{
							string text = "";
							vector.y = (float)Screen.height - (vector.y + 1f);
							string text2 = resourceObject.name.Replace("(Clone)", "");
							if (text2 != null)
							{
								if (!(text2 == "Ore1"))
								{
									if (!(text2 == "Ore2"))
									{
										if (!(text2 == "Ore3"))
										{
											if (text2 == "WoodPile")
											{
												if (ESP_Resource.Reswood)
												{
													text = string.Format("Wood Pile [{0}]", (int)vector.z);
												}
											}
										}
										else if (ESP_Resource.Resstone)
										{
											text = string.Format("Stone Ore [{0}]", (int)vector.z);
										}
									}
									else if (ESP_Resource.Resmetal)
									{
										text = string.Format("Metal Ore [{0}]", (int)vector.z);
									}
								}
								else if (ESP_Resource.Ressulfur)
								{
									text = string.Format("Sulfur Ore [{0}]", (int)vector.z);
								}
							}
							if (text != "")
							{
								Canvas.DrawString(new Vector2(vector.x, vector.y), this.resourceColor.Get(), Canvas.TextFlags.TEXT_FLAG_DROPSHADOW, text);
							}
						}
					}
				}
			}
		}

		// Token: 0x0600005F RID: 95 RVA: 0x00006184 File Offset: 0x00004384
		private void OnGUI()
		{
			if (Event.current.type == EventType.Repaint && ESP_UpdateOBJs.IsIngame)
			{
				try
				{
					this.DrawResources();
				}
				catch
				{
				}
			}
		}

		// Token: 0x0400003C RID: 60
		private UColor resourceColor = new UColor(255f, 255f, 0f, 255f);

		// Token: 0x0400003D RID: 61
		public static bool Resmetal;

		// Token: 0x0400003E RID: 62
		public static bool Ressulfur;

		// Token: 0x0400003F RID: 63
		public static bool Resstone;

		// Token: 0x04000040 RID: 64
		public static bool Reswood;
	}
}
