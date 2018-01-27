dynamic dyn;

dyn = 123; // dyn is [int].
Console.WriteLine(dyn.ToString());
Console.WriteLine(dyn.GetType().Name);

dyn = "abcdef"; // dyn became [string] from [int].
Console.WriteLine(dyn.ToString());
Console.WriteLine(dyn.GetType().Name);
