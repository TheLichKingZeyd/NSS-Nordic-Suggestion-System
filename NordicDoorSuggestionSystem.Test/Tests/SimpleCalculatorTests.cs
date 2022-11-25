using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NordicDoorSuggestionSystem.Test.CodeToTest;

namespace NordicDoorSuggestionSystem.Test.Tests
{
    public class SimpleCalculatorTests
    {
        [Fact]
        public void AddTwoPositiveIntegers()
        {
            //Arrange
            int a = 1;
            int b = 4;
            int expected = 5;

            //Act
            SimpleCalculator calc = new SimpleCalculator();
            int result = calc.AddTwoNumbers(a, b);

            //Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void SubtractTwoPositiveIntegers()
        {
            //Arrange
            int a = 9;
            int b = 4;
            int expected = 5;

            //Act
            SimpleCalculator calc = new SimpleCalculator();
            int result = calc.SubtractTwoNumbers(a, b);

            //Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void DivdeZero()
        {
            //Arrange
            float a = 9;
            float b = 0;
            float expected = 0;

            //Act
            SimpleCalculator calc = new SimpleCalculator();
            float result = calc.DivideAByB(a, b);

            //Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void MultiplyTwoNegativeNumbers()
        {
            //Arrange
            float a =-5;
            float b = -4;
            float expected = 20;

            //Act
            SimpleCalculator calc = new SimpleCalculator();
            float result = calc.MultiplyTwoNumbers(a, b);

            //Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void MultiplyTwoPositiveNumber()
        {
            //Arrange
            float a = 20;
            float b = 40;
            float expected = 800;

            //Act
            SimpleCalculator calc = new SimpleCalculator();
            float result = calc.MultiplyTwoNumbers(a, b);

            //Assert
            Assert.Equal(expected, result);
        }
    }
}
