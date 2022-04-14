using System;

namespace FirstTask
{
    /// <summary>
    /// Starts the project
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Sets values for rectangle
        /// </summary>
        static void Main()
        {
            var isRunning = true;
            var width = 1;
            var length = 1;
            while (isRunning)
            {
                Console.Write("Set width: ");
                var isSuccess = int.TryParse(Console.ReadLine(), out width);
                if (!isSuccess || width == 0)
                {
                    Console.WriteLine("Wrong value");
                    continue;
                }

                Console.Write("Set length: ");
                isSuccess = int.TryParse(Console.ReadLine(), out length);
                if (!isSuccess || length == 0)
                {
                    Console.WriteLine("Wrong value");
                    continue;
                }

                var rectangle = new Rectangle(width, length);
                Console.WriteLine($"Width: {rectangle.Width}, Length: {rectangle.Length}");

                Console.WriteLine("Print N/n to exit, and any character to continue");
                var answer = Console.ReadLine();
                if (string.Equals(answer, "n", StringComparison.InvariantCultureIgnoreCase))
                {
                    isRunning = false;
                }
            }
        }
    }
}
