using System;
using EnriRanjan.Interaction;
using EnriRanjan.Narrative;

namespace EnriRanjan.App.ProyectSalvation
{
    /// <summary>
    /// The player brings a found note close and reads it, marking it as
    /// discovered. Notes (together with audio logs) replace NPCs as the
    /// narrative channel of the demo; every zone drops them.
    /// </summary>
    public sealed class ReadNoteService
    {
        private NarrativeSystem _narrativeSystem;
        private ItemCatalogSystem _itemCatalog;

        public void Install(NarrativeSystem narrativeSystem, ItemCatalogSystem itemCatalog)
        {
            _narrativeSystem = narrativeSystem ?? throw new ArgumentNullException(nameof(narrativeSystem));
            _itemCatalog = itemCatalog ?? throw new ArgumentNullException(nameof(itemCatalog));
        }

        public ReadNoteResult Execute(ItemId noteItemId)
        {
            // TODO: coordinate ItemCatalogSystem (item -> narrative id) and
            // NarrativeSystem (verify the entry is Text, TryTrigger to mark it
            // read); return the content key for the view to display.
            throw new NotImplementedException();
        }
    }
}
