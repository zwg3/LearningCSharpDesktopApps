using System;

public class Person
{
	
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }

    public override string ToString()
    {
        return LastName + " " + FirstName + "\nВозраст: " + Age + "\n";
    }
}
