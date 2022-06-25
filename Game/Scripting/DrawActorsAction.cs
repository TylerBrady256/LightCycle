using System.Collections.Generic;
using LightCycle.Game.Casting;
using LightCycle.Game.Services;


namespace LightCycle.Game.Scripting
{
    
    public class DrawActorsAction : Action
    {
        private VideoService videoService;

        
        public DrawActorsAction(VideoService videoService)
        {
            this.videoService = videoService;
        }

       
        public void Execute(Cast cast, Script script)
        {
            Flynn flynn = (Flynn)cast.GetFirstActor("flynn");
            List<Actor> segments = flynn.GetSegments();

            Cycler_2 cycler2 = (Cycler_2)cast.GetFirstActor("cycler2");
            List<Actor> segments_2 = cycler2.GetSegments();// probably not working
            
            Actor score = cast.GetFirstActor("score");
            Actor food = cast.GetFirstActor("food");
            List<Actor> messages = cast.GetActors("messages");
            
            videoService.ClearBuffer();
            videoService.DrawActors(segments);
            
            videoService.DrawActors(segments_2);
            videoService.DrawActors(messages);
            videoService.FlushBuffer();
        }
    }
}