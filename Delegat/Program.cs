using System;
using System.Collections.Generic;
using Fei.BaseLib;

namespace Delegat
{
    public delegate void SortDelegate(List<Student> students);

    class Studenti
    {
        static void Main(string[] args)
        {
            Random rand = new Random();

            List<Student> students = new List<Student>();
            bool run = true;
            SortDelegate sortDelegate;

            while (run)
            {
                Console.Clear();
                Console.WriteLine("1. Načtení studenta z klávesnice");
                Console.WriteLine("2. Výpis studentů na obrazovku");
                Console.WriteLine("3. Seřazení studentů podle čísla");
                Console.WriteLine("4. Seřazení studentů podle jména");
                Console.WriteLine("5. Seřazení studentů podle fakulty");
                Console.WriteLine("6. Deset náhodných studentů");
                Console.WriteLine("\n0. Ukončit program");

                int option = Fei.BaseLib.Reading.ReadInt("Zvolte hodnotu");

                switch (option)
                {
                    case 0:
                        run = false;
                        break;
                    case 1:
                        Console.Clear();

                        string jmeno = Fei.BaseLib.Reading.ReadString("Jmeno");
                        int cislo = Fei.BaseLib.Reading.ReadInt("Cislo");
                        Fakulta fakulta = (Fakulta)Fei.BaseLib.Reading.ReadInt("Fakulta (0 = FES, 1 = FF, 2 = FEI, 3 = FCHT)");

                        students.Add(new Student(jmeno, cislo, fakulta));
                        break;
                    case 2:
                        Console.Clear();

                        for (int i = 0; i < students.Count; i++)
                        {
                            Student student = students[i];
                            Console.WriteLine($"{student.GetJmeno()}  //  {student.GetCislo()}  //  {student.GetFakulta().ToString()}");
                        }

                        Console.ReadKey();
                        break;
                    case 3: // number sort
                        Console.Clear();
                        sortDelegate = Sort.NumberSort;
                        sortDelegate.Invoke(students);

                        for (int i = 0; i < students.Count; i++)
                        {
                            Student student = students[i];
                            Console.WriteLine($"{student.GetJmeno()}  //  {student.GetCislo()}  //  {student.GetFakulta().ToString()}");
                        }

                        Console.ReadKey();
                        break;
                    case 4: // name sort
                        Console.Clear();
                        sortDelegate = Sort.NameSort;
                        sortDelegate.Invoke(students);

                        for (int i = 0; i < students.Count; i++)
                        {
                            Student student = students[i];
                            Console.WriteLine($"{student.GetJmeno()}  //  {student.GetCislo()}  //  {student.GetFakulta().ToString()}");
                        }

                        Console.ReadKey();
                        break;
                    case 5: // faculty sort
                        Console.Clear();
                        sortDelegate = Sort.FacultySort;
                        sortDelegate.Invoke(students);

                        for (int i = 0; i < students.Count; i++)
                        {
                            Student student = students[i];
                            Console.WriteLine($"{student.GetJmeno()}  //  {student.GetCislo()}  //  {student.GetFakulta().ToString()}");
                        }

                        Console.ReadKey();
                        break;
                    case 6:
                        for (int i = 0; i < 10; i++)
                        {
                            students.Add(new Student(RandomString(), rand.Next(1000, 9999), (Fakulta)rand.Next(0,4)));
                        }
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Špatná hodnota. Zadejte znovu.");
                        Console.ReadKey();
                        break;
                }

            }

            static string RandomString()
            {
                var chars = "abcdefghijklmnopqrstuvwxyz";
                var stringChars = new char[10];
                var random = new Random();

                for (int i = 0; i < stringChars.Length; i++)
                {
                    stringChars[i] = chars[random.Next(chars.Length)];
                }

                var finalString = new String(stringChars);
                return finalString;
            }
        }
    }

    public class Sort
    {
        public static void NameSort(List<Student> students)
        {
            Student temp;

            for (int i = 0; i < students.Count; i++)
            {
                for (int j = i + 1; j < students.Count; j++)
                {
                    if (students[i].GetJmeno().CompareTo(students[j].GetJmeno()) > 0)
                    {
                        temp = students[i];
                        students[i] = students[j];
                        students[j] = temp;
                    }
                }
            }
        }

        public static void NumberSort(List<Student> students)
        {
            Student temp;

            for (int i = 0; i < students.Count; i++)
            {
                for (int j = i + 1; j < students.Count; j++)
                {
                    if (students[i].GetCislo() > students[j].GetCislo())
                    {
                        temp = students[i];
                        students[i] = students[j];
                        students[j] = temp;
                    }
                }
            }
        }

        public static void FacultySort(List<Student> students)
        {
            Student temp;

            for (int i = 0; i < students.Count; i++)
            {
                for (int j = i + 1; j < students.Count; j++)
                {
                    if ((int)students[i].GetFakulta() > (int)students[j].GetFakulta())
                    {
                        temp = students[i];
                        students[i] = students[j];
                        students[j] = temp;
                    }
                }
            }
        }
    }

    public class Student
    {
        private string jmeno;
        private int cislo;
        private Fakulta fakulta;
        
        public Student(string jmeno, int cislo, Fakulta fakulta)
        {
            this.jmeno = jmeno;
            this.cislo = cislo;
            this.fakulta = fakulta;
        }

        public string GetJmeno()
        {
            return jmeno;
        }
        public int GetCislo()
        {
            return cislo;
        }
        public Fakulta GetFakulta()
        {
            return fakulta;
        }
    }
    public enum Fakulta
    {
        FES,
        FF,
        FEI,
        FCHT
    }
}
