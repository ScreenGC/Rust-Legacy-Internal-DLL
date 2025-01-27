using System;
using FPS.CODE;
using FPS.Settings;
using Rust;
using UnityEngine;

namespace FPS.GUIS
{
    public class GUISV : MonoBehaviour
    {
        string inputValue = "";
        private bool showItemsWindow = false;
        private bool showdoisWindow = false;
        private bool showtresWindow = false;
        private bool useExtendedRange = false; // Para alterar o range do slider
        private KeyCode lastPressedKey;
        public static bool SetFlyKey = true;

        private void Update()
        {
            // Verifica se a tecla do FlyHack foi pressionada e alterna o estado
            if (Input.GetKeyDown(CVars.Misc.FlyKey))
            {
                CVars.Misc.FlyHack = !CVars.Misc.FlyHack;
            }
        }

        private void DoMyWindowUm(int windowID)
        {
            Vector2 mousePos = Event.current.mousePosition;
            GUI.Label(new Rect(10f, 10f, 150f, 20f), $"Speed = ({CVars.Misc.SpeedModifer * 4f / 10f:0.#})");

            Rect sliderRect = new Rect(10f, 30f, 150f, 20f);
            useExtendedRange = GUI.Toggle(new Rect(10f, 50f, 150f, 20f), useExtendedRange, "The Flash Mode!");
            float minValue = 10f;
            float maxValue = useExtendedRange ? 120f : 20f;
            CVars.Misc.SpeedModifer = GUI.HorizontalSlider(sliderRect, CVars.Misc.SpeedModifer, minValue, maxValue);

            CVars.Misc.FlyHack = GUI.Toggle(new Rect(10f, 70f, 150f, 20f), CVars.Misc.FlyHack, "Fly Hack");

            string text = SetFlyKey ? CVars.Misc.FlyKey.ToString() : "Set Key";
            if (GUI.Button(new Rect(80f, 70f, 90f, 20f), text))
            {
                SetFlyKey = false;
            }

            CVars.Misc.NoFallDamage = GUI.Toggle(new Rect(10f, 90f, 150f, 20f), CVars.Misc.NoFallDamage, "No Fall Damage");

            if (!sliderRect.Contains(mousePos))
            {
                GUI.DragWindow(new Rect(0, 0, startRect.width, 30f));
            }
            if (GUI.Button(new Rect(10f, 110f, 200f, 20f), "Unlock Blueprints"))
            {
                Misc.AllBlueprints();
                Notice.Inventory("", "All Blueprints Unlocked!");
            }
        }

        private void DoMyWindowDois(int windowID)
        {
            Vector2 mousePos = Event.current.mousePosition;
            // Adicione o conteúdo exclusivo da janela "Dois" aqui

            if (!doisRect.Contains(mousePos))
            {
                GUI.DragWindow(new Rect(0, 0, doisRect.width, 30f));
            }
        }

        private void DoMyWindowTres(int windowID)
        {
            Vector2 mousePos = Event.current.mousePosition;
            // Adicione o conteúdo exclusivo da janela "Tres" aqui

            if (!tresRect.Contains(mousePos))
            {
                GUI.DragWindow(new Rect(0, 0, tresRect.width, 30f));
            }
        }

        private void OnGUI()
        {
            if (!SetFlyKey)
            {
                if (Event.current.type == EventType.KeyDown)
                {
                    lastPressedKey = Event.current.keyCode;
                }
                if (lastPressedKey != KeyCode.None)
                {
                    SetFlyKey = true;
                    CVars.Misc.FlyKey = lastPressedKey;
                    lastPressedKey = KeyCode.None;
                }
            }

            if (Local.atamgmmeg)
            {
                if (GUI.Button(new Rect(10f, 10f, 100f, 30f), "Um"))
                    showItemsWindow = !showItemsWindow;

                if (GUI.Button(new Rect(10f, 50f, 100f, 30f), "Dois"))
                    showdoisWindow = !showdoisWindow;

                if (GUI.Button(new Rect(10f, 90f, 100f, 30f), "Tres"))
                    showtresWindow = !showtresWindow;
            }

            if (showItemsWindow && Local.atamgmmeg)
            {
                GUI.color = Color.blue;
                GUI.backgroundColor = Color.black;
                startRect = GUI.Window(3, startRect, DoMyWindowUm, "<size=13><b><color=#3333ff>Um</color></b></size>");
            }

            if (showdoisWindow && Local.atamgmmeg)
            {
                GUI.color = Color.green;
                GUI.backgroundColor = Color.black;
                doisRect = GUI.Window(4, doisRect, DoMyWindowDois, "<size=13><b><color=#33cc33>Dois</color></b></size>");
            }

            if (showtresWindow && Local.atamgmmeg)
            {
                GUI.color = Color.yellow;
                GUI.backgroundColor = Color.black;
                tresRect = GUI.Window(5, tresRect, DoMyWindowTres, "<size=13><b><color=#ffff00>Tres</color></b></size>");
            }
        }

        private void Start()
        {
            startRect.x = 0f;
            startRect.y = 0f;
            doisRect.x = 100f;
            doisRect.y = 150f;
            tresRect.x = 200f;
            tresRect.y = 300f;
        }

        public static Rect startRect = new Rect(200f, 160f, 250f, 150f);
        public static Rect doisRect = new Rect(200f, 150f, 100f, 100f);
        public static Rect tresRect = new Rect(200f, 150f, 100f, 100f);
    }
}