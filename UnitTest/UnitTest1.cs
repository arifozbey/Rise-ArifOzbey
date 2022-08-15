using System;
using Xunit;

namespace UnitTest
{
    public class UnitTest1
    {
      
        [Fact]
        public void ilktest()
        {
            // Arrange
            int number1 = 5;
            int number2 = 15;
            Calculator sut = new Calculator();
            // Act
            int result = sut.Addition(number1, number2);
            // Assert
            Assert.Equal(20, result);
        }
    }
    public class Calculator
    {
        public int Addition(int n1, int n2) => n1 + n2;
        public int Multiplication(int n1, int n2) => n1 * n2;
        public double Division(double n1, double n2) => n1 / n2;
    }
}
    

