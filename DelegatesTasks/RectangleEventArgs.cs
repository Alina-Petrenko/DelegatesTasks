using System;

namespace FirstTask
{
    /// <summary>
    /// Contains event data, and provides a value to use for events
    /// </summary>
    public class RectangleEventArgs : EventArgs
    {
        #region Properties
        /// <summary>
        /// Length
        /// </summary>
        public int Length { get; set; }

        /// <summary>
        /// Width
        /// </summary>
        public int Width { get; set; }

        /// <summary>
        /// Boolean value is operation Cancel
        /// </summary>
        public bool Cancel { get; set; }
        #endregion
    }
}
