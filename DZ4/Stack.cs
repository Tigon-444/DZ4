namespace DZ4
{
    public class Stack
    {
        public List<string> allPozition { get; private set; } = new List<string>();
        public int Size { get; private set; } = 0;
        public string Top { get; private set; } = "";

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

            if (allPozition.Count > 1)
            {
                nowParametr = allPozition[allPozition.Count - 1];
                allPozition.RemoveAt(allPozition.Count - 1);
                Size--;
                Top = allPozition[allPozition.Count - 1];
                return nowParametr;
            }
            else
            {
                Console.WriteLine("Стек пустой");
                Size = 0;
                Top = "Null";
                return nowParametr = "";
            }

        }

        public static List<string> Concat(params Stack[] list)
        {
            List<string> allStack = new List<string>();

            for (int j = 0; j < list.Length; j++)
            {
                int count = list[j].allPozition.Count - 1;

                for (int i = 0; i <= count; i++)
                {
                    allStack.Add(list[j].allPozition[count - i]);
                }
            }
            foreach (var param in allStack) // вывод значений, для себя)
            {
                //Debug.Print(param);
                Console.WriteLine(param);
            }
            return allStack;
        }
    }
}
