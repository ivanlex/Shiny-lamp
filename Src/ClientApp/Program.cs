using ClientApp.ClientSource;

namespace ClientApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using var game = new GameMain();
            game.Run();
        }
    }
}
