using System;

namespace Ex03.GarageLogic
{
    public class ValueOutOfRangeException : Exception
    {
        private const string k_OutOfRangeMessage = "The current value is not in the range between {0} and {1}";
        private const string k_OutOfPositiveRangeMessage = "The current value is not in the positive range";
        private float m_MaximumRangeValue;
        private float m_MinimumRangeValue;

        // exception for a value that is out of the given range
        public ValueOutOfRangeException(float i_MinimumRangeValue, float i_MaximumRangeValue) : base(string.Format(k_OutOfRangeMessage, i_MinimumRangeValue, i_MaximumRangeValue))
        {
            m_MinimumRangeValue = i_MinimumRangeValue;
            m_MaximumRangeValue = i_MaximumRangeValue;
        }

        // exception for negative inputs when expected positive
        public ValueOutOfRangeException() : base(k_OutOfPositiveRangeMessage)
        {
        }
    }
}
