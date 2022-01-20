using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChristmasLightsKata.Model
{
    public class DimmableLight : ILight
    {
        private int _brightness;

        public int GetBrithness()
        {
            return _brightness;
        }

        public void TurnOn()
        {

            _brightness++;
        }

        public void TurnOff()
        {
            if (_brightness > 0)
                _brightness--;
        }

        public void Toggle()
        {
            _brightness += 2;
        }
    }
}
