//using Microsoft.Xna.Framework;
//using Microsoft.Xna.Framework.Content;
//using Microsoft.Xna.Framework.Graphics;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Game3d.Scenarios
//{
//    public class Startup : ScenarioScriptMonogame
//    {
//        public SimpleGame mainGame;

//        /// <summary>
//        /// - This is run whenever a dep is changed.
//        /// - Deps are found via this method, first time they are registered.
//        /// - As this will run again, but without instantiating everything, need
//        ///   to ensure this really is just 'wiring up' and not running logic that will overwrite.
//        ///   
//        /// - Add custom command to .cs files, so can right click and 'set scenario'
//        ///     - on load of project, load in all types, so ready to go
//        ///     - then run this wire up, and we are ready
//        ///     - Program.cs can start any scenario then, via a ScenarioBootstrapperGame3d.cs, that
//        ///       can setup initial graphics device and content
//        ///       
//        /// - on compile this class - find (new ...) expressions in brackets, and replace with GetOrCreate<T>(name, args)
//        /// </summary>
//        public override void WireUpDependencies()
//        {
//            var mainCamera = (new Camera());

//            var cube1 = (new CubeScript(Logger, Device, Vector3.One));
//            cube1.camera = mainCamera;

//            mainGame = (new SimpleGame(
//                // load content
//                (Action)(() =>
//                {
//                }),
//                // update
//                () =>
//                {
//                    cube1.Update();
//                },
//                // draw
//                () =>
//                {
//                    cube1.Draw();
//                }));

//            //AttachGameToLiveWindowIfHaveNotAlready(mainGame);
//        }
//    }
//}
