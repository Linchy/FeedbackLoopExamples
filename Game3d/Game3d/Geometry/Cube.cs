using System;
using Game3d.State;
using Live.Core;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game3d
{
    public class Cube : ScriptStateful
    {
        private RasterizerState raster;

        private CubeState.ViewModel vm => (CubeState.ViewModel)StateObject;
        //private CubeState.Model m => vm.Model;
        
        public Cube()
        : base(new CubeState.ViewModel())
        {
        }

        public void LoadContent(RT<Camera> camera, GraphicsDevice graphicsDevice, Vector3 scale)
        {
            vm.camera = camera;

            vm. _worldMatrix = Matrix.CreateTranslation(scale);
            vm.GraphicsDevice = graphicsDevice;


            //logger.WriteLine("Loaded");

            vm._vertexDeclaration = new VertexDeclaration(
                new VertexElement(0, VertexElementFormat.Vector3, VertexElementUsage.Position, 0),
                new VertexElement(12, VertexElementFormat.Vector3, VertexElementUsage.Normal, 0),
                new VertexElement(24, VertexElementFormat.Vector2, VertexElementUsage.TextureCoordinate, 0)
            );

            Vector3 topLeftFront = new Vector3(-1.0f, 1.0f, -1.0f);
            Vector3 topRightFront = new Vector3(1.0f, 1.0f, -1.0f);
            Vector3 bottomLeftFront = new Vector3(-1.0f, -1.0f, -1.0f);
            Vector3 bottomRightFront = new Vector3(1.0f, -1.0f, -1.0f);

            Vector3 topLeftBack = new Vector3(-1.0f, 1.0f, 1.0f);
            Vector3 topRightBack = new Vector3(1.0f, 1.0f, 1.0f);
            Vector3 bottomLeftBack = new Vector3(-1.0f, -1.0f, 1.0f);
            Vector3 bottomRightBack = new Vector3(1.0f, -1.0f, 1.0f);

            Vector2 textureTopLeft = new Vector2(0.0f, 0.0f);
            Vector2 textureTopRight = new Vector2(1.0f, 0.0f);
            Vector2 textureBottomLeft = new Vector2(0.0f, 1.0f);
            Vector2 textureBottomRight = new Vector2(1.0f, 1.0f);

            Vector3 frontNormal = new Vector3(0.0f, 0.0f, 1.0f);
            Vector3 backNormal = new Vector3(0.0f, 0.0f, -1.0f);
            Vector3 topNormal = new Vector3(0.0f, 1.0f, 0.0f);
            Vector3 bottomNormal = new Vector3(0.0f, -1.0f, 0.0f);
            Vector3 leftNormal = new Vector3(-1.0f, 0.0f, 0.0f);
            Vector3 rightNormal = new Vector3(1.0f, 0.0f, 0.0f);

            var cubeVertices = new VertexPositionNormalTexture[36];

            // Front face.
            cubeVertices[0] = new VertexPositionNormalTexture(topLeftFront, frontNormal, textureTopLeft);
            cubeVertices[1] = new VertexPositionNormalTexture(bottomLeftFront, frontNormal, textureBottomLeft);
            cubeVertices[2] = new VertexPositionNormalTexture(topRightFront, frontNormal, textureTopRight);
            cubeVertices[3] = new VertexPositionNormalTexture(bottomLeftFront, frontNormal, textureBottomLeft);
            cubeVertices[4] = new VertexPositionNormalTexture(bottomRightFront, frontNormal, textureBottomRight);
            cubeVertices[5] = new VertexPositionNormalTexture(topRightFront, frontNormal, textureTopRight);

            // Back face.
            cubeVertices[6] = new VertexPositionNormalTexture(topLeftBack, backNormal, textureTopRight);
            cubeVertices[7] = new VertexPositionNormalTexture(topRightBack, backNormal, textureTopLeft);
            cubeVertices[8] = new VertexPositionNormalTexture(bottomLeftBack, backNormal, textureBottomRight);
            cubeVertices[9] = new VertexPositionNormalTexture(bottomLeftBack, backNormal, textureBottomRight);
            cubeVertices[10] = new VertexPositionNormalTexture(topRightBack, backNormal, textureTopLeft);
            cubeVertices[11] = new VertexPositionNormalTexture(bottomRightBack, backNormal, textureBottomLeft);

            // Top face.
            cubeVertices[12] = new VertexPositionNormalTexture(topLeftFront, topNormal, textureBottomLeft);
            cubeVertices[13] = new VertexPositionNormalTexture(topRightBack, topNormal, textureTopRight);
            cubeVertices[14] = new VertexPositionNormalTexture(topLeftBack, topNormal, textureTopLeft);
            cubeVertices[15] = new VertexPositionNormalTexture(topLeftFront, topNormal, textureBottomLeft);
            cubeVertices[16] = new VertexPositionNormalTexture(topRightFront, topNormal, textureBottomRight);
            cubeVertices[17] = new VertexPositionNormalTexture(topRightBack, topNormal, textureTopRight);

            // Bottom face.
            cubeVertices[18] = new VertexPositionNormalTexture(bottomLeftFront, bottomNormal, textureTopLeft);
            cubeVertices[19] = new VertexPositionNormalTexture(bottomLeftBack, bottomNormal, textureBottomLeft);
            cubeVertices[20] = new VertexPositionNormalTexture(bottomRightBack, bottomNormal, textureBottomRight);
            cubeVertices[21] = new VertexPositionNormalTexture(bottomLeftFront, bottomNormal, textureTopLeft);
            cubeVertices[22] = new VertexPositionNormalTexture(bottomRightBack, bottomNormal, textureBottomRight);
            cubeVertices[23] = new VertexPositionNormalTexture(bottomRightFront, bottomNormal, textureTopRight);

            // Left face.
            cubeVertices[24] = new VertexPositionNormalTexture(topLeftFront, leftNormal, textureTopRight);
            cubeVertices[25] = new VertexPositionNormalTexture(bottomLeftBack, leftNormal, textureBottomLeft);
            cubeVertices[26] = new VertexPositionNormalTexture(bottomLeftFront, leftNormal, textureBottomRight);
            cubeVertices[27] = new VertexPositionNormalTexture(topLeftBack, leftNormal, textureTopLeft);
            cubeVertices[28] = new VertexPositionNormalTexture(bottomLeftBack, leftNormal, textureBottomLeft);
            cubeVertices[29] = new VertexPositionNormalTexture(topLeftFront, leftNormal, textureTopRight);

            // Right face.
            cubeVertices[30] = new VertexPositionNormalTexture(topRightFront, rightNormal, textureTopLeft);
            cubeVertices[31] = new VertexPositionNormalTexture(bottomRightFront, rightNormal, textureBottomLeft);
            cubeVertices[32] = new VertexPositionNormalTexture(bottomRightBack, rightNormal, textureBottomRight);
            cubeVertices[33] = new VertexPositionNormalTexture(topRightBack, rightNormal, textureTopRight);
            cubeVertices[34] = new VertexPositionNormalTexture(topRightFront, rightNormal, textureTopLeft);
            cubeVertices[35] = new VertexPositionNormalTexture(bottomRightBack, rightNormal, textureBottomRight);

            vm._vertexBuffer = new VertexBuffer(vm.GraphicsDevice, vm._vertexDeclaration, cubeVertices.Length, BufferUsage.None);
            vm._vertexBuffer.SetData(cubeVertices);

            //var mouseState = _mouse.GetState();
            //lastScrollWheelValue = mouseState.ScrollWheelValue;
        }

        public override void OnScriptLoaded()
        {
            float tilt = MathHelper.ToRadians(0);  // 0 degree angle
                                                   // Use the world matrix to tilt the cube along x and y axes.
                                                   //_worldMatrix = Matrix.Identity; //.CreateRotationX(tilt) * Matrix.CreateRotationY(tilt);

            vm._basicEffect = new BasicEffect(vm.GraphicsDevice);
            //vm._basicEffect.EnableDefaultLighting();

            // primitive color
            vm._basicEffect.AmbientLightColor = Color.White.ToVector3();
            vm._basicEffect.SpecularColor = new Vector3(2.25f, 0.25f, 0.25f);
            vm._basicEffect.SpecularPower = 50.0f;
            //vm._basicEffect.Alpha = 1.0f;

            vm._basicEffect.LightingEnabled = true;
            if (vm._basicEffect.LightingEnabled)
            {
                vm._basicEffect.DirectionalLight0.Enabled = true; // enable each light individually
                if (vm._basicEffect.DirectionalLight0.Enabled)
                {
                    // x direction
                    vm._basicEffect.DirectionalLight0.DiffuseColor = new Vector3(1, 0, 0); // range is 0 to 1
                    vm._basicEffect.DirectionalLight0.Direction = Vector3.Normalize(new Vector3(-1, 0, 0));
                    // points from the light to the origin of the scene
                    vm._basicEffect.DirectionalLight0.SpecularColor = Vector3.One * 4;
                }

                vm._basicEffect.DirectionalLight1.Enabled = true;
                if (vm._basicEffect.DirectionalLight1.Enabled)
                {
                    // y direction
                    vm._basicEffect.DirectionalLight1.DiffuseColor = new Vector3(0, 0.75f, 0);
                    vm._basicEffect.DirectionalLight1.Direction = Vector3.Normalize(new Vector3(0, -1, 0));
                    vm._basicEffect.DirectionalLight1.SpecularColor = Vector3.One;
                }

                vm._basicEffect.DirectionalLight2.Enabled = true;
                if (vm._basicEffect.DirectionalLight2.Enabled)
                {
                    // z direction
                    vm._basicEffect.DirectionalLight2.DiffuseColor = new Vector3(0, 0, 0.5f);
                    vm._basicEffect.DirectionalLight2.Direction = Vector3.Normalize(new Vector3(0, 0, -1));
                    vm._basicEffect.DirectionalLight2.SpecularColor = Vector3.One;
                }
            }

            raster = new RasterizerState()
            {
                FillMode = FillMode.WireFrame,
                DepthBias = float.MaxValue/2 
            };
        }

        public void Update()
        {
            //The projection depends on viewport dimensions (aspect ratio).
            // Because WPF controls can be resized at any time (user resizes window)
            // we need to refresh the values each draw call, otherwise cube will look distorted to user
            vm._basicEffect.Projection = vm.camera._.vm.projectionMatrix;
            vm._basicEffect.View = vm.camera._.vm.viewMatrix;

            //vm._basicEffect.EnableDefaultLighting();

            //var mouseState = _mouse.GetState();
            //zPos += ((mouseState.ScrollWheelValue - lastScrollWheelValue) * (float)time.ElapsedGameTime.TotalMilliseconds * 0.0001f);
            //logger.WriteLine(zPos.ToString());

            //lastScrollWheelValue = mouseState.ScrollWheelValue;

            // Rotate cube around up-axis.
            // only update cube when the game is active
            //if (IsActive)
            //_rotation += Time.ElapsedMs / 50000 * MathHelper.TwoPi;
            vm._rotation += 0.02f;
        }

        public void Draw()
        {
            vm.GraphicsDevice.DepthStencilState = DepthStencilState.Default;
            vm.GraphicsDevice.RasterizerState = RasterizerState.CullCounterClockwise;
            vm.GraphicsDevice.SetVertexBuffer(vm._vertexBuffer);

            vm._basicEffect.DiffuseColor = Color.DarkGoldenrod.ToVector3();// new Vector3(1.0f, 1.0f, 1.0f);
            vm._basicEffect.World =
                Matrix.CreateRotationX(vm._rotation)
                * Matrix.CreateRotationY(vm._rotation)
                * Matrix.CreateTranslation(-0, 2f, vm.zPos)
                * vm._worldMatrix
                ;

            foreach (var pass in vm._basicEffect.CurrentTechnique.Passes)
            {
                pass.Apply();
                vm.GraphicsDevice.DrawPrimitives(PrimitiveType.TriangleList, 0, 12);
            }

            //------

            //vm.GraphicsDevice.DepthStencilState = DepthStencilState.Default;
            vm.GraphicsDevice.RasterizerState = raster;
            vm.GraphicsDevice.SetVertexBuffer(vm._vertexBuffer);

            vm._basicEffect.DiffuseColor = Color.Black.ToVector3();// new Vector3(1.0f, 1.0f, 1.0f);
            vm._basicEffect.World =
                Matrix.CreateRotationX(vm._rotation)
                * Matrix.CreateRotationY(vm._rotation)
                * Matrix.CreateTranslation(-0, 2f, vm.zPos)
                * vm._worldMatrix
                ;

            foreach (var pass in vm._basicEffect.CurrentTechnique.Passes)
            {
                pass.Apply();
                vm.GraphicsDevice.DrawPrimitives(PrimitiveType.TriangleList, 0, 12);
            }
        }
    }
}