using Live.Core;
using System.Collections.Generic;

namespace Game3d.Scenarios.State
{
    public class StateGameLoop
    {
        //[MoveToRootAndCompileOnce]
        public class Model
        {
        }

        //[MoveToRootAndCompileOnce]
        public class ViewModel
        {
            public readonly Model Model;
            //public readonly LiveImGuiRenderer Renderer;

            public readonly RT<Camera> Camera;
            public readonly RT<Cube> Cube;

            public ViewModel()
            {
                Model = new Model();
                //Renderer = new LiveImGuiRenderer();
                Camera = RT.Create(new Camera());
                Cube = RT.Create(new Cube());
            }
        }
    }
}