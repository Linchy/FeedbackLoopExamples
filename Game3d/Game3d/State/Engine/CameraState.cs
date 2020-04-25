using System;
using Live.Core;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game3d.State
{
    public class CameraState
    {
        public class ViewModel
        {
            public Matrix viewMatrix;
            public Matrix projectionMatrix;
        }
    }
}