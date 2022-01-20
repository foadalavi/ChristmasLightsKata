namespace ChristmasLightsKata.Model
{
    public class LightGridCordination
    {
        public LightGridCordination(int StartCoordinationX, int StartCoordinationY, int EndCoordinationX, int EndCoordinationY)
        {
            this.StartCoordination = new LightCoordinate(StartCoordinationX, StartCoordinationY);
            this.EndCoordination = new LightCoordinate(EndCoordinationX, EndCoordinationY);
        }

        public LightCoordinate StartCoordination { get; set; }
        public LightCoordinate EndCoordination { get; set; }
    }
}
