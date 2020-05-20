using System;
using System.Collections.Generic;
using System.Text;


namespace PostDemo
{
    class Post : IPost
    {
        public int Id;
        public string Title;
        public string Content;
        public string Author;
        public float AverageRate { get; private set; }
        public List<int> Rate = new List<int>(0);

        public Post()
        {
        }

        public  void CalculatorRate()
        {
            float total = 0;
            if (Rate.Count > 0)
            {
                for (int i = 0; i < Rate.Count; i++)
                {
                    total += (float)Rate[i];
                }
                AverageRate= total / Rate.Count;
            }
            else
            {
                AverageRate = 0;
            }
        }

        public void Display()
        {
            Console.WriteLine($"Id: {Id} \t Title: {Title} " +
                $"\tContent: {Content} \t Author: {Author} " +
                $"\tAverageRate: {AverageRate}");
        }
    }
}
