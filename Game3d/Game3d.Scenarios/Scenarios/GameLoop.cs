using System;
using Game3d.Scenarios.State;
using Live.Core.Rendering;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game3d.Scenarios
{
    public class GameLoop : ScriptEntryPointRenderer
    {
        private StateGameLoop.ViewModel vm => (StateGameLoop.ViewModel)StateObject;
        private StateGameLoop.Model m => vm.Model;

        public GameLoop()
         : base(new StateGameLoop.ViewModel())
        {
        }

        /// <summary>
        /// Called on every hot reload
        /// </summary>
        public override void PerformLoadContent()
        {
            vm.Cube._.LoadContent(vm.Camera, GraphicsDevice, Vector3.One);
            //vm.Renderer.LoadContent(GraphicsDevice);
            //vm.UserInterface._.LoadContent(GraphicsDevice);
        }

        public override void OnScriptLoaded()
        {
            vm.Camera._.OnScriptLoaded();
            vm.Cube._.OnScriptLoaded();
        }

        public override void PerformUnloadContent()
        {
            //vm.UserInterface._.UnloadContent();
        }

        public override void PerformUpdate(GameTime gameTime)
        {
            //The projection depends on viewport dimensions (aspect ratio).
            // Because WPF controls can be resized at any time (user resizes window)
            // we need to refresh the values each draw call, otherwise cube will look distorted to user
            vm.Camera._.RefreshProjection(GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height);

            vm.Cube._.Update();

            //LogError.Invoke(vm.Camera._.vm.viewMatrix.ToString());
        }

        public override void PerformDraw(GameTime gameTime)
        {
            vm.Cube._.Draw();
        }
    }
}