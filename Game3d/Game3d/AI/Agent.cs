//using Microsoft.Xna.Framework;
//using Microsoft.Xna.Framework.Graphics;
//using Microsoft.Xna.Framework.Input;
//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Game3d
//{
//    public class Agent : BaseGameScript
//    {
//        public SpriteBatch spriteBatch;
//        public Texture2D whiteTex;

//        public Vector2 Position;
//        //public Point CellCoords {  get { return new Point(
//        //    (int)(Position.X / Level.cellSize), 
//        //    (int)(Position.Y / Level.cellSize)); } }

//        public Agent(ILogger logger)
//            : base(logger)
//        {
//            Position = new Vector2(5, 5);
//        }

//        public override void Initialise()
//        {
//            spriteBatch = new SpriteBatch(GraphicsDevice);
//            whiteTex = new Texture2D(GraphicsDevice, 1, 1);
//            whiteTex.SetData(new Color[] { Color.White });
//        }

//        public override void Update()
//        {
//        }

//        public override void Draw()
//        {
//            spriteBatch.Begin();

//            float size = 10;
//            float halfSize = size / 2;

//            var area = new Rectangle(
//                (int)(Position.X - halfSize),
//                (int)(Position.Y - halfSize),
//                (int)size,
//                (int)size);
//            spriteBatch.Draw(whiteTex, area, Color.Green);

//            spriteBatch.End();
//        }
//    }
//}
