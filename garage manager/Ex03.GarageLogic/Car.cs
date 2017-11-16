using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class Car : Vehicle
    {
        private const int k_MinimumEnumValue = 1;
        private readonly string r_FirstQuestionForCar = string.Format("what is the color of your car?{0}{1}", Environment.NewLine, GarageManager.PrintEnumValues(typeof(eColorOfCar)));
        private readonly string r_SecondQuestionForCar = string.Format("how many doors your car has?{0}{1}", Environment.NewLine, GarageManager.PrintEnumValues(typeof(eNumberOfDoors)));
        private eColorOfCar m_ColorOfCar;
        private eNumberOfDoors m_NumberOfDoors;

        public Car(string i_Model, string i_LicensePlate, Wheel[] i_Wheels, Energy i_Engine) : base(i_Model, i_LicensePlate, i_Wheels, i_Engine)
        {
        }

        public override List<string> QuestionsForSpecificVariables()
        {
            List<string> specialQuestionsForCar = new List<string>();
            specialQuestionsForCar.Add(r_FirstQuestionForCar);
            specialQuestionsForCar.Add(r_SecondQuestionForCar);

            return specialQuestionsForCar;
        }

        public override bool SetSpecialVariables(int i_NumberOfQuestion, string i_ValueOfVariable)
        {
            const int k_MinimumDoorsValue = 2;
            int indexOfValue;
            int maxNumberOfColors = Enum.GetValues(typeof(eColorOfCar)).Length;
            int maxNumberOfDoors = Enum.GetValues(typeof(eNumberOfDoors)).Length - 1 + k_MinimumDoorsValue;
            if (i_NumberOfQuestion == 1)
            {
                if (int.TryParse(i_ValueOfVariable, out indexOfValue))
                {
                    if (indexOfValue >= k_MinimumEnumValue && indexOfValue <= maxNumberOfColors)
                    {
                        m_ColorOfCar = (eColorOfCar)Enum.Parse(typeof(eColorOfCar), i_ValueOfVariable);
                    }
                    else
                    {
                        throw new ValueOutOfRangeException(k_MinimumEnumValue, maxNumberOfColors);
                    }
                }
                else
                {
                    throw new FormatException();
                }
            }
            else
            {
                if (int.TryParse(i_ValueOfVariable, out indexOfValue))
                {
                    if (indexOfValue >= k_MinimumDoorsValue && indexOfValue <= maxNumberOfDoors)
                    {
                        m_NumberOfDoors = (eNumberOfDoors)Enum.Parse(typeof(eNumberOfDoors), i_ValueOfVariable);
                    }
                    else
                    {
                        throw new ValueOutOfRangeException(k_MinimumEnumValue, maxNumberOfDoors);
                    }
                }
                else
                {
                    throw new FormatException();
                }
            }

            return true;
        }

        public override string ToString()
        {
            string vehicleData = VehicleData();
            string str = string.Format("The Color of the car is {0}, and the number of doors is {1}.{2}{3}", m_ColorOfCar, (int)m_NumberOfDoors, Environment.NewLine, vehicleData);
            return str;
        }

        public enum eColorOfCar
        {
            Yellow = 1,
            White = 2,
            Black = 3,
            Blue = 4
        }

        public enum eNumberOfDoors
        {
            Two = 2,
            Three = 3,
            Four = 4,
            Five = 5
        }
    }
}