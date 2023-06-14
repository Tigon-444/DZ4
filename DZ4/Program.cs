using System.Collections.Generic;
using System.Drawing;

namespace DZ4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var s = new Stack("a", "b", "c");          // size = 3, Top = 'c'
            Console.WriteLine($"size = {s.Size}, Top = '{s.Top}'");
            var deleted = s.Pop();          // Извлек верхний элемент 'c' Size = 2
            Console.WriteLine($"Извлек верхний элемент '{deleted}' Size = {s.Size}");
            s.Add("d");          // size = 3, Top = 'd'
            Console.WriteLine($"size = {s.Size}, Top = '{s.Top}'");
            s.Pop();
            s.Pop();
            s.Pop();          // size = 0, Top = null
            Console.WriteLine($"size = {s.Size}, Top = {(s.Top == null ? "null" : s.Top)}");
            s.Pop();

            //var s1 = new Stack("a", "b", "c");
            //Console.WriteLine(s1.Top);
            //Console.ReadLine();

            //s1.Merge(new Stack("1", "2", "3"));// в стеке s теперь элементы - "a", "b", "c", "3", "2", "1" <- верхний
            //Console.WriteLine(s1.Top);

            //Console.ReadLine();

            var s2 = Stack.Concat(new Stack("a", "b", "c"), new Stack("1", "2", "3"), new Stack("А", "Б", "В"));
            //в стеке s теперь элементы - "c", "b", "a" "3", "2", "1", "В", "Б", "А" < -верхний
            Console.ReadLine();
        }
    }

    class Stack     // class Stack : StackExtensions
    {
        private List<string> allPozition = new List<string>(){"Null"};
        public int Size = 0;
        public string Top = "";

        public Stack (params string[] list)
        {
            for (int i = 0; i < list.Length; i++)
            {
                allPozition.Add(list[i]);
                Size++;
                Top = list[i];
            }
        }

        public void Add(string addElement)
        {
            allPozition.Add(addElement);
            Size++;
            Top = addElement;
        }

        public string Pop()
        {
            string nowParametr;

            try
            {
                nowParametr = allPozition[allPozition.Count - 1];
                allPozition.RemoveAt(allPozition.Count - 1);
                Size--;
                Top = allPozition[allPozition.Count - 1];
                return nowParametr;
            }
            catch (Exception e)
            {
                Console.WriteLine("Стек пустой");
                return nowParametr = "";
            }
            
        }

        public static string Concat(Stack stack1, Stack stack2, Stack stack3)
        {
            List<string> list = new List<string>();
            List<string> listStack = new List<string>();

            for (int j = 0; j <= 3; j++)
            {
                if (j == 0)
                {
                   list = stack1.allPozition;
                }
                else if (j == 1)
                {
                    list = stack2.allPozition;
                }
                else
                {
                    list = stack3.allPozition;
                }

                int count = list.Count - 1;
                for (int i = 1; i <= count; i++)
                {
                    string first = list[count - i];
                    list.Add(first);
                }

                for (int i = 1; i <= (list.Count) / 2; i++)
                {
                    list.RemoveAt(1);
                }

                for (int i = 1; i <= count; i++)
                {
                    listStack.Add(list[i]);
                }
            }
            listStack.Insert(0, "Null");
            listStack.RemoveAt(listStack.Count-1);
            stack1.allPozition = listStack;

            Console.WriteLine(stack1.allPozition[0]); // показывает весь стек
            Console.WriteLine(stack1.allPozition[1] + " " + stack1.allPozition[2] + " " + stack1.allPozition[3] + " ");
            Console.WriteLine(stack1.allPozition[4] + " " + stack1.allPozition[5] + " " + stack1.allPozition[6] + " ");
            Console.WriteLine(stack1.allPozition[7] + " " + stack1.allPozition[8] + " " + stack1.allPozition[9] + " ");

            return "";
        }

    }


    class StackExtensions
    {

        public StackExtensions(params string[] list)
        {
            
        }

        public void Merge(Stack stack1)
        {
           
        }
    }

}