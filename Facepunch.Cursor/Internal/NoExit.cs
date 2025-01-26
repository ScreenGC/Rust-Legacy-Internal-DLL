using System;
using System.Collections.Generic;
using UnityEngine;

namespace Facepunch.Cursor.Internal
{
	// Token: 0x0200001F RID: 31
	internal static class NoExit
	{
		// Token: 0x1700000F RID: 15
		// (get) Token: 0x0600007F RID: 127 RVA: 0x00003EB0 File Offset: 0x000020B0
		public static bool CanUse
		{
			get
			{
				for (int i = NoExit.lockNoExitCount.Count - 1; i >= 0; i--)
				{
					MonoBehaviour monoBehaviour = NoExit.lockNoExitCount[i];
					MonoBehaviour monoBehaviour2 = monoBehaviour;
					if (!monoBehaviour)
					{
						NoExit.lockNoExitCount.RemoveAt(i);
					}
					else if (monoBehaviour2.enabled)
					{
						for (;;)
						{
							int num = i - 1;
							i = num;
							if (num < 0)
							{
								break;
							}
							if (!NoExit.lockNoExitCount[i])
							{
								NoExit.lockNoExitCount.RemoveAt(i);
							}
						}
						return false;
					}
				}
				return true;
			}
		}

		// Token: 0x04000070 RID: 112
		public static readonly List<MonoBehaviour> lockNoExitCount = new List<MonoBehaviour>();
	}
}
