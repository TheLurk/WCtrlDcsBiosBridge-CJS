using WCtrlDcsBiosBridge.Aircrafts;
using Xunit;

namespace WCtrlDcsBiosBridge.Tests;

/// <summary>
/// The CJS Super Hornet mod reports itself as FA-18E, FA-18F or EA-18G, and DCS-BIOS exports
/// all three through its FA-18C_hornet module. Matching is on prefix, and none of them starts
/// with "FA-18C", so each has to be listed or the bridge calls the jet unsupported.
/// </summary>
public class FA18CRegistryTests
{
    [Theory]
    [InlineData("FA-18C_hornet")]
    [InlineData("FA-18E")]
    [InlineData("FA-18F")]
    [InlineData("EA-18G")]
    public void DetectedAsTheHornet(string dcsBiosName)
    {
        Assert.Same(AircraftRegistry.FA18C, AircraftRegistry.FindByDcsBiosName(dcsBiosName));
    }
}
