namespace TouristTourGuide.Common
{
    public static class EntityValidationConstans
    {
        /// <summary>
        /// CRNs are always 8 characters long. These can be either 8 digits or 2 letters followed by 6 digits.
        /// </summary>
        public static class TouristToursConstants
        {
            public const int NameMaxLength = 50;
            public const int NameMinLength = 3;

            public const int DuarationMaxLength = 40;
            public const int DuarationMinLength = 3;

            public const int WhatToBringMax = 5000;
            public const int WhatToBringMin = 1;

            public const int KnowBeforeYouGoMax = 5000;
            

            public const double PricePerPersonMax = 100000000;
            public const double PricePerPersonMin = 1;

            public const int NotSuitableForMaxLenght = 2000;
            public const int NotSuitableForMinLenght = 2;
        }

        public static class GuideUserConstants
        {
            public const int NameMinLength = 2;
            public const int NameMaxLength = 25;

            public const int LegalFirmNameMaxLength = 80;
            public const int LegalFirmNameMinLength = 2;

            public const int CRNLenghtMax = 8;
            public const int CRNLenghtMin = 8;
            public const string CRNpattern = @"([A-Za-z]{2}\d{6}|\d{8})";

            public const int VATNumberMaxLength = 15;
            public const int VATNumberMinLength = 4;

            public const int AboutMaxLength = 4500;


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

        public static class Comments 
        {
            public const int contentMaxLength = 5000;
            public const int contentMinLength = 1;
        }

        public static class VoteValueConstans 
        {
            public const int VoteValueMax = 5;
            public const int VoteValueMin = 1;
        }
    }
}
