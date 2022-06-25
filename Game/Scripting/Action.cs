using LightCycle.Game.Casting;


namespace LightCycle.Game.Scripting 
{
    
    public interface Action
    {
       
        public void Execute(Cast cast, Script script);
    }
}