using System.Text;
using utmbuilder.core.Extensions;
using UtmBuilder.Core.ValuesObjects;
using UtmBuilder.Core.ValuesObjects.Exceptions;

namespace UtmBuilder.Core
{
    public class Utm
    {
        public Utm(Url url, Campaing campaing)
        {
            Url = url;
            Campaing = campaing;
        }
        /// <summary>
        /// Web Site url
        /// </summary>
        /// <value></value>
        public Url Url { get; }
        /// <summary>
        /// Campaing details
        /// </summary>
        /// <value></value>
        public Campaing Campaing { get; }

        public static implicit operator string(Utm utm)
        {
            return utm.ToString();
        }

        public static implicit operator Utm(string link)
        {
            if (string.IsNullOrEmpty(link))
                throw new InvalidUrlException();
            var url = new Url(link);
            var newSegments = url.Address.Split("?");

            if (newSegments.Length == 1)
                throw new InvalidUrlException("No segments were provider");

            var parse = newSegments[1].Split("&");
            var source = parse.Where(x => x.StartsWith("utm_source")).FirstOrDefault("").Split("=")[1];
            var medium = parse.Where(x => x.StartsWith("utm_medium")).FirstOrDefault("").Split("=")[1];
            var name = parse.Where(x => x.StartsWith("utm_campaign")).FirstOrDefault("").Split("=")[1];
            var id = parse.Where(x => x.StartsWith("utm_id")).FirstOrDefault("").Split("=")[1];
            var term = parse.Where(x => x.StartsWith("utm_term")).FirstOrDefault("").Split("=")[1];
            var content = parse.Where(x => x.StartsWith("utm_content")).FirstOrDefault("").Split("=")[1];

            var utm = new Utm(new Url(newSegments[0]),
            new Campaing(source, medium, name));

            return utm;
        }

        public override string ToString()
        {
            var listOfSegments = new List<string>();
            listOfSegments.AddIfNotNull("utm_source", Campaing.Source);
            listOfSegments.AddIfNotNull("utm_medium", Campaing.Medium);
            listOfSegments.AddIfNotNull("utm_campaign", Campaing.Name);
            listOfSegments.AddIfNotNull("utm_id", Campaing.Id ?? string.Empty);
            listOfSegments.AddIfNotNull("utm_term", Campaing.Term ?? string.Empty);
            listOfSegments.AddIfNotNull("utm_content", Campaing.Content ?? string.Empty);
            return $"{Url.Address}?{string.Join("&", listOfSegments)}";
        }


    }

}