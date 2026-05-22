using System;
using System.IO;

class Program
{
    static void Main()
    {
        string fileName = "INFO.TXT";

        Console.Write("Введіть кількість поїздів: ");
        int n = int.Parse(Console.ReadLine());

        using (StreamWriter writer = new StreamWriter(fileName))
        {
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"\nПоїзд #{i + 1}");

                Console.Write("Номер поїзда: ");
                string number = Console.ReadLine();

                Console.Write("Станція призначення: ");
                string destination = Console.ReadLine();

                Console.Write("Час відправлення (год:хв): ");
                string departure = Console.ReadLine();

                Console.Write("Час у дорозі: ");
                string travelTime = Console.ReadLine();

                writer.WriteLine(number + ";" + destination + ";" + departure + ";" + travelTime);
            }
        }

        Console.WriteLine("\nДані записані у файл INFO.TXT");

        Console.WriteLine("\nПоїзди, що відправляються не пізніше 18:00:\n");

        using (StreamReader reader = new StreamReader(fileName))
        {
            string line;

            while ((line = reader.ReadLine()) != null)
            {
                string[] data = line.Split(';');

                string number = data[0];
                string destination = data[1];
                string departure = data[2];
                string travelTime = data[3];

                TimeSpan depTime = TimeSpan.Parse(departure);

                if (depTime <= new TimeSpan(18, 0, 0))
                {
                    Console.WriteLine("Номер поїзда: " + number);
                    Console.WriteLine("Станція: " + destination);
                    Console.WriteLine("Час відправлення: " + departure);
                    Console.WriteLine("Час у дорозі: " + travelTime);
                    Console.WriteLine();
                }
            }
        }

        Console.WriteLine("Натисніть будь-яку клавішу...");
        Console.ReadKey();
    }
}
