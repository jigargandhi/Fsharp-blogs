using System;
public class State<T> where T : class, ICloneable
{
    public State(T item)
    {
        CurrentItem = item.Clone() as T;
        OldState = this;
    }

    private State(T item, State<T> oldState) : this(item)
    {
        OldState = oldState;
    }

    public T CurrentItem { get; private set; }

    public State<T> OldState { get; private set; }

    public State<T> CreateNewState(T item)
    {
        return new State<T>(item, OldState);
    }

    public State<T> GetOldState()
    {
        return this.OldState;
    }
}


class Person : ICloneable
{
    public string Name { get; set; }

    public object Clone()
    {
        return new Person() { Name = this.Name };
    }
}

Person p = new Person();
p.Name = "Jigar";
State<Person> personState = new State<Person>(p);
Console.WriteLine(p.Name);
personState = personState.CreateNewState(p);
p.Name = "Github";
Console.WriteLine(p.Name);
personState = personState.CreateNewState(p);
//oops now we want to undo the effect;
p = personState.GetOldState().CurrentItem;
Console.WriteLine(p.Name);

//The above code may not be 100% accurate memento but does the work.