
using UtmBuilder.Core.ValuesObjects;
using UtmBuilder.Core.ValuesObjects.Exceptions;

namespace UtmBuilder.Core.Tests.ValueObjects;

public class CampaignTests
{
    [TestMethod]
    [DataRow("", "", "", true)]
    [DataRow("src", "", "", true)]
    [DataRow("src", "med", "", true)]
    [DataRow("src", "med", "nme", true)]
    public void ShouldCampaignValid(string source, string medium, string name)
    {
        new Campaing(source, medium, name);
        Assert.IsTrue(true);
    }
}
