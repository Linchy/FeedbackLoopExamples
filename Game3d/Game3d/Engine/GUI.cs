//using Microsoft.Xna.Framework;
//using Microsoft.Xna.Framework.Graphics;
//using Microsoft.Xna.Framework.Input;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Game3d
//{
//    public class GUI : BaseGameScript
//    {
//        public SpriteBatch spriteBatch;
//        public Texture2D whiteTex;

//        public float scrollPercent = 0.4f;

//        public GUI(ILogger logger)
//            :base(logger)
//        {

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

//            int windowWidth = GraphicsDevice.Viewport.Width;
//            int windowHeight = GraphicsDevice.Viewport.Height;

//            var area = new Rectangle(5, windowHeight - 35, windowWidth - 10, 30);
//            var brush = (_mouse.GetState().LeftButton == ButtonState.Pressed ? Color.Red : Color.Red);
//            spriteBatch.Draw(whiteTex, area, brush);

//            var thumbArea = area;
//            thumbArea.X += (int)(thumbArea.Width * scrollPercent);
//            thumbArea.Width = 10;
//            thumbArea.X -= 5;

//            spriteBatch.Draw(whiteTex, thumbArea, Color.Orange);

//            spriteBatch.End();
//        }
//    }
//}
