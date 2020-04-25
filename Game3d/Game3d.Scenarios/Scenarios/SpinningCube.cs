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
//    public class SpinningCube : LiveProgramming.Live.ScenarioScriptMonogame
//    {
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
//            int n = 0;
//            Logger.WriteLine((n++).ToString());
//            var mainCamera = (new Camera());

//            Logger.WriteLine((n++).ToString());
//            //var cube1 = (dynamic)GetOrCreate("CubeScript", Logger, Device, Vector3.One);
//            var cube1 = (new CubeScript(Logger, Device, Vector3.One));
//            cube1.camera = mainCamera;
//            cube1.Initialise();

//            Logger.WriteLine((n++).ToString());
//            //var sphere = (new SphereScript(Logger, Device, Vector3.One));
//            //sphere.camera = mainCamera;
//            //sphere.Initialise();

//            Logger.WriteLine((n++).ToString());
//            var mainGame = (new SimpleGame(
//                // load content
//                (Action)(() =>
//                {
//                }),
//                // update
//                (Action)(() =>
//                {
//                    //sphere.Update();
//                    cube1.Update();
//                }),
//                // draw
//                (Action)(() =>
//                {
//                    //sphere.Draw();
//                    cube1.Draw();
//                })));

//            Logger.WriteLine((n++).ToString());
//            AttachGameToLiveWindowIfHaveNotAlready(mainGame);
//        }
//    }
//}
