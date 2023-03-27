using Newtonsoft.Json;

namespace Model.State
{
    public class BrickState
    {
        public float XPos { get; set; }
        public float YPos { get; set; }
        public float ZPos { get; set; }

        public float XRot { get; set; }
        public float YRot { get; set; }
        public float ZRot { get; set; }
        public float WRot { get; set; }

        public float[] BrickColor { get; set; }

        [JsonConstructor]
        public BrickState(float xPos, float yPos, float zPos, float xRot, float yRot, float zRot, float wRot, float[] brickColor)
        {
            XPos = xPos;
            YPos = yPos;
            ZPos = zPos;
            XRot = xRot;
            YRot = yRot;
            ZRot = zRot;
            WRot = wRot;
            BrickColor = brickColor;
        }
    }
}