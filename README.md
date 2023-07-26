# PinYinConvert 中文转换为拼音
## Describe 描述
### Chinese to Pinyin Pascal Naming： 中文转换为拼音帕斯卡命名方式
### Example 实例
```csharp
string str="中国";
var pinYin= PinYinConverterHelp.ChinessToPingYinPascal(str);
//Output 输出：ZhongGuo;

var totalPingYin= PinYinConverterHelp.GetTotalPingYin(str);
var totalPingYinPascal= PinYinConverterHelp.GetTotalPingYinPascal(str);
```
