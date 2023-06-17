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

            Console.WriteLine();

            var s1 = new Stack("a", "b", "c");
            s1.Merge(new Stack("1", "2", "3"));            //Console.WriteLine(s1.Top);

            Console.WriteLine();

            var s2 = Stack.Concat(new Stack("a", "b", "c","d","e"), new Stack("1", "2", "3"), new Stack("А", "Б", "В","Г"));
            //в стеке s теперь элементы - "c", "b", "a" "3", "2", "1", "В", "Б", "А" < -верхний
            Console.ReadLine();
        }
    }

    public class Stack 
    {
        public List<string> allPozition = new List<string>();
        public int Size = 0;
        public string Top = "";

        public Stack(params string[] list)
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
                Top = "Null";
                return nowParametr = "";
            }
            
        }

        public static List<string> Concat(params Stack[] list)
        {

            List<string> nowStack = new List<string>();
            List<string> allStack = new List<string>();

            for (int j = 0; j < list.Length; j++)
            {
                nowStack = list[j].allPozition;

                int count = nowStack.Count-1;

                for (int i = 0; i <= count; i++)
                {
                    string now = nowStack[count-i];
                    nowStack.Add(now);
                }

                for (int i = 0; i <= nowStack.Count /2 +1; i++)
                {
                    nowStack.RemoveAt(0);
                }

                for (int i = 0; i <= count; i++)
                {
                    allStack.Add(nowStack[i]);
                }

            }

            for (int i = 0; i < allStack.Count; i++) // вывод значений, для себя)
            {
                Console.WriteLine(allStack[i]);
            }

            return allStack;
        }


    }

    public static class StackExtensions
    {
        public static void Merge(this Stack stack, Stack newStack)
        {
            int count = newStack.allPozition.Count - 1;

            for (int i = 0; i <= count; i++)
            {
                string now = newStack.allPozition[count - i];
                newStack.allPozition.Add(now);
            }

            for (int i = 0; i <= newStack.allPozition.Count / 2 + 1; i++)
            {
                newStack.allPozition.RemoveAt(0);
            }

            for (int i = 0; i <= count; i++)
            {
                stack.allPozition.Add(newStack.allPozition[i]);
            }


            for (int i = 0; i < stack.allPozition.Count; i++) // вывод значений, для себя)
            {
                Console.WriteLine(stack.allPozition[i]);
            }
        }
    }

}