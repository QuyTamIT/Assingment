namespace asm_programming
{
    internal class Program
    {
        const double VAT = 0.1;
        const double ENV_FEE = 0.1;
        static void Main(string[] args)
        {
            string customerName, typeofcustomer;
            int numberOfPeople = 1;
            double lastMonthOfWater, thisMonthOfwater;
            double normalPrice;
            double totalWaterBill = 0;            
            Console.WriteLine("Please enter your customer name: ");
            customerName = Console.ReadLine();

            Console.WriteLine(" Please enter last month's water meter:");
            lastMonthOfWater = double.Parse(Console.ReadLine());

            Console.WriteLine(" Please enter this month's water meter:");
            thisMonthOfwater = double.Parse(Console.ReadLine());

            Console.WriteLine("please enter your type of customer: ");
            Console.WriteLine("-------------------");
            Console.WriteLine("1. Household customer");
            Console.WriteLine("2. Administrative agency, public services");
            Console.WriteLine("3. Production units");
            Console.WriteLine("4. Business services");
            double consumption = thisMonthOfwater - lastMonthOfWater;                      
                typeofcustomer = Console.ReadLine();
                switch (typeofcustomer)
                {
                    case "1":
                        Console.WriteLine(" Please enter your number of people:");
                        numberOfPeople = int.Parse(Console.ReadLine());
                        double totalPrice = CaculateForHouseholdCustomer(numberOfPeople, consumption);
                        totalWaterBill = GetTotalWaterBillWithFee(totalPrice);
                        break;
                    case "2":
                        normalPrice = 9955;
                        totalWaterBill = GetTotalWaterBillWithFee(consumption * normalPrice);
                        break;
                    case "3":
                        normalPrice = 11615;
                        totalWaterBill = GetTotalWaterBillWithFee(consumption * normalPrice);
                        break;
                    case "4":
                        normalPrice = 22068;
                        totalWaterBill = GetTotalWaterBillWithFee(consumption * normalPrice);
                        break;
                    default:
                        Console.WriteLine("Type of customer is invalid !!! Please enter again.");
                        Environment.Exit(0);
                        break;
                }          
            ShowInvoice(customerName, typeofcustomer, lastMonthOfWater, thisMonthOfwater, consumption, totalWaterBill);
        }
        public static double CaculateForHouseholdCustomer(int numberOfPeople, double consumption)
        {
            double avgPeople = consumption / numberOfPeople;
            double totalPrice = 0;
            if (avgPeople <=10)
            {
                totalPrice = avgPeople * 5793 * numberOfPeople;

            }
            else if (avgPeople <= 20)
            {
                totalPrice = (10 * 5973 * numberOfPeople) + ((avgPeople - 10) * 7052 * numberOfPeople);
            }
            else if (avgPeople <= 30)
            {
                totalPrice = (10 * 5973 * numberOfPeople) + (10 * 7052 * numberOfPeople) + ((avgPeople - 20) * 8699 * numberOfPeople);
            }
            else
            {
                totalPrice = (10 * 5973 * numberOfPeople) + (10 * 7052 * numberOfPeople) + (10 * 8699 * numberOfPeople) + ((avgPeople - 30) * 15929 * numberOfPeople);
            }
            return totalPrice;
        }
        public static double GetTotalWaterBillWithFee(double totalWaterBill)
        {
            double totalPriceENV = totalWaterBill + (totalWaterBill * ENV_FEE);
            double totalPriceVAT = totalPriceENV + (totalPriceENV * VAT);
            return totalPriceVAT;
        }
        public static void ShowInvoice(string? customerName, string typeOfCustomer, double lastMonth, double thisMonth, double consumption, double? totalPrice)
        {
            Console.WriteLine("----- Invoice-----");
            Console.WriteLine("Customer Name: " + customerName);
            Console.WriteLine("Type Of Customer: " + typeOfCustomer);
            Console.WriteLine("Last month's water meter: " + lastMonth);
            Console.WriteLine("This month's water meter: " + thisMonth);
            Console.WriteLine("Amount Of Consumption: " + consumption);
            Console.WriteLine("Total Water Bill: " + totalPrice);
        }
    }
}
