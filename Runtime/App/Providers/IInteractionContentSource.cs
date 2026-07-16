using System.Collections.Generic;
using EnriRanjan.Interaction;
using EnriRanjan.Narrative;

namespace EnriRanjan.App.ProyectSalvation
{
    /// <summary>
    /// Source of every piece of interaction content the bootstrap needs to
    /// build the interaction systems and services. The Unity layer will
    /// implement this by reading ScriptableObjects; tests and early builds use
    /// <see cref="InMemoryInteractionContentSource"/>.
    /// </summary>
    public interface IInteractionContentSource
    {
        IReadOnlyCollection<ItemData> GetItems();
        IReadOnlyCollection<RecipeData> GetRecipes();
        IReadOnlyCollection<InvalidCombinationData> GetInvalidCombinations();
        IReadOnlyCollection<SocketDefinition> GetSocketDefinitions();
        IReadOnlyCollection<StateDefinition> GetStateDefinitions();
        IReadOnlyCollection<NarrativeEntry> GetNarrativeEntries();
    }
}
