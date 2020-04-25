//using System;
//using System.Collections.Generic;
//using Microsoft.Xna.Framework;
//using Microsoft.Xna.Framework.Graphics;
//using Microsoft.Xna.Framework.Input;

//namespace Game3d
//{		
//    public class SphereScript //: BaseGameScript
//    {
//    	[Dep]
//        public Camera camera;

//        [Dep]
//        public CustomEffect customEffect;

//        //private BasicEffect _basicEffect;
           
//        private float _rotation;
                
//        private int lastScrollWheelValue;
//        private float zPos = 0;

//		private  SpherePrimitive primitive;

//        private readonly GraphicsDevice GraphicsDevice;

//        public SphereScript(ILogger logger, GraphicsDevice graphicsDevice, Vector3 scale)
//        {
//            this.GraphicsDevice = graphicsDevice;

//            const string fxFilepath = @"C:\Git\LiveProgramming\TestConsole\Game3d\Shaders\CustomShader.fx";


//            customEffect = new CustomEffect(logger, graphicsDevice, fxFilepath);

//        }

//    //public override void OnContextSet()
//    //{
//    //        // _basicEffect = new BasicEffect(GraphicsDevice);
//    //}

//    //     public override void OnDependencyResolved(string name, object instance)
//    //     {
//    //         logger.WriteLine("[dep] " + name);

//    //         if (name == nameof(camera))
//    //     	{
//    //         	camera.Initialise();    
//    //         	//_basicEffect.View = camera.viewMatrix;
//    //     	}
//    //         else if (name == nameof(customEffect))
//    //         {
//    //             //customEffect.Initialise();
//    //             //customEffect.effect.Parameters["WorldViewProjection"].SetValue
//    //         }
//    //     }

//    public void Initialise()
//        {
//            camera.Initialise();
//            //_basicEffect.View = camera.viewMatrix;

//            //logger.WriteLine("Loaded");

//            //_basicEffect.World = Matrix.Identity;

//            //// primitive color
//            //_basicEffect.AmbientLightColor = new Vector3(0.1f, 0.1f, 0.1f);
//            //_basicEffect.DiffuseColor = new Vector3(1.0f, 1.0f, 1.0f);
//            //_basicEffect.SpecularColor = new Vector3(0.25f, 0.25f, 0.25f);
//            //_basicEffect.SpecularPower = 10.0f;
//            //_basicEffect.Alpha = 1.0f;

//            //_basicEffect.LightingEnabled = true;
//            //if (_basicEffect.LightingEnabled)
//            //{
//            //    _basicEffect.DirectionalLight0.Enabled = true; // enable each light individually
//            //    if (_basicEffect.DirectionalLight0.Enabled)
//            //    {
//            //        // x direction
//            //        _basicEffect.DirectionalLight0.DiffuseColor = new Vector3(1, 0, 0); // range is 0 to 1
//            //        _basicEffect.DirectionalLight0.Direction = Vector3.Normalize(new Vector3(-1, 0, 0));
//            //        // points from the light to the origin of the scene
//            //        _basicEffect.DirectionalLight0.SpecularColor = Vector3.One * 0.1f;
//            //    }

//            //    _basicEffect.DirectionalLight1.Enabled = true;
//            //    if (_basicEffect.DirectionalLight1.Enabled)
//            //    {
//            //         //y direction
//            //        _basicEffect.DirectionalLight1.DiffuseColor = new Vector3(0, 0.75f, 0);
//            //        _basicEffect.DirectionalLight1.Direction = Vector3.Normalize(new Vector3(0, -1, 0));
//            //        _basicEffect.DirectionalLight1.SpecularColor = Vector3.One * 0.1f;
//            //    }

//            //    _basicEffect.DirectionalLight2.Enabled = true;
//            //    if (_basicEffect.DirectionalLight2.Enabled)
//            //    {
//            //        // z direction
//            //        _basicEffect.DirectionalLight2.DiffuseColor = new Vector3(0, 0, 0.5f);
//            //        _basicEffect.DirectionalLight2.Direction = Vector3.Normalize(new Vector3(0, 0, -1));
//            //        _basicEffect.DirectionalLight2.SpecularColor = Vector3.One * 0.1f; 
//            //    }
//            //}

//            //_basicEffect.PreferPerPixelLighting = true;

//            primitive = new SpherePrimitive(GraphicsDevice, 50, 20);
            
//            //var mouseState = _mouse.GetState();
//            //lastScrollWheelValue = mouseState.ScrollWheelValue;
//        } 
              
         
//        public void Update()
//        {        
//            //The projection depends on viewport dimensions (aspect ratio).
//            // Because WPF controls can be resized at any time (user resizes window)
//            // we need to refresh the values each draw call, otherwise cube will look distorted to user
//            camera.RefreshProjection(GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height);            
//            //_basicEffect.Projection = camera.projectionMatrix;

            
//            //var mouseState = _mouse.GetState();
//            //zPos += ((mouseState.ScrollWheelValue - lastScrollWheelValue) * (float)time.ElapsedGameTime.TotalMilliseconds * 0.0001f);
//            //logger.WriteLine(zPos.ToString());
             
//            //lastScrollWheelValue = mouseState.ScrollWheelValue;
            
//            // Rotate cube around up-axis.
//            // only update cube when the game is active
//            //if (IsActive)
//           //     _rotation += (float)time.ElapsedGameTime.TotalMilliseconds / 100000 * MathHelper.TwoPi;
//        }
        
//        public void Draw()
//        {
//            //var mouseState = _mouse.GetState();
//            //GraphicsDevice.Clear(mouseState.LeftButton == ButtonState.Pressed ? Color.Red : Color.Gray);
//            GraphicsDevice.DepthStencilState = DepthStencilState.Default;
//            // GraphicsDevice.RasterizerState = RasterizerState.CullNone;

//            //GraphicsDevice.SetVertexBuffer(_vertexBuffer);
//            //logger.WriteLine(_basicEffect.Projection.ToString());
//            var world =
//                Matrix.CreateRotationY(_rotation)
//                * Matrix.CreateTranslation(0, 5, 0)
//                * Matrix.CreateScale(0.1f)
//                //* _worldMatrix
//                ;

//            customEffect.effect.Parameters["WorldViewProjection"].SetValue(world * camera.viewMatrix * camera.projectionMatrix);
           
//            //_basicEffect.LightingEnabled = true;
//            //GraphicsDevice.RasterizerState = new RasterizerState()
//            //{
//            //    FillMode = FillMode.WireFrame,
//            //    CullMode = CullMode.None
//            //};

//            //primitive.Draw(_basicEffect);

//            //_basicEffect.LightingEnabled = false;
//            //GraphicsDevice.RasterizerState = new RasterizerState()
//            //{
//            //    FillMode = FillMode.WireFrame,
//            //    //CullMode = CullMode.None
//            //    DepthBias = -0.001f
//            //};
//            //logger.WriteLine("test");
//            //logger.WriteLine(customEffect.effect.CurrentTechnique.Name);

//            foreach (EffectPass effectPass in customEffect.effect.CurrentTechnique.Passes)
//            {
//               // logger.WriteLine(effectPass.Name);
                
//            }
//            primitive.Draw( customEffect.effect);
//        }
//    }
    
//    public class SpherePrimitive : GeometricPrimitive
//    {
//        /// <summary>
//        /// Constructs a new sphere primitive, using default settings.
//        /// </summary>
//        public SpherePrimitive(GraphicsDevice graphicsDevice)
//            : this(graphicsDevice, 1, 16)
//        {
//        }


//        /// <summary>
//        /// Constructs a new sphere primitive,
//        /// with the specified size and tessellation level.
//        /// </summary>
//        public SpherePrimitive(GraphicsDevice graphicsDevice, float diameter, int tessellation)
//        {
//            if (tessellation < 3)
//                throw new ArgumentOutOfRangeException("tessellation");

//            int verticalSegments = tessellation;
//            int horizontalSegments = tessellation * 2; 

//            float radius = diameter / 2;

//            // Start with a single vertex at the bottom of the sphere.
//            AddVertex(Vector3.Down * radius, Vector3.Down);

//            // Create rings of vertices at progressively higher latitudes.
//            for (int i = 0; i < verticalSegments - 1; i++)
//            {
//                float latitude = ((i + 1) * MathHelper.Pi / verticalSegments) - MathHelper.PiOver2;

//                float dy = (float)Math.Sin(latitude);
//                float dxz = (float)Math.Cos(latitude);

//                // Create a single ring of vertices at this latitude.
//                for (int j = 0; j < horizontalSegments; j++)
//                {
//                    float longitude = j * MathHelper.TwoPi / horizontalSegments;

//                    float dx = (float)Math.Cos(longitude) * dxz;
//                    float dz = (float)Math.Sin(longitude) * dxz;

//                    Vector3 normal = new Vector3(dx, dy, dz);

//                    AddVertex(normal * radius, normal);
//                }
//            }

//            // Finish with a single vertex at the top of the sphere.
//            AddVertex(Vector3.Up * radius, Vector3.Up);

//            // Create a fan connecting the bottom vertex to the bottom latitude ring.
//            for (int i = 0; i < horizontalSegments; i++)
//            {
//                AddIndex(0);
//                AddIndex(1 + (i + 1) % horizontalSegments);
//                AddIndex(1 + i);
//            }

//            // Fill the sphere body with triangles joining each pair of latitude rings.
//            for (int i = 0; i < verticalSegments - 2; i++)
//            {
//                for (int j = 0; j < horizontalSegments; j++)
//                {
//                    int nextI = i + 1;
//                    int nextJ = (j + 1) % horizontalSegments;

//                    AddIndex(1 + i * horizontalSegments + j);
//                    AddIndex(1 + i * horizontalSegments + nextJ);
//                    AddIndex(1 + nextI * horizontalSegments + j);

//                    AddIndex(1 + i * horizontalSegments + nextJ);
//                    AddIndex(1 + nextI * horizontalSegments + nextJ);
//                    AddIndex(1 + nextI * horizontalSegments + j);
//                }
//            }

//            // Create a fan connecting the top vertex to the top latitude ring.
//            for (int i = 0; i < horizontalSegments; i++)
//            {
//                AddIndex(CurrentVertex - 1);
//                AddIndex(CurrentVertex - 2 - (i + 1) % horizontalSegments);
//                AddIndex(CurrentVertex - 2 - i);
//            }

//            InitializePrimitive(graphicsDevice);
//        }
//    }
    
//    public abstract class GeometricPrimitive : IDisposable
//    {
//        #region Fields


//        // During the process of constructing a primitive model, vertex
//        // and index data is stored on the CPU in these managed lists.
//        List<VertexPositionNormal> vertices = new List<VertexPositionNormal>();
//        List<ushort> indices = new List<ushort>();


//        // Once all the geometry has been specified, the InitializePrimitive
//        // method copies the vertex and index data into these buffers, which
//        // store it on the GPU ready for efficient rendering.
//        VertexBuffer vertexBuffer;
//        IndexBuffer indexBuffer;
//        BasicEffect basicEffect;


//        #endregion

//        #region Initialization


//        /// <summary>
//        /// Adds a new vertex to the primitive model. This should only be called
//        /// during the initialization process, before InitializePrimitive.
//        /// </summary>
//        protected void AddVertex(Vector3 position, Vector3 normal)
//        {
//            vertices.Add(new VertexPositionNormal(position, Vector3.Normalize(normal)));
//        }


//        /// <summary>
//        /// Adds a new index to the primitive model. This should only be called
//        /// during the initialization process, before InitializePrimitive.
//        /// </summary>
//        protected void AddIndex(int index)
//        {
//            if (index > ushort.MaxValue)
//                throw new ArgumentOutOfRangeException("index");

//            indices.Add((ushort)index);
//        }


//        /// <summary>
//        /// Queries the index of the current vertex. This starts at
//        /// zero, and increments every time AddVertex is called.
//        /// </summary>
//        protected int CurrentVertex
//        {
//            get { return vertices.Count; }
//        }


//        /// <summary>
//        /// Once all the geometry has been specified by calling AddVertex and AddIndex,
//        /// this method copies the vertex and index data into GPU format buffers, ready
//        /// for efficient rendering.
//        protected void InitializePrimitive(GraphicsDevice graphicsDevice)
//        {
//            // Create a vertex declaration, describing the format of our vertex data.

//            // Create a vertex buffer, and copy our vertex data into it.
//            vertexBuffer = new VertexBuffer(graphicsDevice,
//                                            typeof(VertexPositionNormal),
//                                            vertices.Count, BufferUsage.None);

//            vertexBuffer.SetData(vertices.ToArray());

//            // Create an index buffer, and copy our index data into it.
//            indexBuffer = new IndexBuffer(graphicsDevice, IndexElementSize.SixteenBits,
//                                          indices.Count, BufferUsage.None);

//            indexBuffer.SetData(indices.ToArray());

//            // Create a BasicEffect, which will be used to render the primitive.
//            basicEffect = new BasicEffect(graphicsDevice);

//            basicEffect.EnableDefaultLighting();
//            basicEffect.PreferPerPixelLighting = false;
//        }


//        /// <summary>
//        /// Finalizer.
//        /// </summary>
//        ~GeometricPrimitive()
//        {
//            Dispose(false);
//        }


//        /// <summary>
//        /// Frees resources used by this object.
//        /// </summary>
//        public void Dispose()
//        {
//            Dispose(true);
//            GC.SuppressFinalize(this);
//        }


//        /// <summary>
//        /// Frees resources used by this object.
//        /// </summary>
//        protected virtual void Dispose(bool disposing)
//        {
//            if (disposing)
//            { 
//                if (vertexBuffer != null)
//                    vertexBuffer.Dispose();

//                if (indexBuffer != null)
//                    indexBuffer.Dispose();

//                if (basicEffect != null)
//                    basicEffect.Dispose();
//            }
//        } 


//        #endregion 

//        #region Draw


//        /// <summary>
//        /// Draws the primitive model, using the specified effect. Unlike the other
//        /// Draw overload where you just specify the world/view/projection matrices
//        /// and color, this method does not set any renderstates, so you must make
//        /// sure all states are set to sensible values before you call it.
//        /// </summary>
//        public void Draw(Effect effect)
//        {
//            GraphicsDevice graphicsDevice = effect.GraphicsDevice;

//            // Set our vertex declaration, vertex buffer, and index buffer.
//            graphicsDevice.SetVertexBuffer(vertexBuffer);

//            graphicsDevice.Indices = indexBuffer;            


//            foreach (EffectPass effectPass in effect.CurrentTechnique.Passes)
//            {
//                effectPass.Apply();

//                int primitiveCount = indices.Count / 3;

//                graphicsDevice.DrawIndexedPrimitives(PrimitiveType.TriangleList, 0, 0,
//                                                     vertices.Count, 0, primitiveCount);

//            }
//        }


//        /// <summary>
//        /// Draws the primitive model, using a BasicEffect shader with default
//        /// lighting. Unlike the other Draw overload where you specify a custom
//        /// effect, this method sets important renderstates to sensible values
//        /// for 3D model rendering, so you do not need to set these states before
//        /// you call it.
//        /// </summary>
//        public void Draw(Matrix world, Matrix view, Matrix projection, Color color)
//        {
//            // Set BasicEffect parameters.
//            basicEffect.World = world;
//            basicEffect.View = view;
//            basicEffect.Projection = projection;
//            basicEffect.DiffuseColor = color.ToVector3();
//            basicEffect.Alpha = color.A / 255.0f;

//            GraphicsDevice device = basicEffect.GraphicsDevice;
//            device.DepthStencilState = DepthStencilState.Default;

//            if (color.A < 255)
//            {
//                // Set renderstates for alpha blended rendering.
//                device.BlendState = BlendState.AlphaBlend;
//            }
//            else
//            {
//                // Set renderstates for opaque rendering.
//                device.BlendState = BlendState.Opaque;
//            }

//            // Draw the model, using BasicEffect.
//            Draw(basicEffect);
//        }


//        #endregion
//    } 
    
//    public struct VertexPositionNormal : IVertexType
//    {
//        public Vector3 Position;
//        public Vector3 Normal;


//        /// <summary>
//        /// Constructor.
//        /// </summary>
//        public VertexPositionNormal(Vector3 position, Vector3 normal)
//        {
//            Position = position;
//            Normal = normal;
//        } 

//        /// <summary>
//        /// A VertexDeclaration object, which contains information about the vertex
//        /// elements contained within this struct.
//        /// </summary>
//        public static readonly VertexDeclaration VertexDeclaration = new VertexDeclaration
//        (
//            new VertexElement(0, VertexElementFormat.Vector3, VertexElementUsage.Position, 0),
//            new VertexElement(12, VertexElementFormat.Vector3, VertexElementUsage.Normal, 0)
//        );

//        VertexDeclaration IVertexType.VertexDeclaration
//        {
//            get { return VertexPositionNormal.VertexDeclaration; }
//        }

//    }
//}