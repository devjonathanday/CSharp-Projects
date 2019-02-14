using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raylib;
using static Raylib.Raylib;

namespace CSharpProjects
{
    class Program
    {
        static void Main(string[] args)
        {
            InitWindow(800, 600, "Raylib For CSharp");

            while(!WindowShouldClose())
            {
                BeginDrawing();
                ClearBackground(Color.BLACK);
                DrawText("Raylib for C#!", 200, 200, 20, Color.WHITE);

                EndDrawing();
            }            
        }
    }
}