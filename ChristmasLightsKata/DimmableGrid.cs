using ChristmasLightsKata.Model;

namespace ChristmasLightsKata
{
    public class DimmableGrid : GridBase
    {
        public DimmableGrid() : this(0, 0)
        {
        }

        public DimmableGrid(int width, int heigth) : base(width, heigth)
        {
        }

        protected override void InstanciateGrid()
        {
            for (int x = 0; x < _width; x++)
            {
                for (int y = 0; y < _height; y++)
                {
                    _grid[x, y] = new DimmableLight();
                }
            }
        }
    }
}
