using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Graf_ed.Form1;

namespace Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Test_AddMethod()
        {
            Coordinates bm = new Coordinates();
            double res = bm.Add(10, 10);
            Assert.AreEqual(res, 20);
        }
        [TestMethod]
        public void Test_SubstractMethod()
        {
            Coordinates bm = new Coordinates();
            double res = bm.Substract(10, 10);
            Assert.AreEqual(res, 0);
        }
        [TestMethod]
        public void Test_DivideMethod()
        {
            Coordinates bm = new Coordinates();
            double res = bm.divide(10, 5);
            Assert.AreEqual(res, 2);
        }
    }
}
