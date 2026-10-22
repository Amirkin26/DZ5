
class Hospital
{
    public string Name;
    public int Capacity;

    public List<string> Diseases = new List<string>();
    public List<Grandma> Patients = new List<Grandma>();

    public void Print()
    {
        Console.WriteLine("\nБольница: " + Name);
        Console.WriteLine("Лечатся болезни: " + string.Join(", ", Diseases));
        Console.WriteLine("Вместимость: " + Capacity);
        Console.WriteLine("Количество бабуль: " + Patients.Count);

        double percent = 0;

        if (Capacity > 0)
            percent = (double)Patients.Count / Capacity * 100;

        Console.WriteLine("Заполненность: " + percent + "%");

        Console.WriteLine("Бабули в больнице:");

        for (int i = 0; i < Patients.Count; i++)
        {
            Console.WriteLine(
                Patients[i].Name + ", возраст: " + Patients[i].Age);
        }
    }
}