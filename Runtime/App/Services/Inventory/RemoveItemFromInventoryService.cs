using System;
using EnriRanjan.Interaction;
using EnriRanjan.Inventory;

namespace EnriRanjan.App.ProyectSalvation
{
    /// <summary>
    /// The player takes an item out of the backpack — or the game consumes it
    /// (e.g. the key is spent when used on the lock in Zone 3). Generic: used
    /// across every zone of the demo.
    /// </summary>
    public sealed class RemoveItemFromInventoryService
    {
        private InventorySystem<ItemId> _backpack;

        public void Install(InventorySystem<ItemId> backpack)
        {
            _backpack = backpack ?? throw new ArgumentNullException(nameof(backpack));
        }

        /// <summary>Returns false when the backpack does not contain the item.</summary>
        public bool Execute(ItemId itemId)
        {
            return _backpack.TryRemove(itemId);
        }
    }
}
