using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class Motorcycle : Vehicle
    {
        private readonly string r_FirstQuestionForMotorcycle = string.Format("Which license type your motorcycle have?{0}{1}", Environment.NewLine, GarageManager.PrintEnumValues(typeof(eLicenseType)));
        private const string k_SecondQuestionForMotorcycle = "What is your motorcycle CC?";
        private eLicenseType m_LicenseType;
        private int m_Cc;

        public eLicenseType LicenseType
        {
            get
            {
                return m_LicenseType;
            }

            set
            {
                m_LicenseType = value;
            }
        }

        public int CC
        {
            get
            {
                return m_Cc;
            }

            set
            {
                m_Cc = value;
            }
        }

        public Motorcycle(string i_Model, string i_LicensePlate, Wheel[] i_Wheels, Energy i_Engine) : base(i_Model, i_LicensePlate, i_Wheels, i_Engine)
        {
        }

        public override List<string> QuestionsForSpecificVariables()
        {
            List<string> specialQuestionsForMotorcycle = new List<string>();
            specialQuestionsForMotorcycle.Add(r_FirstQuestionForMotorcycle);
            specialQuestionsForMotorcycle.Add(k_SecondQuestionForMotorcycle);

            return specialQuestionsForMotorcycle;
        }

        public override string ToString()
        {
            string str = string.Format("The license type is {0} and the CC is {1}.{2}{3}", m_LicenseType, m_Cc, Environment.NewLine, VehicleData());
            return str;
        }

        public override bool SetSpecialVariables(int i_NumberOfQuestion, string i_ValueOfVariable)
        {
            int indexOfValue;
            int maxNumberOfLicenses = Enum.GetValues(typeof(eLicenseType)).Length;
            if (i_NumberOfQuestion == 1)
            {
                if (int.TryParse(i_ValueOfVariable, out indexOfValue))
                {
                    if (indexOfValue >= 1 && indexOfValue <= maxNumberOfLicenses)
                    {
                        m_LicenseType = (eLicenseType)indexOfValue;
                    }
                    else
                    {
                        throw new ValueOutOfRangeException(1, maxNumberOfLicenses);
                    }
                }
                else
                {
                    throw new FormatException();
                }
            }
            else
            {
                {
                    int cc;
                    if (int.TryParse(i_ValueOfVariable, out cc))
                    {
                        if (cc > 0)
                        {
                            m_Cc = cc;
                        }
                        else
                        {
                            throw new ValueOutOfRangeException();
                        }
                    }
                    else
                    {
                        throw new FormatException();
                    }
                }
            }

            return true;
        }

        public enum eLicenseType
        {
            A = 1,
            AB = 2,
            A2 = 3,
            B1 = 4
        }
    }
}