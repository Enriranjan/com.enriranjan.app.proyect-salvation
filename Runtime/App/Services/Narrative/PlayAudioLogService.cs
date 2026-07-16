using System;
using EnriRanjan.Interaction;
using EnriRanjan.Narrative;

namespace EnriRanjan.App.ProyectSalvation
{
    /// <summary>
    /// The player picks up one of the mentor's field recordings and it plays.
    /// Audio logs (together with notes) replace NPCs as the narrative channel
    /// of the demo; the final recording of Zone 4 is triggered by
    /// <see cref="ValidatePlateLibraryOrderService"/> instead.
    /// </summary>
    public sealed class PlayAudioLogService
    {
        private NarrativeSystem _narrativeSystem;
        private ItemCatalogSystem _itemCatalog;

        public void Install(NarrativeSystem narrativeSystem, ItemCatalogSystem itemCatalog)
        {
            _narrativeSystem = narrativeSystem ?? throw new ArgumentNullException(nameof(narrativeSystem));
            _itemCatalog = itemCatalog ?? throw new ArgumentNullException(nameof(itemCatalog));
        }

        public PlayAudioLogResult Execute(ItemId audioLogItemId)
        {
            // TODO: coordinate ItemCatalogSystem (item -> narrative id) and
            // NarrativeSystem (verify the entry is Audio, TryTrigger to mark it
            // discovered); return the content key for the view to play.
            throw new NotImplementedException();
        }
    }
}
