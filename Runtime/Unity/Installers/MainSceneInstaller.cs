using EnriRanjan.Core;
using EnriRanjan.Core.Unity;

namespace EnriRanjan.App.ProyectSalvation.Unity
{
    /// <summary>
    /// Scene composition root for the main gameplay scene. Reads the
    /// services registered by <see cref="ProyectSalvationBootstrap"/>,
    /// creates this scene's controllers and wires them to the views. This
    /// installer is the only place allowed to know about both sides, since
    /// its concrete views are assigned here via [SerializeField].
    /// </summary>
    public sealed class MainSceneInstaller : SceneContextInstaller
    {
        // [SerializeField]
        // private SomeView someView;

        protected override void InstallScene(IReferenceLocator locator)
        {
            // 1. Resolve the services this scene needs from the locator:
            // var someService = locator.Get<SomeService>();

            // 2. Create this scene's controllers, injecting those services:
            // var someController = new SomeController(someService);

            // 3. Connect controllers to views assigned above:
            // someController.Bind(someView);
        }
    }
}
