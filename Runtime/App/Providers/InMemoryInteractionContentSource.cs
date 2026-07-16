using System;
using System.Collections.Generic;
using EnriRanjan.Interaction;
using EnriRanjan.Narrative;

namespace EnriRanjan.App.ProyectSalvation
{
    /// <summary>
    /// In-memory <see cref="IInteractionContentSource"/> for bootstrapping and
    /// tests before the ScriptableObject-backed source exists in the Unity
    /// layer. Every collection defaults to empty.
    /// </summary>
    public sealed class InMemoryInteractionContentSource : IInteractionContentSource
    {
        private readonly ItemData[] _items;
        private readonly RecipeData[] _recipes;
        private readonly InvalidCombinationData[] _invalidCombinations;
        private readonly SocketDefinition[] _socketDefinitions;
        private readonly StateDefinition[] _stateDefinitions;
        private readonly NarrativeEntry[] _narrativeEntries;

        public InMemoryInteractionContentSource(
            IEnumerable<ItemData> items = null,
            IEnumerable<RecipeData> recipes = null,
            IEnumerable<InvalidCombinationData> invalidCombinations = null,
            IEnumerable<SocketDefinition> socketDefinitions = null,
            IEnumerable<StateDefinition> stateDefinitions = null,
            IEnumerable<NarrativeEntry> narrativeEntries = null)
        {
            _items = ToArray(items);
            _recipes = ToArray(recipes);
            _invalidCombinations = ToArray(invalidCombinations);
            _socketDefinitions = ToArray(socketDefinitions);
            _stateDefinitions = ToArray(stateDefinitions);
            _narrativeEntries = ToArray(narrativeEntries);
        }

        public IReadOnlyCollection<ItemData> GetItems() => _items;
        public IReadOnlyCollection<RecipeData> GetRecipes() => _recipes;
        public IReadOnlyCollection<InvalidCombinationData> GetInvalidCombinations() => _invalidCombinations;
        public IReadOnlyCollection<SocketDefinition> GetSocketDefinitions() => _socketDefinitions;
        public IReadOnlyCollection<StateDefinition> GetStateDefinitions() => _stateDefinitions;
        public IReadOnlyCollection<NarrativeEntry> GetNarrativeEntries() => _narrativeEntries;

        private static T[] ToArray<T>(IEnumerable<T> source)
        {
            if (source == null)
            {
                return Array.Empty<T>();
            }

            return new List<T>(source).ToArray();
        }
    }
}
