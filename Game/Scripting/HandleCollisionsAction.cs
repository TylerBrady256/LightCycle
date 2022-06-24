using System;
using System.Collections.Generic;
using System.Data;
using Unit05.Game.Casting;
using Unit05.Game.Services;


namespace Unit05.Game.Scripting
{
    /// <summary>
    /// <para>An update action that handles interactions between the actors.</para>
    /// <para>
    /// The responsibility of HandleCollisionsAction is to handle the situation when the snake 
    /// collides with the food, or the snake collides with its segments, or the game is over.
    /// </para>
    /// </summary>
    public class HandleCollisionsAction : Action
    {
        private bool play_2_win = false;
        private bool play_1_win = false;

        /// <summary>
        /// Constructs a new instance of HandleCollisionsAction.
        /// </summary>
        public HandleCollisionsAction()
        {
        }

        /// <inheritdoc/>
        public void Execute(Cast cast, Script script)
        {
            if (play_1_win == false && play_2_win == false)
            {
                HandleFoodCollisions(cast);
                HandleSegmentCollisions(cast);
                HandleGameOver(cast);
            }
        }

        /// <summary>
        /// Updates the score nd moves the food if the snake collides with it.
        /// </summary>
        /// <param name="cast">The cast of actors.</param>
        private void HandleFoodCollisions(Cast cast)
        {
            Snake snake = (Snake)cast.GetFirstActor("snake");
            Cycler_2 cycler2 = (Cycler_2)cast.GetFirstActor("cycler2");
            // Score score = (Score)cast.GetFirstActor("score");
            Food food = (Food)cast.GetFirstActor("food");
            
            int points = food.GetPoints();

            KeyboardService key  = new KeyboardService();
            bool PlayerONETrail = key.lightCycleToggleLEFTShift();   // Change Keyboard service  
            bool PlayerTWOTrail = key.lightCycleToggleSpace();  
    
            if (PlayerONETrail == true){
                snake.GrowTail(1);
            }    
            if (PlayerTWOTrail == true){ 
                cycler2.GrowTail(1);
            }
        }

        /// <summary>
        /// Sets the game over flag if the snake collides with one of its segments.
        /// </summary>
        /// <param name="cast">The cast of actors.</param>
        private void HandleSegmentCollisions(Cast cast)
        {
            Snake snake = (Snake)cast.GetFirstActor("snake");
            Cycler_2 cycler2 = (Cycler_2)cast.GetFirstActor("cycler2");

            Actor head = snake.GetHead();
            Actor head_2 = cycler2.GetHead();
            
            List<Actor> body = snake.GetBody();
            List<Actor> body_2 = cycler2.GetBody();

            

            foreach (Actor segment in body)
            {
                if (segment.GetPosition().Equals(head.GetPosition()))
                {
                    play_2_win = true;
                }
                if (segment.GetPosition().Equals(head_2.GetPosition())){
                    play_1_win = true;
                }
            }
            foreach (Actor segment in body_2)
            {
                if (segment.GetPosition().Equals(head.GetPosition()))
                {
                    play_2_win = true;
                }
                if (segment.GetPosition().Equals(head_2.GetPosition())){
                    play_1_win = true;
                }
                int counter = 0;
                foreach(Actor segments in body)
                {
                    if (segment.GetPosition().Equals(segments.GetPosition()))
                    {
                        //play_2_win=true;
                       segment.SetColor(Constants.GREEN);
                       segments.SetColor(Constants.GREEN);
                       segment.SetText("#"); 
                       segments.SetText("#");
                       head.SetColor(Constants.RED);
                       head_2.SetColor(Constants.RED);
                       counter++;
                    }
                    else
                    {
                      head.SetColor(Constants.BLUE);
                       head_2.SetColor(Constants.ORANGE);  
                    }
                    if (counter == 3)
                    {
                        play_2_win = true;
                    }
                }
            }
            
        }

        private void HandleGameOver(Cast cast)
        {
            if (play_1_win == true || play_2_win == true)
            {
                Snake snake = (Snake)cast.GetFirstActor("snake");
                Cycler_2 cycler2 = (Cycler_2)cast.GetFirstActor("cycler2");
                List<Actor> segments = snake.GetSegments();
                List<Actor> segments_2 = cycler2.GetSegments();
                Food food = (Food)cast.GetFirstActor("food");

                // create a "game over" message
                int x = Constants.MAX_X / 2;
                int y = Constants.MAX_Y / 2;
                Point position = new Point(x, y);

                Actor message = new Actor();
                message.SetPosition(position);
                cast.AddActor("messages", message);



                if (play_1_win){
                    message.SetText("Player 1 Wins!");
                    message.SetColor(Constants.BLUE);
                    foreach (Actor segment in segments_2)
                    {
                        segment.SetColor(Constants.WHITE);
                    }
                food.SetColor(Constants.WHITE);
                }
                else if (play_2_win){
                    message.SetText("Player 2 Wins!");
                    message.SetColor(Constants.ORANGE);
                    foreach (Actor segment in segments)
                    {
                        segment.SetColor(Constants.WHITE);
                    }
                }
            }
        }

    }
}