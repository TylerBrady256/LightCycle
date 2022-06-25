using LightCycle.Game.Casting;
using LightCycle.Game.Directing;
using LightCycle.Game.Scripting;
using LightCycle.Game.Services;


namespace LightCycle
{
    
    class Program
    {
    
        static void Main(string[] args)
        {
            // create the cast
            Cast cast = new Cast();
            cast.AddActor("food", new Food());
            cast.AddActor("flynn", new Flynn());
            cast.AddActor("cycler2", new Cycler_2());

            // create the services
            KeyboardService keyboardService = new KeyboardService();
            VideoService videoService = new VideoService(false);
           
            // create the script
            Script script = new Script();
            script.AddAction("input", new ControlActorsAction(keyboardService));
            script.AddAction("input", new ControlActorsAction2(keyboardService));
            script.AddAction("update", new MoveActorsAction());
            script.AddAction("update", new HandleCollisionsAction());
            script.AddAction("output", new DrawActorsAction(videoService));

            // start the game
            Director director = new Director(videoService);
            director.StartGame(cast, script);
        }
    }
}