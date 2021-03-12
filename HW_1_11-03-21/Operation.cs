using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HW_1_11_03_21
{
    class Operation
    {
        public static void Create()
        {
            try
            {
                using (var Context = new DBContext())
                {
                    Console.Write("LastName:");
                    string LastName = Console.ReadLine();
                    Console.Write("FirstName:");
                    string FirstName = Console.ReadLine();
                    Console.Write("MiddleName:");
                    string MiddleName = Console.ReadLine();
                    Console.Write("BirthDate:");
                    DateTime BirthDate = Convert.ToDateTime(Console.ReadLine());
                    var person = new Customer()
                    {
                        LastName = LastName,
                        FirstName = FirstName,
                        MiddleName = MiddleName,
                        BirthDate = BirthDate
                    };
                    Context.Customers.Add(person);
                    if (Context.SaveChanges() > 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Успешно добавлен!");
                        Console.ResetColor();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.ReadKey();
            }
        }
        public static void Read(string Type = null)
        {
            try
            {
                using (var context = new DBContext())
                {
                    var PersonList = context.Customers.ToList();

                    PersonList.ForEach(p =>
                    {
                        Console.WriteLine($"ID:{p.Id}\tLastName:{p.LastName}\tFirstName:{p.FirstName}\tMiddleName:{p.MiddleName}\tBirthDate:{p.BirthDate}");
                    });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (Type == null) Console.ReadKey();
            }

        }
        public static void Update()
        {
            try
            {
                using (var Context = new DBContext())
                {
                    Read("Update");
                    Console.WriteLine("Введите Id человека: ");
                    Console.Write("Id: ");
                    int ID = Convert.ToInt32(Console.ReadLine());
                    var person = Context.Customers.Find(ID);
                    if (person != null)
                    {
                        Console.Write("LastName:");
                        string LastName = Console.ReadLine();
                        Console.Write("FirstName:");
                        string FirstName = Console.ReadLine();
                        Console.Write("MiddleName:");
                        string MiddleName = Console.ReadLine();
                        Console.Write("BirthDate:");
                        DateTime BirthDate = Convert.ToDateTime(Console.ReadLine());
                        person.LastName = LastName;
                        person.FirstName = FirstName;
                        person.MiddleName = MiddleName;
                        person.BirthDate = BirthDate;

                        if (Context.SaveChanges() > 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Успешно изменено!");
                            Console.ResetColor();
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Не изменень!");
                            Console.ResetColor();
                        }
                    }
                    else Console.WriteLine("В нашу таблицу человек по такой Id не существует!");

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.ReadKey();
            }
        }
        public static void Delete()
        {
            try
            {
                using (var Context = new DBContext())
                {
                    Read("Delete");
                    Console.WriteLine("Введите Id человека каторый вы хотели удалить его данныe!");
                    Console.Write("Id: ");
                    var ID = Convert.ToInt32(Console.ReadLine());
                    var person = Context.Customers.Find(ID);

                    if (person != null)
                    {
                        Console.Write("Вы действительно хотели удалить? Д(да)/Н(нет):");
                        var confirm = Console.ReadLine();
                        if (confirm.ToUpper() == "Д") Context.Customers.Remove(person);

                        if (Context.SaveChanges() > 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Успешно удален!");
                            Console.ResetColor();
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Не удален!");
                            Console.ResetColor();
                        }
                    }
                    else Console.WriteLine("В нашу таблицу человек по такой ID не существует!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.ReadKey();
            }
        }
    }
}
