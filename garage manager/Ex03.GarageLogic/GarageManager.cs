using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class GarageManager
    {
        private const int k_NumberOfSupportedOperations = 7;
        private readonly Dictionary<string, ClientData> r_ClientList = null;
        private VehicleFactory m_vehicleCreator;


        public int numberOfSupportedOperations
        {
            get
            {
                return k_NumberOfSupportedOperations;
            }
        }

        /// <summary>
        /// parses and gets the values
        /// of a given enum type
        /// </summary>
        /// <param name="i_enum_type"></param>
        /// <returns></returns>
        public static string PrintEnumValues(Type i_EnumType)
        {
            StringBuilder listOfEnumValues = new StringBuilder();

            // Goes over each value in array of enum values
            foreach (object enumValue in Enum.GetValues(i_EnumType))
            {
                listOfEnumValues.Append(string.Format("{0}-{1}{2}", (int)enumValue, enumValue, Environment.NewLine));
            }

            return listOfEnumValues.ToString();
        }

        public GarageManager()
        {
            r_ClientList = new Dictionary<string, ClientData>();
            m_vehicleCreator = new VehicleFactory();
        }

        public Vehicle CreateVehicle(VehicleFactory.eVehicleType i_VehicleType, string i_Model, string i_LicensePlate, string i_WheelManufacturer, float i_CurentAirPreasure, float i_CurrentEnergy)
        {
            return m_vehicleCreator.CreateVehicle(i_VehicleType, i_Model, i_LicensePlate, i_WheelManufacturer, i_CurentAirPreasure, i_CurrentEnergy);
        }

        public void InsertVehicleToGarage(ClientData i_Client)
        {
            r_ClientList.Add(i_Client.vehicle.licensePlate, i_Client);
        }

        public List<string> GetLicensePlatesAccordingToStatus(int i_Status)
        {
            List<string> licensePlatesList = new List<string>();

            if (i_Status == 0)
            {
                foreach (string key in r_ClientList.Keys)
                {
                    licensePlatesList.Add(key);
                }
            }
            else
            {
                foreach (ClientData client in r_ClientList.Values)
                {
                    // Check if parsing works
                    if ((int)client.carStatus == i_Status)
                    {
                        licensePlatesList.Add(client.vehicle.licensePlate);
                    }
                }
            }

            return licensePlatesList;
        }

        public VehicleFactory.eVehicleType[] GetVehicleTypes()
        {
            return (VehicleFactory.eVehicleType[])Enum.GetValues(typeof(VehicleFactory.eVehicleType));
        }

        public void ChangeStatusOfVehicle(string i_LicensePlate, ClientData.eVehicleStatusInGarage i_Status)
        {
            ClientData client = FindClient(i_LicensePlate);
            client.ChangeStatusOfVehicle(i_Status);
        }

        public void InflateTires(string i_LicensePlate)
        {
            ClientData client = FindClient(i_LicensePlate);
            client.InflateTires(client.vehicle.wheels[0].maxAirPressure - client.vehicle.wheels[0].airPressure);
        }

        public void RefuelSpecificVehicle(string i_LicensePlate, FuelEngine.eFuelType i_FuelType, float i_QuantityToFuel)
        {
            ClientData client = FindClient(i_LicensePlate);
            client.RefuelVehicle(i_FuelType, i_QuantityToFuel);
        }

        public void RechargeSpecificVehicle(string i_LicensePlate, float i_HoursToCharge)
        {
            ClientData client = FindClient(i_LicensePlate);
            ((ElectricEngine)client.vehicle.engine).HoursOfElectricityAddition(i_HoursToCharge);
        }

        public string InformationToShow(string i_LicensePlate)
        {
            ClientData client = FindClient(i_LicensePlate);
            return client.ToString();
        }

        public ClientData FindClient(string i_LicensePlate)
        {
            ClientData client;
            r_ClientList.TryGetValue(i_LicensePlate, out client);
            return client;
        }

        public bool IsVehicleIngarage(string i_LicensePlate)
        {
            return r_ClientList.ContainsKey(i_LicensePlate);
        }
    }
}