namespace DZ4
{
    public class Stack
    {
        private List<string> allPozition = new List<string>();
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

            if (Top == null)
            {
                Console.WriteLine("Стек пустой");
                return "";
            }

            if (allPozition.Count > 1)
            {
                nowParametr = allPozition[allPozition.Count - 1];
                allPozition.RemoveAt(allPozition.Count - 1);
                Size--;
                Top = allPozition[allPozition.Count - 1];
                return nowParametr;
            }
            Size = 0;
            Top = null;
            return "";
        }

        public static List<string> Concat(params Stack[] list)
        {
            List<string> allStack = new List<string>();

            foreach (var stack in list)
            {
                while (stack.Top != null)
                {
                    allStack.Add(stack.Top);
                    stack.Pop();
                }

            }
            Console.WriteLine(string.Join(',',allStack)); // вывод для себя
            return allStack;
        }
    }
}
