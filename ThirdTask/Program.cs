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
            var delegateClass = new DelegateClass(67,-89,0);
            Console.WriteLine($"Initial values: first: {delegateClass.ActionValue}, second: {delegateClass.FuncValue}, third: {delegateClass.PredicateValue}");

            Console.WriteLine("\nResult of changing the first field");
            delegateClass.ActionValue = 23;
            Console.WriteLine("\nResult of changing the second field");
            delegateClass.FuncValue = 65;
            Console.WriteLine("\nResult of changing the third field");
            delegateClass.PredicateValue = -43;
        }
    }
}
