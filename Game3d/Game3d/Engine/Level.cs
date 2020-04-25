//using Microsoft.Xna.Framework;
//using Microsoft.Xna.Framework.Graphics;
//using Microsoft.Xna.Framework.Input;
//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Game3d
//{
//    //using Game3d.Engine;

//    public class Level : BaseGameScript
//    {
//        public const int cellSize = 25;

//        public SpriteBatch spriteBatch;
//        public Texture2D whiteTex;
        
//        private FloorType[][] map;
//        private List<Point> path; 

//        private SpriteFont font;
//        private int frameCount;
//        private double elapsedMs;
//        private string fpsString = "";
         
//        public Level(ILogger logger)
//            : base(logger)
//        {

//        }

//        public override void Initialise()
//        {
//#if !LIVE
//            Content.RootDirectory = @"C:\Git\LiveProgramming\TestConsole\Game3d\Content\bin\Windows";
//#endif

//            spriteBatch = new SpriteBatch(GraphicsDevice);
//            whiteTex = new Texture2D(GraphicsDevice, 1, 1);
//            whiteTex.SetData(new Color[] { Color.White });

//            //logger.WriteLine($"content dir: {Path.GetFullPath(Content.RootDirectory)}");
//            font = Content.Load<SpriteFont>("defaultFont");

//            string mapString = @"
//W,W,W,W,W,W,W,W,W,W,W,W,W,W,W,W,W
//W, , , , , , , ,F, , , , , , , ,W
//W, , , , , , , ,F, , , , , , , ,W
//W, , , , , , , ,F, , , , , , , ,W
//W, , , , ,F,F,F,F,F,F,F, , , , ,W
//W, , , , ,F, , , , , ,F, , , , ,W
//W, , , , ,F, , , , , ,F, , , , ,W
//W, , , , ,F, , , , , ,F, , , , ,W
//W, , , , ,F, , , , , ,F, , , , ,W
//W, , , , ,F,F,F,F,F,F,F, , , , ,W
//W, , , , , , , ,F, , , , , , , ,W
//W, , , , , , , ,F, , , , , , , ,W
//W, , , , , , , ,F, , , , , , , ,W
//W,W,W,W,W,W,W,W,W,W,W,W,W,W,W,W,W";

//            map = mapString.Trim()
//                .Split(new[] { "\r\n" }, StringSplitOptions.None)
//                .Select(row => row.Split(',')
//                    .Select(cell => ParseFloorType(cell))
//                    .ToArray())
//                .ToArray(); 

//            // create the tiles map
//            var tilesmap = mapString.Trim()
//                .Split(new[] { "\r\n" }, StringSplitOptions.None)
//                .Select(row => row.Split(',')
//                    .Select(cell => ParseTileCost(cell))
//                    .ToArray())
//                .ToArray();

//            // set values here....
//            // every float in the array represent the cost of passing the tile at that position.
//            // use 0.0f for blocking tiles.

//            //logger.WriteLine("v");
//            // create a grid
//            var grid = new Grid(map[0].Length, map.Length, tilesmap);

//            // create source and target points
//            var _from = new Point(3, 3);
//            var _to = new Point(7, 10); 

//            // get path
//            // path will either be a list of Points (x, y), or an empty list if no path is found.
//            path = Pathfinding.FindPath(grid, _from, _to);
//            //logger.WriteLine(string.Join("->", path));

//            Vis.PauseAndDisplay(d =>
//            {
//                spriteBatch.Begin();
//                spriteBatch.Draw(whiteTex, new Rectangle(_from.X * cellSize, _from.Y * cellSize, cellSize, cellSize), Color.LimeGreen);
//                spriteBatch.Draw(whiteTex, new Rectangle(3 * cellSize, 3 * cellSize, cellSize, cellSize), Color.Gold);
//                spriteBatch.Draw(whiteTex, new Rectangle(_to.X * cellSize, _to.Y * cellSize, cellSize, cellSize), Color.Orange);
//                spriteBatch.End();
//            });
//        }
         
//        private float ParseTileCost(string cell)
//        {
//            switch (cell)
//            {
//                case "F":
//                    return 0;
//                case "W":
//                    return 1;
//                default:
//                    return 2;
//            }
//        } 

//        private FloorType ParseFloorType(string cell)
//        {
//            switch(cell)
//            {
//                case "F":
//                    return FloorType.Floor;
//                case "W":
//                    return FloorType.Wall;
//                default:
//                    return FloorType.None;
//            }
//        }

//        public override void Update() 
//        {
//            //Vis.PauseAndDisplay(Vis2);

//            //elapsedMs += Time.ElapsedMs;//.ElapsedGameTime.TotalMilliseconds;
//            frameCount++;
//            if (elapsedMs >= 1000)
//            {
//                fpsString = frameCount + " FPS";
//                frameCount = 0;
//                elapsedMs = 0;
//            }
//        }

//        private void Vis2(GraphicsDevice d)
//        {
//            spriteBatch.Begin();
//            spriteBatch.Draw(whiteTex, new Rectangle(3 * cellSize, 3 * cellSize, cellSize, cellSize), Color.Gold);
//            spriteBatch.End();
//        }

//        public override void Draw()
//        { 
//            spriteBatch.Begin();

//            int windowWidth = GraphicsDevice.Viewport.Width;
//            int windowHeight = GraphicsDevice.Viewport.Height;


//            for (int y = 0; y < map.Length; y++)
//            {
//                for (int x = 0; x < map[y].Length; x++)
//                {
//                    var cell = map[y][x];
//                    if (cell == FloorType.Wall)
//                    {
//                        var brush = Color.Red;
//                        spriteBatch.Draw(whiteTex, new Rectangle(x * cellSize, y * cellSize, cellSize, cellSize), brush);
//                    }
//                    else if (cell == FloorType.Floor)
//                    {
//                        var brush = Color.Blue;
//                        spriteBatch.Draw(whiteTex, new Rectangle(x * cellSize, y * cellSize, cellSize, cellSize), brush);
//                    }
//                }
//            }

//            for (int i = 0; i < path.Count; i++)
//            {
//                var alpha = 0.5f + (((float)(i+1) / path.Count) * 0.5f);
//                var brush = Color.Green;// * alpha;
//                spriteBatch.Draw(whiteTex, new Rectangle(path[i].X * cellSize, path[i].Y * cellSize, cellSize, cellSize), brush);
//                //if (i == 9)
//                //    break;
//            }

//            spriteBatch.DrawString(font, fpsString, new Vector2(5,5), Color.White);
//            spriteBatch.End();
//        }
//    }

//    public enum FloorType
//    {
//        None,
//        Wall = 1,
//        Floor = 2
//    }
//}
