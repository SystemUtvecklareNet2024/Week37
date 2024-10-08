﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiplicationLoop
{
    public class Color
    {
        ConsoleColor baseColor;
        public Color(ConsoleColor color)
        {
            baseColor = color;
        }

        public void ResetColor()
        {
            Console.ForegroundColor = baseColor;
        }
        public void Red(string text)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(text);
            ResetColor();
        }

        public void Green(string text)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(text);
            ResetColor();
        }

        public void Yellow(string text)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(text);
            ResetColor();
        }

        public void Blue(string text)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write(text);
            ResetColor();
        }

        public void White(string text)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(text);
            ResetColor();
        }

        public void Magenta(string text)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write(text);
            ResetColor();
        }

        public void Gray(string text)
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write(text);
            ResetColor();
        }

        public void Cyan(string text)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(text);
            ResetColor();
        }
    }   
}
