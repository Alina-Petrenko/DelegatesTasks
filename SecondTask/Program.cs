using System;

namespace SecondTask
{
    /// <summary>
    /// Starts the project
    /// </summary>
    public class Program
    {
        #region Public Methods
        /// <summary>
        /// Displays the results of working with a delegate
        /// </summary>
        static void Main()
        {
            var superClass = new SuperClass(10);
            var firstSuperDelegate = new SuperDelegate(superClass.CheckValue);
            var secondSuperDelegate = new SuperDelegate(superClass.CheckValue);

            Console.WriteLine($"\nMethod {nameof(superClass.PrintStringRepresentation)} subscribed to event");
            superClass.SuperDelegateEvent += superClass.PrintStringRepresentation;
            superClass.Value = 11;
            Console.WriteLine($"\nMethods {nameof(superClass.CheckValue)} and {nameof(superClass.PrintStringRepresentation)} subscribed to event");
            superClass.SuperDelegateEvent += superClass.CheckValue;
            superClass.Value = -1;
            Console.WriteLine($"\nMethods {nameof(superClass.CheckValue)} and {nameof(superClass.PrintStringRepresentation)} unsubscripted from event");
            superClass.SuperDelegateEvent -= superClass.PrintStringRepresentation;
            superClass.SuperDelegateEvent -= superClass.CheckValue;
            superClass.Value = 3;
            Console.WriteLine("");

            firstSuperDelegate += superClass.CheckValue;
            firstSuperDelegate += superClass.CheckValue;
            firstSuperDelegate += superClass.PrintStringRepresentation;
            firstSuperDelegate += superClass.PrintStringRepresentation;
            Console.WriteLine($"firstSuperDelegate Output: ");
            firstSuperDelegate?.Invoke(43);

            Console.WriteLine($"\nsecondSuperDelegate Output: ");
            secondSuperDelegate += superClass.PrintStringRepresentation;
            secondSuperDelegate?.Invoke(54);

            Console.WriteLine($"\nfirstSuperDelegate + secondSuperDelegate Output: ");
            var thirdSuperDelegate = firstSuperDelegate + secondSuperDelegate;
            thirdSuperDelegate?.Invoke(-32);

            Console.WriteLine($"\nfirstSuperDelegate and thirdSuperDelegate Comparison");
            if (firstSuperDelegate.Equals(thirdSuperDelegate))
            {
                Console.WriteLine("Delegates Equal");
            }
            else
            {
                Console.WriteLine("Delegates Different");
            }

            Console.WriteLine($"\nfirstSuperDelegate - secondSuperDelegate Output: ");
            thirdSuperDelegate = firstSuperDelegate - secondSuperDelegate;
            thirdSuperDelegate += superClass.CheckValue;
            thirdSuperDelegate.Invoke(12);

            Console.WriteLine($"\nthirdSuperDelegate's list of methods: ");
            var list = thirdSuperDelegate.GetInvocationList();
            foreach (var item in list)
            {
                Console.WriteLine($"{item.Method}");
            }
        }
        #endregion
    }
}
