using EnriRanjan.Core.Unity;

namespace EnriRanjan.App.ProyectSalvation.Unity
{
    /// <summary>
    /// Composition root of Proyect Salvation. Place on a GameObject in the
    /// empty Bootstrap scene (<c>Scenes/Bootstrap.unity</c>) that every
    /// consuming project sets as its entry point.
    /// </summary>
    public sealed class ProyectSalvationBootstrap : ApplicationBootstrap
    {
        protected override void InstallBindings()
        {
            // Create and register every system, service and provider the
            // game needs, in this order:
            //   1. Systems    - engine adapters wrapping raw Unity/engine APIs.
            //   2. Providers  - read-only data/content sources built on top of systems.
            //   3. Services   - application/domain logic consumed by scene controllers.
            //
            // Example:
            // var someSystem = new SomeSystem();
            // var someProvider = new SomeProvider(someSystem);
            // var someService = new SomeService(someProvider);
            // Register(someService);
        }
    }
}
