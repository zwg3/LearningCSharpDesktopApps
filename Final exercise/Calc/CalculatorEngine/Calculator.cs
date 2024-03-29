using System.Reflection;
using System.Threading;


namespace Calculator
{
    using Microsoft.SqlServer.Server;
    using System;
    using System.Runtime.Remoting.Messaging;
    using System.Threading.Tasks;
    using static Calculator.CalcEngine;

	public class CalcEngine
	{
        //
        // Operation Constants.
        //
        public enum Operator : int
		{
			eUnknown = 0,
			eAdd = 1,
			eSubtract = 2,
			eMultiply = 3,
			eDivide = 4,
			ePow = 5,
			eSqrt = 6,
			eBack = 7,
			eSquared = 8,
			eFactorial = 9,
			eCubert = 10,
		}

		//
		// Module-Level Constants
		//

		private static double negativeConverter = -1;
		// TODO: Upgrade the version number to 3.0.1.1
		private static string versionInfo = "Calculator v3.0.1.1";

		//
		// Module-level Variables.
		//

		private static double numericAnswer;
		private static string stringAnswer;
		private static Operator calcOperation;
		private static double firstNumber;
		private static double secondNumber;
		private static bool secondNumberAdded;
		private static bool decimalAdded;

		//
		// Class Constructor.
		//

		public CalcEngine()
		{
			decimalAdded = false;
			secondNumberAdded = false;
		}

		//
		// Returns the custom version string to the caller.
		//

		public static string GetVersion()
		{
			return (versionInfo);
		}
		//
		// Called when the Date key is pressed.
		//

		public static string GetDate()
		{
			DateTime curDate = new DateTime();
			curDate = DateTime.Now;

			stringAnswer = String.Concat(curDate.ToShortDateString(), " ", curDate.ToLongTimeString());

			return (stringAnswer);
		}

		//
		// Called when a number key is pressed on the keypad.
		//

		public static string CalcNumber(string KeyNumber)
		{
			stringAnswer = stringAnswer + KeyNumber;
			return (stringAnswer);
		}

		//
		// Called when an operator is selected (+, -, *, /)
		//

		public static void CalcOperation(Operator calcOper)
		{
			if (stringAnswer != "" && !secondNumberAdded)
			{
				firstNumber = System.Convert.ToDouble(stringAnswer);
				calcOperation = calcOper;
				stringAnswer = "";
				decimalAdded = false;
			}
		}

		//
		// Called when the +/- key is pressed.
		//

		public static string CalcSign()
		{
			double numHold;

			if (stringAnswer != "")
			{
				numHold = Convert.ToDouble(stringAnswer);
				stringAnswer = Convert.ToString(numHold * negativeConverter);
			}

			return (stringAnswer);
		}

		//
		// Called when the . key is pressed.
		//

		public static string CalcDecimal()
		{
			if (!decimalAdded && !secondNumberAdded)
			{
				if (stringAnswer != "")
					stringAnswer = stringAnswer + ".";
				else
					stringAnswer = "0.";

				decimalAdded = true;
			}

			return (stringAnswer);
		}

		//
		// Called when = is pressed.
		//
		public static string CalcEqual()
		{
			bool validEquation = false;

			if (stringAnswer != "")
			{
				secondNumber = Convert.ToDouble(stringAnswer);
				secondNumberAdded = true;

				switch (calcOperation)
				{
					case Operator.eUnknown:
						validEquation = false;
						break;

					case Operator.eAdd:
						numericAnswer = firstNumber + secondNumber;
						validEquation = true;
						break;

					case Operator.eSubtract:
						numericAnswer = firstNumber - secondNumber;
						validEquation = true;
						break;

					case Operator.eMultiply:
						numericAnswer = firstNumber * secondNumber;
						validEquation = true;
						break;

					case Operator.eDivide:
						numericAnswer = firstNumber / secondNumber;
						validEquation = true;
						break;

					case Operator.ePow:
						numericAnswer = Math.Pow(firstNumber, secondNumber);
						validEquation = true;
						break;

					case Operator.eSqrt:
						numericAnswer = Convert.ToDouble(Math.Sqrt(firstNumber));

						validEquation = true;
						break;

					case Operator.eBack:
						numericAnswer = 1 / firstNumber;
						validEquation = true;
						break;

					case Operator.eSquared:
						numericAnswer = Math.Pow(firstNumber, 2);
						validEquation = true;
						break;

					default:
						validEquation = false;
						break;
				}

				if (validEquation)
					stringAnswer = Convert.ToString(numericAnswer);
			}

			return (stringAnswer);
		}

		//Single number calculations

		public static string CalcEqual2()
		{
			bool validEquation = false;
			switch (calcOperation)
			{
				case Operator.eSqrt:
					numericAnswer = Convert.ToDouble(Math.Sqrt(firstNumber));

					validEquation = true;
					break;

				case Operator.eBack:
					numericAnswer = 1 / firstNumber;
					validEquation = true;
					break;

				case Operator.eSquared:
					numericAnswer = Math.Pow(firstNumber, 2);
					validEquation = true;
					break;

                case Operator.eFactorial:
                    if (firstNumber < 0)
					{
						validEquation = false;
                        break;
                    }
                    else
					{
						numericAnswer = 1;
						while (firstNumber != 1)
						{
							numericAnswer = numericAnswer * firstNumber;
							firstNumber = firstNumber - 1;
						}
						validEquation = true;
                        break;
                    }
                case Operator.eCubert:
                    numericAnswer = Math.Ceiling(Math.Pow(firstNumber, (double)1 / 3));
                    validEquation = true;
                    break;


                default:
					validEquation = false;
					break;
			}
			if (validEquation)
				stringAnswer = Convert.ToString(numericAnswer);
			return (stringAnswer);
        }
		public async static Task<string> CalcFactorial()
		{
			double num = firstNumber;
			double res;
			if (num < 0)
			{
				return await Task.Run(() =>
				{
					Thread.Sleep(5000);
					return Convert.ToString(numericAnswer);
				});
            }

			else
			{
				return await Task.Run(() =>
				{
                    res = 1;
					while (num != 1)
					{
                        res = res * num;
                        num = num - 1;
					}
					Thread.Sleep(5000);
					return Convert.ToString(res);
				});					
			}
                
		}

        //
        // Resets the various module-level variables for the next calculation.
        //
        public static void CalcReset()
		{
			numericAnswer = 0;
			firstNumber = 0;
			secondNumber = 0;
			stringAnswer = "";
			calcOperation = Operator.eUnknown;
			decimalAdded = false;
			secondNumberAdded = false;
		}

	}
}