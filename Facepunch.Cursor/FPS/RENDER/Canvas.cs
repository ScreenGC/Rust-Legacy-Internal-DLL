using System;
using FPS.Settings;
using UnityEngine;

namespace FPS.RENDER
{
	// Token: 0x02000018 RID: 24
	public class Canvas : MonoBehaviour
	{
		// Token: 0x06000059 RID: 89 RVA: 0x000031B4 File Offset: 0x000013B4
		public static void DrawBox(Vector2 pos, Vector2 size, Color color)
		{
			if (Canvas.drawingTex == null)
			{
				Canvas.drawingTex = new Texture2D(1, 1);
			}
			if (color != Canvas.lastTexColor)
			{
				Canvas.drawingTex.SetPixel(0, 0, color);
				Canvas.drawingTex.Apply();
				Canvas.lastTexColor = color;
			}
			GUI.DrawTexture(new Rect(pos.x, pos.y, size.x, size.y), Canvas.drawingTex);
		}

		// Token: 0x0600005A RID: 90 RVA: 0x00003244 File Offset: 0x00001444
		public static void DrawBoxOutlines(Vector2 position, Vector2 size, float borderSize, Color color)
		{
			Canvas.DrawBox(new Vector2(position.x + borderSize, position.y), new Vector2(size.x - 2f * borderSize, borderSize), color);
			Canvas.DrawBox(new Vector2(position.x, position.y), new Vector2(borderSize, size.y), color);
			Canvas.DrawBox(new Vector2(position.x + size.x - borderSize, position.y), new Vector2(borderSize, size.y), color);
			Canvas.DrawBox(new Vector2(position.x + borderSize, position.y + size.y - borderSize), new Vector2(size.x - 2f * borderSize, borderSize), color);
		}

		// Token: 0x0600005B RID: 91 RVA: 0x0000205B File Offset: 0x0000025B
		public static void DrawCrosshair()
		{
		}

		// Token: 0x0600005C RID: 92 RVA: 0x00002292 File Offset: 0x00000492
		public static void DrawFPS()
		{
			bool showWatermark = CVars.FPSTUDO.ShowWatermark;
		}

		// Token: 0x0600005D RID: 93 RVA: 0x00003318 File Offset: 0x00001518
		public void DrawInjectTXT()
		{
			if (this.showinjtxt)
			{
				Canvas.DrawString(new Vector2(Canvas.brandingRect.xMax + 5f, (float)Screen.height - 30f), new UColor(160f, 32f, 240f, 255f).Get(), Canvas.TextFlags.TEXT_FLAG_OUTLINED, "Injection Successful, Press INSERT To toggle the menu!");
			}
		}

		// Token: 0x0600005E RID: 94 RVA: 0x00003380 File Offset: 0x00001580
		public static void DrawLine(Vector2 pointA, Vector2 pointB, Color color)
		{
			if (Canvas.lineMaterial == null)
			{
				Canvas.lineMaterial = new Material("Shader \"Lines/Colored Blended\" {SubShader { Pass {   BindChannels { Bind \"Color\",color }   Blend SrcAlpha OneMinusSrcAlpha   ZWrite Off Cull Off Fog { Mode Off }} } }")
				{
					hideFlags = HideFlags.HideAndDontSave
				};
				Canvas.lineMaterial.shader.hideFlags = HideFlags.HideAndDontSave;
			}
			Canvas.lineMaterial.SetPass(0);
			GL.Begin(1);
			GL.Color(color);
			GL.Vertex3(pointA.x, pointA.y, 0f);
			GL.Vertex3(pointB.x, pointB.y, 0f);
			GL.End();
		}

		// Token: 0x0600005F RID: 95 RVA: 0x00003420 File Offset: 0x00001620
		public static void DrawString(Vector2 pos, Color color, Canvas.TextFlags flags, string text)
		{
			bool center = (flags & Canvas.TextFlags.TEXT_FLAG_CENTERED) == Canvas.TextFlags.TEXT_FLAG_CENTERED;
			if ((flags & Canvas.TextFlags.TEXT_FLAG_OUTLINED) == Canvas.TextFlags.TEXT_FLAG_OUTLINED)
			{
				Canvas.DrawStringInternal(pos + new Vector2(1f, 0f), Color.black, text, center);
				Canvas.DrawStringInternal(pos + new Vector2(0f, 1f), Color.black, text, center);
				Canvas.DrawStringInternal(pos + new Vector2(0f, -1f), Color.black, text, center);
			}
			if ((flags & Canvas.TextFlags.TEXT_FLAG_DROPSHADOW) == Canvas.TextFlags.TEXT_FLAG_DROPSHADOW)
			{
				Canvas.DrawStringInternal(pos + new Vector2(1f, 1f), Color.black, text, center);
			}
			Canvas.DrawStringInternal(pos, color, text, center);
		}

		// Token: 0x06000060 RID: 96 RVA: 0x000034E8 File Offset: 0x000016E8
		private static void DrawStringInternal(Vector2 pos, Color color, string text, bool center)
		{
			GUIStyle guistyle = new GUIStyle(GUI.skin.label)
			{
				normal = 
				{
					textColor = color
				},
				fontSize = 13
			};
			if (center)
			{
				pos.x -= guistyle.CalcSize(new GUIContent(text)).x / 2f;
			}
			GUI.Label(new Rect(pos.x, pos.y, 264f, 20f), text, guistyle);
		}

		// Token: 0x06000061 RID: 97 RVA: 0x00003574 File Offset: 0x00001774
		public static void DrawWatermark()
		{
			if (CVars.FPSTUDO.fps)
			{

			}
		}

		// Token: 0x06000062 RID: 98 RVA: 0x0000205B File Offset: 0x0000025B
		public static void resetmenu()
		{
		}

		// Token: 0x06000063 RID: 99 RVA: 0x0000229A File Offset: 0x0000049A
		public static void HeliosBox()
		{
			Canvas.HeliosBox((float)(Screen.width / 2), (float)(Screen.height / 2));
		}

		// Token: 0x06000064 RID: 100 RVA: 0x00003640 File Offset: 0x00001840
		public static void HeliosBox(float sx, float sy)
		{
			Color color = new Color(255f, 255f, 0f);
			Canvas.DrawLine(new Vector2(sx - 8f, sy - 8f), new Vector2(sx + 8f, sy - 8f), color);
			Canvas.DrawLine(new Vector2(sx + 8f, sy - 8f), new Vector2(sx + 8f, sy + 8f), color);
			Canvas.DrawLine(new Vector2(sx - 8f, sy + 8f), new Vector2(sx + 8f, sy + 8f), color);
			Canvas.DrawLine(new Vector2(sx - 8f, sy - 8f), new Vector2(sx - 8f, sy + 8f), color);
		}

		// Token: 0x06000065 RID: 101 RVA: 0x000022B3 File Offset: 0x000004B3
		public void InjectText()
		{
			this.showinjtxt = !this.showinjtxt;
		}

		// Token: 0x06000066 RID: 102 RVA: 0x000022C5 File Offset: 0x000004C5
		public void Start()
		{
			this.DrawInjectTXT();
			base.Invoke("InjectText", 10f);
			this.timeA = Time.timeSinceLevelLoad;
			UnityEngine.Object.DontDestroyOnLoad(this);
		}

		// Token: 0x06000067 RID: 103 RVA: 0x0000371C File Offset: 0x0000191C
		public static Vector2 TextBounds(string text)
		{
			GUIStyle guistyle = new GUIStyle(GUI.skin.label)
			{
				fontSize = 13
			};
			return guistyle.CalcSize(new GUIContent(text));
		}

		// Token: 0x06000068 RID: 104 RVA: 0x00003758 File Offset: 0x00001958
		public static void UpdateFPS()
		{
			float num = (float)Environment.TickCount;
			Canvas.totalFramesPerSecond = (Canvas.framesPerSecond + 0.1f) / ((num - Canvas.lastFrameTime) / 1000f);
			if (num - Canvas.lastFrameTime > 1000f)
			{
				Canvas.lastFrameTime = num;
				Canvas.framesPerSecond = 0f;
				Canvas.averageFramesPerSecond = Canvas.totalFramesPerSecond;
			}
			Canvas.framesPerSecond += 1f;
		}

		// Token: 0x04000052 RID: 82
		private static float averageFramesPerSecond = 0f;

		// Token: 0x04000053 RID: 83
		private static Rect brandingRect;

		// Token: 0x04000054 RID: 84
		private static Texture2D drawingTex = null;

		// Token: 0x04000055 RID: 85
		private static float framesPerSecond = 0f;

		// Token: 0x04000056 RID: 86
		private static float lastFrameTime = (float)Environment.TickCount;

		// Token: 0x04000057 RID: 87
		private static Color lastTexColor;

		// Token: 0x04000058 RID: 88
		private static Material lineMaterial;

		// Token: 0x04000059 RID: 89
		private static float totalFramesPerSecond = 0f;

		// Token: 0x0400005A RID: 90
		private float timeA;

		// Token: 0x0400005B RID: 91
		public bool showinjtxt = true;

		// Token: 0x0400005C RID: 92
		public static Texture2D blip = null;

		// Token: 0x02000019 RID: 25
		[Flags]
		public enum TextFlags
		{
			// Token: 0x0400005E RID: 94
			TEXT_FLAG_NONE = 0,
			// Token: 0x0400005F RID: 95
			TEXT_FLAG_CENTERED = 1,
			// Token: 0x04000060 RID: 96
			TEXT_FLAG_OUTLINED = 2,
			// Token: 0x04000061 RID: 97
			TEXT_FLAG_DROPSHADOW = 3
		}
	}
}
