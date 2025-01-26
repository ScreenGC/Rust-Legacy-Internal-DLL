using System;
using System.Diagnostics;
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

        private void DoMyWindow(int windowID)
        {
            Rect textBoxRect = new Rect(810f, 500f, 70f, 20f);
            inputValue = GUI.TextField(textBoxRect, inputValue, 3);
            GUI.DragWindow(new Rect(0f, 0f, (float)Screen.width, (float)Screen.height));
        }

        private void OnGUI()
        {
            if (Local.atamgmmeg)
            {
                if (GUI.Button(new Rect(10f, 10f, 100f, 30f), "Um"))
                {
                    showItemsWindow = !showItemsWindow;
                }

                if (GUI.Button(new Rect(10f, 50f, 100f, 30f), "Dois"))
                {
                    showdoisWindow = !showdoisWindow;
                }

                if (GUI.Button(new Rect(10f, 90f, 100f, 30f), "Tres"))
                {
                    showtresWindow = !showtresWindow;
                }
            }

            if (showItemsWindow && Local.atamgmmeg)
            {
                GUI.color = Color.blue;
                GUI.backgroundColor = Color.black;
                GUISV.startRect = GUI.Window(3, GUISV.startRect, new GUI.WindowFunction(this.DoMyWindow), "<size=13><b><color=#3333ff>Um</color></b></size>");
            }

            if (showdoisWindow && Local.atamgmmeg)
            {
                GUI.color = Color.green;
                GUI.backgroundColor = Color.black;
                GUISV.doisRect = GUI.Window(4, GUISV.doisRect, new GUI.WindowFunction(this.DoMyWindow), "<size=13><b><color=#33cc33>Dois</color></b></size>");
            }

            if (showtresWindow && Local.atamgmmeg)
            {
                GUI.color = Color.yellow;
                GUI.backgroundColor = Color.black;
                GUISV.tresRect = GUI.Window(5, GUISV.tresRect, new GUI.WindowFunction(this.DoMyWindow), "<size=13><b><color=#ffff00>Tres</color></b></size>");
            }
        }

        private void Start()
        {
            GUISV.startRect.x = 0f;
            GUISV.startRect.y = 0f;
            GUISV.doisRect.x = 100f;
            GUISV.doisRect.y = 150f;
            GUISV.tresRect.x = 200f;
            GUISV.tresRect.y = 300f;
        }

        public static Rect startRect = new Rect(200f, 150f, 100f, 100f);
        public static Rect doisRect = new Rect(200f, 150f, 100f, 100f);
        public static Rect tresRect = new Rect(200f, 150f, 100f, 100f);
    }
}
