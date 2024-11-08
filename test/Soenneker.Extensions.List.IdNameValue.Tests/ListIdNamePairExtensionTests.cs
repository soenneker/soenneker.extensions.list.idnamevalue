using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Soenneker.Extensions.List.IdNameValue.Abstract;
using Soenneker.Tests.FixturedUnit;
using Xunit;
using Xunit.Abstractions;

namespace Soenneker.Extensions.List.IdNameValue.Tests;

[Collection("Collection")]
public class ListIdNamePairExtensionTests : FixturedUnitTest
{
    private readonly IListIdNamePairExtension _extension;

    public ListIdNamePairExtensionTests(Fixture fixture, ITestOutputHelper output) : base(fixture, output)
    {
        _extension = Resolve<IListIdNamePairExtension>(true);
    }
}
