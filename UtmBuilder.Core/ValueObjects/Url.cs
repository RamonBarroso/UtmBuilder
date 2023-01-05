using UtmBuilder.Core.ValuesObjects.Exceptions;

namespace UtmBuilder.Core.ValuesObjects
{
    public class Url : ValueObject
    {




        /// <summary>
        /// Address of URL (Website link)
        /// </summary>
        /// <value></value>
        public string Address { get; private set; } = null!;

        /// <summary>
        /// Create new URL
        /// </summary>
        /// <param name="address"></param>
        public Url(string address)
        {
            this.Address = address;

            InvalidUrlException.ThrowUIfInvalidUrl(address);
        }
    }
}

