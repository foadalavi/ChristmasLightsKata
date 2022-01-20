using ChristmasLightsKata.Model;
using NUnit.Framework;
using System.Collections.Generic;

namespace ChristmasLightsKata.Test
{
    public class Tests
    {
        Grid _christmasGrid;

        [SetUp]
        public void Setup()
        {
            _christmasGrid = new Grid(1000, 1000);
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

        [TestCase(0, 0, 0, 0, 999999)]
        [TestCase(0, 0, 9, 9, 999900)]
        public void GivenChristmasGridWhenThenOnAllLightAndTurnedOffSomeLightsShouldHaveExpectedLightsOn(int StartCoordinationX, int StartCoordinationY, int EndCoordinationX, int EndCoordinationY, int ExpectedResult)
        {
            _christmasGrid.TurnOn(new LightCoordinate(0, 0), new LightCoordinate(999, 999));
            _christmasGrid.TurnOff(new LightCoordinate(StartCoordinationX, StartCoordinationY), new LightCoordinate(EndCoordinationX, EndCoordinationY));
            Assert.AreEqual(ExpectedResult, _christmasGrid.CountLightsOn());
        }

        [TestCase(0, 0, 999, 999, 1000000)]
        [TestCase(0, 0, 9, 9, 100)]
        public void GivenChristmasGridWhenSomeLightsTurnedOnTwiceShouldHaveTheSameNumberLightsOn(int StartCoordinationX, int StartCoordinationY, int EndCoordinationX, int EndCoordinationY, int ExpectedResult)
        {
            _christmasGrid.TurnOn(new LightCoordinate(StartCoordinationX, StartCoordinationY), new LightCoordinate(EndCoordinationX, EndCoordinationY));
            _christmasGrid.TurnOn(new LightCoordinate(StartCoordinationX, StartCoordinationY), new LightCoordinate(EndCoordinationX, EndCoordinationY));
            Assert.AreEqual(ExpectedResult, _christmasGrid.CountLightsOn());
        }

        [TestCase(0, 0, 0, 0, 999999)]
        [TestCase(0, 0, 9, 9, 999900)]
        public void GivenTurnedOnChristmasGridWhenThenOnAllLightAndTurnedOffSomeLightsTwiceShouldHaveTheSameLightsOn(int StartCoordinationX, int StartCoordinationY, int EndCoordinationX, int EndCoordinationY, int ExpectedResult)
        {
            _christmasGrid.TurnOn(new LightCoordinate(0, 0), new LightCoordinate(999, 999));
            _christmasGrid.TurnOff(new LightCoordinate(StartCoordinationX, StartCoordinationY), new LightCoordinate(EndCoordinationX, EndCoordinationY));
            _christmasGrid.TurnOff(new LightCoordinate(StartCoordinationX, StartCoordinationY), new LightCoordinate(EndCoordinationX, EndCoordinationY));
            Assert.AreEqual(ExpectedResult, _christmasGrid.CountLightsOn());
        }

        public static IEnumerable<TestCaseData> OverLapGridsValueProvider()
        {
            yield return new TestCaseData(new LightGridCordination(0, 0, 9, 9), new LightGridCordination(5, 5, 14, 14));
        }

        [Test, TestCaseSource("OverLapGridsValueProvider")]
        public void GivenTurnedOnChristmasGridWhenTurnonTwoTimesWithOverlapShouldHaveCorrectLightsOn(LightGridCordination firstCoordination, LightGridCordination secondCoordination)
        {
            _christmasGrid.TurnOn(firstCoordination.StartCoordination, firstCoordination.EndCoordination);
            _christmasGrid.TurnOn(secondCoordination.StartCoordination, secondCoordination.EndCoordination);
            Assert.AreEqual(175, _christmasGrid.CountLightsOn());
        }


        [Test, TestCaseSource("OverLapGridsValueProvider")]
        public void GivenTurnedOnChristmasGridWhenTurnonAllLightsAndTurnoffTwoTimesWithOverlapShouldHaveCorrectLightsOn(LightGridCordination firstCoordination, LightGridCordination secondCoordination)
        {
            _christmasGrid.TurnOn(new LightCoordinate(0, 0), new LightCoordinate(999, 999));
            _christmasGrid.TurnOff(firstCoordination.StartCoordination, firstCoordination.EndCoordination);
            _christmasGrid.TurnOff(secondCoordination.StartCoordination, secondCoordination.EndCoordination);
            Assert.AreEqual(999825, _christmasGrid.CountLightsOn());
        }

        public static IEnumerable<TestCaseData> LightToggleValueProvider1()
        {
            yield return new TestCaseData(new LightGridCordination(0, 0, 0, 9), 10);
        }

        [Test, TestCaseSource("LightToggleValueProvider1")]
        public void GivenTurnedOnChristmasGridWhenThenOnSomeLightAndToggleSomeLightsShouldHaveExpectedLightsOn(LightGridCordination toggleCoordination, int ExpectedResult)
        {
            _christmasGrid.Toggle(toggleCoordination.StartCoordination, toggleCoordination.EndCoordination);
            Assert.AreEqual(ExpectedResult, _christmasGrid.CountLightsOn());
        }


        public static IEnumerable<TestCaseData> LightToggleValueProvider2()
        {
            yield return new TestCaseData(new LightGridCordination(0, 0, 0, 19), new LightGridCordination(0, 0, 0, 2), 17);
        }

        [Test, TestCaseSource("LightToggleValueProvider2")]
        public void GivenTurnedOnChristmasGridWhenThenOnSomeLightAndToggleSomeLightsShouldHaveExpectedLightsOn(LightGridCordination firstCoordination, LightGridCordination secondCoordination, int ExpectedResult)
        {
            _christmasGrid.TurnOn(firstCoordination.StartCoordination, firstCoordination.EndCoordination);
            _christmasGrid.Toggle(secondCoordination.StartCoordination, secondCoordination.EndCoordination);
            Assert.AreEqual(ExpectedResult, _christmasGrid.CountLightsOn());
        }
    }
}