using System;
using UnityEngine;

namespace FPS.Settings
{
	// Token: 0x02000011 RID: 17
	internal class CVars
	{
		// Token: 0x0600004A RID: 74 RVA: 0x000021AC File Offset: 0x000003AC
		public static void Initialize()
		{
			CVars.FPSTUDO.fps = true;
			CVars.FPSTUDO.Rendertree = 1500f;
			CVars.FPSTUDO.FPS2 = 5f;
			CVars.FPSTUDO.FPS3 = 300f;
			CVars.FPSTUDO.FPS1 = 10000f;
			CVars.FPSTUDO.FPS4 = 300f;
            CVars.Misc.SpeedModifer = 15f;
            CVars.Misc.NoFallDamage = false;
            CVars.Misc.FlyHack = false;
        }

		// Token: 0x02000012 RID: 18
		internal class fps4
		{
			// Token: 0x04000028 RID: 40
			public static bool DrawAnimals;

			// Token: 0x04000029 RID: 41
			public static bool DrawLoot;

			// Token: 0x0400002A RID: 42
			public static bool DrawPlayers;

			// Token: 0x0400002B RID: 43
			public static bool DrawRaid;

			// Token: 0x0400002C RID: 44
			public static bool DrawResources;

			// Token: 0x0400002D RID: 45
			public static bool DrawSleepers;
		}

		// Token: 0x02000013 RID: 19
		internal class fps2
		{
			// Token: 0x0400002E RID: 46
			public static bool DrawAnimals;

			// Token: 0x0400002F RID: 47
			public static bool DrawLoot;

			// Token: 0x04000030 RID: 48
			public static bool DrawPlayers;

			// Token: 0x04000031 RID: 49
			public static bool DrawRaid;

			// Token: 0x04000032 RID: 50
			public static bool DrawResources;

			// Token: 0x04000033 RID: 51
			public static bool DrawSleepers;
		}

		// Token: 0x02000014 RID: 20
		internal class FPSTUDO
		{
			// Token: 0x04000034 RID: 52
			public static bool map2;

			// Token: 0x04000035 RID: 53
			public static bool map;

			// Token: 0x04000036 RID: 54
			public static bool radar;

			// Token: 0x04000037 RID: 55
			public static bool rustpto;

			// Token: 0x04000038 RID: 56
			public static bool rustpto2;

			// Token: 0x04000039 RID: 57
			public static bool ShowWatermark;

			// Token: 0x0400003A RID: 58
			public static float Rendertree;

			// Token: 0x0400003B RID: 59
			public static float FPS1;

			// Token: 0x0400003C RID: 60
			public static float FPS2;

			// Token: 0x0400003D RID: 61
			public static float FPS3;

			// Token: 0x0400003E RID: 62
			public static float FPS4;

			// Token: 0x0400003F RID: 63
			public static bool recoil;

			// Token: 0x04000040 RID: 64
			public static bool fps;

			// Token: 0x04000041 RID: 65
			public static bool Minecraft;
		}

		// Token: 0x02000015 RID: 21
		internal class nada
		{
			// Token: 0x04000042 RID: 66
			public static bool whack;

			// Token: 0x04000043 RID: 67
			public static bool NoWalls;

			// Token: 0x04000044 RID: 68
			public static bool NoCeilings;

			// Token: 0x04000045 RID: 69
			public static bool NoDoorways;

			// Token: 0x04000046 RID: 70
			public static bool NoPillars;

			// Token: 0x04000047 RID: 71
			public static bool NoWindowWalls;

			// Token: 0x04000048 RID: 72
			public static bool NoFoundations;

			// Token: 0x04000049 RID: 73
			public static bool NoStairs;

			// Token: 0x0400004A RID: 74
			public static bool NoRamps;
		}

        internal class Misc
		{
            public static float SpeedModifer;
            public static float JumpModifer;
            public static bool FlyHack;
            public static bool NoFallDamage;
            public static KeyCode FlyKey;

        }
	}
}
