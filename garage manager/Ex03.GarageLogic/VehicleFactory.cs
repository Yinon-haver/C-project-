namespace Ex03.GarageLogic
{
    public class VehicleFactory
    {
        private const float k_MaximumAirPressureForMotorcycle = 33f;
        private const float k_MaximumAirPressureForCar = 30f;
        private const float k_mMximumAirPressureForTruck = 32f;
        private const int k_NumberOfWheelsForMotorcycle = 2;
        private const int k_NumberOfWheelsForCar = 4;
        private const int k_NumberOfWheelsForTruck = 12;

        public Vehicle CreateVehicle(eVehicleType i_VehicleType, string i_Model, string i_LicensePlate, string i_WheelManufacturer, float i_CurentAirPreasure, float i_CurrentEnergy)
        {
            Vehicle vehicle = null;
            switch (i_VehicleType)
            {
                case eVehicleType.NormalMotorcycle:
                    vehicle = CreateNormalMotorcycle(i_Model, i_LicensePlate, i_WheelManufacturer, i_CurentAirPreasure, i_CurrentEnergy);
                    break;
                case eVehicleType.ElectricMotorcycle:
                    vehicle = CreateElectricMotorcycle(i_Model, i_LicensePlate, i_WheelManufacturer, i_CurentAirPreasure, i_CurrentEnergy);
                    break;
                case eVehicleType.ElectricCar:
                    vehicle = CreateElectricCar(i_Model, i_LicensePlate, i_WheelManufacturer, i_CurentAirPreasure, i_CurrentEnergy);
                    break;
                case eVehicleType.NormalCar:
                    vehicle = CreateNormalCar(i_Model, i_LicensePlate, i_WheelManufacturer, i_CurentAirPreasure, i_CurrentEnergy);
                    break;
                case eVehicleType.Truck:
                    vehicle = CreateTruck(i_Model, i_LicensePlate, i_WheelManufacturer, i_CurentAirPreasure, i_CurrentEnergy);
                    break;

                // Method should not get to this default
                default:
                    break;
            }

            return vehicle;
        }

        private Truck CreateTruck(string i_VehicleModel, string i_LicensePlate, string i_WheelManufacturer, float i_CurentAirPressure, float i_CurrentEnergy)
        {
            FuelEngine.eFuelType fuelTypeForTruck = FuelEngine.eFuelType.Octan96;
            const float k_MaximumTankCapacity = 135f;
            Wheel[] wheels = new Wheel[k_NumberOfWheelsForTruck];
            for (int i = 0; i < k_NumberOfWheelsForTruck; i++)
            {
                wheels[i] = new Wheel(i_WheelManufacturer, k_mMximumAirPressureForTruck);
                wheels[i].WheelInflation(i_CurentAirPressure);
            }

            FuelEngine fuelEngine = new FuelEngine(fuelTypeForTruck, k_MaximumTankCapacity);
            fuelEngine.FuelAddition(fuelTypeForTruck, i_CurrentEnergy);
            Truck newTruck = new Truck(i_VehicleModel, i_LicensePlate, wheels, fuelEngine);

            return newTruck;
        }

        private Car CreateNormalCar(string i_VehicleModel, string i_LicensePlate, string i_WheelManufacturer, float i_CurentAirPreasure, float i_CurrentEnergy)
        {
            FuelEngine.eFuelType fuelType = FuelEngine.eFuelType.Octan98;
            const float k_MaxTankCapacity = 42f;
            FuelEngine fuelEngine = new FuelEngine(fuelType, k_MaxTankCapacity);
            fuelEngine.FuelAddition(fuelType, i_CurrentEnergy);
            Car car = CreateCar(i_VehicleModel, i_LicensePlate, i_WheelManufacturer, fuelEngine, i_CurentAirPreasure);

            return car;
        }

        private Car CreateElectricCar(string i_VehicleModel, string i_LicensePlate, string i_wWeelManufacturer, float i_CurentAirPreasure, float i_CurrentEnergy)
        {
            const float k_MaxBatteryHours = 2.5f;
            ElectricEngine electricEngine = new ElectricEngine(k_MaxBatteryHours);
            electricEngine.HoursOfElectricityAddition(i_CurrentEnergy);
            Car car = CreateCar(i_VehicleModel, i_LicensePlate, i_wWeelManufacturer, electricEngine, i_CurentAirPreasure);

            return car;
        }

        private Car CreateCar(string i_VehicleModel, string i_LicensePlate, string i_WheelManufacturer, Energy i_Engine, float i_CurentAirPreasure)
        {
            Wheel[] wheels = new Wheel[k_NumberOfWheelsForCar];
            for (int i = 0; i < k_NumberOfWheelsForCar; i++)
            {
                wheels[i] = new Wheel(i_WheelManufacturer, k_MaximumAirPressureForCar);
                wheels[i].WheelInflation(i_CurentAirPreasure);
            }

            Car newCar = new Car(i_VehicleModel, i_LicensePlate, wheels, i_Engine);

            return newCar;
        }

        private Motorcycle CreateElectricMotorcycle(string i_VehicleModel, string i_LicensePlate, string i_WheelManufacturer, float i_CurentAirPreasure, float i_currentEnergy)
        {
            const float k_maxBatteryHours = 2.7f;
            ElectricEngine electricEngine = new ElectricEngine(k_maxBatteryHours);
            electricEngine.HoursOfElectricityAddition(i_currentEnergy);
            Motorcycle motorcycle = CreateMotorcycle(i_VehicleModel, i_LicensePlate, i_WheelManufacturer, electricEngine, i_CurentAirPreasure);

            return motorcycle;
        }

        private Motorcycle CreateNormalMotorcycle(string i_VehicleModel, string i_LicensePlate, string i_WheelManufacturer, float i_CurentAirPreasure, float i_CurrentEnergy)
        {
            FuelEngine.eFuelType fuelType = FuelEngine.eFuelType.Octan95;
            const float k_maxTankCapacity = 5.5f;
            FuelEngine fuelEngine = new FuelEngine(fuelType, k_maxTankCapacity);
            fuelEngine.FuelAddition(fuelType, i_CurrentEnergy);
            Motorcycle motorcycle = CreateMotorcycle(i_VehicleModel, i_LicensePlate, i_WheelManufacturer, fuelEngine, i_CurentAirPreasure);

            return motorcycle;
        }

        private Motorcycle CreateMotorcycle(string i_VehicleModel, string i_LicensePlate, string i_WheelManufacturer, Energy i_Engine, float i_CurentAirPreasure)
        {
            Wheel[] wheels = new Wheel[k_NumberOfWheelsForMotorcycle];
            for (int i = 0; i < k_NumberOfWheelsForMotorcycle; i++)
            {
                wheels[i] = new Wheel(i_WheelManufacturer, k_MaximumAirPressureForMotorcycle);
                wheels[i].WheelInflation(i_CurentAirPreasure);
            }

            Motorcycle newMotorcycle = new Motorcycle(i_VehicleModel, i_LicensePlate, wheels, i_Engine);

            return newMotorcycle;
        }

        public enum eVehicleType
        {
            NormalMotorcycle = 1,
            ElectricMotorcycle = 2,
            NormalCar = 3,
            ElectricCar = 4,
            Truck = 5
        }
    }
}