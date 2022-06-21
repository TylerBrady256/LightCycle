using System;
using System.Collections.Generic;
using System.Linq;

namespace Unit05.Game.Casting
{
    /// <summary>
    /// <para>A long limbless reptile.</para>
    /// <para>The responsibility of Snake is to move itself.</para>
    /// </summary>
    public class Cycler_2 : Actor
    {
        private List<Actor> segments = new List<Actor>();

        /// <summary>
        /// Constructs a new instance of a Snake.
        /// </summary>
        public Cycler_2()
        {
            PrepareBody();
        }

        /// <summary>
        /// Gets the snake's body segments.
        /// </summary>
        /// <returns>The body segments in a List.</returns>
        public List<Actor> GetBody()
        {
            return new List<Actor>(segments.Skip(1).ToArray());
        }

        /// <summary>
        /// Gets the snake's head segment.
        /// </summary>
        /// <returns>The head segment as an instance of Actor.</returns>
        public Actor GetHead()
        {
            return segments[0];
        }

        /// <summary>
        /// Gets the snake's segments (including the head).
        /// </summary>
        /// <returns>A list of snake segments as instances of Actors.</returns>
        public List<Actor> GetSegments()
        {
            return segments;
        }

        /// <summary>
        /// Grows the snake's tail by the given number of segments.
        /// </summary>
        /// <param name="numberOfSegments">The number of segments to grow.</param>
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
                segment.SetColor(Constants.GREEN);
                segments.Add(segment);
            }
        }

        /// <inheritdoc/>
        public override void MoveNext()
        {
            // foreach (Actor segment in segments)//Moves each actor to the next position starting with the head and going down the tail.
            // {
            //     segment.MoveNext();
            // }

            // for (int i = segments.Count - 1; i > 0; i--)
            // {
            //     Actor trailing = segments[i];
            //     Actor previous = segments[i - 1];
            //     Point velocity = previous.GetVelocity();
            //     trailing.SetVelocity(velocity);
            // }

            segments[0].MoveNext();// This is needed to move the actor.
            
                Actor trailing = segments[0];//head
                Actor previous = segments[0];
                Point velocity = previous.GetVelocity();
                trailing.SetVelocity(velocity);
        }

        /// <summary>
        /// Turns the head of the snake in the given direction.
        /// </summary>
        /// <param name="velocity">The given direction.</param>
        public void TurnHead(Point direction)
        {
            segments[0].SetVelocity(direction);
        }

        /// <summary>
        /// Prepares the snake body for moving.
        /// </summary>
        private void PrepareBody()
        {
            int x = Constants.MAX_X / 2;
            int y = Constants.MAX_Y / 2;

             Point position = new Point(x * Constants.CELL_SIZE + 200, y);
                Point velocity = new Point(1 * Constants.CELL_SIZE, 0);
                string text = "8";
                Color color = Constants.RED;

                Actor segment = new Actor();
                segment.SetPosition(position);
                segment.SetVelocity(velocity);
                segment.SetText(text);
                segment.SetColor(color);
                segments.Add(segment);
        }
    }
}