namespace ChristmasLightsKata.Model
{
    public interface ILight
    {
        int GetBrithness();
        void Toggle();
        void TurnOff();
        void TurnOn();
    }
}