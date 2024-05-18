namespace TowerDefense.Utils
{
    public class ScreenResolutionChangedEventArgs
    {
        public int Width { get; private set; }
        public int Height { get; private set; }

        public ScreenResolutionChangedEventArgs(int width, int height)
        {
            Width = width;
            Height = height;
        }
    }
}