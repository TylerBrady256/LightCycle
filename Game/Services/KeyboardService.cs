using System.Collections.Generic;
using Raylib_cs;
using LightCycle.Game.Casting;


namespace LightCycle.Game.Services
{
 
    public class KeyboardService
    {
        private Dictionary<string, KeyboardKey> keys
                = new Dictionary<string, KeyboardKey>();

        
        public KeyboardService()
        {
            keys["w"] = KeyboardKey.KEY_W;
            keys["a"] = KeyboardKey.KEY_A;
            keys["s"] = KeyboardKey.KEY_S;
            keys["d"] = KeyboardKey.KEY_D;
            keys["i"] = KeyboardKey.KEY_I;
            keys["j"] = KeyboardKey.KEY_J;
            keys["k"] = KeyboardKey.KEY_K;
            keys["l"] = KeyboardKey.KEY_L;
        }

        
        public bool IsKeyDown(string key)
        {
            KeyboardKey raylibKey = keys[key.ToLower()];
            return Raylib.IsKeyDown(raylibKey);
        }

      
        public bool IsKeyUp(string key)
        {
            KeyboardKey raylibKey = keys[key.ToLower()];
            return Raylib.IsKeyUp(raylibKey);
        }


        public bool toggleONE = true;
        public bool lightCycleToggleSpace()
        {
            if (Raylib.IsKeyDown(KeyboardKey.KEY_SPACE))
            {
                this.toggleONE = false;
            }
            else if (Raylib.IsKeyUp(KeyboardKey.KEY_SPACE))
            {
                this.toggleONE = true;
            }
            return this.toggleONE;
        }


        public bool toggleTWO = true;
        public bool lightCycleToggleLEFTShift()
        {
            if (Raylib.IsKeyDown(KeyboardKey.KEY_LEFT_SHIFT))
            {
                this.toggleTWO = false;
            }
            else if (Raylib.IsKeyUp(KeyboardKey.KEY_LEFT_SHIFT))
            {
                this.toggleTWO = true;
            }
            return this.toggleTWO;
        }


    }
}