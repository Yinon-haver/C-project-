namespace Ex03.GarageLogic
{
    public abstract class Energy
    {
        private float m_RemainingEnergy = 0;
        private float m_MximumEnergy = 0;

        public float remainingEnergy
        {
            get
            {
                return m_RemainingEnergy;
            }
        }

        public float maximumEnergy
        {
            get
            {
                return m_MximumEnergy;
            }
        }

        public Energy(float i_MaximumEnergy)
        {
            m_RemainingEnergy = 0;
            m_MximumEnergy = i_MaximumEnergy;
        }

        protected void EnergyAddition(float i_EnergyToAdd)
        {
            // Checks if energy addition to the tank/battery exceeds the maximum capacity
            if (m_RemainingEnergy + i_EnergyToAdd > m_MximumEnergy)
            {
                throw new ValueOutOfRangeException(0, m_MximumEnergy);
            }

            m_RemainingEnergy += i_EnergyToAdd;
        }

        public abstract override string ToString();
    }
}
