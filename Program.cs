namespace KundalikCom;

internal class Program
{
    static void Main(string[] args)
    {
        Menu();
    }

    static void Menu()
    {
        Console.WriteLine("1. Register \n" +
            "2. SignIn \n" +
            "3. Exit");

        int option = int.Parse(Console.ReadLine());

        switch (option)
        {
            case 1:
                Register();
                break;

            case 2:
                SignIn();
                break;

            case 3:
                Environment.Exit(0);
                break;
        }
    }

    private static void SignIn()
    {
        int option = GetRole();

        Console.Write("Email : ");
        string email = Console.ReadLine();

        Console.Write("Password : ");
        string passWord = Console.ReadLine();

        switch(option)
        {
            case 1:

                StudentDashboard();
                break;
            case 2:
                TeacherDashBoard();

                
                break;
        }
        Menu();

        void StudentDashboard()
        {
            Student student = (Student)KundalikCOM.Instance.LogIn(
                   new Student() { Email = email, Password = passWord });

            if (student is null)
            {
                SignIn();
            }
            Operation(student);

            Console.WriteLine("1. Yana baholarni ko'rish \n" +
                "2. Ortga");
            int opt1 = int.Parse(Console.ReadLine());


            if (opt1 == 1)
                StudentDashboard();
        }

        void TeacherDashBoard()
        {
            Teacher teacher = (Teacher)KundalikCOM.Instance.LogIn(
                  new Teacher() { Email = email, Password = passWord });

            int subject = Operation(teacher);
            int studentOption = int.Parse(Console.ReadLine());

            Console.Write("Mark : ");
            int mark = int.Parse(Console.ReadLine());

            KundalikCOM.Instance.EditMark(studentOption - 1, subject - 1, mark);

            Console.WriteLine("1. Yana baholash \n" +
                    "2. Ortga");
            int opt = int.Parse(Console.ReadLine());

            if (opt == 1)
                TeacherDashBoard();
        }
    }

    private static int Operation(User user)
    {
        user.ViewSubjects();

        int subject = int.Parse(Console.ReadLine());

        KundalikCOM.Instance.ViewMarkALLStudents(subject - 1);

        return subject;
    }


    private static void Register()
    {
        int option = GetRole();
        bool isRegistred = false;
       
        switch (option)
        {
            case 1:
                Console.Write("Group number : ");
                int group = int.Parse(Console.ReadLine());

                User user = GeneralData();
                isRegistred = KundalikCOM.Instance.Register(
                    new Student()
                    {
                        GroupNumber = group,
                        Name = user.Name,
                        Email = user.Email,
                        Password = user.Password,
                        TellNumber = user.TellNumber
                    }
                    );

                break;

            case 2:
                Console.Write("Dagree : ");
                string dagree = Console.ReadLine();

                User userTeacher = GeneralData();
                isRegistred = KundalikCOM.Instance.Register(
                    new Teacher()
                    {
                        Dagree = dagree,
                        Name = userTeacher.Name,
                        Email = userTeacher.Email,
                        Password = userTeacher.Password,
                        TellNumber = userTeacher.TellNumber
                    }
                    );
                break;
        }

        if (!isRegistred)
        {
            Register();
        }

        Menu();
    }

    static User GeneralData()
    {
        Console.Write("Name : ");
        string name = Console.ReadLine();

        Console.Write("Email : ");
        string email = Console.ReadLine();

        Console.Write("Password : ");
        string password = Console.ReadLine();

        Console.Write("Telephone number : ");
        string tell = Console.ReadLine();

        return new User()
        { 
            Name = name,
            Email = email,
            Password = password,
            TellNumber = tell
        };
    }

    static int GetRole()
    {
        Console.WriteLine("1. Student \n" +
            "2. Teacher ");
        return int.Parse(Console.ReadLine());
    }
}