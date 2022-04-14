using System;

namespace ThirdTask
{
    /// <summary>
    /// Represents class for working with a delegate
    /// </summary>
    public class DelegateClass
    {
        #region Private Fields
        /// <summary>
        /// First Value
        /// </summary>
        private int _firstValue;

        /// <summary>
        /// Second Value
        /// </summary>
        private int _secondValue;

        /// <summary>
        /// Third Value
        /// </summary>
        private int _thirdValue;
        #endregion

        #region Constructors
        public DelegateClass(int firstValue, int secondValue, int thirdValue)
        {
            FirstValue = firstValue;
            SecondValue = secondValue;
            ThirdValue = thirdValue;
            FirstValueChangeHandler += NotifyActionFieldsChange;
            SecondValueChangeHandler += NotifyFuncFieldsChange;
            ThirdValueChangeHandler += NotifyPredicateFieldsChange;
        }
        #endregion

        #region Events
        /// <summary>
        /// Event for changing the first value
        /// </summary>
        event Action<object, int> FirstValueChangeHandler;

        /// <summary>
        /// Event for changing the second value
        /// </summary>
        event Func<object, int, int> SecondValueChangeHandler;

        /// <summary>
        /// Event for changing the third value
        /// </summary>
        event Predicate<int> ThirdValueChangeHandler;
        #endregion

        #region Properties
        /// <summary>
        /// First Value
        /// </summary>
        public int FirstValue
        {
            get => _firstValue;
            set
            {
                FirstValueChangeHandler?.Invoke(this, _firstValue);
                _firstValue = value;
            }
        }

        /// <summary>
        /// Second Value
        /// </summary>
        public int SecondValue
        {
            get => _secondValue;
            set
            {
                SecondValueChangeHandler?.Invoke(this, _secondValue);
                _secondValue = value;               
            }
        }

        /// <summary>
        /// Third Value
        /// </summary>
        public int ThirdValue
        {
            get => _thirdValue;
            set
            {
                _thirdValue = value;
                ThirdValueChangeHandler?.Invoke(value);
            }
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Notifies of a change in the value of one of the fields
        /// </summary>
        /// <param name="sender">The type object where the event occurred</param>
        /// <param name="value">Value that has been changed</param>
        public void NotifyActionFieldsChange(object sender, int value)
        {
            var newSender = sender as DelegateClass;
            Console.WriteLine($"The value: {newSender._firstValue} was change by {newSender}!");
        }

        /// <summary>
        /// Notifies of a change in the value of one of the fields
        /// </summary>
        /// <param name="sender">The type object where the event occurred</param>
        /// <param name="value">Value that has been changed</param>
        /// <returns>Returns sum of all fields</returns>
        public int NotifyFuncFieldsChange(object sender, int value)
        {
            var newSender = sender as DelegateClass;
            var sum = _firstValue + _secondValue + _thirdValue;
            Console.WriteLine($"The value: {value} was change by {newSender}! Sum: {newSender._firstValue} + {newSender._secondValue} + {newSender._thirdValue} = {sum}");
            return sum;
        }

        /// <summary>
        /// Notifies of a change in the value of one of the fields
        /// </summary>
        /// <param name="value">The value the field changed to<param>
        /// <returns>Returns the success value of the change</returns>
        public bool NotifyPredicateFieldsChange (int value)
        {
            Console.WriteLine($"Field was change. New value is {value}");
            return true;
        }
        #endregion
    }
}
