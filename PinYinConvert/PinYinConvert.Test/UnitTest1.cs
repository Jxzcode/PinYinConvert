using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PinYinConvert.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            string str = "ÖÐ¹ú";
            var pinYin = PinYinConverterHelp.ChinessToPingYinPascal(str);
            //Output Êä³ö£ºZhongGuo;

            var totalPingYin = PinYinConverterHelp.GetTotalPingYin(str);
            var totalPingYinPascal = PinYinConverterHelp.GetTotalPingYinPascal(str);
        }
    }
}
