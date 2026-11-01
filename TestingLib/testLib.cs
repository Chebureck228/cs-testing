namespace TestingLib;

public class Person
{
    public string Name { get; }
    public Person(string name)
    {
        Name = name;
    }
}

public class Week : IEnumerable
{
    string[] days = { "Monday", "Tuesday", "Wednesday", "Thursday",
                      "Friday", "Saturday", "Sunay" };
    public IEnumerator GetEnumerator() => days.GetEnumerator();
}