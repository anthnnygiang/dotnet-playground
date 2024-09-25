using System;
using System.Collections.Generic;
using dotnet_playground;

var myParty = new MeList<int>();
myParty.Add(1);
myParty.Add(2);
myParty.Add(3);
myParty.Add(4);
myParty.Add(5);


IEnumerator<int> enr = myParty.GetEnumerator();
while (enr.MoveNext())
{
    Console.WriteLine(enr.Current);
}

if (true)
{
}

enr.Dispose();
