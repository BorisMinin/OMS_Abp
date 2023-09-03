using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace OMS_Demo_Sample.Pages;

public class Index_Tests : OMS_Demo_SampleWebTestBase
{
    [Fact]
    public async Task Welcome_Page()
    {
        var response = await GetResponseAsStringAsync("/");
        response.ShouldNotBeNull();
    }
}
