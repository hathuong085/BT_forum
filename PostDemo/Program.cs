using System;

namespace PostDemo
{
    class Program
    {
        public static void Main(string[] args)
        {
            CreateMenu();
        }
           public static Forum forum = new Forum();
        public static void CreateMenu()
        {
            int option = 0;
            do
            {
                Console.WriteLine();
                Console.WriteLine("Please select an option from 1 to 6:");
                Console.WriteLine("1. Create Post");
                Console.WriteLine("2. Update Post");
                Console.WriteLine("3. Remove Post");
                Console.WriteLine("4. Show Post");
                Console.WriteLine("5. Search Post");
                Console.WriteLine("6. Rating");
                Console.WriteLine("7. Exit");
                Console.Write("Input number: ");

                if (int.TryParse(Console.ReadLine(), out int number))
                {
                    option = number;
                }
                if(option > 7 || option < 1)
                {
                    Console.Clear();
                }
            }
            while (option > 7 || option < 1);

            Process(option);
        }

        public static void Process(int opt)
        {
            Console.Clear();
            switch (opt)
            {
                case 1:
                    {
                        add();
                        break;
                    }
                case 2:
                    {
                        Update();
                        break;
                    }
                case 3:
                    {
                        remove();
                        break;
                    }
                case 4:
                    {
                        show();
                        break;
                    }
                case 5:
                    {
                        search();
                        break;
                    }
                case 6:
                    {
                        Rating();
                        break;
                    }
                case 7:
                    {
                        Environment.Exit(Environment.ExitCode);
                        break;
                    }
            }
            CreateMenu();
        }

        private static void Rating()
        {
            Console.Write("Input Id Post:");
            int id = int.Parse (Console.ReadLine());
            Console.Write("Input Rate (1-5):");
            int rate = int.Parse(Console.ReadLine());
            forum.Rate(id,rate);
        }

        private static void Update()
        {
            Console.Write("Input Id Post:");
            int id = int.Parse(Console.ReadLine());
            Console.Write("Input Content:");
            string cont = Console.ReadLine();
            forum.Update(id, cont);
        }

        public static void add()
        {
            Post post = new Post();
            Console.Write("Input new Title:");
            post.Title = Console.ReadLine();
            Console.Write("Input Content:");
            post.Content = Console.ReadLine();
            Console.Write("Input Author:");
            post.Author = Console.ReadLine();
            post.CalculatorRate();
            post.Id = forum.Posts.Count;
            forum.Add(post);
        }
        public static void show()
        {
            forum.Show();
        }
        public static void search()
        {
            Console.Write("Input Author or Title:");
            string AuOrTi = Console.ReadLine();
            forum.Search(AuOrTi);
        }
        public static void remove()
        {
            Console.Write("Input Id Post:");
            int id = int.Parse(Console.ReadLine());
            forum.Remove(id);
        }

    }
}
