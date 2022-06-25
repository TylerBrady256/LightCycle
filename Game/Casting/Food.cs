using System;


namespace LightCycle.Game.Casting
{
    
    public class Food : Actor
    {
        private int points = 0;

        public Food()
        {
            SetText("@");
            SetColor(Constants.RED); 
            Reset();
        }

      
        public int GetPoints()
        {
            return points;
        }

        
        public void Reset()
        {
            Random random = new Random();
            points = random.Next(9);
            int x = random.Next(Constants.COLUMNS);
            int y = random.Next(Constants.ROWS);
            Point position = new Point(x, y);
            position = position.Scale(Constants.CELL_SIZE);
            SetPosition(position);
        }
    }
}