using System;

namespace SecondTask
{
    /// <summary>
    /// Starts the project
    /// </summary>
    public class Program
    {
        // TODO: In current case, Main() - it is private method
        // TODO: Read this:
        // https://stackoverflow.com/questions/3736019/c-sharp-default-access-modifier-of-main-method#:~:text=Both%2C%20the%20default%20class%20modifier,without%20a%20declaration%20are%20private.
        #region Public Methods
        /// <summary>
        /// Displays the results of working with a delegate
        /// </summary>
        static void Main()
        {
            var superClass = new SuperClass(10);
            var firstSuperDelegate = new SuperDelegate(superClass.CheckValue);
            var secondSuperDelegate = new SuperDelegate(superClass.CheckValue);

            // TODO: If message is "subscribed to event" then firstly we should DO an action and secondly we PRINT info about it
            // TODO: You don't know when your application is crash. So notifying about action should be after this action.
            // TODO: Before
            //Console.WriteLine($"\nMethod {nameof(superClass.PrintStringRepresentation)} subscribed to event");
            //superClass.SuperDelegateEvent += superClass.PrintStringRepresentation;
            // TODO: After
            superClass.SuperDelegateEvent += superClass.PrintStringRepresentation;
            Console.WriteLine($"\nMethod {nameof(superClass.PrintStringRepresentation)} subscribed to event");

            superClass.Value = 11;
            Console.WriteLine($"\nMethods {nameof(superClass.CheckValue)} and {nameof(superClass.PrintStringRepresentation)} subscribed to event");
            superClass.SuperDelegateEvent += superClass.CheckValue;
            superClass.Value = -1;
            Console.WriteLine($"\nMethods {nameof(superClass.CheckValue)} and {nameof(superClass.PrintStringRepresentation)} unsubscribed from event");
            superClass.SuperDelegateEvent -= superClass.PrintStringRepresentation;
            superClass.SuperDelegateEvent -= superClass.CheckValue;
            superClass.Value = 3;
            Console.WriteLine();

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
