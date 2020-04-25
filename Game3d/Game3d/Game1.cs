//using Game3d.Engine;
//using Microsoft.Xna.Framework;
//using Microsoft.Xna.Framework.Content;
//using Microsoft.Xna.Framework.Graphics;
//using Microsoft.Xna.Framework.Input;

//namespace Game3d
//{
//    public class Game1 : Game
//    {
//        private readonly GraphicsDeviceManager graphics;
//        private SimpleGame simpleGame;

//        //private BaseGameScript[] items;

//        public Game1()
//        {
//            graphics = new GraphicsDeviceManager(this);
//            Content.RootDirectory = "Content";
//        }
        
//        protected override void Initialize()
//        {
//            var startup = new Startup()
//            {
//                Device=GraphicsDevice,
//                Content = Content,
//                Logger = new ConsoleLogger()
//            };
//            startup.WireUpDependencies();
//            simpleGame = startup.mainGame;

//            //var liveGame = new DummyLiveGame()
//            //{
//            //    GraphicsDevice = GraphicsDevice,
//            //   // _mouse = new WpfMouse(null),
//            //   // _keyboard=new WpfKeyboard(null)
//            //};

//            //var logger = new ConsoleLogger();

//            //var mainCamera = (new MainCamera() { logger = logger }).CreateInstance() as Camera;
//            //var customEffect = (new CustomEffectInstance() { logger = logger }).CreateInstance() as CustomEffect;

//            //var cube = (new Cube1() { logger = logger }).CreateInstance() as CubeScript;
//            //var sphere = (new Sphere1() { logger = logger }).CreateInstance() as SphereScript;

//            //customEffect.SetGame(liveGame);
//            //cube.SetGame(liveGame);
//            //sphere.SetGame(liveGame);

//            //customEffect.OnContextSet();
//            //cube.OnContextSet();
//            //sphere.OnContextSet();

//            //cube.camera = mainCamera;
//            //cube.OnDependencyResolved(nameof(cube.camera), mainCamera);

//            //sphere.camera = mainCamera;
//            //sphere.OnDependencyResolved(nameof(sphere.camera), mainCamera);

//            //sphere.customEffect = customEffect;
//            //sphere.OnDependencyResolved(nameof(sphere.customEffect), customEffect);

//            //mainCamera.Initialise();
//            //customEffect.Initialise();
//            //cube.Initialise();
//            //sphere.Initialise();

//            //items = new BaseGameScript[] { customEffect, cube, sphere };

//            base.Initialize();
//        }
        
//        protected override void LoadContent()
//        {
//            simpleGame.DoLoadContent();
//        }
        
//        protected override void UnloadContent()
//        {
//        }
        
//        protected override void Update(GameTime gameTime)
//        {
//            Time.GameTime = gameTime;
//            simpleGame.DoUpdate();

//            //foreach (var item in items)
//            //{
//            //    item.Update(gameTime);
//            //}

//            base.Update(gameTime);
//        }

//        protected override void Draw(GameTime gameTime)
//        {
//            GraphicsDevice.Clear(Color.CornflowerBlue);

//            Time.GameTime = gameTime;
//            simpleGame.DoDraw();

//            //foreach (var item in items)
//            //{
//            //    item.Draw(gameTime);
//            //}

//            base.Draw(gameTime);
//        }
//    }
//}
