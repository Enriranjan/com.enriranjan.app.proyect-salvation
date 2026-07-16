using EnriRanjan.Core.Unity;
using EnriRanjan.Interaction;
using EnriRanjan.Inventory;
using EnriRanjan.Narrative;

namespace EnriRanjan.App.ProyectSalvation.Unity
{
    /// <summary>
    /// Composition root of Proyect Salvation. Place on a GameObject in the
    /// empty Bootstrap scene (<c>Scenes/Bootstrap.unity</c>) that every
    /// consuming project sets as its entry point.
    /// </summary>
    public sealed class ProyectSalvationBootstrap : ApplicationBootstrap
    {
        /// <summary>
        /// Backpack slot count. Constant until it moves into the content
        /// source / configuration.
        /// </summary>
        private const int BackpackCapacity = 8;

        protected override void InstallBindings()
        {
            // 1. Content source. In-memory stub until the ScriptableObject
            //    (ItemDefinition) backed source exists in this Unity layer.
            var contentSource = new InMemoryInteractionContentSource();

            // 2. Interaction systems, built from the content source's data.
            var combinationSystem = new CombinationSystem(
                contentSource.GetRecipes(),
                contentSource.GetInvalidCombinations());

            var socketSystem = new SocketSystem();
            foreach (SocketDefinition socketDefinition in contentSource.GetSocketDefinitions())
            {
                // One instance per definition until scene installers register
                // per-scene socket instances.
                socketSystem.RegisterSocket(socketDefinition.SocketId, socketDefinition);
            }

            var stateSystem = new StateSystem(contentSource.GetStateDefinitions());
            var containerSystem = new ContainerSystem();

            var items = contentSource.GetItems();
            foreach (ItemData item in items)
            {
                if (item.HasCapability(ItemCapabilities.Stateful) && item.StateDefinitionId != null)
                {
                    stateSystem.RegisterItem(item.Id, item.StateDefinitionId);
                }

                if (item.HasCapability(ItemCapabilities.Container))
                {
                    containerSystem.RegisterContainer(item.Id, item.InitialContents);
                }
            }

            // 3. Remaining systems: the item catalog (interaction), the
            //    backpack (inventory) and the narrative registry (app layer
            //    until it moves into its own package).
            var itemCatalogSystem = new ItemCatalogSystem(items);
            var backpack = new InventorySystem<ItemId>(BackpackCapacity);
            var narrativeSystem = new NarrativeSystem(contentSource.GetNarrativeEntries());

            // 4. Services: one class per game use case. Each receives,
            //    through Install, only the systems and services it coordinates.

            // 4a. Inventory.
            var addItemToInventory = new AddItemToInventoryService();
            addItemToInventory.Install(backpack, itemCatalogSystem);

            var removeItemFromInventory = new RemoveItemFromInventoryService();
            removeItemFromInventory.Install(backpack);

            // 4b. Zone progression (created before the services that chain it).
            var getCurrentZone = new GetCurrentZoneService();
            getCurrentZone.Install();

            var unlockZone = new UnlockZoneService();
            unlockZone.Install();

            // 4c. Core interaction actions.
            var pickUpItem = new PickUpItemService();
            pickUpItem.Install(itemCatalogSystem, addItemToInventory);

            var releaseItem = new ReleaseItemService();
            releaseItem.Install();

            var examineItem = new ExamineItemService();
            examineItem.Install(itemCatalogSystem, containerSystem, narrativeSystem);

            var combineItems = new CombineItemsService();
            combineItems.Install(combinationSystem, addItemToInventory);

            var useItemOnPoint = new UseItemOnPointService();
            useItemOnPoint.Install(socketSystem, removeItemFromInventory);

            // 4d. Narrative (notes and audio logs).
            var readNote = new ReadNoteService();
            readNote.Install(narrativeSystem, itemCatalogSystem);

            var playAudioLog = new PlayAudioLogService();
            playAudioLog.Install(narrativeSystem, itemCatalogSystem);

            // 4e. Field journal / hints.
            var toggleJournal = new ToggleJournalService();
            toggleJournal.Install();

            var getPuzzleHint = new GetPuzzleHintService();
            getPuzzleHint.Install(getCurrentZone);

            // 4f. Puzzle-specific validations.
            var validateSolarDoorAlignment = new ValidateSolarDoorAlignmentService();
            validateSolarDoorAlignment.Install(unlockZone);

            var validateKeyFragmentsCombination = new ValidateKeyFragmentsCombinationService();
            validateKeyFragmentsCombination.Install(
                combinationSystem, validateSolarDoorAlignment, addItemToInventory);

            var validatePlateLibraryOrder = new ValidatePlateLibraryOrderService();
            validatePlateLibraryOrder.Install(socketSystem, narrativeSystem);

            // 5. Systems are registered as-is (they are the query/event
            //    surface for controllers); services by their concrete type.
            Register(combinationSystem);
            Register(socketSystem);
            Register(stateSystem);
            Register(containerSystem);
            Register(itemCatalogSystem);
            Register(backpack);
            Register(narrativeSystem);

            Register(addItemToInventory);
            Register(removeItemFromInventory);
            Register(getCurrentZone);
            Register(unlockZone);
            Register(pickUpItem);
            Register(releaseItem);
            Register(examineItem);
            Register(combineItems);
            Register(useItemOnPoint);
            Register(readNote);
            Register(playAudioLog);
            Register(toggleJournal);
            Register(getPuzzleHint);
            Register(validateSolarDoorAlignment);
            Register(validateKeyFragmentsCombination);
            Register(validatePlateLibraryOrder);
        }
    }
}
