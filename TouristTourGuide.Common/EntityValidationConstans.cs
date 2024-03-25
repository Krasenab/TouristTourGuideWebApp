
namespace TouristTourGuide.Common
{
    public static class EntityValidationConstans
    {
        public static class TouristToursConstants
        {
            public const int NameMaxLength = 50;
            public const int NameMinLength = 3;

            public const int DuarationMaxLength = 40;
            public const int DuarationMinLength = 3;

            public const int IncludesMexLenght = 5000;

            public const int InformationMaxLenght = 5000;
            

            public const double PricePerPersonMax = 100000000;
            public const double PricePerPersonMin = 1;

        }

        public static class GuideUserConstants
        {
            public const int NameMinLength = 2;
            public const int NameMaxLength = 25;

            public const int LegalFirmNameMaxLength = 80;
            public const int LegalFirmNameMinLength = 2;

            public const int CRNLenghtMax = 8;
            public const int CRNLenghtMin = 8;

            public const int VATNumberMaxLength = 15;
            public const int VATNumberMinLength = 4;

            public const int AboutMaxLength = 5000;


            public const int RegisteredAddressMaxLength = 25;
            public const int RegisteredAddressMinLength = 3;

        }

        public static class LocationConstans
        {
            public const int LocationPlaceMinLength = 2;
            public const int LocationPlaceMaxLength = 100;
        }

        public static class TouristTourBookingConstans
        {
            public const int countOfPeopleMax = 100;
            public static int countOfPeopleMin = 1;
        }
    }
}
