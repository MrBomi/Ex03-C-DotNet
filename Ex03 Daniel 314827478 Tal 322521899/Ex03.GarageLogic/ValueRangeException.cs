using System;

namespace Ex03.GarageLogic
{
    public class ValueRangeException : Exception
    {
        private readonly float r_MaxValue;
        private readonly float r_MinValue;

        public ValueRangeException(float i_MaxValue, float i_MinValue, string i_Msg) : 
            base (i_Msg ?? String.Format($"The value should be in the range of  {i_MinValue} - {i_MaxValue}"))
        {
            r_MaxValue = i_MaxValue;
            r_MinValue = i_MinValue;
        }
    }
}
