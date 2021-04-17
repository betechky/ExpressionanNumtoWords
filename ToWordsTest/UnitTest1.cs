using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ToWordsTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            string toSend = "004";

            string res = Program.PartToWords(toSend);

            string exRes = "four";

            Assert.AreEqual(exRes, res);
        }
        [TestMethod]
        public void TestMethod2()
        {
            string toSend = "127";
            string exRes = "seven";

            string actualRes = Program.PartToWords(toSend);

            Assert.AreEqual(exRes, actualRes);
        }
    }
}
