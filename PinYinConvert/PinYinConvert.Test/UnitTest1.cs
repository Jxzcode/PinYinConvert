using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PinYinConvert.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            string str = "�й�";
            var pinYin = PinYinConverterHelp.ChinessToPingYinPascal(str);
            //Output �����ZhongGuo;

            var totalPingYin = PinYinConverterHelp.GetTotalPingYin(str);
            var totalPingYinPascal = PinYinConverterHelp.GetTotalPingYinPascal(str);
        }
    }
}
