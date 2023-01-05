

using UtmBuilder.Core.ValuesObjects;
using UtmBuilder.Core.ValuesObjects.Exceptions;

namespace UtmBuilder.Core.Tests.ValueObjects
{
    [TestClass]
    public class UrlTests
    {
        private const string InvalidUrl = "fruits";
        private const string ValidUrl = "hhtps://google.com";
        [TestMethod]
        [ExpectedException(typeof(InvalidUrlException))]
        public void ShouldReturnExceptionWhenUrlIsInvalid()
        {

            new Url(InvalidUrl);

        }

        [TestMethod]
        public void ShouldNotReturnExceptionWhenUrlIsInvalid()
        {
            new Url(ValidUrl);
            Assert.IsTrue(true);
        }
    }
}