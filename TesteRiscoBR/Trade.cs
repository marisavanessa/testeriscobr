using System.Collections;
using System.Globalization;
using System.Text.Json;

namespace TesteRiscoBR
{
    internal class Trade
    {

        public class CategoryTrade
        {
            public double? dayPaymentDelayed { get; set; }
            public double? higherValue { get; set; }
            public string? sectorCustomer { get; set; }
            public string? result { get; set; }
        }

        public interface ITrade
        {
            double Value { get; }
            string ClientSector { get; }
            DateTime NextPaymentDate { get; }
        }

        public enum InputLine
        {
            VALUE,
            CLIENTSECTOR,
            NEXTPAYMENTDATE
        };

        public static void Main(string[] args)
        {


            //American format date, and decimal point
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");

            //1: Read (out inputDate, @referenceDate)

            //Inputing referenceDate 
            DateTime referenceDate;
            while (!DateTime.TryParse(Console.ReadLine(), out referenceDate))
            {
                Console.WriteLine("Incorrect Date!"); //Exception
            }

            int n;
            while (!int.TryParse(Console.ReadLine(), out n))
            {
                Console.WriteLine("Incorrect number!"); //Exception
            }

            ArrayList inputTrade = new ArrayList();  // All input data

            int i = 0;
            double parsedValue;             //Only for validation input
            DateTime parsedDateValue;       //Only for validation input
            while (i < n)
            {
                string inputLine = Console.ReadLine();

                //Validations
                //InputLine.VALUE validates its type for integer
                //InputLine.CLIENTSECTOR its free, no validate
                //InputLine.NEXTPAYMENTDATE validates format american date MM/dd/yyyy

                string[] vInputLine = inputLine.Split();

                if (vInputLine.Length != 3){
                    Console.WriteLine("The detail format is: '999999.99 <Public/Private> MM/dd/yyyy'");
                    continue;
                } else if (!double.TryParse(vInputLine[(int)InputLine.VALUE], out parsedValue))
                {
                    Console.WriteLine("The first parameter of detail should be a number!");
                } else if (!DateTime.TryParse(vInputLine[(int)InputLine.NEXTPAYMENTDATE], out parsedDateValue))
                {
                    Console.WriteLine("The third parameter of detail should be a date, in format 'MM/dd/yyyy'!");
                }


                inputTrade.Add(inputLine);
                i++;

            }

            //2: Preparing files (out detCategory)

            //Preparing to read file in attachment
            string fileName = "../../../files/config.json";
            using FileStream openStream = File.OpenRead(fileName);

            var categoryTrade =
                JsonSerializer.Deserialize<IEnumerable<CategoryTrade>>(openStream);
            List<CategoryTrade> detCategory = new List<CategoryTrade>();

            foreach (var itemCT in categoryTrade)
            {
                //Put these in memory
                detCategory.Add(new CategoryTrade()
                {
                    dayPaymentDelayed = itemCT?.dayPaymentDelayed,
                    higherValue = itemCT?.higherValue,
                    sectorCustomer = itemCT?.sectorCustomer,
                    result = itemCT?.result
                });
            }

            //3: Printing results (inputTrade, detCategory, referenceDate)

            //Exit
            foreach (string itemInput in inputTrade)
            {
                string[] vInputLine = itemInput.Split();
                double.TryParse(vInputLine[(int)InputLine.VALUE], out parsedValue);
                DateTime.TryParse(vInputLine[(int)InputLine.NEXTPAYMENTDATE], out parsedDateValue);
                TimeSpan diffDueDate = referenceDate - parsedDateValue; //Diff. between RefDate and DueDate

                //Será aqui toda a varredura de detCategory
                string printOut = "";

                // Looping through the outer array
                foreach(var line in detCategory)
                {

                    if ((line.dayPaymentDelayed == 0 ? true : (diffDueDate.Days > line.dayPaymentDelayed))
                        &&
                        ((line.sectorCustomer.Equals("") ? true : line.sectorCustomer.Equals(vInputLine[1])))
                        &&
                        (line.higherValue == 0 ? true : (parsedValue > line.higherValue)))
                    {
                        printOut = line.result;
                        break;
                    }
                }

                //Final result
                Console.WriteLine(printOut);

            }

        }
    }
}
