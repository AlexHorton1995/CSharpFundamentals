using MainProjectApplication.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestNewArithmetic()
        {
            var expected = new ArithmeticClass();
            Assert.IsInstanceOfType(expected, typeof(ArithmeticClass));
        }

        [TestMethod]
        public void TestAdd()
        {
            var instance = new ArithmeticClass();
            int num1 = 5;
            int num2 = 5;
            int expected = 10;
            var result = instance.Add(num1, num2);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestSubtract()
        {
            var instance = new ArithmeticClass();
            int num1 = 10;
            int num2 = 5;
            int expected = 5;
            var result = instance.Subtract(num1, num2);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestMultiply()
        {
            var instance = new ArithmeticClass();
            int num1 = 5;
            int num2 = 5;
            int expected = 25;
            var result = instance.Multiply(num1, num2);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestDivide()
        {
            var instance = new ArithmeticClass();
            int num1 = 5;
            int num2 = 5;
            int expected = 1;
            var result = instance.Divide(num1, num2);

            Assert.AreEqual(expected, result);
        }
    }
}
