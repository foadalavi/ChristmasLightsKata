using ChristmasLightsKata.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChristmasLightsKata
{
    public abstract class GridBase
    {
        protected int _width;
        protected int _height;
        protected ILight[,] _grid;
        public GridBase(int width, int heigth) 
        {
            _width = width;
            _height = heigth;
            _grid = new ILight[width, heigth];
            InstanciateGrid();
        }

        public int CountLights()
        {
            return _width * _height;
        }

        public int CountLightsOn()
        {
            var count = 0;
            for (int x = 0; x < _width; x++)
            {
                for (int y = 0; y < _height; y++)
                {
                    count += _grid[x, y].GetBrithness();
                }
            }
            return count;
        }

        public void TurnOn(LightCoordinate startCoordination, LightCoordinate endCoordination)
        {
            Action<int, int> action =
                (x, y) =>
                {
                    _grid[x, y].TurnOn();
                };
            GridIteratorByCoordination(startCoordination, endCoordination, action);
        }

        public void TurnOff(LightCoordinate startCoordination, LightCoordinate endCoordination)
        {
            Action<int, int> action =
                (x, y) =>
                {
                    _grid[x, y].TurnOff();
                };
            GridIteratorByCoordination(startCoordination, endCoordination, action);
        }

        public void Toggle(LightCoordinate startCoordination, LightCoordinate endCoordination)
        {
            Action<int, int> action =
                (x, y) =>
                {
                    _grid[x, y].Toggle();
                };
            GridIteratorByCoordination(startCoordination, endCoordination, action);
        }

        protected abstract void InstanciateGrid();

        private void GridIteratorByCoordination(LightCoordinate startCoordination, LightCoordinate endCoordination, Action<int, int> action)
        {
            for (int x = startCoordination.X; x <= endCoordination.X; x++)
            {
                for (int y = startCoordination.Y; y <= endCoordination.Y; y++)
                {
                    action(x, y);
                }
            }
        }
    }
}
