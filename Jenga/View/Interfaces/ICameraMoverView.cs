namespace View.Interfaces
{
    public interface ICameraMoverView
    {
        public bool IsMouseDown { get; set; }
        void MouseOrbit();
        void Zoom();
        void Pan();
    }
}