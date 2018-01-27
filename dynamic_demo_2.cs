///
/// 使用 dynamic 臨時加入 attribute 與 method。
///

using System.Dynamic;

dynamic sampleObject = new ExpandoObject();
sampleObject.test = "Dynamic Property"; //# 動態加入新 Attribute
Console.WriteLine(sampleObject.test);
Console.WriteLine(sampleObject.test.GetType());
// output =>
// Dynamic Property
// System.String
sampleObject.number = 10;
sampleObject.Increment = (Action)(() => { sampleObject.number++; }); //# 動態加入新 method

// Before calling the Increment method.
Console.WriteLine(sampleObject.number);

sampleObject.Increment(); //# 呼叫新 method

// After calling the Increment method.
Console.WriteLine(sampleObject.number);
// output =>
// 10
// 11
