class student
{
    public string Surname;
    public string Name;
    public int BirthYear;
    public string Exam;
    public int Points;

    public void Print()
    {
        Console.WriteLine(Surname + " " + Name + ", год рождения: " + BirthYear + ", экзамен: " + Exam + ", баллы: " + Points);
    }
}