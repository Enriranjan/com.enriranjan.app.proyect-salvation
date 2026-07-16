using System;
using EnriRanjan.Interaction;

namespace EnriRanjan.App.ProyectSalvation
{
    /// <summary>
    /// The player lets go of the object currently held in hand. Generic
    /// counterpart of <see cref="PickUpItemService"/> for every zone.
    /// </summary>
    public sealed class ReleaseItemService
    {
        public void Install()
        {
            // TODO: inject the system that tracks the held item once "what is
            // in hand" becomes domain state (today only the view knows it).
        }

        /// <summary>Returns false when the item could not be released.</summary>
        public bool Execute(ItemId itemId)
        {
            // TODO: coordinate the held-item state; the view handles the
            // physical drop/re-attach itself.
            throw new NotImplementedException();
        }
    }
}
