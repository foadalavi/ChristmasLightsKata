using NUnit.Framework;
using System.Collections.Generic;

namespace ChristmasLightsKata.Test
{
    public class Tests
    {

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestMethod()
        {
            Assert.Pass();
        }

        [TestCase(0, 0, 0)]
        [TestCase(1, 5, 6)]
        [TestCase(10, 20, 30)]
        public void ParameterizedTestExample(int number1, int number2, int expectedResult)
        {
            var result = (number1 + number2);
            Assert.AreEqual(expectedResult, result);
        }
    }
}