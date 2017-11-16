using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    public class UIManager
    {
        // constant variables
        private const int k_MinIndexForEnums = 1;
        private const int k_ExitInput = 0;

        // constant messages
        private const string k_VehicleTypeQuestion = "What is your vehicle type?";
        private const string k_ModelGeneralQuestionForVehicle = "What is your vehicle model?";
        private const string k_LicenseGeneralQuestionForVehicle = "What is your vehicle license plate?";
        private const string k_ManufacturerGeneralQuestionForVehicle = "What is your wheels manufacturer?";
        private const string k_AirPressureGeneralQuestionForVehicle = "What is your wheels current air pressure?";
        private const string k_EnergyGeneralQuestionForVehicle = "How much energy do you have left?";
        private const string k_NameGeneralQuestionForVehicle = "What is your name?";
        private const string k_PhoneGeneralQuestionForVehicle = "what is your phone number";
        private const string k_EnteredWrongInput = "Please enter a valid input";
        private const string k_WrongEngineMessage = "The engine is not compatible";
        private const string k_InvalidRangeMessage = "There was a problem with the information, please reenter information";
        private string k_SuccessMessage = string.Format("Success !{0}", Environment.NewLine);

        private GarageManager m_GarageManager;

        // UIConsole constructor
        public UIManager()
        {
            m_GarageManager = new GarageManager();
        }

        /// <summary>
        /// shows to the user the different
        /// actions to do in the garage
        /// and returns the number selected by the user
        /// </summary>
        /// <returns>
        /// numberOfServiceToPerform
        /// </returns>
        public int ChooseService()
        {
            string serviceMenu = string.Format(
   @"Please choose one of the following options: 
  1) Insert a new vehicle to the garage
  2) Show the license plates of the cars that are in the garage
  3) Change a vehicle status
  4) Inflate air to maximum capacity in a specific vehicle
  5) Refuel a vehicle
  6) Recharge a vehicle
  7) Show full information of a vehicle
  0) Exit
  ");
            Console.WriteLine(serviceMenu);

            int numberOfServiceToPerform = getValidInputForIntVarriable(k_ExitInput, m_GarageManager.numberOfSupportedOperations);

            return numberOfServiceToPerform;
        }

        /// <summary>
        /// receives the minimum and maximal values
        /// and checks if the input from user
        /// is between them and numeric
        /// </summary>
        /// <param name="i_min"></param>
        /// <param name="i_max"></param>
        /// <returns>
        /// a valid number chosen by user
        /// </returns>
        private int getValidInputForIntVarriable(int i_min, int i_max)
        {
            int inputNumber;
            string inputMassage = string.Format("Please enter a number between {0} and {1}", i_min, i_max);
            Console.WriteLine(inputMassage);
            while (true)
            {
                bool isParseSucceed = int.TryParse(Console.ReadLine(), out inputNumber);
                if (isParseSucceed && (inputNumber >= i_min) && (inputNumber <= i_max))
                {
                    break;
                }

                Console.WriteLine(k_EnteredWrongInput);
            }

            return inputNumber;
        }

        /// <summary>
        /// loop for doing services until the user
        /// press 0 for exiting
        /// </summary>
        public void StartService()
        {
            Console.WriteLine("Welcome to our garage!\n");
            while (true)
            {
                int numberOServiceToPerform = ChooseService();
                if (numberOServiceToPerform == k_ExitInput)
                {
                    Console.WriteLine("Thank you! Please come again!\n");
                    break;
                }

                PerformService(numberOServiceToPerform);
            }
        }

        /// <summary>
        /// receives a number of an service
        /// and activates it
        /// </summary>
        /// <param name="numberOServiceToPerform"></param>
        private void PerformService(int numberOServiceToPerform)
        {
            switch (numberOServiceToPerform)
            {
                case 1:
                    InsertNewVehicle();
                    break;
                case 2:
                    ShowLicensePlates();
                    break;
                case 3:
                    ChangeVehicleStatus();
                    break;
                case 4:
                    InflateWheels();
                    break;
                case 5:
                    RefuelVehicle();
                    break;
                case 6:
                    RechargeVehicle();
                    break;
                case 7:
                    ShowFullInformation();
                    break;
            }
        }

        /// <summary>
        /// inserts a new vehicle to the garage with the whole
        /// client's data
        /// </summary>
        private void InsertNewVehicle()
        {
            int vehicleType = getEnumValue(k_VehicleTypeQuestion, typeof(VehicleFactory.eVehicleType));
            string modelVehicle;
            string licensePlate;
            string wheelManufacturer;
            string ownersName;
            string ownersPhoneNumber;
            float currentAirPressure;
            float currentEnergy;

            GetAnswerForQuestion(k_LicenseGeneralQuestionForVehicle, out licensePlate);
            GetAnswerForQuestion(k_VehicleTypeQuestion, out modelVehicle);
            GetAnswerForQuestion(k_ManufacturerGeneralQuestionForVehicle, out wheelManufacturer);
            GetFloatAnswerForQuestion(k_AirPressureGeneralQuestionForVehicle, out currentAirPressure);
            GetFloatAnswerForQuestion(k_EnergyGeneralQuestionForVehicle, out currentEnergy);
            Vehicle newVehicle = null;

            try
            {
                newVehicle = m_GarageManager.CreateVehicle((VehicleFactory.eVehicleType)vehicleType, modelVehicle, licensePlate, wheelManufacturer, currentAirPressure, currentEnergy);
                if (m_GarageManager.IsVehicleIngarage(newVehicle.licensePlate))
                {
                    Console.WriteLine("Your car is already in the garage, we will repair it again!");
                    m_GarageManager.FindClient(newVehicle.licensePlate).ChangeStatusOfVehicle(ClientData.eVehicleStatusInGarage.Repairing);
                    return;
                }
            }
            catch (ValueOutOfRangeException)
            {
                Console.WriteLine(k_InvalidRangeMessage);
                return;
            }

            int indexOfQuestion = 1;

            // specific questions for each type of vehicle
            foreach (string question in newVehicle.QuestionsForSpecificVariables())
            {
                Console.WriteLine(question);
                bool isSucceed = false;
                while (!isSucceed)
                {
                    try
                    {
                        newVehicle.SetSpecialVariables(indexOfQuestion, Console.ReadLine());
                        isSucceed = true;
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine(k_EnteredWrongInput);
                    }
                    catch (ValueOutOfRangeException)
                    {
                        Console.WriteLine(k_EnteredWrongInput);
                    }
                }

                indexOfQuestion++;
            }

            GetAnswerForQuestion(k_NameGeneralQuestionForVehicle, out ownersName);
            ownersPhoneNumber = GetPhoneNumber(k_PhoneGeneralQuestionForVehicle);

            ClientData newClient = new ClientData(ownersName, ownersPhoneNumber, newVehicle);

            m_GarageManager.InsertVehicleToGarage(newClient);
            Console.WriteLine(k_SuccessMessage);
        }

        private void ShowLicensePlates()
        {
            StringBuilder filterMessage = new StringBuilder();
            filterMessage.Append(string.Format("{0}0-No filter ", GarageManager.PrintEnumValues(typeof(ClientData.eVehicleStatusInGarage)), Environment.NewLine));
            Console.WriteLine(filterMessage);
            int userInput = getValidInputForIntVarriable(0, Enum.GetValues(typeof(ClientData.eVehicleStatusInGarage)).Length);

            List<string> licenses = m_GarageManager.GetLicensePlatesAccordingToStatus(userInput);
            foreach (string license in licenses)
            {
                Console.WriteLine(license);
            }

            Console.WriteLine(k_SuccessMessage);
        }

        private void ChangeVehicleStatus()
        {
            string changeStatusMessage = string.Format("Please Enter a Licance number");
            string licensePlate;
            if (SearchVehicle(changeStatusMessage, out licensePlate))
            {
                int maxStatusNumber = Enum.GetValues(typeof(ClientData.eVehicleStatusInGarage)).Length;
                string statusMessage = string.Format("Please enter a new status to update{0} {1}", Environment.NewLine, GarageManager.PrintEnumValues(typeof(ClientData.eVehicleStatusInGarage)));
                Console.WriteLine(statusMessage);
                int userInput = getValidInputForIntVarriable(1, maxStatusNumber);
                m_GarageManager.ChangeStatusOfVehicle(licensePlate, (ClientData.eVehicleStatusInGarage)userInput);
                Console.WriteLine(k_SuccessMessage);
            }
        }

        private void InflateWheels()
        {
            string inflateMessage = "Enter the license plate number of the vehicle that you wish to inflate its wheels";
            string licensePlate;
            if (SearchVehicle(inflateMessage, out licensePlate))
            {
                m_GarageManager.InflateTires(licensePlate);
            }

            Console.WriteLine(k_SuccessMessage);
        }

        private void RefuelVehicle()
        {
            try
            {
                string refuelVehicleMessage = "Enter a license number for a vehicle to refuel";
                string licensePlate;
                if (SearchVehicle(refuelVehicleMessage, out licensePlate))
                {
                    Vehicle customerVehicle = m_GarageManager.FindClient(licensePlate).vehicle;
                    if (customerVehicle.engine is FuelEngine)
                    {
                        int numOfFuelTypes = Enum.GetValues(typeof(FuelEngine.eFuelType)).Length;
                        string fuelTypeMessage = string.Format("Which fuel type should we use?{0}{1}", Environment.NewLine, GarageManager.PrintEnumValues(typeof(FuelEngine.eFuelType)));
                        Console.WriteLine(fuelTypeMessage);
                        int userInputForFuelType = getValidInputForIntVarriable(1, numOfFuelTypes);
                        string amountTorefillMessage = "How much fuel do you wish to add?";
                        Console.WriteLine(amountTorefillMessage);
                        float amountToRefull;
                        while (!float.TryParse(Console.ReadLine(), out amountToRefull))
                        {
                            Console.WriteLine(k_InvalidRangeMessage);
                        }

                        m_GarageManager.RefuelSpecificVehicle(licensePlate, (FuelEngine.eFuelType)userInputForFuelType, amountToRefull);
                        Console.WriteLine(k_SuccessMessage);
                    }

                    else
                    {
                        Console.WriteLine(k_WrongEngineMessage);
                    }
                }
            }
            catch (ValueOutOfRangeException)
            {
                Console.WriteLine("Wrong amount to refuel, the amount entered was too much");
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Wrong fuel type entered");
            }
        }
        private void RechargeVehicle()
        {
            try
            {
                string rechargeVehicleMessage = "Enter a license number for a vehicle to recharge";
                string licensePlate;
                if (SearchVehicle(rechargeVehicleMessage, out licensePlate))
                {
                    Vehicle customerVehicle = m_GarageManager.FindClient(licensePlate).vehicle;
                    if (customerVehicle.engine is ElectricEngine)
                    {

                        string timeToRechargeMessage = "How much time to charge?";
                        Console.WriteLine(timeToRechargeMessage);
                        float timeToRecharge;
                        while (!float.TryParse(Console.ReadLine(), out timeToRecharge))
                        {
                            Console.WriteLine(k_InvalidRangeMessage);
                        }

                        m_GarageManager.RechargeSpecificVehicle(licensePlate, timeToRecharge);
                        Console.WriteLine(k_SuccessMessage);
                    }
                    else
                    {
                        Console.WriteLine(k_WrongEngineMessage);
                    }
                }
            }
            catch (ValueOutOfRangeException)
            {
                Console.WriteLine("Too much hours to recharge");
            }
            catch (ArgumentException)
            {
                Console.WriteLine(k_EnteredWrongInput);
            }
        }

        private void ShowFullInformation()
        {
            string showInformationMessage = "Enter a license number of the car you wish to get information about";
            string licensePlate;
            if (SearchVehicle(showInformationMessage, out licensePlate))
            {
                string informationMessage = string.Format("{0}{1}", m_GarageManager.FindClient(licensePlate).ToString(), Environment.NewLine);
                Console.WriteLine(informationMessage);
            }
        }

        /// <summary>
        /// checks float number validity from user's input
        /// </summary>
        /// <param name="i_question"></param>
        /// <param name="o_number"></param>
        private void GetFloatAnswerForQuestion(string i_question, out float o_number)
        {
            Console.WriteLine(i_question);
            do
            {
                bool isValidNumber = float.TryParse(Console.ReadLine(), out o_number);
                if (isValidNumber)
                {
                    break;
                }

                Console.WriteLine(k_EnteredWrongInput);
            }
            while (true);
        }

        /// <summary>
        /// checks numeric validity from user's input
        /// </summary>
        /// <param name="i_question"></param>
        private string GetPhoneNumber(string i_question)
        {
            Console.WriteLine(i_question);
            string getInputFromUser = string.Empty;
            do
            {
                getInputFromUser = Console.ReadLine();
                string validInput = "^[0-9]+[-]?[0-9]+$";
                Match match = Regex.Match(getInputFromUser, validInput);

                if (match.Success)
                {
                    break;
                }

                Console.WriteLine(k_EnteredWrongInput);
            }
            while (true);

            return getInputFromUser;
        }

        private int getEnumValue(string i_question, Type i_enumType)
        {
            Console.WriteLine(i_question);
            string enumTypeString = GarageManager.PrintEnumValues(i_enumType);
            Console.WriteLine(enumTypeString);

            return getValidInputForIntVarriable(k_MinIndexForEnums, Enum.GetValues(i_enumType).Length);
        }

        private bool SearchVehicle(string i_message, out string o_licensePlate)
        {
            bool isFounded;
            Console.WriteLine(i_message);
            string userLicensePlateInput = Console.ReadLine();
            if (!m_GarageManager.IsVehicleIngarage(userLicensePlateInput))
            {
                o_licensePlate = string.Empty;
                Console.WriteLine("The Vehicle was not found in the garage");
                isFounded = false;
            }
            else
            {
                o_licensePlate = userLicensePlateInput;
                isFounded = true;
            }

            return isFounded;
        }

        /// <summary>
        /// receives a question to show in console
        /// and return the user's answer
        /// </summary>
        /// <param name="i_question"></param>
        /// <param name="o_answer"></param>
        private void GetAnswerForQuestion(string i_question, out string o_answer)
        {
            Console.WriteLine(i_question);
            do
            {
                o_answer = Console.ReadLine();
                if (!o_answer.Equals(string.Empty))
                {
                    break;
                }

                Console.WriteLine(k_EnteredWrongInput);
            }
            while (true);
        }
    }
}