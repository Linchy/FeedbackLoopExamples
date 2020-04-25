using System;
using Game3d.State;
using Live.Core;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game3d
{
    public class Camera : ScriptStateful
    {
        public CameraState.ViewModel vm => (CameraState.ViewModel)StateObject;
      
        public Camera()
            : base(new CameraState.ViewModel())
        {
        }

        public override void OnScriptLoaded()
        {
            vm.viewMatrix = Matrix.CreateLookAt(new Vector3(5, 20, 5), Vector3.Zero, Vector3.Up);
        }

        /// <summary>
        /// Update projection matrix values, both in the calculated matrix <see cref="_projectionMatrix"/> as well as
        /// the <see cref="_basicEffect"/> projection.
        /// </summary>
        public void RefreshProjection(float width, float height)
        {
            vm.projectionMatrix = Matrix.CreatePerspectiveFieldOfView(
                MathHelper.ToRadians(45), // 45 degree angle
                width / height,
                0.00001f, 10000.0f);
        }
    }
}