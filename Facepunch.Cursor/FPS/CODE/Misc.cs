﻿using System;
using Facepunch;
using FPS.Settings;
using UnityEngine;

namespace FPS.CODE
{
	// Token: 0x02000010 RID: 16
	internal class Misc : Facepunch.MonoBehaviour
	{
		// Token: 0x06000047 RID: 71 RVA: 0x00002166 File Offset: 0x00000366
		private void Motorfasf()
		{
			Terrain.activeTerrain.treeDistance = CVars.FPSTUDO.Rendertree;
			Terrain.activeTerrain.basemapDistance = CVars.FPSTUDO.FPS1;
			Terrain.activeTerrain.treeBillboardDistance = CVars.FPSTUDO.FPS3;
			Terrain.activeTerrain.treeCrossFadeLength = CVars.FPSTUDO.FPS4;
		}

		// Token: 0x06000048 RID: 72 RVA: 0x00002F84 File Offset: 0x00001184
		private void Update()
		{
			if (ESP_UpdateOBJs.IsIngame)
			{
				try
				{
					if (CVars.FPSTUDO.radar && !UnityEngine.Object.FindObjectOfType(typeof(radarScr)))
					{
						new GameObject("asdf").AddComponent<radarScr>();
						Debug.Log("asda");
					}
					if (CVars.FPSTUDO.map)
					{
						if (Input.GetKeyDown(KeyCode.M))
						{
							if (!GrossMapInit.IsInit())
							{
								GrossMapInit.Init();
							}
							else if (!GrossMapInit.IsVisible())
							{
								GrossMapInit.Show();
							}
							else
							{
								GrossMapInit.Hide();
							}
						}
					}
					else if (Input.GetKeyDown(KeyCode.M))
					{
						if (!GrossMapInit.IsVisible())
						{
							GrossMapInit.Hide();
						}
						else
						{
							GrossMapInit.Hide();
						}
					}
					if (GrossMapInit.IsVisible())
					{
						if (PlayerClient.localPlayerClient.controllable == null)
						{
							GrossMapInit.Hide();
						}
						if (ESP_UpdateOBJs.LocalCharacter == null)
						{
							GrossMapInit.Hide();
						}
					}
					this.Motorfasf();
				}
				catch
				{
				}
			}
		}

		// Token: 0x04000027 RID: 39
		private bool sla = true;
	}
}
