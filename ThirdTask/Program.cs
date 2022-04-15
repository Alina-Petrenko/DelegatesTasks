using System;

namespace ThirdTask
{
    /// <summary>
    /// Starts the project
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Displays the results of working with a delegate
        /// </summary>
        static void Main()
        {
            var delegateClass = new DelegateClass(67,-89,0, -1);
            Console.WriteLine($"Initial values: first: {delegateClass.ActionValue}, second: {delegateClass.FirstFuncValue}, third: {delegateClass.PredicateValue}, fourth: {delegateClass.SecondFuncValue}");

            Console.WriteLine("\nResult of changing the first field");
            delegateClass.ActionValue = 23;
            Console.WriteLine("\nResult of changing the second field");
            delegateClass.FirstFuncValue = 65;
            Console.WriteLine("\nResult of changing the third field");
            delegateClass.PredicateValue = -43;
            Console.WriteLine("\nResult of changing the fourth field");
            delegateClass.SecondFuncValue = 0;
        }
    }
}
