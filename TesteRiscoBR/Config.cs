using static TesteRiscoBR.Trade;

namespace TesteRiscoBR
{
    internal class Config
    {
        public static void addingCategoryTrade(List<CategoryTrade> detCategory)
        {

            //1: If payment delayed above 30 days, result is EXPIRED
            detCategory.Add(new CategoryTrade()
            {
                dayPaymentDelayed = 30,
                higherValue = 0,
                sectorCustomer = "",
                result = "EXPIRED"
            });

            //2: If Private, and value above 1000000, result is HIGHRISK
            detCategory.Add(new CategoryTrade()
            {
                dayPaymentDelayed = 0,
                higherValue = 1000000,
                sectorCustomer = "Private",
                result = "HIGHRISK"
            });

            //3: If Public, and value above 1000000, result is MEDIUMRISK
            detCategory.Add(new CategoryTrade()
            {
                dayPaymentDelayed = 0,
                higherValue = 1000000,
                sectorCustomer = "Public",
                result = "MEDIUMRISK"
            });

            //4: From item 4, is possible to increase new parameters, as per example:
            detCategory.Add(new CategoryTrade()
            {
                dayPaymentDelayed = 0,
                higherValue = 400000,
                sectorCustomer = "",
                result = "LOWRISK"
            });

        }


    }
}
