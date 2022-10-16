using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UpdateNumberApp;

namespace UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestCalculateTotal()
        {
            // Arrange
            var numUpdate = new UpdateNumber(0);

            // Act & Assert
            var ret = numUpdate.CalculateTotal(5);
            Assert.AreEqual(5, numUpdate.Number);

            ret = numUpdate.CalculateTotal(9);
            Assert.AreEqual(14, numUpdate.Number);

            ret = numUpdate.CalculateTotal(130);
            Assert.AreEqual(144, numUpdate.Number);

            ret = numUpdate.CalculateTotal(20);
            Assert.AreEqual(12, numUpdate.Number);

            ret = numUpdate.CalculateTotal(1);
            Assert.AreEqual(13, numUpdate.Number);
        }

        public void TestCalculateTotalInvalid()
        {
            var numUpdate = new UpdateNumber(int.MaxValue);

            var ret = numUpdate.CalculateTotal(int.MaxValue);
            Assert.AreEqual(0, numUpdate.Number);
        }

        public void TestReadNumberInvalid()
        {
            // Arrange
            var numUpdate = new UpdateNumber(0);
            var invalidName = "@#$%%.xxx";

            // Act
            var bRet = numUpdate.ReadNumber(invalidName);

            // Assert
            Assert.AreEqual(0, numUpdate.Number);
            Assert.IsFalse(bRet);
        }

        public void TestReadNumber()
        {
            // Arrange
            var numUpdate = new UpdateNumber(-100);
            var validName = "test.txt";

            // Act
            var bRet = numUpdate.WriteNumber(validName);
            Assert.IsTrue(bRet);

            bRet = numUpdate.ReadNumber(validName);
            Assert.IsTrue(bRet);

            // Assert
            Assert.AreEqual(-100, numUpdate.Number);
        }

        public void TestWriteNumber()
        {
            // Arrange
            var numUpdate = new UpdateNumber(-100);
            var validName = "test.txt";

            // Act
            var bRet = numUpdate.WriteNumber(validName);

            // Assert
            Assert.IsTrue(bRet);
            Assert.AreEqual(-100, numUpdate.Number);
        }

        public void TestWriteNumberInvalid()
        {
            // Arrange
            var numUpdate = new UpdateNumber(-100);
            var validName = "@#$%%";

            // Act
            var bRet = numUpdate.WriteNumber(validName);

            // Assert
            Assert.IsFalse(bRet);
        }

        public void TestUpdateNumber()
        {
            // Arrange
            var numUpdate = new UpdateNumber(0);
            var validName = "testUpdate.txt";
            if (File.Exists(validName))
                File.Delete(validName);

            // Act 1.
            numUpdate.ReadNumber(validName);
            Assert.AreEqual(0, numUpdate.Number);

            numUpdate.CalculateTotal(123);
            Assert.AreEqual(123, numUpdate.Number);

            var bRet = numUpdate.WriteNumber(validName);
            Assert.IsTrue(bRet);
            Assert.IsTrue(File.Exists(validName));

            // Act 2.
            numUpdate.ReadNumber(validName);
            Assert.AreEqual(123, numUpdate.Number);

            numUpdate.CalculateTotal(456);
            Assert.AreEqual(427, numUpdate.Number);

            bRet = numUpdate.WriteNumber(validName);
            Assert.IsTrue(bRet);

            numUpdate.ReadNumber(validName);
            Assert.AreEqual(427, numUpdate.Number);
        }
    }
}