using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        private const int k_ConstHundred = 100;
        private string m_Model;
        private string m_LicensePlate;
        private Wheel[] m_Wheels;
        private Energy m_Engine;

        public float remainingEnergyPercentage
        {
            get
            {
                return m_Engine.remainingEnergy / m_Engine.maximumEnergy;
            }
        }

        public Wheel[] wheels
        {
            get
            {
                return m_Wheels;
            }
        }

        public string licensePlate
        {
            get
            {
                return m_LicensePlate;
            }
        }

        public Energy engine
        {
            get
            {
                return m_Engine;
            }
        }

        public Vehicle(string i_Model, string i_LicensePlate, Wheel[] i_Wheels, Energy i_Engine)
        {
            m_Model = i_Model;
            m_LicensePlate = i_LicensePlate;
            m_Wheels = i_Wheels;
            m_Engine = i_Engine;
        }

        // abstract methods
        public abstract List<string> QuestionsForSpecificVariables();

        public abstract bool SetSpecialVariables(int i_IndexOfVariable, string i_ValueOfVariable);

        public abstract override string ToString();

        public string VehicleData()
        {
            string engineStr = (m_Engine is FuelEngine) ? ((FuelEngine)m_Engine).ToString() : ((ElectricEngine)m_Engine).ToString();
            string engineStatus = string.Format("The remaining energy percentage is {0:0.00}%", remainingEnergyPercentage * k_ConstHundred);
            string str = string.Format(
            @"The license plate is {0} and the model is {1}
            {2}
            {3}
            {4}",
            m_LicensePlate,
            m_Model,
            wheels[0].ToString(),
            engineStr,
            engineStatus);

            return str;
        }
    }
}