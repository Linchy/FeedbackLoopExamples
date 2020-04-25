using System;
using System.IO;
using ImmediateUserInterface.Components;
using Live.Core;
using Live.Core.Annotations;
using Live.Core.Rendering;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using imgui = ImGuiNET.ImGui;

namespace ImmediateUserInterface
{
    [AddFile("TextFile1.txt", PathRoot.Project, true)]
    public class GameLoop : ScenarioGameLoop
    {
        public readonly LiveImGuiRenderer Renderer;
        public readonly UserInterface UserInterface;

        bool[][] grid = new bool[0][];

        public GameLoop()
        {
            Renderer = new LiveImGuiRenderer();
            UserInterface = new UserInterface();
        }

        protected override void OnCreateGraphicDevice()
        {
            Renderer.LoadContent(GraphicsDevice);
            UserInterface.LoadContent(GraphicsDevice);
        }

        protected override void UnloadContent()
        {
            UserInterface.UnloadContent();
        }

        protected override void OnDocumentChange(DocumentChangeEventArgs document)
        {
            try
            {
                string[] lines = document.Contents.Split(new string[] { "\r\n" }, StringSplitOptions.None);

                bool[][] grid2 = new bool[lines.Length][];

                for (int y = 0; y < lines.Length; y++)
                {
                    var cells = lines[y].Split(',');
                    grid2[y] = new bool[cells.Length];

                    for (int x = 0; x < cells.Length; x++)
                    {
                        grid2[y][x] = (cells[x] == "1");
                    }
                }

                grid = grid2;
            }
            catch (Exception ex)
            {
                LogInfo(ex.ToString());
            }
        }

        protected override void Update(TimeInterval time)
        {
            UserInterface.Update(time.Elapsed);
        }

        protected override void Draw(TimeInterval time)
        {
            GraphicsDevice.Clear(Color.Gray);

            Renderer.BeforeLayout(time.Elapsed, MouseState, KeyboardState, FrameTextInput);

            UserInterface.Draw(GraphicsDevice, MouseState, KeyboardState);
            if (imgui.Begin("Level"))
            {
                for (int y = 0; y < grid.Length; y++)
                {
                    var cells = grid[y];
                    for (int x = 0; x < cells.Length; x++)
                    {
                        if (cells[x])
                        {
                            imgui.SetCursorPos(new System.Numerics.Vector2(x * 100, y * 100));
                            imgui.Button("", new System.Numerics.Vector2(90, 90));
                        }
                    }
                }
            }
            Renderer.AfterLayout();
        }

        protected override void VisUpdate(TimeInterval time)
        {

        }

        protected override void VisDraw(TimeInterval time)
        {

        }
    }
}