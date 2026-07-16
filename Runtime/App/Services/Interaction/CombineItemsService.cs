using System;
using EnriRanjan.Interaction;

namespace EnriRanjan.App.ProyectSalvation
{
    /// <summary>
    /// The player tries to combine the two objects they are holding. Generic:
    /// whether the pair is valid (recipe) or a known red herring is data owned
    /// by the CombinationSystem, never hardcoded here. Puzzle-specific
    /// combination rules (e.g. the key fragments of Zone 3) live in their own
    /// services instead.
    /// </summary>
    public sealed class CombineItemsService
    {
        private CombinationSystem _combinationSystem;
        private AddItemToInventoryService _addItemToInventory;

        public void Install(CombinationSystem combinationSystem, AddItemToInventoryService addItemToInventory)
        {
            _combinationSystem = combinationSystem ?? throw new ArgumentNullException(nameof(combinationSystem));
            _addItemToInventory = addItemToInventory ?? throw new ArgumentNullException(nameof(addItemToInventory));
        }

        public CombinationResult Execute(ItemId a, ItemId b)
        {
            // TODO: coordinate CombinationSystem (recipe lookup) and
            // AddItemToInventoryService (store the produced item when the
            // recipe says so); report the outcome for the view to react.
            throw new NotImplementedException();
        }
    }
}
