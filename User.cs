namespace KundalikCom;

internal class User
{
    public Subject[] Subjects =
    {
    new Subject(){Name = "Math"},
    new Subject(){Name = "Physics"},
    new Subject(){Name = "History"},
    new Subject(){Name = "PI"},
    new Subject(){Name = "Chemistry"},
    };
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }

    public string TellNumber { get; set; }

    public void ViewSubjects()
    {
        Console.WriteLine(new string('-', 28));
        Console.WriteLine("|{0, 5}|{1, 20}|", "No", "Name");
        Console.WriteLine(new string('-', 28));

        int count = 1;
        foreach (Subject subject in Subjects)
        {
            Console.WriteLine("|{0, 5}|{1, 20}|", count++, subject.Name);
            Console.WriteLine(new string('-', 28));
        }
    }
}
