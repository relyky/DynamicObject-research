# DynamicObject 再研究

DynamicObject是在.NET Framework 4 才加入的功能。  
要研究的話，以下這三個項目要同時研究：
* [dynamic keyword](https://docs.microsoft.com/zh-tw/dotnet/csharp/language-reference/keywords/dynamic)
* [DynamicObject 類別](https://msdn.microsoft.com/zh-tw/library/system.dynamic.dynamicobject(v=vs.110).aspx)
* [ExpandoObject 類別](https://msdn.microsoft.com/zh-tw/library/system.dynamic.expandoobject(v=vs.100).aspx)

拋開官方文件，本人的理解如下
* DynamicObject 類別  
整個"dyanmic"機制的核心。  
然而DynamicObject類別不可直接使用，必需透過繼承。
* dynamic keyword  
操作DynamicObject的context。
* ExpandoObject 類別  
是DynamicObject 類別的一般化，可以直接使用。  
或說 ExpandoObject 是整個"dyanmic"機制開發的目的。  
透過 ExpandoObject，可以做到JavaScript物件所能做到的“prototyp object”的能力。  
也就是可透過 ExpandoObject 建構弱型別物件，以可以隨意增減物件成員。

這裡有之前的研究文章。(C#, dynamic, DynamicObject, ExpandoObject)[http://relycoding.blogspot.tw/search?q=dynamic]

在本人的應用上“dynamic”的應用有
1. 在WebApp應用中，減少弱型別轉換成強型別轉換的工作。  
由web client side 送到 Server Side 的JSON/XML的轉換工作。  
這裡有例子[Querying JSON with dynamic](https://www.newtonsoft.com/json/help/html/QueryJsonDynamic.htm)、[Create JSON with dynamic](https://www.newtonsoft.com/json/help/html/CreateJsonDynamic.htm)。
	
2. 第二個應用，Dynamic Proxy Pattern。

(EOF)
