using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class Truck : Vehicle
    {
        private const string k_FirstQuestionForTruck = "Does your truck carry dangerous materials? Enter yes/no";
        private const string k_SecondQuestionForTruck = "What is your truck maximum carrying weight?";
        private bool m_IsCarryingDangerousMaterials;
        private float m_MaxCarryingWeight;

        public Truck(string i_Model, string i_LicensePlate, Wheel[] i_Wheels, Energy i_Engine) : base(i_Model, i_LicensePlate, i_Wheels, i_Engine)
        {
        }

        public bool IsCarryingDangerousMaterials
        {
            get
            {
                return m_IsCarryingDangerousMaterials;
            }
        }

        public float MaxCarryingWeight
        {
            get
            {
                return m_MaxCarryingWeight;
            }
        }

        public override List<string> QuestionsForSpecificVariables()
        {
            List<string> specialQuestionsForCar = new List<string>();
            specialQuestionsForCar.Add(k_FirstQuestionForTruck);
            specialQuestionsForCar.Add(k_SecondQuestionForTruck);

            return specialQuestionsForCar;
        }

        public override string ToString()
        {
            string tempString = m_IsCarryingDangerousMaterials ? "carrying" : "not carrying";

            string str = string.Format(
@"The truck is {0} dangerous materials
and the maximum carrying weight is {1}
{2}",
            tempString,
            m_MaxCarryingWeight,
            VehicleData());

            return str;
        }

        public override bool SetSpecialVariables(int i_NumberOfQuestion, string i_ValueOfVariable)
        {
            if (i_NumberOfQuestion == 1)
            {
                if (!i_ValueOfVariable.Equals("yes") && !i_ValueOfVariable.Equals("no"))
                {
                    throw new ArgumentException();
                }

                m_IsCarryingDangerousMaterials = i_ValueOfVariable.Equals("yes") ? true : false;
            }
            else
            {
                float maxCarrying;
                if (!float.TryParse(i_ValueOfVariable, out maxCarrying))
                {
                    throw new ArgumentException();
                }

                m_MaxCarryingWeight = maxCarrying;
            }

            return true;
        }
    }
}