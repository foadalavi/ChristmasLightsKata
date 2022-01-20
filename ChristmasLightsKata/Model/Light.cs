namespace ChristmasLightsKata.Model
{
    public class Light : ILight
    {
        private bool _isLightOn;

        public int GetBrithness()
        {
            if (_isLightOn == true)
            {
                return 1;
            }
            return 0;
        }

        public void TurnOn()
        {
            _isLightOn = true;
        }

        public void TurnOff()
        {
            _isLightOn = false;
        }

        public void Toggle()
        {
            _isLightOn ^= true;
        }
    }
}
