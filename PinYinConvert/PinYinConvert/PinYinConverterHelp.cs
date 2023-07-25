using Microsoft.International.Converters.PinYinConverter;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace PinYinConvert
{
    public class PinYinConverterHelp
    {
        public static PingYinModel GetTotalPingYin(string str)
        {
            var chs = str.ToCharArray();
            //记录每个汉字的全拼
            Dictionary<int, List<string>> totalPingYins = new Dictionary<int, List<string>>();
            for (int i = 0; i < chs.Length; i++)
            {
                var pinyins = new List<string>();
                var ch = chs[i];
                //是否是有效的汉字
                if (ChineseChar.IsValidChar(ch))
                {
                    ChineseChar cc = new ChineseChar(ch);
                    pinyins = cc.Pinyins.Where(p => !string.IsNullOrWhiteSpace(p)).ToList();
                }
                else
                {
                    pinyins.Add(ch.ToString());
                }

                //去除声调，转小写
                pinyins = pinyins.ConvertAll(p => Regex.Replace(p, @"\d", "").ToLower());
                //去重
                pinyins = pinyins.Where(p => !string.IsNullOrWhiteSpace(p)).Distinct().ToList();
                if (pinyins.Any())
                {
                    totalPingYins[i] = pinyins;
                }
            }
            PingYinModel result = new PingYinModel();
            foreach (var pinyins in totalPingYins)
            {
                var items = pinyins.Value;
                if (result.TotalPingYin.Count <= 0)
                {
                    result.TotalPingYin = items;
                    result.FirstPingYin = items.ConvertAll(p => p.Substring(0, 1)).Distinct().ToList();
                }
                else
                {
                    //全拼循环匹配
                    var newTotalPingYins = new List<string>();
                    foreach (var totalPingYin in result.TotalPingYin)
                    {
                        newTotalPingYins.AddRange(items.Select(item => totalPingYin + item));
                    }
                    newTotalPingYins = newTotalPingYins.Distinct().ToList();
                    result.TotalPingYin = newTotalPingYins;

                    //首字母循环匹配
                    var newFirstPingYins = new List<string>();
                    foreach (var firstPingYin in result.FirstPingYin)
                    {
                        newFirstPingYins.AddRange(items.Select(item => firstPingYin + item.Substring(0, 1)));
                    }
                    newFirstPingYins = newFirstPingYins.Distinct().ToList();
                    result.FirstPingYin = newFirstPingYins;
                }
            }
            return result;
        }
        public static PingYinModel GetTotalPingYinPascal(string str)
        {
            var chs = str.ToCharArray();
            //记录每个汉字的全拼
            Dictionary<int, List<string>> totalPingYins = new Dictionary<int, List<string>>();
            for (int i = 0; i < chs.Length; i++)
            {
                var pinyins = new List<string>();
                var ch = chs[i];
                //是否是有效的汉字
                if (ChineseChar.IsValidChar(ch))
                {
                    ChineseChar cc = new ChineseChar(ch);
                    pinyins = cc.Pinyins.Where(p => !string.IsNullOrWhiteSpace(p)).ToList();
                }
                else
                {
                    pinyins.Add(ch.ToString());
                }

                //去除声调，转小写
                pinyins = pinyins.ConvertAll(p => Regex.Replace(p, @"\d", "").ToLower());
                //去重
                pinyins = pinyins.Where(p => !string.IsNullOrWhiteSpace(p)).Distinct().ToList();
                if (pinyins.Any())
                {
                    totalPingYins[i] = pinyins;
                }
            }
            PingYinModel result = new PingYinModel();
            foreach (var pinyins in totalPingYins)
            {
                var items = pinyins.Value;
                //拼音首字母改为大写
                for (int i = 0; i < items.Count; i++)
                {
                    var firstChar = items[i].Substring(0, 1);
                    var upperChar = firstChar.ToUpper();
                    Regex regex = new Regex(firstChar);
                    items[i] = regex.Replace(items[i], upperChar, 1);
                }
                if (result.TotalPingYin.Count <= 0)
                {
                    result.TotalPingYin = items;
                    result.FirstPingYin = items.ConvertAll(p => p.Substring(0, 1)).Distinct().ToList();
                }
                else
                {
                    //全拼循环匹配
                    var newTotalPingYins = new List<string>();
                    foreach (var totalPingYin in result.TotalPingYin)
                    {
                        newTotalPingYins.AddRange(items.Select(item => totalPingYin + item));
                    }
                    newTotalPingYins = newTotalPingYins.Distinct().ToList();
                    result.TotalPingYin = newTotalPingYins;

                    //首字母循环匹配
                    var newFirstPingYins = new List<string>();
                    foreach (var firstPingYin in result.FirstPingYin)
                    {
                        newFirstPingYins.AddRange(items.Select(item => firstPingYin + item.Substring(0, 1)));
                    }
                    newFirstPingYins = newFirstPingYins.Distinct().ToList();
                    result.FirstPingYin = newFirstPingYins;
                }
            }
            return result;
        }

        /// <summary>
        /// 中文转拼音
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string ChinessToPingYinPascal(string str)
        {
            var pingyins = GetTotalPingYinPascal(str);
            var quanPin = string.Join(",", pingyins.TotalPingYin);
            return quanPin;
        }
        public class PingYinModel
        {
            public List<string> TotalPingYin { get; set; } = new List<string>();
            public List<string> FirstPingYin { get; set; } = new List<string>();
        }
    }
}
