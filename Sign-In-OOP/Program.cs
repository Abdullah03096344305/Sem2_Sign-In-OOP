using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Sign_In_OOP
{
    class Program
    {
        class Credentials
        {
            public string names;
            public string passwords;
        }
        static int Menu()
        {
            Console.Clear();
            int choice;
            Console.WriteLine("Press 1 to Sign-In:");
            Console.WriteLine("Press 2 to Sign-Up:");           
            Console.WriteLine("Press 3 to Exit:");
            choice = int.Parse(Console.ReadLine());
            return choice;
        }
        static Credentials SignUp(Credentials[] s)
        {
            Credentials s1 = new Credentials();
            Console.WriteLine("Enter Name: ");
            s1.names = Console.ReadLine();           
            Console.WriteLine("Enter Password: ");
            s1.passwords = Console.ReadLine();
            string path = @"E:\SecondSemester\Sign-In-OOP\Sign-In-Data.txt";
            StreamWriter file = new StreamWriter(path, true);
            file.WriteLine(s[1].names + "," + s[1].passwords);
            file.Flush();
            file.Close();
            return s1;           
        }
        static void SignIn(Credentials[] s)
        {          
            Console.WriteLine("Enter Your Name: ");
            string n = Console.ReadLine();
            Console.WriteLine("Enter Your Password: ");
            string p = Console.ReadLine();
            bool flag = false;
            for (int x = 0; x < 5; x++)
            {
                if (n == s[x].names && p == s[x].passwords)
                {
                    Console.WriteLine("Valid User");
                    flag = true;
                }
            }
            if (flag == false)
            {
                Console.WriteLine("Invalid User");
            }
            Console.ReadKey();

        }
        static string ParseData(string record, int field)
        {
            int comma = 1;
            string item = "";
            for (int x = 0; x < record.Length; x++)
            {
                if (record[x] == ',')
                {
                    comma++;
                }
                else if (comma == field)
                {
                    item = item + record[x];
                }
            }
            return item;
        }
        static void ReadData(Credentials[] s, string[] names, string[] password)
        {
            string path = @"E:\SecondSemester\Sign-In-OOP\Sign-In-Data.txt";
            int x = 0;
            if (File.Exists(path))
            {
                StreamReader fileVariable = new StreamReader(path);
                string record;
                while ((record = fileVariable.ReadLine()) != null)
                {
                    names[x] = ParseData(record, 1);
                    password[x] = ParseData(record, 2);
                    x++;
                    if (x >= 5)
                    {
                        break;
                    }
                }
                fileVariable.Close();
            }
            else
            {
                Console.WriteLine("Not Exists ");
            }
            Console.ReadKey();
        }
        static void Main(string[] args)
        {
            Credentials[] s = new Credentials[10];
            int option;
            string[] names = new string[5];
            string[] password = new string[5];
            do
            {
                ReadData(s,  names,  password);
                Console.Clear();
                option = Menu();
                Console.Clear();
                if (option == 1)
                {
                    Console.WriteLine("Enter Your Name: ");
                    string n = Console.ReadLine();
                    Console.WriteLine("Enter Your Password: ");
                    string p = Console.ReadLine();
                    SignIn(s);
                }
                else if (option == 2)
                {
                    Console.WriteLine("Enter New Name: ");
                    string n = Console.ReadLine();
                    Console.WriteLine("Enter New Password: ");
                    string p = Console.ReadLine();
                    SignUp(s);
                }
                else if (option > 3 || option < 1)
                {
                    Console.WriteLine("Ani Daya Mazaq Ayy ");
                    Console.WriteLine("Sahi Input Dyy");
                }
            }
            while (option < 3);
            Console.Read();
        }
    }
}
