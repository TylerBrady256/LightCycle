using LightCycle.Game.Casting;
using LightCycle.Game.Services;


namespace LightCycle.Game.Scripting
{
   
    public class ControlActorsAction2 : Action
    {
        private KeyboardService keyboardService;
        private Point direction = new Point(Constants.CELL_SIZE, 0);

       
        public ControlActorsAction2(KeyboardService keyboardService)
        {
            this.keyboardService = keyboardService;
        }

        /// <inheritdoc/>
        public void Execute(Cast cast, Script script)
        {
            // left
            if (keyboardService.IsKeyDown("j"))
            {
                direction = new Point(Constants.CELL_SIZE, 0);
            }

            // right
            if (keyboardService.IsKeyDown("l"))
            {
                direction = new Point(-Constants.CELL_SIZE, 0);
            }

            // up
            if (keyboardService.IsKeyDown("i"))
            {
                direction = new Point(0, Constants.CELL_SIZE);
            }

            // down
            if (keyboardService.IsKeyDown("k"))
            {
                direction = new Point(0, -Constants.CELL_SIZE);
            }

            Cycler_2 cycler2 = (Cycler_2)cast.GetFirstActor("cycler2");
            cycler2.TurnHead(direction);

        }
    }
}