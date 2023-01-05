using System.Text.RegularExpressions;

namespace UtmBuilder.Core.ValuesObjects.Exceptions
{
    public class InvalidCampaignException : Exception
    {
        private const string DefaultUrlErrorMessage = "Invalid UTM parameters";
        public InvalidCampaignException(string message = DefaultUrlErrorMessage) : base(message)
        {

        }


        public static void ThrowIfNUll(string? item, string message = DefaultUrlErrorMessage)
        {
            if (string.IsNullOrEmpty(item))
                throw new InvalidCampaignException(message);
        }
    }
}