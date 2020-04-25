using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Live.Core.Annotations;
using imgui = ImGuiNET.ImGui;

namespace ImmediateUserInterface.Components
{
    [ReloadableClass]
    public class Square
    {
        static Random rng = new Random();

        public Vector2 pos, size;


        // for reload only
        public Square()
        { }

        public Square(int xpos, int ypos)
        {
            pos = new Vector2(xpos, ypos);
            size = new Vector2(rng.Next(200, 300), rng.Next(150, 400));
        }

        public void Draw()
        {
            imgui.SetCursorPos(pos);
            imgui.Button("baa baa sheep", new Vector2(300,50));
        }
    }
}
