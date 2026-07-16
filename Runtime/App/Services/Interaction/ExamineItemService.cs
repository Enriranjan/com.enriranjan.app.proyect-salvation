using System;
using EnriRanjan.Interaction;
using EnriRanjan.Narrative;

namespace EnriRanjan.App.ProyectSalvation
{
    /// <summary>
    /// The player brings an object close to their face to examine it. Generic:
    /// what each object reveals (a rolled-up note, a hidden slot, an engraved
    /// detail...) is configuration data of the item — its container contents
    /// and narrative id — never logic hardcoded here.
    /// </summary>
    public sealed class ExamineItemService
    {
        private ItemCatalogSystem _itemCatalog;
        private ContainerSystem _containerSystem;
        private NarrativeSystem _narrativeSystem;

        public void Install(
            ItemCatalogSystem itemCatalog,
            ContainerSystem containerSystem,
            NarrativeSystem narrativeSystem)
        {
            _itemCatalog = itemCatalog ?? throw new ArgumentNullException(nameof(itemCatalog));
            _containerSystem = containerSystem ?? throw new ArgumentNullException(nameof(containerSystem));
            _narrativeSystem = narrativeSystem ?? throw new ArgumentNullException(nameof(narrativeSystem));
        }

        public ExamineItemResult Execute(ItemId itemId)
        {
            // TODO: coordinate ItemCatalogSystem (Examinable capability and the
            // item's reveal configuration), ContainerSystem (reveal hidden
            // contents) and NarrativeSystem (fire the item's narrative entry).
            throw new NotImplementedException();
        }
    }
}
