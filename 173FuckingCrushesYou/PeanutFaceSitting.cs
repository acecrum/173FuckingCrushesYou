using LabApi.Features;
using LabApi.Loader.Features.Plugins;

namespace _173FuckingCrushesYou;

public class _173FuckingCrushesYouPlugin : Plugin
{
    public override string Name { get; } = "173 Fucking Crushes You";
    public override string Description { get; } = "Peanut can crush players when landing like with grey candy";
    public override string Author { get; } = "acecrum";
    public override Version Version { get; } = new Version(1, 0, 0);
    public override Version RequiredApiVersion { get; } = new (LabApiProperties.CompiledVersion);

    private HeWhoShallPullMeOutOf173ShallBeNamedKingArthur? _eventHandler;
    
    public override void Enable()
    {
        _eventHandler = new HeWhoShallPullMeOutOf173ShallBeNamedKingArthur();
        _eventHandler?.Register();
    }

    public override void Disable()
    {
        _eventHandler?.Unregister();
        _eventHandler = null;
    }
}