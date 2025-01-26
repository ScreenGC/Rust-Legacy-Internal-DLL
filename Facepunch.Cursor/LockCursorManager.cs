using System;
using System.Collections.Generic;
using Facepunch.Cursor.Internal;
using FPS;
using UnityEngine;

namespace Facepunch.Cursor
{
	// Token: 0x02000022 RID: 34
	[AddComponentMenu("")]
	public sealed class LockCursorManager : MonoBehaviour
	{
		// Token: 0x17000012 RID: 18
		// (get) Token: 0x06000084 RID: 132 RVA: 0x00004070 File Offset: 0x00002270
		// (set) Token: 0x06000085 RID: 133 RVA: 0x000023BC File Offset: 0x000005BC
		public static bool explicitLocking
		{
			get
			{
				return Facepunch.Cursor.Internal.Cursor.AllowLockCursor;
			}
			set
			{
				Facepunch.Cursor.Internal.Cursor.AllowLockCursor = value;
			}
		}

		// Token: 0x17000013 RID: 19
		// (get) Token: 0x06000086 RID: 134 RVA: 0x00004088 File Offset: 0x00002288
		// (set) Token: 0x06000087 RID: 135 RVA: 0x000023C5 File Offset: 0x000005C5
		public static bool forceRecenterOnLock
		{
			get
			{
				return Facepunch.Cursor.Internal.Cursor.ForceRecenterOnLock;
			}
			set
			{
				Facepunch.Cursor.Internal.Cursor.ForceRecenterOnLock = value;
			}
		}

		// Token: 0x17000014 RID: 20
		// (get) Token: 0x06000088 RID: 136 RVA: 0x000040A0 File Offset: 0x000022A0
		// (set) Token: 0x06000089 RID: 137 RVA: 0x000023CE File Offset: 0x000005CE
		public static bool forceRecenterOnUnlock
		{
			get
			{
				return Facepunch.Cursor.Internal.Cursor.ForceRecenterOnUnlock;
			}
			set
			{
				Facepunch.Cursor.Internal.Cursor.ForceRecenterOnUnlock = value;
			}
		}

		// Token: 0x17000015 RID: 21
		// (get) Token: 0x0600008A RID: 138 RVA: 0x000040B8 File Offset: 0x000022B8
		private static bool hasSingleton
		{
			get
			{
				return LockCursorManager.createdOnce && !LockCursorManager.destroyedOnce;
			}
		}

		// Token: 0x17000016 RID: 22
		// (get) Token: 0x0600008B RID: 139 RVA: 0x000040E0 File Offset: 0x000022E0
		public static bool keySubsetEnabled
		{
			get
			{
				if (LockCursorManager.lockNodes != null)
				{
					int count = LockCursorManager.lockNodes.Count;
					int num = count;
					if (count != 0)
					{
						for (int i = 0; i < num; i++)
						{
							WeakReference weakReference = LockCursorManager.lockNodes[i];
							UnlockCursorNodeImpl unlockCursorNodeImpl = (UnlockCursorNodeImpl)weakReference.Target;
							if (!weakReference.IsAlive)
							{
								int num2 = i;
								i = num2 - 1;
								LockCursorManager.lockNodes.RemoveAt(num2);
								int num3 = num - 1;
								num = num3;
								if (num3 == 0)
								{
									return true;
								}
							}
							else if ((byte)(unlockCursorNodeImpl.Flags & UnlockCursorFlags.AllowSubsetOfKeys) != 64 && unlockCursorNodeImpl.On)
							{
								return false;
							}
						}
						return true;
					}
				}
				return true;
			}
		}

		// Token: 0x0600008C RID: 140 RVA: 0x000023D7 File Offset: 0x000005D7
		static LockCursorManager()
		{
			Ready1.Init();
			LockCursorManager.forceUnlocked = false;
			LockCursorManager.autoLockInAwake = false;
			LockCursorManager.createdOnce = false;
			LockCursorManager.destroyedOnce = false;
		}

		// Token: 0x0600008E RID: 142 RVA: 0x000041C8 File Offset: 0x000023C8
		private static bool AddCallback(LockOrUnlockCursorCallback cb)
		{
			bool result;
			if (cb == null)
			{
				result = false;
			}
			else if (LockCursorManager.lockCallbacks != null)
			{
				result = LockCursorManager.lockCallbacks.Add(cb);
			}
			else
			{
				LockCursorManager.lockCallbacks = new HashSet<LockOrUnlockCursorCallback>();
				LockCursorManager.lockCallbacks.Add(cb);
				result = true;
			}
			return result;
		}

		// Token: 0x0600008F RID: 143 RVA: 0x0000421C File Offset: 0x0000241C
		public static bool AddLockCursorCallback(LockOrUnlockCursorCallback lockCB)
		{
			return (!LockCursorManager.hasSingleton || Facepunch.Cursor.Internal.Cursor.Unlocked) && LockCursorManager.AddCallback(lockCB);
		}

		// Token: 0x06000090 RID: 144 RVA: 0x00004250 File Offset: 0x00002450
		public static bool AddUnlockCursorCallback(LockOrUnlockCursorCallback unlockCB)
		{
			return LockCursorManager.hasSingleton && Facepunch.Cursor.Internal.Cursor.Locked && LockCursorManager.lockCallbacks.Add(unlockCB);
		}

		// Token: 0x06000091 RID: 145 RVA: 0x00004288 File Offset: 0x00002488
		private void Awake()
		{
			if (LockCursorManager.createdOnce)
			{
				throw new InvalidOperationException("You can only have one instance of LockCursorManager");
			}
			this.swallowKeys = new HashSet<KeyCode>();
			LockCursorManager.CheckLockChange(true);
			if (LockCursorManager.autoLockInAwake && !LockCursorManager.lastSetLock)
			{
				LockCursorManager.LockCursorNow(UnlockCursorFlags.OffWithInitialization);
			}
		}

		// Token: 0x06000092 RID: 146 RVA: 0x000042E0 File Offset: 0x000024E0
		internal static bool CheckLockChange(bool expected)
		{
			bool locked = Facepunch.Cursor.Internal.Cursor.Locked;
			bool result;
			if (locked == LockCursorManager.lastSetLock)
			{
				result = false;
			}
			else
			{
				LockCursorManager.lastSetLock = locked;
				if (!LockCursorManager.lastSetLock)
				{
					LockCursorManager.PostCursorUnlocked((UnlockCursorFlags)0);
				}
				else
				{
					LockCursorManager.PostCursorLocked();
				}
				result = true;
			}
			return result;
		}

		// Token: 0x06000093 RID: 147 RVA: 0x00004330 File Offset: 0x00002530
		public static UnlockCursorNode CreateCursorUnlockNode(bool startsUnlocked, string debugInfo)
		{
			return new UnlockCursorNodeImpl(startsUnlocked, (UnlockCursorFlags)0, debugInfo);
		}

		// Token: 0x06000094 RID: 148 RVA: 0x0000434C File Offset: 0x0000254C
		public static UnlockCursorNode CreateCursorUnlockNode(bool startsUnlocked, UnlockCursorFlags nonBlocking, string debugInfo)
		{
			return new UnlockCursorNodeImpl(startsUnlocked, nonBlocking, debugInfo);
		}

		// Token: 0x06000095 RID: 149 RVA: 0x000023F8 File Offset: 0x000005F8
		public static void DisableGUICheckOnDisable(MonoBehaviour paddee)
		{
			NoExit.lockNoExitCount.Remove(paddee);
		}

		// Token: 0x06000096 RID: 150 RVA: 0x00004368 File Offset: 0x00002568
		public static void DisableGUICheckOnEnable(MonoBehaviour paddee)
		{
			if (!NoExit.lockNoExitCount.Contains(paddee))
			{
				NoExit.lockNoExitCount.Add(paddee);
			}
		}

		// Token: 0x06000097 RID: 151 RVA: 0x00004394 File Offset: 0x00002594
		private static void EnsureNoCallbacks()
		{
			if (LockCursorManager.lockOrUnlockCallbackInProgress)
			{
				throw new InvalidOperationException("DO NOT LOCK OR UNLOCK SCREEN IN A UNLOCK OR LOCK CALLBACK!");
			}
		}

		// Token: 0x06000098 RID: 152 RVA: 0x000043BC File Offset: 0x000025BC
		private void HandleEvent(Event evnt, int controlID, bool button)
		{
			switch (evnt.GetTypeForControl(controlID))
			{
			case EventType.MouseDown:
				if (LockCursorManager.lastSetLock || evnt.button != 0)
				{
					return;
				}
				this.swallowMouse = true;
				GUIUtility.hotControl = controlID;
				evnt.Use();
				LockCursorManager.LockCursorNow(UnlockCursorFlags.OffWithOutsideMouseClick);
				return;
			case EventType.MouseUp:
				if (!this.swallowMouse || evnt.button != 0 || GUIUtility.hotControl != controlID)
				{
					return;
				}
				this.swallowMouse = false;
				GUIUtility.hotControl = 0;
				evnt.Use();
				return;
			case EventType.MouseMove:
				if (!this.swallowMouse || GUIUtility.hotControl != controlID)
				{
					return;
				}
				evnt.Use();
				return;
			case EventType.MouseDrag:
				if (!this.swallowMouse || GUIUtility.hotControl != controlID)
				{
					return;
				}
				evnt.Use();
				return;
			case EventType.KeyDown:
			{
				if (button)
				{
					return;
				}
				KeyCode keyCode = evnt.keyCode;
				if (!LockCursorManager.lastSetLock)
				{
					if (!this.ShouldSwallowKey(keyCode) || !this.swallowKeys.Add(keyCode))
					{
						return;
					}
					evnt.Use();
					this.anyKeysSwallowed = true;
					this.SwallowedKey(keyCode);
					return;
				}
				else
				{
					if (keyCode != KeyCode.Escape || !this.OnLockedEscapePress())
					{
						return;
					}
					this.swallowKeys.Add(keyCode);
					this.anyKeysSwallowed = true;
					if (LockCursorManager.onEscapeKey == null)
					{
						return;
					}
					try
					{
						LockCursorManager.onEscapeKey();
						return;
					}
					catch (Exception exception)
					{
						Debug.LogException(exception);
						return;
					}
				}
				break;
			}
			case EventType.KeyUp:
				break;
			default:
				return;
			}
			if (!button && this.anyKeysSwallowed)
			{
				KeyCode keyCode2 = evnt.keyCode;
				if (this.swallowKeys.Remove(keyCode2))
				{
					evnt.Use();
					this.anyKeysSwallowed = (this.swallowKeys.Count > 0);
				}
			}
		}

		// Token: 0x06000099 RID: 153 RVA: 0x000045FC File Offset: 0x000027FC
		private static bool IsLockBlocked(UnlockCursorFlags blockingFlag)
		{
			if (LockCursorManager.lockNodes != null)
			{
				int count = LockCursorManager.lockNodes.Count;
				int num = count;
				if (count != 0)
				{
					if ((byte)(blockingFlag & (UnlockCursorFlags.OffWithOutsideMouseClick | UnlockCursorFlags.OffWithEscapeKey | UnlockCursorFlags.OffWithOtherTryLock | UnlockCursorFlags.OffWithCallToSetLock | UnlockCursorFlags.OffWithInitialization)) == 0)
					{
						for (int i = 0; i < num; i++)
						{
							WeakReference weakReference = LockCursorManager.lockNodes[i];
							UnlockCursorNodeImpl unlockCursorNodeImpl = (UnlockCursorNodeImpl)weakReference.Target;
							if (!weakReference.IsAlive)
							{
								int num2 = i;
								i = num2 - 1;
								LockCursorManager.lockNodes.RemoveAt(num2);
								num--;
							}
							else if (unlockCursorNodeImpl.On)
							{
								return true;
							}
						}
					}
					else
					{
						for (int j = 0; j < num; j++)
						{
							WeakReference weakReference2 = LockCursorManager.lockNodes[j];
							UnlockCursorNodeImpl unlockCursorNodeImpl2 = (UnlockCursorNodeImpl)weakReference2.Target;
							if (!weakReference2.IsAlive)
							{
								int num3 = j;
								j = num3 - 1;
								LockCursorManager.lockNodes.RemoveAt(num3);
								num--;
							}
							else if ((byte)(unlockCursorNodeImpl2.Flags & blockingFlag) == 0 && unlockCursorNodeImpl2.On)
							{
								return true;
							}
						}
					}
					return LockCursorManager.forceUnlocked;
				}
			}
			return false;
		}

		// Token: 0x0600009A RID: 154 RVA: 0x0000475C File Offset: 0x0000295C
		public static bool IsLocked(bool ideal)
		{
			bool locked;
			if (LockCursorManager.hasSingleton)
			{
				LockCursorManager.CheckLockChange(false);
				locked = LockCursorManager.lastSetLock;
			}
			else if (!ideal)
			{
				locked = Facepunch.Cursor.Internal.Cursor.Locked;
			}
			else
			{
				LockCursorManager.autoLockInAwake = true;
				Binder.Bind();
				locked = LockCursorManager.lastSetLock;
			}
			return locked;
		}

		// Token: 0x0600009B RID: 155 RVA: 0x000047AC File Offset: 0x000029AC
		public static bool IsLocked()
		{
			if (LockCursorManager.hasSingleton)
			{
				LockCursorManager.CheckLockChange(false);
			}
			return Facepunch.Cursor.Internal.Cursor.Locked;
		}

		// Token: 0x0600009C RID: 156 RVA: 0x000047D8 File Offset: 0x000029D8
		private static bool IsUnlockBlocked()
		{
			return false;
		}

		// Token: 0x0600009D RID: 157 RVA: 0x00002407 File Offset: 0x00000607
		private void LateUpdate()
		{
			LockCursorManager.CheckLockChange(false);
		}

		// Token: 0x0600009E RID: 158 RVA: 0x000047EC File Offset: 0x000029EC
		internal static bool LockCursorNow(UnlockCursorFlags blockingFlag)
		{
			return LockCursorManager.LockCursorNow(blockingFlag, (UnlockCursorFlags)0);
		}

		// Token: 0x0600009F RID: 159 RVA: 0x00004808 File Offset: 0x00002A08
		internal static bool LockCursorNow(UnlockCursorFlags blockingFlag, UnlockCursorFlags specialFlags)
		{
			LockCursorManager.EnsureNoCallbacks();
			bool result;
			if (Facepunch.Cursor.Internal.Cursor.Locked || LockCursorManager.IsLockBlocked(blockingFlag) || (!Facepunch.Cursor.Internal.Cursor.Lock() && (!Application.isEditor || !Facepunch.Cursor.Internal.Cursor.Lock())))
			{
				result = false;
			}
			else
			{
				LockCursorManager.PostCursorLocked();
				if (Facepunch.Cursor.Internal.Cursor.Unlocked)
				{
					Debug.LogError("NOTHING in the game should modify Screen.lockCursor");
				}
				if ((byte)(specialFlags & UnlockCursorFlags.DoNotResetInput) != 32)
				{
					Input.ResetInputAxes();
				}
				result = true;
			}
			return result;
		}

		// Token: 0x060000A0 RID: 160 RVA: 0x0000488C File Offset: 0x00002A8C
		public static void LogBlockers()
		{
			if (LockCursorManager.lockNodes != null)
			{
				int count = LockCursorManager.lockNodes.Count;
				int num = count;
				if (count > 0)
				{
					for (int i = 0; i < num; i++)
					{
						WeakReference weakReference = LockCursorManager.lockNodes[i];
						UnlockCursorNodeImpl unlockCursorNodeImpl = (UnlockCursorNodeImpl)weakReference.Target;
						if (!weakReference.IsAlive)
						{
							int num2 = i;
							i = num2 - 1;
							LockCursorManager.lockNodes.RemoveAt(num2);
							num--;
						}
						else if (unlockCursorNodeImpl.On)
						{
							Debug.Log(unlockCursorNodeImpl.DebugInfo + " blocked. unblocks: " + unlockCursorNodeImpl.Flags);
						}
					}
				}
			}
		}

		// Token: 0x060000A1 RID: 161 RVA: 0x0000495C File Offset: 0x00002B5C
		private void OnDestroy()
		{
			LockCursorManager.destroyedOnce = true;
			if (LockCursorManager.createdOnce)
			{
				Binder.singleton = null;
			}
		}

		// Token: 0x060000A2 RID: 162 RVA: 0x00004984 File Offset: 0x00002B84
		private void OnGUI()
		{
			Ready1.Init();
			GUI.depth = 99;
			Event current = Event.current;
			EventType type = current.type;
			LockCursorManager.lastEventType = type;
			if (type == EventType.Repaint)
			{
				LockCursorManager.CheckLockChange(false);
			}
			bool canUse = NoExit.CanUse;
			LockCursorManager.buttonID = RectIdentifiers.buttonControlID;
			if (canUse)
			{
				this.HandleEvent(current, LockCursorManager.buttonID, true);
			}
			LockCursorManager.keyboardID = RectIdentifiers.keyboardControlID;
			if (canUse)
			{
				this.HandleEvent(current, LockCursorManager.keyboardID, false);
			}
		}

		// Token: 0x060000A3 RID: 163 RVA: 0x00004A14 File Offset: 0x00002C14
		private bool OnLockedEscapePress()
		{
			return LockCursorManager.CheckLockChange(true) || LockCursorManager.UnlockCursorNow();
		}

		// Token: 0x060000A4 RID: 164 RVA: 0x00004A3C File Offset: 0x00002C3C
		private static void PostCursorLocked()
		{
			if (LockCursorManager.lockNodes != null)
			{
				int count = LockCursorManager.lockNodes.Count;
				int num = count;
				if (count > 0)
				{
					for (int i = 0; i < num; i++)
					{
						WeakReference weakReference = LockCursorManager.lockNodes[i];
						UnlockCursorNodeImpl unlockCursorNodeImpl = (UnlockCursorNodeImpl)weakReference.Target;
						if (weakReference.IsAlive)
						{
							unlockCursorNodeImpl.On = false;
						}
						else
						{
							int num2 = i;
							i = num2 - 1;
							LockCursorManager.lockNodes.RemoveAt(num2);
							num--;
						}
					}
				}
			}
			if (LockCursorManager.lockCallbacks != null && LockCursorManager.lockCallbacks.Count > 0)
			{
				List<LockOrUnlockCursorCallback> list = new List<LockOrUnlockCursorCallback>(LockCursorManager.lockCallbacks);
				LockCursorManager.lockCallbacks.Clear();
				try
				{
					LockCursorManager.lockOrUnlockCallbackInProgress = true;
					foreach (LockOrUnlockCursorCallback lockOrUnlockCursorCallback in list)
					{
						try
						{
							lockOrUnlockCursorCallback();
						}
						catch (Exception ex)
						{
							object[] args = new object[]
							{
								"In lock callback :",
								lockOrUnlockCursorCallback,
								":",
								ex
							};
							Debug.LogError(string.Concat(args));
						}
					}
				}
				finally
				{
					LockCursorManager.lockOrUnlockCallbackInProgress = false;
				}
			}
		}

		// Token: 0x060000A5 RID: 165 RVA: 0x00004BD8 File Offset: 0x00002DD8
		private static void PostCursorUnlocked(UnlockCursorFlags specialFlags)
		{
			if (LockCursorManager.lockCallbacks != null && LockCursorManager.lockCallbacks.Count > 0)
			{
				List<LockOrUnlockCursorCallback> list = new List<LockOrUnlockCursorCallback>(LockCursorManager.lockCallbacks);
				LockCursorManager.lockCallbacks.Clear();
				try
				{
					LockCursorManager.lockOrUnlockCallbackInProgress = true;
					foreach (LockOrUnlockCursorCallback lockOrUnlockCursorCallback in list)
					{
						try
						{
							lockOrUnlockCursorCallback();
						}
						catch (Exception ex)
						{
							object[] args = new object[]
							{
								"In unlock callback :",
								lockOrUnlockCursorCallback,
								":",
								ex
							};
							Debug.LogError(string.Concat(args));
						}
					}
				}
				finally
				{
					LockCursorManager.lockOrUnlockCallbackInProgress = false;
				}
			}
			if ((byte)(specialFlags & UnlockCursorFlags.DoNotResetInput) == 0)
			{
				Input.ResetInputAxes();
			}
		}

		// Token: 0x060000A6 RID: 166 RVA: 0x00002411 File Offset: 0x00000611
		private void Reset()
		{
			Debug.LogError("DO NOT USE LOCK CURSOR MANAGER ON A GAME OBJECT", this);
			base.hideFlags = HideFlags.HideAndDontSave;
		}

		// Token: 0x060000A7 RID: 167 RVA: 0x00004CF0 File Offset: 0x00002EF0
		public static bool SetLocked(bool locked)
		{
			bool result;
			if (!locked)
			{
				result = (Facepunch.Cursor.Internal.Cursor.Unlocked || LockCursorManager.UnlockCursorNow());
			}
			else
			{
				result = (Facepunch.Cursor.Internal.Cursor.Locked || LockCursorManager.LockCursorNow(UnlockCursorFlags.OffWithCallToSetLock));
			}
			return result;
		}

		// Token: 0x060000A8 RID: 168 RVA: 0x00004D38 File Offset: 0x00002F38
		private bool ShouldSwallowKey(KeyCode key)
		{
			return key == KeyCode.Escape;
		}

		// Token: 0x060000A9 RID: 169 RVA: 0x00004D50 File Offset: 0x00002F50
		private void SwallowedKey(KeyCode key)
		{
			if (key == KeyCode.Escape && !this.swallowMouse)
			{
				LockCursorManager.LockCursorNow(UnlockCursorFlags.OffWithEscapeKey);
			}
		}

		// Token: 0x060000AA RID: 170 RVA: 0x00004D7C File Offset: 0x00002F7C
		internal static bool UnlockCursorNow()
		{
			return LockCursorManager.UnlockCursorNow((UnlockCursorFlags)0);
		}

		// Token: 0x060000AB RID: 171 RVA: 0x00004D94 File Offset: 0x00002F94
		internal static bool UnlockCursorNow(UnlockCursorFlags specialFlags)
		{
			LockCursorManager.EnsureNoCallbacks();
			bool result;
			if (Facepunch.Cursor.Internal.Cursor.Unlocked || LockCursorManager.IsUnlockBlocked() || !Facepunch.Cursor.Internal.Cursor.Unlock())
			{
				result = false;
			}
			else
			{
				LockCursorManager.PostCursorUnlocked(specialFlags);
				if (Facepunch.Cursor.Internal.Cursor.Locked)
				{
					Debug.LogError("NOTHING in the game should modify Screen.lockCursor");
				}
				result = true;
			}
			return result;
		}

		// Token: 0x060000AC RID: 172 RVA: 0x00002429 File Offset: 0x00000629
		private void Update()
		{
			Ready1.Init();
			LockCursorManager.CheckLockChange(false);
		}

		// Token: 0x14000001 RID: 1
		// (add) Token: 0x060000AD RID: 173 RVA: 0x00004DF0 File Offset: 0x00002FF0
		// (remove) Token: 0x060000AE RID: 174 RVA: 0x00004E2C File Offset: 0x0000302C
		public static event EscapeKeyEventHandler onEscapeKey;

		// Token: 0x04000077 RID: 119
		internal const string globalGameObjectName = "__LockCursorManager";

		// Token: 0x04000078 RID: 120
		private const int guiDepth = 99;

		// Token: 0x04000079 RID: 121
		internal const HideFlags globalGameObjectHideFlags = HideFlags.HideInHierarchy;

		// Token: 0x0400007A RID: 122
		internal const HideFlags globalLockCursorManagerHideFlags = HideFlags.NotEditable;

		// Token: 0x0400007B RID: 123
		private static bool lockOrUnlockCallbackInProgress;

		// Token: 0x0400007C RID: 124
		private static bool forceUnlocked;

		// Token: 0x0400007D RID: 125
		private static bool autoLockInAwake;

		// Token: 0x0400007E RID: 126
		internal static List<WeakReference> lockNodes;

		// Token: 0x0400007F RID: 127
		private static HashSet<LockOrUnlockCursorCallback> lockCallbacks;

		// Token: 0x04000080 RID: 128
		internal static bool createdOnce;

		// Token: 0x04000081 RID: 129
		internal static bool destroyedOnce;

		// Token: 0x04000082 RID: 130
		internal static bool lastSetLock;

		// Token: 0x04000083 RID: 131
		private bool swallowMouse;

		// Token: 0x04000084 RID: 132
		private bool anyKeysSwallowed;

		// Token: 0x04000085 RID: 133
		private HashSet<KeyCode> swallowKeys;

		// Token: 0x04000086 RID: 134
		private static EventType lastEventType;

		// Token: 0x04000087 RID: 135
		private static int buttonID;

		// Token: 0x04000088 RID: 136
		private static int keyboardID;
	}
}
