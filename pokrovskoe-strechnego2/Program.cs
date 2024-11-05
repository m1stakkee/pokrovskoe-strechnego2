using System.Globalization;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        string name;
        while (true)
        {
            Console.Write("Введите ФИО: ");
            name = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(name))
                break;
            Console.WriteLine("ФИО не может быть пустым. Попробуйте снова.");
        }

        DateTime birthDate;
        while (true)
        {
            Console.Write("Введите дату рождения (дд.мм.гггг): ");
            var dateOfBirth = Console.ReadLine();
            if (DateTime.TryParseExact(dateOfBirth, "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out birthDate))
                break;
            Console.WriteLine("Некорректный формат даты. Используйте дд.мм.гггг. Попробуйте снова.");
        }

        string number;
        while (true)
        {
            Console.Write("Введите номер телефона: ");
            number = Console.ReadLine();
            if (Regex.IsMatch(number, @"^\+?[1-9]\d{1,14}$"))
                break;
            Console.WriteLine("Некорректный номер телефона. Попробуйте снова.");
        }

        string email;
        while (true)
        {
            Console.Write("Введите почту: ");
            email = Console.ReadLine();
            if (Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                break;
            Console.WriteLine("Некорректный адрес электронной почты. Попробуйте снова.");
        }

        DateTime currentDate = DateTime.Now;
        int age = currentDate.Year - birthDate.Year;
        if (currentDate.Month < birthDate.Month ||
            (currentDate.Month == birthDate.Month && currentDate.Day < birthDate.Day))
        {
            age--;
        }

        Console.WriteLine($"Привет {name}\nДата: {birthDate:dd.MM.yyyy}\nНомер: {number}\nПочта: {email}\nВаш возраст: {age}");
    }
}
