using System.Collections.Generic;
using LightCycle.Game.Casting;


namespace LightCycle.Game.Scripting
{

    public class MoveActorsAction : Action{

        public MoveActorsAction(){}

         void Action.Execute(Cast cast, Script script){

            List<Actor> Actor_list = cast.GetAllActors();
            foreach (Actor actor in Actor_list){
                actor.MoveNext(1,1);
            }
        }
    }
}