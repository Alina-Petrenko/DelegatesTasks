using System;

namespace ThirdTask
{
    /// <summary>
    /// Represents class for working with a delegates
    /// </summary>
    public class DelegateClass
    {
        #region Private Fields
        /// <summary>
        /// First Value
        /// </summary>
        private int _actionValue;

        /// <summary>
        /// Second Value
        /// </summary>
        private int _funcValue;

        /// <summary>
        /// Third Value
        /// </summary>
        private int _predicateValue;
        #endregion

        #region Constructors
        // TODO: constructor should has summary too
        /// <summary>
        /// Initializes a new instance of the <see cref="DelegateClass" /> class.
        /// </summary>
        /// <param name="actionValue">First value</param>
        /// <param name="funcValue">Second value</param>
        /// <param name="predicateValue">Third value</param>
        public DelegateClass(int actionValue, int funcValue, int predicateValue)
        {
            ActionValue = actionValue;
            FuncValue = funcValue;
            PredicateValue = predicateValue;
            ActionChangeHandler += NotifyActionFieldsChange;
            FuncChangeHandler += NotifyFuncFieldsChange;
            PredicateChangeHandler += NotifyPredicateFieldsChange;
        }
        #endregion

        #region Events
        /// <summary>
        /// Event for changing the <see cref="ActionValue"/>
        /// </summary>
        event Action<object, int> ActionChangeHandler;

        // TODO: step 3 of the task is missed

        /// <summary>
        /// Event for changing the <see cref="FuncValue"/>
        /// </summary>
        event Func<object, int, int> FuncChangeHandler;

        /// <summary>
        /// Event for changing the <see cref="PredicateValue"/>
        /// </summary>
        event Predicate<int> PredicateChangeHandler;
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
                ActionChangeHandler?.Invoke(this, _actionValue);
                _actionValue = value;
            }
        }

        /// <summary>
        /// Second Value
        /// </summary>
        public int FuncValue
        {
            get => _funcValue;
            set
            {
                FuncChangeHandler?.Invoke(this, _funcValue);
                _funcValue = value;               
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
                PredicateChangeHandler?.Invoke(value);
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
            // TODO: cast to type could make newSender = null
            // TODO: need check for null
            // TODO: Before
            // Console.WriteLine($"The value: {newSender._actionValue} was change by {newSender}!");
            // TODO: After
            Console.WriteLine($"The value: {newSender?._actionValue} was change by {newSender}!");
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
            var sum = _actionValue + _funcValue + _predicateValue;
            Console.WriteLine($"The value: {value} was change by {newSender}! Sum: {newSender._actionValue} + {newSender._funcValue} + {newSender._predicateValue} = {sum}");
            return sum;
        }

        /// <summary>
        /// Notifies of a change in the value of one of the fields
        /// </summary>
        /// <param name="value">The value the field changed to.</param>
        /// <returns>Returns the success value of the change</returns>
        public bool NotifyPredicateFieldsChange (int value)
        {
            Console.WriteLine($"Field was change. New value is {value}");
            return true;
        }
        #endregion
    }
}
