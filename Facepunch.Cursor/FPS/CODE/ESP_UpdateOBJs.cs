using System;
using System.Collections;
using System.Collections.Generic;
using FPS.Settings;
using UnityEngine;

namespace FPS.CODE
{
	// Token: 0x02000023 RID: 35
	internal class ESP_UpdateOBJs : MonoBehaviour
	{
		// Token: 0x060000B0 RID: 176 RVA: 0x00004E68 File Offset: 0x00003068
		public static int InvItemCount(Inventory inventory, ItemDataBlock datablock)
		{
			int num = 0;
			Inventory.OccupiedIterator occupiedIterator = inventory.occupiedIterator;
			while (occupiedIterator.Next())
			{
				if (!(occupiedIterator.item.datablock != datablock))
				{
					num = ((!occupiedIterator.item.datablock.IsSplittable()) ? (num + 1) : (num + occupiedIterator.item.uses));
				}
			}
			return num;
		}

		// Token: 0x060000B1 RID: 177 RVA: 0x00004ED8 File Offset: 0x000030D8
		public static List<Character> GetAnimalList()
		{
			List<Character> list = new List<Character>();
			UnityEngine.Object[] characterOBJs = ESP_UpdateOBJs.CharacterOBJs;
			List<Character> result;
			if (characterOBJs != null && ESP_UpdateOBJs.CharacterOBJs1)
			{
				foreach (UnityEngine.Object @object in characterOBJs)
				{
					if (@object != null)
					{
						Character character = (Character)@object;
						if (character != null && character.playerClient == null && character.alive && !character.dead && !character.name.Contains("Ragdoll"))
						{
							list.Add(character);
						}
					}
				}
				result = list;
			}
			else
			{
				result = null;
			}
			return result;
		}

		// Token: 0x060000B2 RID: 178 RVA: 0x00004FA8 File Offset: 0x000031A8
		

		// Token: 0x060000B3 RID: 179 RVA: 0x00002439 File Offset: 0x00000639
		private void Start()
		{
			base.StartCoroutine(this.UpdateObjects());
		}

		// Token: 0x060000B4 RID: 180 RVA: 0x00002449 File Offset: 0x00000649
		private IEnumerator UpdateObjects()
		{
			for (;;)
			{
				yield return new WaitForSeconds(0.5f);
				try
				{
					ESP_UpdateOBJs.IsIngame = false;
					ESP_UpdateOBJs.LocalPlayerClient = PlayerClient.GetLocalPlayer();
					if (ESP_UpdateOBJs.LocalPlayerClient != null)
					{
						Controllable controllable = ESP_UpdateOBJs.LocalPlayerClient.controllable;
						if (controllable != null)
						{
							ESP_UpdateOBJs.LocalCharacter = controllable.character;
							if (ESP_UpdateOBJs.LocalCharacter != null)
							{
								ESP_UpdateOBJs.LocalController = (ESP_UpdateOBJs.LocalCharacter.controller as HumanController);
								if (!(ESP_UpdateOBJs.LocalCharacter.gameObject == null) && ESP_UpdateOBJs.LocalController != null)
								{
									ESP_UpdateOBJs.IsIngame = true;
								}
                                if (CVars.ESP.DrawResources)
                                {
                                    ESP_UpdateOBJs.ResourceOBJs = UnityEngine.Object.FindObjectsOfType<ResourceObject>();
                                }
                            }
						}
					}
					continue;
				}
				catch
				{
					continue;
				}
				yield break;
			}
		}

		// Token: 0x0400008A RID: 138
		public static UnityEngine.Object[] CharacterOBJs;

		// Token: 0x0400008B RID: 139
		public static bool CharacterOBJs1 = false;

		// Token: 0x0400008C RID: 140
		public static UnityEngine.Object[] DoorOBJs;

		// Token: 0x0400008D RID: 141
		public static bool DoorOBJs1 = false;

		// Token: 0x0400008E RID: 142
		public static UnityEngine.Object[] LootableOBJs;

		// Token: 0x0400008F RID: 143
		public static bool LootableOBJs1 = false;

		// Token: 0x04000090 RID: 144
		public static UnityEngine.Object[] PlayerOBJs;

		// Token: 0x04000091 RID: 145
		public static bool PlayerOBJs1 = false;

		// Token: 0x04000092 RID: 146
		public static UnityEngine.Object[] ResourceOBJs;

		// Token: 0x04000093 RID: 147
		public static bool ResourceOBJs1 = false;

		// Token: 0x04000094 RID: 148
		public static UnityEngine.Object[] SleeperOBJs;

		// Token: 0x04000095 RID: 149
		public static bool SleeperOBJs1 = false;

		// Token: 0x04000096 RID: 150
		public static UnityEngine.Object[] StructureOBJs;

		// Token: 0x04000097 RID: 151
		public static bool StructureOBJs1 = false;

		// Token: 0x04000098 RID: 152
		public static Character LocalCharacter;

		// Token: 0x04000099 RID: 153
		public static HumanController LocalController;

		// Token: 0x0400009A RID: 154
		public static PlayerClient LocalPlayerClient;

		// Token: 0x0400009B RID: 155
		public static bool IsIngame;
	}
}
