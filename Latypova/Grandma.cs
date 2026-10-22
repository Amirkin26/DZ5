class Grandma
{
    public string Name;
    public int Age;

    public List<string> Diseases = new List<string>();
    public List<string> Medicines = new List<string>();

    public void Print()
    {
        Console.WriteLine("Имя: " + Name + ", возраст: " + Age);

        if (Diseases.Count == 0)
        {
            Console.WriteLine("Болезней нет, пришла на консультацию.");
        }
        else
        {
            for (int i = 0; i < Diseases.Count; i++)
            {
                Console.WriteLine(
                    "Болезнь: " + Diseases[i] + ", лекарство: " + Medicines[i]);
            }
        }
    }
}