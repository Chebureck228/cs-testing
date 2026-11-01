using TestingLib;
using static System.Console;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

class Program
{
    static void Main(string[] args)
    {
        ObservableCollection<Person> people = new ObservableCollection<Person>()
        {
            new Person("Tom"),
            new Person("Sam"),
        };

        people.CollectionChanged += People_CollectionChanged;

        people.Add(new Person("Bob"));
        people.RemoveAt(1);
        people[0] = new Person("Eugene");

        WriteLine("\nСписок пользователей:");
        foreach (var person in people)
        {
            WriteLine(person.Name);
        }
    }

    static void People_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
    {
        switch (e.Action)
        {
            case NotifyCollectionChangedAction.Add: 
                if (e.NewItems?[0] is Person newPerson)
                    WriteLine($"Добавлен новый объект {newPerson.Name}");
                break;
            case NotifyCollectionChangedAction.Remove:
                if (e.OldItems?[0] is Person oldPerson)
                    WriteLine($"Удален объект {oldPerson.Name}");
                break;
            case NotifyCollectionChangedAction.Replace:
                if (e.NewItems?[0] is Person replacingPerson &&
                    e.OldItems?[0] is Person replacedPerson)
                    WriteLine($"Объект {replacedPerson.Name} заменен объектом {replacingPerson.Name}");
                break;
        }
    }
}
