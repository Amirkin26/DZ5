class Program
{
    static void Main()
    {
        Task1();
        Task2();
        Task3();
        Task4();

        Console.WriteLine("\nВсе задания выполнены.");
    }
    
/// <summary>
/// Создаёт список из 32 пар картинок, копирует его и перемешивает копию случайным образом. Выводит исходный и перемешанный списки.
/// </summary>
    static void Task1()
    {
        Console.WriteLine("\nЗадание 1. Перемешивание картинок");
        Console.WriteLine("Создать 32 пары картинок и перемешать список.");

        List<string> original = new List<string>();

        for (int i = 1; i <= 32; i++)
        {
            string path = "Images/" + i + ".jpg";

            original.Add(path);
            original.Add(path);
        }

        List<string> shuffled = new List<string>(original);
        Random random = new Random();

        for (int i = shuffled.Count - 1; i > 0; i--)
        {
            int j = random.Next(i + 1);

            string temp = shuffled[i];
            shuffled[i] = shuffled[j];
            shuffled[j] = temp;
        }

        Console.WriteLine("\nИсходный список:");

        for (int i = 0; i < original.Count; i++)
        {
            Console.Write((i + 1) + "(" + Path.GetFileNameWithoutExtension(original[i]) + ") ");
        }

        Console.WriteLine("\n\nПеремешанный список:");

        for (int i = 0; i < shuffled.Count; i++)
        {
            Console.Write((i + 1) + "(" + Path.GetFileNameWithoutExtension(shuffled[i]) + ") ");
        }

        Console.WriteLine();
    }
    
/// <summary>
/// Управляет списком студентов. Загружает данные из файла students.txt, позволяет добавлять и удалять студентов, сортировать их по баллам и выводить информацию о студентах на экран.
/// </summary>
static void Task2()
{
    Console.WriteLine("\nЗадание 2. Студенты");
    Console.WriteLine("Команды: Новый студент, Удалить, Сортировать, Показать, Выход");

    List<student> students = new List<student>();
    Dictionary<string, student> dictionary = new Dictionary<string, student>();

    string path = "..//..//..//Files//students.txt";

    if (File.Exists(path))
    {
        string[] lines = File.ReadAllLines(path);

        for (int i = 0; i < lines.Length; i++)
        {
            string[] data = lines[i].Split(';');

            if (data.Length == 5 && int.TryParse(data[2], out int year) && int.TryParse(data[4], out int points))
            {
                student student = new student();

                student.Surname = data[0];
                student.Name = data[1];
                student.BirthYear = year;
                student.Exam = data[3];
                student.Points = points;

                students.Add(student);

                string key = student.Surname + " " + student.Name;
                dictionary[key] = student;
            }
        }
    }
    else
    {
        Console.WriteLine("Файл students.txt не найден.");
    }

    string command;

    do
    {
        Console.Write("\nВведите команду: ");
        command = Console.ReadLine();

        if (command == "Выход")
        {
            Console.WriteLine("Выход из программы.");
        }
        else if (command == "Новый студент")
        {
            student student = new student();

            Console.Write("Фамилия: ");
            student.Surname = Console.ReadLine();

            Console.Write("Имя: ");
            student.Name = Console.ReadLine();

            Console.Write("Год рождения: ");
            if (!int.TryParse(Console.ReadLine(), out student.BirthYear))
            {
                Console.WriteLine("Неверный год рождения.");
                continue;
            }

            Console.Write("Экзамен: ");
            student.Exam = Console.ReadLine();

            Console.Write("Баллы: ");
            if (!int.TryParse(Console.ReadLine(), out student.Points))
            {
                Console.WriteLine("Неверные баллы.");
                continue;
            }

            students.Add(student);
            dictionary[student.Surname + " " + student.Name] = student;

            Console.WriteLine("Студент добавлен.");
        }
        else if (command == "Удалить")
        {
            Console.Write("Фамилия: ");
            string surname = Console.ReadLine();

            Console.Write("Имя: ");
            string name = Console.ReadLine();

            student found = null;

            for (int i = 0; i < students.Count; i++)
            {
                if (students[i].Surname == surname && students[i].Name == name)
                {
                    found = students[i];
                    break;
                }
            }

            if (found != null)
            {
                students.Remove(found);
                dictionary.Remove(found.Surname + " " + found.Name);

                Console.WriteLine("Студент удалён.");
            }
            else
            {
                Console.WriteLine("Студент не найден.");
            }
        }
        else if (command == "Сортировать")
        {
            students.Sort((a, b) => a.Points.CompareTo(b.Points));

            Console.WriteLine("Список отсортирован по баллам.");
        }
        else if (command == "Показать")
        {
            for (int i = 0; i < students.Count; i++)
            {
                students[i].Print();
            }
        }
        else if (command != "Выход")
        {
            Console.WriteLine("Неизвестная команда.");
        }

    } while (command != "Выход");
}


/// <summary>
/// Организует очередь бабуль и распределяет их по больницам с учётом заболеваний, специализации больниц и их вместимости. Позволяет добавлять бабуль, распределять их и просматривать списки.
/// </summary>
static void Task3()
{
    Console.WriteLine("\nЗадание 3. Бабули и больницы");
    Console.WriteLine("Добавляйте бабуль в очередь, затем распределяйте их.");

    Stack<Hospital> hospitals = new Stack<Hospital>();

    Hospital hospital1 = new Hospital();
    hospital1.Name = "Городская больница";
    hospital1.Capacity = 3;
    hospital1.Diseases.Add("Простуда");
    hospital1.Diseases.Add("Давление");
    hospital1.Diseases.Add("Сердце");

    Hospital hospital2 = new Hospital();
    hospital2.Name = "Специализированная клиника";
    hospital2.Capacity = 2;
    hospital2.Diseases.Add("Диабет");
    hospital2.Diseases.Add("Сердце");

    hospitals.Push(hospital1);
    hospitals.Push(hospital2);

    Queue<Grandma> grandmas = new Queue<Grandma>();

    bool running = true;

    while (running)
    {
        Console.WriteLine("\n1. Добавить бабулю");
        Console.WriteLine("2. Распределить бабуль");
        Console.WriteLine("3. Показать списки");
        Console.WriteLine("0. Закончить задание");
        Console.Write("Выбор: ");

        string choice = Console.ReadLine();

        if (choice == "0")
        {
            running = false;
        }
        else if (choice == "1")
        {
            Grandma grandma = new Grandma();

            Console.Write("Имя: ");
            grandma.Name = Console.ReadLine();

            Console.Write("Возраст: ");
            if (!int.TryParse(Console.ReadLine(), out grandma.Age))
            {
                Console.WriteLine("Неверный возраст.");
                continue;
            }

            Console.WriteLine("Введите болезни через запятую.");
            Console.WriteLine("Если болезней нет, нажмите Enter.");
            string input = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(input))
            {
                string[] diseases = input.Split(',');

                for (int i = 0; i < diseases.Length; i++)
                {
                    string disease = diseases[i].Trim();

                    if (disease.Length > 0)
                    {
                        grandma.Diseases.Add(disease);
                    }
                }
            }

            for (int i = 0; i < grandma.Diseases.Count; i++)
            {
                Console.Write("Лекарство от болезни " + grandma.Diseases[i] + ": ");

                grandma.Medicines.Add(Console.ReadLine());
            }

            grandmas.Enqueue(grandma);
            Console.WriteLine("Бабуля добавлена в очередь.");
        }
        else if (choice == "2")
        {
            int count = grandmas.Count;

            for (int i = 0; i < count; i++)
            {
                Grandma grandma = grandmas.Dequeue();
                Hospital selected = null;

                foreach (Hospital hospital in hospitals)
                {
                    if (hospital.Patients.Count >= hospital.Capacity)
                    {
                        continue;
                    }

                    if (grandma.Diseases.Count == 0)
                    {
                        selected = hospital;
                        break;
                    }

                    int matching = 0;

                    for (int j = 0; j < grandma.Diseases.Count; j++)
                    {
                        if (hospital.Diseases.Contains(grandma.Diseases[j]))
                        {
                            matching++;
                        }
                    }

                    if ((double)matching / grandma.Diseases.Count > 0.5)
                    {
                        selected = hospital;
                        break;
                    }
                }

                if (selected != null)
                {
                    selected.Patients.Add(grandma);

                    Console.WriteLine(grandma.Name + " поступила в " + selected.Name + ".");
                }
                else
                {
                    Console.WriteLine(grandma.Name + " осталась на улице плакать.");
                }
            }
        }
        else if (choice == "3")
        {
            Console.WriteLine("\nБабули в очереди:");

            foreach (Grandma grandma in grandmas)
            {
                grandma.Print();
            }

            Console.WriteLine("\nБольницы:");

            foreach (Hospital hospital in hospitals)
            {
                hospital.Print();
            }
        }
        else
        {
            Console.WriteLine("Неизвестная команда.");
        }
    }

    Console.WriteLine("\nИтоговый список больниц:");

    foreach (Hospital hospital in hospitals)
    {
        hospital.Print();
    }
}

/// <summary>
/// Создаёт граф по введённым пользователем вершинам и рёбрам. Запрашивает начальную и конечную вершины, находит кратчайший путь между ними и выводит результат на экран.
/// </summary>
    static void Task4()
    {
        Console.WriteLine("\nЗадание 4. Кратчайший путь в графе");
        Console.WriteLine("Вершины нумеруются от 0 до N - 1.");

        Console.Write("Количество вершин: ");

        if (!int.TryParse(Console.ReadLine(), out int n) || n < 1)
        {
            Console.WriteLine("Неверное количество вершин.");
            return;
        }

        Graph graph = new Graph(n);

        Console.Write("Количество рёбер: ");

        if (!int.TryParse(Console.ReadLine(), out int m) || m < 0)
        {
            Console.WriteLine("Неверное количество рёбер.");
            return;
        }

        for (int i = 0; i < m; i++)
        {
            Console.Write("Введите две вершины через пробел: ");
            string[] data = Console.ReadLine().Split(' ');

            if (data.Length != 2 || !int.TryParse(data[0], out int a) || !int.TryParse(data[1], out int b) || a < 0 || a >= n || b < 0 || b >= n)
            {
                Console.WriteLine("Неверное ребро.");
                i--;
                continue;
            }

            graph.AddEdge(a, b);
        }

        Console.Write("Начальная вершина: ");

        if (!int.TryParse(Console.ReadLine(), out int start) || start < 0 || start >= n)
        {
            Console.WriteLine("Неверная вершина.");
            return;
        }

        Console.Write("Конечная вершина: ");

        if (!int.TryParse(Console.ReadLine(), out int end) || end < 0 || end >= n)
        {
            Console.WriteLine("Неверная вершина.");
            return;
        }

        List<int> path = graph.ShortestPath(start, end);

        if (path.Count == 0)
        {
            Console.WriteLine("Путь не найден.");
        }
        else
        {
            Console.WriteLine("Кратчайший путь: " + string.Join(" -> ", path));
        }
    }
}
