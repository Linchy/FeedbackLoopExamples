using System;
using ImmediateUserInterface.Render;

namespace ImmediateUserInterface
{
//#if WINDOWS || LINUX
    /// <summary>
    /// The main class.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            using (var game1 = new Game1())
            {
                game1.Run();
            }
        }
    }
//#endif
}
