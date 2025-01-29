using System;
using System.Collections.Generic;
using Facepunch;
using FPS.Settings;
using Rust;
using UnityEngine;

namespace FPS.CODE
{
	// Token: 0x02000010 RID: 16
	internal class Misc : Facepunch.MonoBehaviour
	{
		// Token: 0x06000047 RID: 71 RVA: 0x00002166 File Offset: 0x00000366
		private void Motorfasf()
		{
			HumanController localController = ESP_UpdateOBJs.LocalController;
			Character localCharacter = ESP_UpdateOBJs.LocalCharacter;
			CCMotor ccmotor = localController.ccmotor;
			if (ccmotor != null)
			{
				if (this.defaultJumping == null)
				{

				}
				else
				{

				}
				if (this.defaultMovement == null)
				{
					this.defaultMovement = new CCMotor.Movement?(ccmotor.movement.setup);
				}
				else
				{
					ccmotor.movement.setup.maxForwardSpeed = this.defaultMovement.Value.maxForwardSpeed * CVars.Misc.SpeedModifer / 10f;
					ccmotor.movement.setup.maxSidewaysSpeed = this.defaultMovement.Value.maxSidewaysSpeed * CVars.Misc.SpeedModifer / 10f;
					ccmotor.movement.setup.maxBackwardsSpeed = this.defaultMovement.Value.maxBackwardsSpeed * CVars.Misc.SpeedModifer / 10f;
					ccmotor.movement.setup.maxGroundAcceleration = this.defaultMovement.Value.maxGroundAcceleration * CVars.Misc.SpeedModifer / 10f;
					ccmotor.movement.setup.maxAirAcceleration = this.defaultMovement.Value.maxAirAcceleration * CVars.Misc.SpeedModifer / 10f;
					if (CVars.Misc.NoFallDamage)
					{
						ccmotor.movement.setup.maxFallSpeed = 17f;
					}
					else
					{
						ccmotor.movement.setup.maxFallSpeed = this.defaultMovement.Value.maxFallSpeed;
					}
				}
				Terrain.activeTerrain.treeDistance = CVars.FPSTUDO.Rendertree;
				Terrain.activeTerrain.basemapDistance = CVars.FPSTUDO.FPS1;
				Terrain.activeTerrain.treeBillboardDistance = CVars.FPSTUDO.FPS3;
				Terrain.activeTerrain.treeCrossFadeLength = CVars.FPSTUDO.FPS4;
				if (ccmotor != null)
				{

					if (this.defaultMovement == null)
					{
						this.defaultMovement = new CCMotor.Movement?(ccmotor.movement.setup);
					}
					else
					{
						ccmotor.movement.setup.maxForwardSpeed = this.defaultMovement.Value.maxForwardSpeed * CVars.Misc.SpeedModifer / 10f;
						ccmotor.movement.setup.maxSidewaysSpeed = this.defaultMovement.Value.maxSidewaysSpeed * CVars.Misc.SpeedModifer / 10f;
						ccmotor.movement.setup.maxBackwardsSpeed = this.defaultMovement.Value.maxBackwardsSpeed * CVars.Misc.SpeedModifer / 10f;
						ccmotor.movement.setup.maxGroundAcceleration = this.defaultMovement.Value.maxGroundAcceleration * CVars.Misc.SpeedModifer / 10f;
						ccmotor.movement.setup.maxAirAcceleration = this.defaultMovement.Value.maxAirAcceleration * CVars.Misc.SpeedModifer / 10f;
					}
				}
				if (CVars.Misc.FlyHack)
				{
					ccmotor.velocity = Vector3.zero;
					Vector3 forward = localCharacter.eyesAngles.forward;
					Vector3 right = localCharacter.eyesAngles.right;
					if (!ChatUI.IsVisible())
					{
						if (Input.GetKey(KeyCode.W))
						{
							ccmotor.velocity += forward * (ccmotor.movement.setup.maxForwardSpeed * 3f);
						}
						if (Input.GetKey(KeyCode.S))
						{
							ccmotor.velocity += forward * (ccmotor.movement.setup.maxBackwardsSpeed * 3f);
						}
						if (Input.GetKey(KeyCode.A))
						{
							ccmotor.velocity += forward * (ccmotor.movement.setup.maxSidewaysSpeed * 3f);
						}
						if (Input.GetKey(KeyCode.D))
						{
							ccmotor.velocity += forward * (ccmotor.movement.setup.maxSidewaysSpeed * 3f);
						}
						if (Input.GetKey(KeyCode.Space))
						{
							ccmotor.velocity += Vector3.up * (this.defaultMovement.Value.maxAirAcceleration * 3f);
						}
					}
					if (ccmotor.velocity == Vector3.zero)
					{
						ccmotor.velocity += Vector3.up * (ccmotor.settings.gravity * Time.deltaTime * 0.5f);
					}
				}
			}
		}
        public static void AllBlueprints()
        {
            Character component = PlayerClient.GetLocalPlayer().controllable.GetComponent<Character>();
            PlayerInventory playerInventory = component.GetComponent(typeof(PlayerInventory)) as PlayerInventory;
            if (playerInventory)
            {
                List<BlueprintDataBlock> boundBPs = playerInventory.GetBoundBPs();
                foreach (BlueprintDataBlock blueprintDataBlock in Bundling.LoadAll<BlueprintDataBlock>())
                {
                    if (!boundBPs.Contains(blueprintDataBlock))
                    {
                        Notice.Inventory(" ", blueprintDataBlock.name);
                        boundBPs.Add(blueprintDataBlock);
                    }
                }
            }
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
        private CCMotor.Movement? defaultMovement = null;
        private CCMotor.Jumping? defaultJumping = null;
    }
}
