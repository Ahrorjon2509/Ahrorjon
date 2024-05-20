namespace KundalikCom;

internal class Subject
{
    public string Name { get; set; }
    private int _grade;

    public int Grade
    {
        get
        {
            return _grade;
        }

        set
        {
            if(value >= 1 && value <= 5)
                _grade = value;
        }
    }
}
