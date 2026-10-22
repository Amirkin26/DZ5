
class Program
{
    static void Main(string[] args)
    {
        string filePath = "..//..//..//Files//NewFile1.txt";

        Task6_1(filePath);
        Task6_2();
        Task6_3();

        Homework6_1(filePath);
        Homework6_2();
        Homework6_3();
    }

    // Упражнение 6.1
    
    /// <summary>
    /// Считывает текст из файла и выводит количество гласных и согласных букв.
    /// </summary>
    static void Task6_1(string filePath)
    {
        Console.WriteLine("\nУпражнение 6.1");

        if (!File.Exists(filePath))
        {
            Console.WriteLine("Файл не найден. Проверьте путь к файлу.");
            return;
        }

        char[] characters = File.ReadAllText(filePath).ToCharArray();

        var result = CountLetters(characters);

        Console.WriteLine($"Количество гласных букв: {result.CountVowels}");
        Console.WriteLine($"Количество согласных букв: {result.CountConsonants}");
    }
    
    /// <summary>
    /// Подсчитывает количество гласных и согласных букв в массиве символов.
    /// </summary>
    static (int CountVowels, int CountConsonants) CountLetters(char[] characters)
    {
        string vowels = "аеёиоуыэюя";
        string consonants = "бвгджзйклмнпрстфхцчшщ";

        int vowelCount = 0;
        int consonantCount = 0;

        foreach (char character in characters)
        {
            char letter = char.ToLowerInvariant(character);

            if (vowels.Contains(letter))
            {
                vowelCount++;
            }
            else if (consonants.Contains(letter))
            {
                consonantCount++;
            }
        }

        return (vowelCount, consonantCount);
    }

    // Упражнение 6.2
    /// <summary>
    /// Создаёт две случайные матрицы, проверяет возможность их умножения, перемножает их и выводит результат.
    /// </summary>
    static void Task6_2()
    {
        Console.WriteLine("\nУпражнение 6.2");

        Console.Write("Введите количество строк первой матрицы: ");
        if (!int.TryParse(Console.ReadLine(), out int rowCountA) || rowCountA <= 0)
        {
            Console.WriteLine("Ошибка ввода.");
            return;
        }

        Console.Write("Введите количество столбцов первой матрицы: ");
        if (!int.TryParse(Console.ReadLine(), out int columnCountA) || columnCountA <= 0)
        {
            Console.WriteLine("Ошибка ввода.");
            return;
        }

        Console.Write("Введите количество строк второй матрицы: ");
        if (!int.TryParse(Console.ReadLine(), out int rowCountB) || rowCountB <= 0)
        {
            Console.WriteLine("Ошибка ввода.");
            return;
        }

        Console.Write("Введите количество столбцов второй матрицы: ");
        if (!int.TryParse(Console.ReadLine(), out int columnCountB) || columnCountB <= 0)
        {
            Console.WriteLine("Ошибка ввода.");
            return;
        }

        if (columnCountA != rowCountB)
        {
            Console.WriteLine(
                "Умножение невозможно: число столбцов первой матрицы должно совпадать с числом строк второй.");
            return;
        }

        Random random = new Random();

        int[,] matrixA = CreateRandomMatrix(rowCountA, columnCountA, random);
        int[,] matrixB = CreateRandomMatrix(rowCountB, columnCountB, random);

        Console.WriteLine("\nПервая матрица:");
        PrintMatrix(matrixA);

        Console.WriteLine("\nВторая матрица:");
        PrintMatrix(matrixB);

        int[,] result = MultiplyMatrices(matrixA, matrixB);

        Console.WriteLine("\nРезультат умножения:");
        PrintMatrix(result);
    }
    
    /// <summary>
    /// Создаёт двумерную матрицу заданного размера и заполняет её случайными числами от 1 до 9.
    /// </summary>
    static int[,] CreateRandomMatrix(int rowCount, int columnCount, Random random)
    {
        int[,] matrix = new int[rowCount, columnCount];

        for (int row = 0; row < rowCount; row++)
        {
            for (int column = 0; column < columnCount; column++)
            {
                matrix[row, column] = random.Next(1, 10);
            }
        }

        return matrix;
    }
    
    /// <summary>
    /// Перемножает две двумерные матрицы и возвращает матрицу с результатом умножения.
    /// </summary>
    static int[,] MultiplyMatrices(int[,] matrixA, int[,] matrixB)
    {
        int rowCount = matrixA.GetLength(0);
        int columnCount = matrixB.GetLength(1);
        int commonSize = matrixA.GetLength(1);

        int[,] result = new int[rowCount, columnCount];

        for (int row = 0; row < rowCount; row++)
        {
            for (int column = 0; column < columnCount; column++)
            {
                for (int index = 0; index < commonSize; index++)
                {
                    result[row, column] +=
                        matrixA[row, index] * matrixB[index, column];
                }
            }
        }

        return result;
    }
    
    /// <summary>
    /// Выводит двумерную матрицу в консоль в табличном виде.
    /// </summary>
    static void PrintMatrix(int[,] matrix)
    {
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int column = 0; column < matrix.GetLength(1); column++)
            {
                Console.Write($"{matrix[row, column],5}");
            }

            Console.WriteLine();
        }
    }

    // Упражнение 6.3
    /// <summary>
    /// Создаёт массив температур за 12 месяцев, вычисляет среднюю температуру каждого месяца и выводит средние значения по возрастанию.
    /// </summary>
    static void Task6_3()
    {
        Console.WriteLine("\nУпражнение 6.3");

        Random random = new Random();
        double[,] temperature = new double[12, 30];

        for (int month = 0; month < 12; month++)
        {
            for (int day = 0; day < 30; day++)
            {
                temperature[month, day] = random.Next(-20, 36);
            }
        }

        double[] averages = CalculateAverages(temperature);

        string[] months =
        {
            "Январь", "Февраль", "Март", "Апрель",
            "Май", "Июнь", "Июль", "Август",
            "Сентябрь", "Октябрь", "Ноябрь", "Декабрь"
        };

        for (int month = 0; month < months.Length; month++)
        {
            Console.WriteLine($"{months[month]}: {averages[month]:F2} °C");
        }

        Array.Sort(averages);

        Console.WriteLine("\nСредние температуры по возрастанию:");

        foreach (double average in averages)
        {
            Console.Write($"{average:F2} °C  ");
        }

        Console.WriteLine();
    }
    
    /// <summary>
    /// Вычисляет среднюю температуру для каждого месяца и возвращает массив средних значений.
    /// </summary>
    static double[] CalculateAverages(double[,] temperature)
    {
        int monthCount = temperature.GetLength(0);
        int dayCount = temperature.GetLength(1);

        double[] averages = new double[monthCount];

        for (int month = 0; month < monthCount; month++)
        {
            double sum = 0;

            for (int day = 0; day < dayCount; day++)
            {
                sum += temperature[month, day];
            }

            averages[month] = sum / dayCount;
        }

        return averages;
    }

    // Домашнее задание 6.1
    /// <summary>
    /// Считывает символы из файла, подсчитывает количество букв с помощью метода CountLetters и выводит результат.
    /// </summary>
    static void Homework6_1(string filePath)
    {
        Console.WriteLine("\nДомашнее задание 6.1");

        if (!File.Exists(filePath))
        {
            Console.WriteLine("Файл не найден. Проверьте путь к файлу.");
            return;
        }

        List<char> characters = new List<char>(File.ReadAllText(filePath));

        var result = CountLetters(characters);

        Console.WriteLine($"Количество гласных букв: {result.CountVowels}");
        Console.WriteLine($"Количество согласных букв: {result.CountConsonants}");
    }
    
    /// <summary>
    /// Подсчитывает количество букв в списке символов и возвращает полученное значение.
    /// </summary>
    static (int CountVowels, int CountConsonants) CountLetters(List<char> characters)
    {
        string vowels = "аеёиоуыэюя";
        string consonants = "бвгджзйклмнпрстфхцчшщ";

        int vowelCount = 0;
        int consonantCount = 0;

        foreach (char character in characters)
        {
            char letter = char.ToLowerInvariant(character);

            if (vowels.Contains(letter))
            {
                vowelCount++;
            }
            else if (consonants.Contains(letter))
            {
                consonantCount++;
            }
        }

        return (vowelCount, consonantCount);
    }

    // Домашнее задание 6.2
    /// <summary>
    /// Создаёт две случайные матрицы, перемножает их и выводит исходные матрицы и результат умножения.
    /// </summary>
    static void Homework6_2()
    {
        Console.WriteLine("\nДомашнее задание 6.2");

        Console.Write("Введите количество строк первой матрицы: ");
        if (!int.TryParse(Console.ReadLine(), out int rowCountA) || rowCountA <= 0)
        {
            Console.WriteLine("Ошибка ввода.");
            return;
        }

        Console.Write("Введите количество столбцов первой матрицы: ");
        if (!int.TryParse(Console.ReadLine(), out int columnCountA) || columnCountA <= 0)
        {
            Console.WriteLine("Ошибка ввода.");
            return;
        }

        Console.Write("Введите количество строк второй матрицы: ");
        if (!int.TryParse(Console.ReadLine(), out int rowCountB) || rowCountB <= 0)
        {
            Console.WriteLine("Ошибка ввода.");
            return;
        }

        Console.Write("Введите количество столбцов второй матрицы: ");
        if (!int.TryParse(Console.ReadLine(), out int columnCountB) || columnCountB <= 0)
        {
            Console.WriteLine("Ошибка ввода.");
            return;
        }

        if (columnCountA != rowCountB)
        {
            Console.WriteLine("Умножение невозможно: число столбцов первой матрицы должно совпадать с числом строк второй.");
            return;
        }

        Random random = new Random();

        LinkedList<LinkedList<int>> matrixA = CreateLinkedMatrix(rowCountA, columnCountA, random);

        LinkedList<LinkedList<int>> matrixB = CreateLinkedMatrix(rowCountB, columnCountB, random);

        Console.WriteLine("\nПервая матрица:");
        PrintLinkedMatrix(matrixA);

        Console.WriteLine("\nВторая матрица:");
        PrintLinkedMatrix(matrixB);

        LinkedList<LinkedList<int>> result = MultiplyLinkedMatrices(matrixA, matrixB);

        Console.WriteLine("\nРезультат умножения:");
        PrintLinkedMatrix(result);
    }
    /// <summary>
    /// Создаёт матрицу в виде связанного списка, заполняя её случайными числами в заданном диапазоне.
    /// </summary>
    static LinkedList<LinkedList<int>> CreateLinkedMatrix(int rowCount, int columnCount, Random random)
    {
        LinkedList<LinkedList<int>> matrix = new LinkedList<LinkedList<int>>();

        for (int row = 0; row < rowCount; row++)
        {
            LinkedList<int> values = new LinkedList<int>();

            for (int column = 0; column < columnCount; column++)
            {
                values.AddLast(random.Next(1, 10));
            }

            matrix.AddLast(values);
        }

        return matrix;
    }
    /// <summary>
    /// Перемножает две матрицы, представленные связанными списками, и возвращает результирующую матрицу.
    /// </summary>
    static LinkedList<LinkedList<int>> MultiplyLinkedMatrices(LinkedList<LinkedList<int>> matrixA, LinkedList<LinkedList<int>> matrixB)
    {
        int rowCount = matrixA.Count;
        int columnCount = matrixB.First.Value.Count;
        int commonSize = matrixA.First.Value.Count;

        LinkedList<LinkedList<int>> result = new LinkedList<LinkedList<int>>();

        for (int row = 0; row < rowCount; row++)
        {
            LinkedList<int> resultRow = new LinkedList<int>();

            for (int column = 0; column < columnCount; column++)
            {
                int sum = 0;

                for (int index = 0; index < commonSize; index++)
                {
                    int valueA = GetLinkedValue(matrixA, row, index);
                    int valueB = GetLinkedValue(matrixB, index, column);

                    sum += valueA * valueB;
                }

                resultRow.AddLast(sum);
            }

            result.AddLast(resultRow);
        }

        return result;
    }
    
    /// <summary>
    /// Возвращает значение элемента связанной матрицы по указанным индексам строки и столбца.
    /// </summary>
    static int GetLinkedValue(LinkedList<LinkedList<int>> matrix, int rowIndex, int columnIndex)
    {
        LinkedListNode<LinkedList<int>> rowNode = matrix.First;

        for (int row = 0; row < rowIndex; row++)
        {
            rowNode = rowNode.Next;
        }

        LinkedListNode<int> valueNode = rowNode.Value.First;

        for (int column = 0; column < columnIndex; column++)
        {
            valueNode = valueNode.Next;
        }

        return valueNode.Value;
    }
    /// <summary>
    /// Выводит элементы матрицы, представленной связанным списком, в консоль в табличном формате.
    /// </summary>
    static void PrintLinkedMatrix(LinkedList<LinkedList<int>> matrix)
    {
        foreach (LinkedList<int> row in matrix)
        {
            foreach (int value in row)
            {
                Console.Write($"{value,5}");
            }

            Console.WriteLine();
        }
    }

    // Домашнее задание 6.3
    /// <summary>
    /// Создаёт словарь температур по месяцам, вычисляет средние температуры и выводит месяцы в порядке возрастания средней температуры.
    /// </summary>
    static void Homework6_3()
    {
        Console.WriteLine("\nДомашнее задание 6.3");

        string[] months =
        {
            "Январь", "Февраль", "Март", "Апрель", "Май", "Июнь", "Июль", "Август", "Сентябрь", "Октябрь", "Ноябрь", "Декабрь"
        };

        Random random = new Random();

        Dictionary<string, int[]> temperature = new Dictionary<string, int[]>();

        foreach (string month in months)
        {
            int[] dailyTemperatures = new int[30];

            for (int day = 0; day < dailyTemperatures.Length; day++)
            {
                dailyTemperatures[day] = random.Next(-20, 36);
            }

            temperature.Add(month, dailyTemperatures);
        }

        Dictionary<string, double> averages = new Dictionary<string, double>();

        foreach (KeyValuePair<string, int[]> entry in temperature)
        {
            double average = entry.Value.Average();

            averages.Add(entry.Key, average);

            Console.WriteLine($"{entry.Key}: {average:F2} °C");
        }

        Console.WriteLine("\nМесяцы по возрастанию средней температуры:");

        foreach (KeyValuePair<string, double> entry in averages.OrderBy(item => item.Value))
        {
            Console.WriteLine($"{entry.Key}: {entry.Value:F2} °C");
        }
    }
}