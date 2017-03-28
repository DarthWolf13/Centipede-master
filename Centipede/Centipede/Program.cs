using System;

namespace Centipede
{
#if WINDOWS || XBOX
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            using (Centipede game = new Centipede())
            {
                game.Run();
            }
        }
    }
#endif
}

