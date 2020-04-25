using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using imgui = ImGuiNET.ImGui;
using ImGuiNET;
using num = System.Numerics;
using System.Diagnostics;
using Microsoft.Xna.Framework.Input;
using Live.Core.Annotations;
using System.Collections.Generic;

namespace ImmediateUserInterface.Components
{
    [ReloadableClass]
    public class UserInterface
    {
        public float counter;

        public float fpsCount = 0;
        public float fps = 0;
        public float totalElapsedSeconds = 0;

        public readonly List<Square> squares;

        public Texture2D tex;
        public SpriteBatch batch;

        public UserInterface()
        {
            squares = new List<Square>();

            for (int i = 0; i < 5; i++)
            {
                squares.Add(new Square(i * 200, i * 10));
            }
        }

        /// <summary>
        /// Called on every hot reload
        /// </summary>
        public void LoadContent(GraphicsDevice graphicsDevice)
        {
            tex = new Texture2D(graphicsDevice, 1, 1);
            tex.SetData(new[] { Color.White });

            batch = new SpriteBatch(graphicsDevice);
        }

        public void UnloadContent()
        {
            //throw new NotImplementedException();
        }

        public void Update(TimeSpan elapsed)
        {
            fpsCount++;
            totalElapsedSeconds += (float)elapsed.TotalSeconds;
            if (totalElapsedSeconds >= 1)
            {
                fps = fpsCount;
                fpsCount = 0;
                totalElapsedSeconds = 0;
            }
        }

        string textArea = "";

        public void Draw(GraphicsDevice graphicsDevice, MouseState mouseState, KeyboardState keyboardState)
        {
            for (int i = 0; i < 5; i++)
            {
                squares[i].Draw();
            }

            var vp = graphicsDevice.Viewport;
            var pp = graphicsDevice.PresentationParameters;

            //graphicsDevice.Clear(Color.Gray);

            //batch.Begin();
            //batch.Draw(tex, new Rectangle(0, 0, vp.Width, vp.Height), Color.Red);
            //batch.Draw(tex, new Rectangle(0, 0, pp.BackBufferWidth, pp.BackBufferHeight), Color.Green);
            //batch.End();

            imgui.SetNextWindowSize(new num.Vector2(400, 400), ImGuiCond.FirstUseEver);
            counter -= 0.1f;
            //imgui.SetWindowPos("Control Panel", new num.Vector2(80 + (float)Math.Sin(m.counter) * 60, 120 + (float)Math.Cos(m.counter) * 90));

            if (imgui.Begin("Control Panel"))
            {

                //imgui.Columns(5);
                //imgui.SetColumnWidth(0, 100); 

                imgui.Text("          FPssS:");
                imgui.SameLine(); imgui.Text(fps.ToString());

                imgui.Text("        Count:");
                imgui.SameLine(); imgui.Text(Math.Round(counter*-1).ToString());


                imgui.Text("     Viewport: W");
                imgui.SameLine(); imgui.Text(vp.Width.ToString());
                imgui.SameLine(); imgui.Text("H");
                imgui.SameLine(); imgui.Text(vp.Height.ToString());

                imgui.Text("   BackBuffer: W");
                imgui.SameLine(); imgui.Text(pp.BackBufferWidth.ToString());
                imgui.SameLine(); imgui.Text("H");
                imgui.SameLine(); imgui.Text(pp.BackBufferHeight.ToString());

                imgui.Text("   Difference: W");
                imgui.SameLine(); imgui.Text((pp.BackBufferWidth - vp.Width).ToString());
                imgui.SameLine(); imgui.Text("H");
                imgui.SameLine(); imgui.Text((pp.BackBufferHeight - vp.Height).ToString());

                imgui.Text("        Mouse: X:");
                imgui.SameLine(); imgui.Text(mouseState.X.ToString());
                imgui.SameLine(); imgui.Text("Y");
                imgui.SameLine(); imgui.Text(mouseState.Y.ToString());
                imgui.Text("Mouse Buttons:");
                imgui.SameLine(); imgui.Text(mouseState.LeftButton.ToString());
                imgui.SameLine(); imgui.Text(mouseState.RightButton.ToString());

                imgui.InputText("", ref textArea, 100);

                for (int i = 0; i < 5; i++)
                //    foreach (var square in squares)
                {
                    squares[i].Draw();   
                }

                imgui.End();
            }

            //if (imgui.Begin("Control Panel 22222"))
            //{
            //    //LogError("test");
                   
            //    ////imgui.Columns(5);
            //    ////imgui.SetColumnWidth(0, 100);  

            //    //imgui.Text("       FPS:");
            //    //imgui.SameLine(); imgui.Text(fps.ToString());
            //    //imgui.SameLine(); imgui.Text(state.counter.ToString());


            //    //imgui.Text("BackBuffer: W");
            //    //imgui.SameLine(); imgui.Text(pp.BackBufferWidth.ToString());
            //    //imgui.SameLine(); imgui.Text("H");
            //    //imgui.SameLine(); imgui.Text(pp.BackBufferHeight.ToString());

            //    //imgui.Text("Difference: W");
            //    //imgui.SameLine(); imgui.Text((pp.BackBufferWidth - vp.Width).ToString());
            //    //imgui.SameLine(); imgui.Text("H");
            //    //imgui.SameLine(); imgui.Text((pp.BackBufferHeight - vp.Height).ToString());
            //}
        }
    }
}