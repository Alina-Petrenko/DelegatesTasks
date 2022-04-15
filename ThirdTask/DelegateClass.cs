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
        private int _actionValue;

        /// <summary>
        /// First Func Value
        /// </summary>
        private int _firstFuncValue;

        /// <summary>
        /// Second Func Value
        /// </summary>
        private int _secondFuncValue;

        /// <summary>
        /// Third Value
        /// </summary>
        private int _predicateValue;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="DelegateClass" /> class.
        /// </summary>
        /// <param name="actionValue">First value</param>
        /// <param name="firstFuncValue">Second value</param>
        /// <param name="predicateValue">Third value</param>
        public DelegateClass(int actionValue, int firstFuncValue, int predicateValue, int secondFuncValue)
        {
            ActionValue = actionValue;
            FirstFuncValue = firstFuncValue;
            SecondFuncValue = secondFuncValue;
            PredicateValue = predicateValue;
            FirstValueChangeHandler += NotifyActionFieldsChange;
            SecondValueChangeHandler += NotifyfFirstFuncFieldsChange;
            ThirdValueChangeHandler += NotifyPredicateFieldsChange;
            FourthValueChangeHandler += NotifySecondFuncFieldsChange;
        }
        #endregion

        #region Events
        /// <summary>
        /// Event for changing the actionValue
        /// </summary>
        event Action<object, int> FirstValueChangeHandler;

        /// <summary>
        /// Event for changing the firstFuncValue
        /// </summary>
        event Func<object, int, int> SecondValueChangeHandler;

        /// <summary>
        /// Event for changing the predicateValue
        /// </summary>
        event Predicate<int> ThirdValueChangeHandler;

        /// <summary>
        /// Event for changing the secondFuncValue
        /// </summary>
        event Func<int> FourthValueChangeHandler;
        #endregion

        #region Properties
        /// <summary>
        /// First Value
        /// </summary>
        public int ActionValue
        {
            get => _actionValue;
            set
            {
                FirstValueChangeHandler?.Invoke(this, _actionValue);
                _actionValue = value;
            }
        }

        /// <summary>
        /// First Func Value
        /// </summary>
        public int FirstFuncValue
        {
            get => _firstFuncValue;
            set
            {
                SecondValueChangeHandler?.Invoke(this, _firstFuncValue);
                _firstFuncValue = value;               
            }
        }

        /// <summary>
        /// Second Func Value
        /// </summary>
        public int SecondFuncValue
        {
            get => _secondFuncValue;
            set
            {
                _firstFuncValue = value;
                FourthValueChangeHandler?.Invoke();
            }
        }

        /// <summary>
        /// Third Value
        /// </summary>
        public int PredicateValue
        {
            get => _predicateValue;
            set
            {
                _predicateValue = value;
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
            Console.WriteLine($"The value: {newSender._actionValue} was change by {newSender}!");
        }

        /// <summary>
        /// Notifies of a change in the value of one of the fields
        /// </summary>
        /// <param name="sender">The type object where the event occurred</param>
        /// <param name="value">Value that has been changed</param>
        /// <returns>Returns sum of all fields</returns>
        public int NotifyfFirstFuncFieldsChange(object sender, int value)
        {
            var newSender = sender as DelegateClass;
            var sum = _actionValue + _firstFuncValue + _predicateValue;
            Console.WriteLine($"The value: {value} was change by {newSender}! Sum: {newSender?._actionValue} + {newSender?._firstFuncValue} + {newSender?._predicateValue} + {newSender?._secondFuncValue} = {sum}");
            return sum;
        }

        /// <summary>
        /// Notifies of a change in the value of one of the fields
        /// </summary>
        /// <returns>Returns sum of all fields</returns>
        public int NotifySecondFuncFieldsChange()
        {
            var sum = _actionValue + _firstFuncValue + _predicateValue;
            Console.WriteLine($"The value was change! Sum: {_actionValue} + {_firstFuncValue} + {_predicateValue} + {_secondFuncValue} = {sum}");
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
