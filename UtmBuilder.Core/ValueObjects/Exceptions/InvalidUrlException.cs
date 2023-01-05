using System.Text.RegularExpressions;

namespace UtmBuilder.Core.ValuesObjects.Exceptions
{

    public class InvalidUrlException : Exception
    {
        private const string DefaultUrlErrorMessage = "Invalid URL";
        private const string UrlRegexPatterns = @"^http(s)?://([\w-]+.)+[\w-]+(/[\w- ./?%&=])?$";
        public InvalidUrlException(string message = DefaultUrlErrorMessage) : base(message)
        {

        }

        public static void ThrowUIfInvalidUrl(string url, string message = DefaultUrlErrorMessage)
        {
            if (string.IsNullOrEmpty(url))
                throw new InvalidUrlException();
            if (!Regex.IsMatch(url, UrlRegexPatterns))
                throw new InvalidUrlException();


        }

    }


}


