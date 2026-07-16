using System;
using EnriRanjan.Interaction;

namespace EnriRanjan.App.ProyectSalvation
{
    /// <summary>
    /// The player brings an object to a highlighted point of the environment
    /// (assisted snap). Generic: whether that item+point pair is a valid
    /// interaction and what it triggers is data owned by the SocketSystem
    /// (socket definitions), never hardcoded here. E.g. the key on the lock in
    /// Zone 3, a plate on its shelf slot in Zone 4.
    /// </summary>
    public sealed class UseItemOnPointService
    {
        private SocketSystem _socketSystem;
        private RemoveItemFromInventoryService _removeItemFromInventory;

        public void Install(SocketSystem socketSystem, RemoveItemFromInventoryService removeItemFromInventory)
        {
            _socketSystem = socketSystem ?? throw new ArgumentNullException(nameof(socketSystem));
            _removeItemFromInventory = removeItemFromInventory ?? throw new ArgumentNullException(nameof(removeItemFromInventory));
        }

        public UseItemOnPointResult Execute(ItemId itemId, string pointId, int? slotIndex = null)
        {
            // TODO: coordinate SocketSystem (TryPlace on the point's socket)
            // and RemoveItemFromInventoryService (consume the item when the
            // socket accepts it, e.g. the key on the lock).
            throw new NotImplementedException();
        }
    }
}
