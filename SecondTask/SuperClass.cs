using System;

namespace SecondTask
{
    /// <summary>
    /// Represents delegate
    /// </summary>
    /// <param name="value">Value</param>
    public delegate void SuperDelegate(int value);

    /// <summary>
    /// Represents class for working with a delegate
    /// </summary>
    public class SuperClass
    {
        #region Fields
        /// <summary>
        /// Event
        /// </summary>
        public event SuperDelegate SuperDelegateEvent;

        /// <summary>
        /// Value
        /// </summary>
        private int _value;
        #endregion

        #region Properties
        /// <summary>
        /// Value
        /// </summary>
        public int Value
        {
            get
            {
                return _value;
            }
            set 
            {
                _value = value;
                SuperDelegateEvent?.Invoke(value);
            }
        }
        #endregion

        #region Constructors
        /// <summary>
        /// Sets initial value of field
        /// </summary>
        /// <param name="value">Value</param>
        public SuperClass(int value)
        {
            Value = value;
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Compares the <paramref name="value"/> to zero
        /// </summary>
        /// <param name="value">Value</param>
        public void CheckValue(int value)
        {
            // TODO: Before
            //if (value > 0)
            //{
            //    Console.WriteLine("Bigger than 0"); 
            //}
            //else if (value < 0)
            //{
            //    Console.WriteLine("Less than 0");
            //}
            //else
            //{
            //    Console.WriteLine("Equal");
            //}

            // TODO: After
            switch (value)
            {
                case > 0:
                    Console.WriteLine("Bigger than 0");
                    break;
                case < 0:
                    Console.WriteLine("Less than 0");
                    break;
                default:
                    Console.WriteLine("Equal");
                    break;
            }
        }

        /// <summary>
        /// Prints the string representation of the <paramref name="value"/> to the console
        /// </summary>
        /// <param name="value">Value</param>
        public void PrintStringRepresentation(int value)
        {
            Console.WriteLine($"In string type: {value}");
        }
        #endregion
    }
}
