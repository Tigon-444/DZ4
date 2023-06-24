namespace DZ4
{
    public static class StackExtensions
    {
        public static void Merge(this Stack stack, Stack newStack)
        {
            int count = newStack.allPozition.Count-1;

            for (int i = 0; i <= count; i++)
            {
                stack.allPozition.Add(newStack.allPozition[count - i]);
            }

            foreach (var param in stack.allPozition) // вывод для себя
            {
                Console.WriteLine(param);
            }
        }
    }
}
