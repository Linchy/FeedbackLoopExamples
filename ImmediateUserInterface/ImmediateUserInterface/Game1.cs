using ImGuiNET;
using ImmediateUserInterface.Components;
using Live.Core.Rendering;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.ImGui;

namespace ImmediateUserInterface.Render
{
    public class Game1 : Game
    {
        private readonly GraphicsDeviceManager graphics;

        private readonly LiveImGuiRenderer Renderer;
        private readonly UserInterface UserInterface;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            Window.TextInput += (s, a) =>
            {
                if (a.Character == '\t') 
                    return;

                ImGui.GetIO().AddInputCharacter(a.Character);
            };

            this.IsMouseVisible = true;
            this.IsFixedTimeStep = true;
            this.Window.AllowUserResizing = true;

            this.Renderer = new LiveImGuiRenderer();
            this.UserInterface = new UserInterface();
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            Renderer.LoadContent(GraphicsDevice);
            UserInterface.LoadContent(GraphicsDevice);
        }

        protected override void UnloadContent()
        {
        }

        protected override void Update(GameTime gameTime)
        {
            UserInterface.Update(gameTime.ElapsedGameTime);

            base.Update(gameTime);
        }

        protected override unsafe void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            var mouse = Mouse.GetState();
            var keyboard = Keyboard.GetState();

            Renderer.BeforeLayout(gameTime.ElapsedGameTime, mouse, keyboard, "");
            UserInterface.Draw(GraphicsDevice, mouse, keyboard);
            Renderer.AfterLayout();

            base.Draw(gameTime);
        }
    }
}
