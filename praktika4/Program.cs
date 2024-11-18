using System;
using System.Collections.Generic;
using System.Linq;

namespace practika3
{
    public class Student
    {
        // Закрытые поля
        private string lastName;
        private string firstName;
        private string middleName;
        private DateTime birthDate;
        private int course;
        private string group;

        // Конструктор
        public Student(string lastName, string firstName, string middleName, DateTime birthDate, int course, string group)
        {
            LastName = lastName; // Используем свойства для проверки
            FirstName = firstName;
            MiddleName = middleName;
            BirthDate = birthDate;
            Course = course;
            Group = group;
        }

        // Открытые свойства с проверкой корректности
        public string LastName
        {
            get => lastName;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Фамилия не может быть пустой.");
                lastName = value;
            }
        }

        public string FirstName
        {
            get => firstName;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Имя не может быть пустым.");
                firstName = value;
            }
        }

        public string MiddleName
        {
            get => middleName;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Отчество не может быть пустым.");
                middleName = value;
            }
        }

        public DateTime BirthDate
        {
            get => birthDate;
            set
            {
                if (value >= DateTime.Now)
                    throw new ArgumentException("Дата рождения не может быть в будущем.");
                birthDate = value;
            }
        }

        public int Course
        {
            get => course;
            set
            {
                if (value < 1 || value > 6) // Предполагаем, что курс от 1 до 6
                    throw new ArgumentOutOfRangeException("Курс должен быть от 1 до 6.");
                course = value;
            }
        }

        public string Group
        {
            get => group;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Группа не может быть пустой.");
                group = value;
            }
        }

        // Метод для вывода информации о студенте
        public override string ToString()
        {
            return $"{LastName} {FirstName} {MiddleName}, Дата рождения: {BirthDate.ToShortDateString()}, Курс: {Course}, Группа: {Group}";
        }

        static void Main()
        {
            try
            {
                // Создаем список студентов
                List<Student> students = new List<Student>
                {
                    new Student("Золотарёв", "Иван", "Иванович", new DateTime(2001, 5, 15), 2, "Группа И91"),
                    new Student("Траутвейн", "Виктория", "Денисовна", new DateTime(2004, 8, 20), 1, "Группа И91"),
                    new Student("Холодов", "Сергей", "Сидорович", new DateTime(2005, 12, 5), 3, "Группа П91"),
                    new Student("Калачин", "Вадим", "Алексеевич", new DateTime(2002, 3, 10), 1, "Группа И92"),
                    new Student("Смирнов", "Николай", "Сергеевич", new DateTime(2001, 11, 25), 2, "Группа АФ01")
                };

                // Запросы LINQ

                // Список студентов заданного курса (например, курс 1)
                var studentsInCourse1 = students.Where(s => s.Course == 1).ToList();
                Console.WriteLine("Студенты курса 1:");
                foreach (var student in studentsInCourse1)
                {
                    Console.WriteLine(student);
                }

                // Самый молодой студент
                var youngestStudent = students.OrderBy(s => s.BirthDate).LastOrDefault();

                if (youngestStudent != null)
                {
                    Console.WriteLine($"Самый молодой студент: {youngestStudent}"); 
                }
                else
                {
                    Console.WriteLine("Список студентов пуст.");
                }

                // Количество студентов заданной группы (например, "Группа И91")
                var groupCount = students.Count(s => s.Group == "Группа И91");
                Console.WriteLine($"nКоличество студентов в 'Группа И91': {groupCount}");

                // Первый студент с заданным именем (например, "Иван")
                var firstStudentNamedPetr = students.FirstOrDefault(s => s.FirstName == "Иван");
                Console.WriteLine($"nПервый студент с именем 'Иван': {firstStudentNamedPetr}");

                // Список студентов, упорядоченных по фамилии
                var orderedStudents = students.OrderBy(s => s.LastName).ToList();
                Console.WriteLine("nСтуденты, упорядоченные по фамилии:");
                foreach (var student in orderedStudents)
                {
                    Console.WriteLine(student);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }
    }
}

