using ChristmasLightsKata.Model;
using System;

namespace ChristmasLightsKata
{
    public class Grid
    {
        int _width;
        int _height;
        bool[,] _grid;

        public Grid() : this(0, 0)
        {
        }

        public Grid(int width, int heigth)
        {
            _width = width;
            _height = heigth;
            _grid = new bool[width, heigth];
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
                    if (_grid[x, y] == true)
                    {
                        count++;
                    }
                }
            }
            return count;
        }

        public void TurnOn(LightCoordinate startCoordination, LightCoordinate endCoordination)
        {
            Action<int, int> action =
                (x, y) =>
                {
                    _grid[x, y] = true;
                };
            GridIterator(startCoordination, endCoordination, action);
        }

        public void TurnOff(LightCoordinate startCoordination, LightCoordinate endCoordination)
        {
            Action<int, int> action =
                (x, y) =>
                {
                    _grid[x, y] = false;
                };
            GridIterator(startCoordination, endCoordination, action);
        }

        public void Toggle(LightCoordinate startCoordination, LightCoordinate endCoordination)
        {
            Action<int, int> action =
                (x, y) =>
                    {
                        _grid[x, y] ^= true;
                    };
            GridIterator(startCoordination, endCoordination, action);
        }

        public void GridIterator(LightCoordinate startCoordination, LightCoordinate endCoordination, Action<int, int> action)
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
