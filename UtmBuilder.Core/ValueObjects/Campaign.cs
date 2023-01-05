using UtmBuilder.Core.ValuesObjects.Exceptions;

namespace UtmBuilder.Core.ValuesObjects
{
    public class Campaing : ValueObject
    {
        public string? Id { get; } = null;
        public string Source { get; }
        public string Name { get; }
        public string Medium { get; }
        public string? Term { get; }
        public string? Content { get; }

        public Campaing(string source, string medium, string name)
        {
            Source = source;
            Name = name;
            Medium = medium;

            InvalidCampaignException.ThrowIfNUll(source, "UTM Source invalid");
            InvalidCampaignException.ThrowIfNUll(name, "UTM Name Invalid");
            InvalidCampaignException.ThrowIfNUll(medium, "UTM Medium invalid");
        }
    }
}