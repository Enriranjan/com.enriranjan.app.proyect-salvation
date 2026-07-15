using NUnit.Framework;

namespace EnriRanjan.App.ProyectSalvation.Tests
{
    /// <summary>
    /// Plain NUnit tests for the noEngineReferences runtime assembly.
    /// No UnityTest / coroutines here on purpose: code under
    /// EnriRanjan.App.ProyectSalvation must stay engine-free and testable with
    /// pure NUnit, without needing PlayMode.
    /// </summary>
    public class RuntimePlaceholderTests
    {
        [Test]
        public void RuntimePlaceholder_CanBeConstructed()
        {
            var instance = new RuntimePlaceholder();

            Assert.IsNotNull(instance);
        }
    }
}
