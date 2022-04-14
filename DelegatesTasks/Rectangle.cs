using System;

namespace FirstTask
{
    /// <summary>
    /// Represents rectangle
    /// </summary>
    public class Rectangle
    {
        #region Fields
        /// <summary>
        /// Event object
        /// </summary>
        private event Action<object, RectangleEventArgs> ValidationEvent;

        /// <summary>
        /// Length
        /// </summary>
        private int _length;

        /// <summary>
        /// Width
        /// </summary>
        private int _width;
        #endregion

        #region Properties
        /// <summary>
        /// Length
        /// </summary>
        public int Length
        {
            // TODO: Before
            // get { return _length; }
            // TODO: After
            get => _length;

            // TODO: compare this set and in Width
            set
            {
                var rectangleEventArgs = new RectangleEventArgs
                {
                    Length = value
                };

                ValidationEvent?.Invoke(this, rectangleEventArgs);

                if (!rectangleEventArgs.Cancel)
                {
                    _length = value;
                }
            }
        }

        /// <summary>
        /// Width
        /// </summary>
        public int Width
        {
            get { return _width; }

            set
            {
                var rectangleEventArgs = new RectangleEventArgs();
                rectangleEventArgs.Length = value;
                ValidationEvent.Invoke(this, rectangleEventArgs);
                if (!rectangleEventArgs.Cancel)
                {
                    _width = value;
                }

            }
        }
        #endregion

        #region Constructors
        /// <summary>
        /// Sets initial values
        /// </summary>
        /// <param name="length">Length</param>
        /// <param name="width">Width</param>
        public Rectangle(int length, int width)
        {
            // TODO: sender is never used. Change to "_"
            ValidationEvent += (sender, events) =>
            {
                // TODO: Read this
                // https://stackoverflow.com/questions/35301/what-is-the-difference-between-the-and-or-operators
                if (width <= 0 | length <= 0)
                {
                    events.Cancel = true;
                }
            };
            Length = length;
            Width = width;
        }
        #endregion
    }
}