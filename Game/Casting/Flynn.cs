using System;
using System.Collections.Generic;
using System.Linq;

namespace LightCycle.Game.Casting
{
  
    public class Flynn : Actor
    {
        private List<Actor> segments = new List<Actor>();

        
        public Flynn()
        {
            PrepareBody();
        }

       
        public List<Actor> GetBody()
        {
            return new List<Actor>(segments.Skip(1).ToArray());
        }

        
        public Actor GetHead()
        {
            return segments[0];
        }

        
        public List<Actor> GetSegments()
        {
            return segments;
        }

      
        public void GrowTail(int numberOfSegments)
        {
            for (int i = 0; i < numberOfSegments; i++)
            {
                Actor tail = segments.Last<Actor>();
                Point velocity = segments[0].GetVelocity();
                Point offset = velocity.Reverse();
                Point position = segments[0].GetPosition().Add(offset);

                Actor segment = new Actor();
                segment.SetPosition(position);
                segment.SetText("=");
                segment.SetColor(Constants.BLUE);
                segments.Add(segment);
            }
        }

        
        public override void MoveNext(int direction_X, int direction_Y)
        {
            

            segments[0].MoveNext(1,1);// This is needed to move the actor.
            
                Actor trailing = segments[0];//head
                Actor previous = segments[0];
                Point velocity = previous.GetVelocity();
                trailing.SetVelocity(velocity);
        }

        
        public void TurnHead(Point direction)
        {
            segments[0].SetVelocity(direction);
        }

       
        private void PrepareBody()
        {
            int x = Constants.MAX_X/3;
            int y = Constants.MAX_Y / 2;
            

                Point position = new Point(x * Constants.CELL_SIZE, y);
                Point velocity = new Point(1 * Constants.CELL_SIZE, 0);
                string text = "8";
                Color color = Constants.BLUE;

                Actor segment = new Actor();
                segment.SetPosition(position);
                segment.SetVelocity(velocity);
                segment.SetText(text);
                segment.SetColor(color);
                segments.Add(segment);
        }
    }
}