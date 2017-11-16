namespace Ex03.GarageLogic
{
    public class ClientData
    {
        private readonly string r_FullName;
        private string m_PhoneNumber;
        private Vehicle m_Vehicle;
        private eVehicleStatusInGarage m_CarStatus;

        public ClientData(string i_FullName, string i_PhoneNumber, Vehicle i_Vehicle)
        {
            r_FullName = i_FullName;
            m_PhoneNumber = i_PhoneNumber;
            m_Vehicle = i_Vehicle;
            m_CarStatus = eVehicleStatusInGarage.Repairing;
        }

        // getters
        public string fullName
        {
            get
            {
                return r_FullName;
            }
        }

        public string phoneNumber
        {
            get
            {
                return m_PhoneNumber;
            }

            set
            {
                m_PhoneNumber = value;
            }
        }

        public Vehicle vehicle
        {
            get
            {
                return m_Vehicle;
            }
        }

        public eVehicleStatusInGarage carStatus
        {
            get
            {
                return m_CarStatus;
            }

            set
            {
                m_CarStatus = value;
            }
        }

        public void ChangeStatusOfVehicle(eVehicleStatusInGarage i_Status)
        {
            m_CarStatus = i_Status;
        }

        public void RechargeVehicle(float i_HoursToCharge)
        {
            ((ElectricEngine)m_Vehicle.engine).HoursOfElectricityAddition(i_HoursToCharge);
        }

        public void RefuelVehicle(FuelEngine.eFuelType i_FuelType, float i_QuantityToFuel)
        {
            ((FuelEngine)m_Vehicle.engine).FuelAddition(i_FuelType, i_QuantityToFuel);
        }

        public void InflateTires(float i_AirPressure)
        {
            foreach (Wheel wheel in m_Vehicle.wheels)
            {
                wheel.WheelInflation(i_AirPressure);
            }
        }

        public override string ToString()
        {
            string str = string.Format(
            @"The name of the owner is {0}.
            The status of the vehicle is {1}
            {2}",
            r_FullName,
            m_CarStatus,
            m_Vehicle.ToString());

            return str;
        }

        public enum eVehicleStatusInGarage
        {
            Repairing = 1,
            Fixed = 2,
            Paid = 3
        }
    }
}