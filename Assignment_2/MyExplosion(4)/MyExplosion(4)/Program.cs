using ExplosionSimulator;
using System;

namespace MyExplosion_4_
{
#if WINDOWS || LINUX
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
            using (var game = new My_Explosion())
                game.Run();
        }
    }
#endif
}
