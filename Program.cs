using System;

namespace DIO.Series
{
    class Program
    {
        static SerieRepository serieRepository = new SerieRepository();
        static MovieRepository movieRepository = new MovieRepository();
        static string userType = "";
        static dynamic repository;
        static void Main(string[] args)
        {
            string option = GetUserOption().ToUpper();

            while (option != "X")
            {
                repository = GetRepository();

                switch (option)
                {
                    case "1":
                        ListResource();
                        break;

                    case "2":
                        InsertResource();
                        break;

                    case "3":
                        UpdateResource();
                        break;

                    case "4":
                        DeleteResource();
                        break;

                    case "5":
                        ViewResource();
                        break;

                    case "C":
                        Console.Clear();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }
                option = GetUserOption();
            }
            Console.WriteLine("Thank you for user our services!");
        }

        private static dynamic GetRepository()
        {
            if (userType == "Movie")
            {
                return movieRepository;
            }
            else
            {
                return serieRepository;
            }
        }

        private static void DeleteResource()
        {
            Console.WriteLine($"Type the {userType} ID that you want to delete:");
            int id = int.Parse(Console.ReadLine());
            repository.Delete(id);
        }

        private static void ViewResource()
        {
            Console.WriteLine($"Type the {userType} ID that you want to view:");
            int id = int.Parse(Console.ReadLine());
            dynamic resource = repository.GetById(id);
            Console.WriteLine(resource);
        }

        private static void UpdateResource()
        {
            Console.WriteLine($"Type the {userType} ID that you want to update: ");
            int id = int.Parse(Console.ReadLine());
            if (userType == "Movie")
            {
                Movie resource = (Movie)GetUserResource(id);
                repository.Update(id, resource);
            }
            else
            {
                Serie resource = (Serie)GetUserResource(id);
                repository.Update(id, resource);
            }

        }

        private static BaseType GetUserResource(int? id = null)
        {
            foreach (int item in Enum.GetValues(typeof(Gender)))
            {
                Console.WriteLine("{0} - {1}", item, Enum.GetName(typeof(Gender), item));
            }

            Console.Write($"Select the {userType} gender from the above: ");
            int gender = int.Parse(Console.ReadLine());

            Console.Write($"Type the {userType} title: ");
            string title = Console.ReadLine();

            Console.Write($"Type the {userType} description: ");
            string description = Console.ReadLine();
            int seriesId = (int)(id.HasValue ? id : repository.NextId());

            Console.Write($"Type the {userType} year: ");
            int year = int.Parse(Console.ReadLine());

            if (userType != "Movie")
            {
                Console.Write($"Type the {userType} number of episodes: ");
                int numberOfSeasons = int.Parse(Console.ReadLine());
                Console.Write($"Type the {userType} finished year: ");
                int finishedYear = int.Parse(Console.ReadLine());
                return new Serie(seriesId, (Gender)gender, title, description, year, finishedYear, numberOfSeasons);
            }
            else
            {
                Console.Write($"Type if the {userType} was available online (Y/n)");
                string availableOnlineString = Console.ReadLine().ToUpper();
                bool availableOnline = availableOnlineString == "Y" ? true : false;

                Console.Write($"Type the {userType} duration: ");
                int duration = int.Parse(Console.ReadLine());

                return new Movie(seriesId, (Gender)gender, title, description, year, availableOnline, duration);
            }
        }



        private static void InsertResource()
        {
            Console.WriteLine($"Insert {userType}");
            if (userType == "Movie")
            {
                Movie resource = (Movie)GetUserResource();
                repository.Insert(resource);
            }
            else
            {
                Serie resource = (Serie)GetUserResource();
                repository.Insert(resource);
            }
        }

        private static void ListResource()
        {
            Console.WriteLine($"Listing all non deleted {userType}...");

            var resources = repository.List();

            if (resources.Count == 0)
            {
                Console.WriteLine($"There are no registered {userType}.");
                return;
            }

            foreach (var item in resources)
            {
                var deleted = item.getDeleted();
                if (deleted)
                {
                    continue;
                }
                Console.WriteLine($"ID {item.getId()}: - {item.getTitle()}");
            }
        }

        private static void GetTypeOption()
        {
            string type;
            do
            {
                Console.WriteLine("Select an option:");
                foreach (int item in Enum.GetValues(typeof(Type)))
                {
                    Console.WriteLine("{0} - {1}", item, Enum.GetName(typeof(Type), item));
                }
                type = Console.ReadLine();
            } while (!Enum.IsDefined(typeof(Type), int.Parse(type)));
            userType = Enum.GetName(typeof(Type), int.Parse(type));
            Console.Clear();
        }

        private static string GetUserOption()
        {
            GetTypeOption();

            Console.WriteLine("Select an option:");
            Console.WriteLine("1 - List {0}", userType);
            Console.WriteLine("2 - Add a new {0}", userType);
            Console.WriteLine("3 - Update {0}", userType);
            Console.WriteLine("4 - Delete {0}", userType);
            Console.WriteLine("5 - View {0}", userType);
            Console.WriteLine("C - Clear Console");
            Console.WriteLine("X - Quit");
            Console.WriteLine();

            string option = Console.ReadLine();
            Console.WriteLine();
            return option;
        }
    }
}
