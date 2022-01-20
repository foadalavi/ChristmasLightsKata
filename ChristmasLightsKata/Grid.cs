﻿using ChristmasLightsKata.Model;
using System;

namespace ChristmasLightsKata
{
    public class Grid : GridBase
    {
        public Grid() : this(0, 0)
        {
        }

        public Grid(int width, int heigth):base(width, heigth)
        {
        }

        protected override void InstanciateGrid()
        {
            for (int x = 0; x < _width; x++)
            {
                for (int y = 0; y < _height; y++)
                {
                    _grid[x, y] = new Light();
                }
            }
        }
    }
}
