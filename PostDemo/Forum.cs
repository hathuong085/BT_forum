using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Runtime.InteropServices.ComTypes;

namespace PostDemo
{
    class Forum
    {
        public  SortedList<int,Post> Posts = new SortedList<int,Post>();

        public void Add(Post post)
        {
            Console.WriteLine("Add success!");
            Posts.Add(post.Id, post);
        }

        public void Update(int Id,string content)
        {
            int index = CheckId(Id);
            if (index != -1)
            {
                Posts[index].Content = content;
                Console.WriteLine("Update done!");
            }
            else
            {
                Console.WriteLine("Can't find the post you want to update");
            }
        }

        public void Remove(int Id)
        {
            int index = CheckId(Id);
            if (index != -1)
            {
                Posts.RemoveAt(index);
                Console.WriteLine("Deleted!");
            } else
            {
                Console.WriteLine("Can't find the post you want to delete");
            }
        }

        public void Show()
        {
            if (Posts.Count > 0)
            {
                foreach (Post ps in Posts.Values)
                {
                    ps.Display();
                }
            } else
            {
                Console.WriteLine("No posts yet");
            }
        }

        public void Search(string AutOrTit)
        {
            bool result = false;
            AutOrTit = AutOrTit.ToLower();
            for (int i = 0; i < Posts.Count; i++)
            {
                if (Posts[i].Author.ToLower().Contains(AutOrTit) || Posts[i].Title.ToLower().Contains(AutOrTit))
                {
                    Posts[i].Display();
                    result = true;
                }
            } 
            if(!result)
            {
                Console.WriteLine("Not Found");
            }
        }

        public void Rate(int Id,int rate)
        {
            int index = CheckId(Id);
            if (index != -1)
            {
                Posts[index].Rate.Add(rate);
                Posts[index].CalculatorRate();
                Console.WriteLine("Added a rate!");
            }
            else {
                Console.WriteLine("Not found Id");
                }
        }

        private int CheckId(int id)
        {
            for (int i=0;i<Posts.Count;i++)
            {
                if (Posts[i].Id.Equals(id))
                {
                    return id;
                }
            }
            return -1;
        }

    }
}
