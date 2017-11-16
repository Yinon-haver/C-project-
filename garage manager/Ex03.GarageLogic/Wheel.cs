namespace Ex03.GarageLogic
{
    public class Wheel
    {
        private readonly string r_WheelModel;
        private readonly float r_MaxAirPressure;
        private float m_airPressure;

        public Wheel(string i_WheelModel, float i_MaxAirPressure)
        {
            r_WheelModel = i_WheelModel;
            m_airPressure = 0;
            r_MaxAirPressure = i_MaxAirPressure;
        }

        public float maxAirPressure
        {
            get
            {
                return r_MaxAirPressure;
            }
        }

        public float airPressure
        {
            get
            {
                return m_airPressure;
            }
        }

        public string wheelModel
        {
            get
            {
                return r_WheelModel;
            }
        }

        public void WheelInflation(float i_AirToAdd)
        {
            // checks if air addition to the wheel exceeds the max air pressure
            if (m_airPressure + i_AirToAdd > r_MaxAirPressure)
            {
                throw new ValueOutOfRangeException(0, r_MaxAirPressure);
            }

            m_airPressure += i_AirToAdd;
        }

        public override string ToString()
        {
            string str = string.Format("The wheel's manufacturer is {0} and the current air pressure is {1}.", r_WheelModel, m_airPressure);
            return str;
        }
    }
}
