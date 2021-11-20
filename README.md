# Names compare

Compare two list of names and return common and unique names between them.

```csharp
IEnumerable<string> nameList1 = new List<string> { "Name1", "Name2", "Name3", "Name4" };
IEnumerable<string> nameList2 = new List<string> { "Name1", "Name3", "Name5" };

ComparisonResult result = Compare.GetComparisonResult(nameList1, nameList2);

foreach(string name in result.CommonNames)
{
    Console.WriteLine(name); // Name1 and Name3
}

foreach(string name in result.UniqueList1Names)
{
    Console.WriteLine(name); // Name2 and Name4
}

foreach(string name in result.UniqueList2Names)
{
    Console.WriteLine(name); // Name5
}
```

Install in your project with NuGet.

```
dotnet add package Arc.NamesCompare
```