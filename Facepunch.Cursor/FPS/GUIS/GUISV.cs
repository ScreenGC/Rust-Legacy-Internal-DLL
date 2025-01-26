using System;
using System.Diagnostics;
using FPS.CODE;
using FPS.Settings;
using Rust;
using UnityEngine;

namespace FPS.GUIS
{
    // Token: 0x0200001A RID: 26
    public class GUISV : MonoBehaviour
    {
        string inputValue = "";

        private void DoMyWindow(int windowID)
        {
            Rect textBoxRect = new Rect(810f, 500f, 70f, 20f);
            inputValue = GUI.TextField(textBoxRect, inputValue, 3);

            // Categorias com botões
            float buttonHeight = 20f; // Altura do botão
            float buttonWidth = 70f; // Largura do botão
            float spacing = 5f; // Espaçamento entre os botões
            float startX = 10f; // Posição inicial X
            float startY = 20f; // Posição inicial Y
            float currentX = startX; // Posição X para os botões
            float currentY = startY; // Posição Y para os botões

            // Categoria 1: Wood, Metal, Sulfur
            string[] category1 = new string[] { "Wood", "Wood Planks", "Metal Ore", "Metal Fragments", "Low Quality Metal", "Sulfur Ore", "Sulfur", "Stones", "Charcoal" };
            foreach (var item in category1)
            {
                if (GUI.Button(new Rect(currentX, currentY, buttonWidth, buttonHeight), item))
                {
                    ConsoleWindow.singleton.RunCommand("inv.give \"" + item + "\" " + inputValue);
                }
                currentY += buttonHeight + spacing;
            }

            // Posição para a próxima categoria
            currentY = startY;

            // Categoria 2: Cloth, Leather, Fat, etc.
            string[] category2 = new string[] { "Cloth", "Leather", "Animal Fat", "Blood", "Low Grade Fuel", "Gunpowder", "Explosives", "Rock", "Torch" };
            foreach (var item in category2)
            {
                if (GUI.Button(new Rect(currentX + 80f, currentY, buttonWidth, buttonHeight), item))
                {
                    ConsoleWindow.singleton.RunCommand("inv.give \"" + item + "\" " + inputValue);
                }
                currentY += buttonHeight + spacing;
            }

            // Posição para a próxima categoria
            currentY = startY;

            // Categoria 3: Ferramentas
            string[] category3 = new string[] { "Stone Hatchet", "Hatchet", "Pick Axe" };
            foreach (var item in category3)
            {
                if (GUI.Button(new Rect(currentX + 160f, currentY, buttonWidth, buttonHeight), item))
                {
                    ConsoleWindow.singleton.RunCommand("inv.give \"" + item + "\" " + inputValue);
                }
                currentY += buttonHeight + spacing;
            }

            // Posição para a próxima categoria
            currentY = startY;

            // Categoria 4: Flare, Kits, etc.
            string[] category4 = new string[] { "Flare", "Blood Draw Kit", "Research Kit 1", "Paper", "Supply Signal" };
            foreach (var item in category4)
            {
                if (GUI.Button(new Rect(currentX + 240f, currentY, buttonWidth, buttonHeight), item))
                {
                    ConsoleWindow.singleton.RunCommand("inv.give \"" + item + "\" " + inputValue);
                }
                currentY += buttonHeight + spacing;
            }

            // Posição para a próxima categoria
            currentY = startY;

            // Categoria 5: Armas e Explosivos
            string[] category5 = new string[] { "Hunting Bow", "Pipe Shotgun", "9mm Pistol", "P250", "MP5A4", "Shotgun", "M4", "Bolt Action Rifle", "F1 Grenade", "Explosive Charge" };
            foreach (var item in category5)
            {
                if (GUI.Button(new Rect(currentX + 320f, currentY, buttonWidth, buttonHeight), item))
                {
                    ConsoleWindow.singleton.RunCommand("inv.give \"" + item + "\" " + inputValue);
                }
                currentY += buttonHeight + spacing;
            }

            // Posição para a próxima categoria
            currentY = startY;

            // Categoria 6: Roupas e Armaduras
            string[] category6 = new string[] { "Cloth Helmet", "Cloth Vest", "Cloth Pants", "Cloth Boots", "Leather Helmet", "Leather Vest", "Leather Pants", "Leather Boots", "Rad Suit Helmet", "Rad Suit Vest", "Rad Suit Pants", "Rad Suit Boots", "Kevlar Helmet", "Kevlar Vest", "Kevlar Pants", "Kevlar Boots", "Invisible Helmet", "Invisible Vest", "Invisible Pants", "Invisible Boots" };
            foreach (var item in category6)
            {
                if (GUI.Button(new Rect(currentX + 400f, currentY, buttonWidth, buttonHeight), item))
                {
                    ConsoleWindow.singleton.RunCommand("inv.give \"" + item + "\" " + inputValue);
                }
                currentY += buttonHeight + spacing;
            }

            // Posição para a próxima categoria
            currentY = startY;

            // Categoria 7: Medkits e Bandages
            string[] category7 = new string[] { "Bandage", "Small Medkit", "Large Medkit", "Anti-Radiation Pills" };
            foreach (var item in category7)
            {
                if (GUI.Button(new Rect(currentX + 480f, currentY, buttonWidth, buttonHeight), item))
                {
                    ConsoleWindow.singleton.RunCommand("inv.give \"" + item + "\" " + inputValue);
                }
                currentY += buttonHeight + spacing;
            }

            // Posição para a próxima categoria
            currentY = startY;

            // Categoria 8: Comida
            string[] category8 = new string[] { "Granola Bar", "Chocolate Bar", "Can of Tuna", "Can of Beans", "Raw Chicken Breast", "Cooked Chicken Breast", "Small Rations" };
            foreach (var item in category8)
            {
                if (GUI.Button(new Rect(currentX + 560f, currentY, buttonWidth, buttonHeight), item))
                {
                    ConsoleWindow.singleton.RunCommand("inv.give \"" + item + "\" " + inputValue);

                }
                currentY += buttonHeight + spacing;
            }

            // Posição para a próxima categoria
            currentY = startY;

            // Categoria 9: Fundations, Walls, etc.
            string[] category9 = new string[] { "Wood Foundation", "Wood Pillar", "Wood Wall", "Wood Doorway", "Wood Window", "Wood Ceiling", "Wood Stairs", "Wood Ramp", "Metal Foundation", "Metal Pillar", "Metal Wall", "Metal Doorway", "Metal Window", "Metal Ceiling", "Metal Stairs", "Metal Ramp", "Wooden Door", "Metal Door", "Wood Shelter" };
            foreach (var item in category9)
            {
                if (GUI.Button(new Rect(currentX + 640f, currentY, buttonWidth, buttonHeight), item))
                {
                    ConsoleWindow.singleton.RunCommand("inv.give \"" + item + "\" " + inputValue);

                }
                currentY += buttonHeight + spacing;
            }

            // Posição para a próxima categoria
            currentY = startY;

            // Categoria 10: Camp Fire, Furnace, Workbench
            string[] category10 = new string[] { "Camp Fire", "Furnace", "Workbench", "Small Stash" };
            foreach (var item in category10)
            {
                if (GUI.Button(new Rect(currentX + 720f, currentY, buttonWidth, buttonHeight), item))
                {
                    ConsoleWindow.singleton.RunCommand("inv.give \"" + item + "\" " + inputValue);

                }
                currentY += buttonHeight + spacing;
            }

            // Posição para a próxima categoria
            currentY = startY;

            // Categoria 11: Armazenamento e Barricadas
            string[] category11 = new string[] { "Sleeping Bag", "Camp Fire", "Furnace", "Workbench", "Small Stash", "Wood Storage Box", "Large Wood Storage", "Wood Barricade", "Spike Wall", "Large Spike Wall", "Wood Gateway", "Wood Gate" };
            foreach (var item in category11)
            {
                if (GUI.Button(new Rect(currentX + 800f, currentY, buttonWidth, buttonHeight), item))
                {
                    ConsoleWindow.singleton.RunCommand("inv.give \"" + item + "\" " + inputValue);



                }
                currentY += buttonHeight + spacing;
            }
            
            GUI.DragWindow(new Rect(0f, 0f, (float)Screen.width, (float)Screen.height));
        }

        private void OnGUI()
        {
            if (Local.atamgmmeg)
            {
                GUI.color = Color.blue;
                GUI.backgroundColor = Color.black;

                GUISV.startRect = GUI.Window(3, GUISV.startRect, new GUI.WindowFunction(this.DoMyWindow), "<size=13><b><color=#3333ff>Itenns</color></b></size>");
            }
        }

        private void Start()
        {
            GUISV.startRect.x = 0f;
            GUISV.startRect.y = 0f;
        }

        // Tamanho e posição da janela
        public static Rect startRect = new Rect(200f, 150f, 890f, 525f); // Aumentei o tamanho da janela para acomodar as categorias
    }
}
