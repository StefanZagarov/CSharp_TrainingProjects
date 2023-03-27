using System;
using System.Collections.Generic;

namespace Model.State
{
    [System.Serializable]
    public class GameState
    {
        public List<BrickState> BrickStates { get; set; }
        public CameraState CameraPosition { get; set; }
        public string AccountName { get; set; }
        public string TimeOfSave { get; set; }
        public bool IsGameOver { get; set; }
    }
}