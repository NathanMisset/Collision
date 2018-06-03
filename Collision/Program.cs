using System;

namespace CollisionBalls {
#if WINDOWS || LINUX
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            using (var game = new CollisionBalls())
                game.Run();
        }
    }
#endif
}

