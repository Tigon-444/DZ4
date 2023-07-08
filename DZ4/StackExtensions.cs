using static System.Collections.Stack;

namespace DZ4
{
    public static class StackExtensions
    {
        public static void Merge(this Stack stack, Stack newStack)
        {
            while (newStack.Top != null)
            {
                stack.Add(newStack.Top);
                newStack.Pop();
            }
        }
    }
}
