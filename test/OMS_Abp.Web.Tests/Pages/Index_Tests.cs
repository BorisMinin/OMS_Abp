using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace OMS_Abp.Pages;

public class Index_Tests : OMS_AbpWebTestBase
{
    [Fact]
    public async Task Welcome_Page()
    {
        var response = await GetResponseAsStringAsync("/");
        response.ShouldNotBeNull();
    }
}
