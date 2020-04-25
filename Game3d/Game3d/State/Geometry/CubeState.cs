using System;
using Live.Core;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game3d.State
{
    public class CubeState
    {
        public class ViewModel
        {
            public GraphicsDevice GraphicsDevice;
            public RT<Camera> camera;

            public BasicEffect _basicEffect;

            public VertexBuffer _vertexBuffer;
            public VertexDeclaration _vertexDeclaration;
            public Matrix _worldMatrix;

            public float _rotation;

            public int lastScrollWheelValue;
            public float zPos = 0;
        }
    }
}