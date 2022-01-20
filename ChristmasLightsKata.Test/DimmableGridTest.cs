using ChristmasLightsKata.Model;
using NUnit.Framework;
using System.Collections.Generic;

namespace ChristmasLightsKata.Test
{
    public class DimmableGridTest
    {
        GridBase _christmasGrid;

        [SetUp]
        public void Setup()
        {
            _christmasGrid = new DimmableGrid(1000, 1000);
        }

        [Test]
        public void GivenGridWhenInitializedItShouldHaveZeroLights()
        {
            var grid = new Grid();
            Assert.AreEqual(0, grid.CountLights());
        }

        [Test]
        public void GivenChristmasGridWhenInitializedItShouldHave1000000lnLights()
        {
            Assert.AreEqual(1000000, _christmasGrid.CountLights());
        }

        [Test]
        public void GivenChristmasGridWhenInitializedShouldAllLightsBeOff()
        {
            Assert.AreEqual(0, _christmasGrid.CountLightsOn());
        }

        [TestCase(0, 0, 999, 999, 1000000)]
        [TestCase(0, 0, 9, 9, 100)]
        public void GivenChristmasGridWhenSomeLightsTurnedOnShouldHaveExpectedLightsOn(int StartCoordinationX, int StartCoordinationY, int EndCoordinationX, int EndCoordinationY, int ExpectedResult)
        {
            _christmasGrid.TurnOn(new LightCoordinate(StartCoordinationX, StartCoordinationY), new LightCoordinate(EndCoordinationX, EndCoordinationY));
            Assert.AreEqual(ExpectedResult, _christmasGrid.CountLightsOn());
        }

        [TestCase(0, 0, 999, 999, 3000000)]
        [TestCase(0, 0, 9, 9, 300)]
        public void GivenChristmasGridWhenSomeLightsTurnedOnThriceShouldHaveTheSameNumberLightsOn(int StartCoordinationX, int StartCoordinationY, int EndCoordinationX, int EndCoordinationY, int ExpectedResult)
        {
            _christmasGrid.TurnOn(new LightCoordinate(StartCoordinationX, StartCoordinationY), new LightCoordinate(EndCoordinationX, EndCoordinationY));
            _christmasGrid.TurnOn(new LightCoordinate(StartCoordinationX, StartCoordinationY), new LightCoordinate(EndCoordinationX, EndCoordinationY));
            _christmasGrid.TurnOn(new LightCoordinate(StartCoordinationX, StartCoordinationY), new LightCoordinate(EndCoordinationX, EndCoordinationY));
            Assert.AreEqual(ExpectedResult, _christmasGrid.CountLightsOn());
        }

        [TestCase(0, 0, 999, 999, 3000000)]
        [TestCase(0, 0, 9, 9, 300)]
        public void GivenChristmasGridWhenSomeLightsTurnedOnThriceAndTurnOffOneShouldHaveTheSameNumberLightsOn(int StartCoordinationX, int StartCoordinationY, int EndCoordinationX, int EndCoordinationY, int ExpectedResult)
        {
            _christmasGrid.TurnOn(new LightCoordinate(StartCoordinationX, StartCoordinationY), new LightCoordinate(EndCoordinationX, EndCoordinationY));
            _christmasGrid.TurnOn(new LightCoordinate(StartCoordinationX, StartCoordinationY), new LightCoordinate(EndCoordinationX, EndCoordinationY));
            _christmasGrid.TurnOn(new LightCoordinate(StartCoordinationX, StartCoordinationY), new LightCoordinate(EndCoordinationX, EndCoordinationY));
            Assert.AreEqual(ExpectedResult, _christmasGrid.CountLightsOn());
        }

        [Test]
        public void GivenChristmasGridWhenThenOnAllLightThriceAndTurnedOffOneLightShouldHave2999999LightsOn()
        {
            _christmasGrid.TurnOn(new LightCoordinate(0, 0), new LightCoordinate(999, 999));
            _christmasGrid.TurnOn(new LightCoordinate(0, 0), new LightCoordinate(999, 999));
            _christmasGrid.TurnOn(new LightCoordinate(0, 0), new LightCoordinate(999, 999));
            _christmasGrid.TurnOff(new LightCoordinate(0, 0), new LightCoordinate(0, 0));
            Assert.AreEqual(2999999, _christmasGrid.CountLightsOn());
        }

        [Test]
        public void GivenChristmasGridWhenTurnedOffOneLightShouldHaveZeroLightsOn()
        {
            _christmasGrid.TurnOff(new LightCoordinate(0, 0), new LightCoordinate(0, 0));
            Assert.AreEqual(0, _christmasGrid.CountLightsOn());
        }

        [Test]
        public void GivenChristmasGridWhenToggleAllLightsShouldHave2000000LightsOn()
        {
            _christmasGrid.Toggle(new LightCoordinate(0, 0), new LightCoordinate(999, 999));
            Assert.AreEqual(2000000, _christmasGrid.CountLightsOn());
        }
    }
}