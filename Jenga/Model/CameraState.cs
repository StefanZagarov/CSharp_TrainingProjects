namespace Model.State
{
    public class CameraState
    {
        public float XPos { get; set; }
        public float YPos { get; set; }
        public float ZPos { get; set; }

        public float XRot { get; set; }
        public float YRot { get; set; }
        public float ZRot { get; set; }

        public CameraState(float xPos, float yPos, float zPos, float xRot, float yRot, float zRot)
        {
            XPos = xPos;
            YPos = yPos;
            ZPos = zPos;
            XRot = xRot;
            YRot = yRot;
            ZRot = zRot;
        }
    }
}