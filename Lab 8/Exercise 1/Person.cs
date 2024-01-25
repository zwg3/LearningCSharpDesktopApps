using System;
using System.Xml.Serialization;

[Serializable, XmlRoot(Namespace = "http://www.MyCompany.com")]
public class Person
{	
    public string FirstName { get; set; }
    public string LastName { get; set; }
    [NonSerialized]
    int age;
    public int Age
    {
        get { return age; }
        set { age = value; }
    }
    public override string ToString()
    {
        return LastName + " " + FirstName + "\nВозраст: " + Age + "\n";
    }
}
