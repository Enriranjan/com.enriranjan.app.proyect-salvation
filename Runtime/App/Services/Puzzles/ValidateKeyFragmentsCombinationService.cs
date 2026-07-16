using System;
using EnriRanjan.Interaction;

namespace EnriRanjan.App.ProyectSalvation
{
    /// <summary>
    /// Zone 3 — "The three key fragments". When the player combines the three
    /// fragments they must be oriented according to the solar symbol
    /// orientation persisted by <see cref="ValidateSolarDoorAlignmentService"/>
    /// in Zone 2; otherwise the combination fails even with the right
    /// fragments present. That cross-zone rule is what distinguishes this use
    /// case from a generic <see cref="CombineItemsService"/>.
    /// </summary>
    public sealed class ValidateKeyFragmentsCombinationService
    {
        private CombinationSystem _combinationSystem;
        private ValidateSolarDoorAlignmentService _solarDoorAlignment;
        private AddItemToInventoryService _addItemToInventory;

        public void Install(
            CombinationSystem combinationSystem,
            ValidateSolarDoorAlignmentService solarDoorAlignment,
            AddItemToInventoryService addItemToInventory)
        {
            _combinationSystem = combinationSystem ?? throw new ArgumentNullException(nameof(combinationSystem));
            _solarDoorAlignment = solarDoorAlignment ?? throw new ArgumentNullException(nameof(solarDoorAlignment));
            _addItemToInventory = addItemToInventory ?? throw new ArgumentNullException(nameof(addItemToInventory));
        }

        public KeyFragmentsCombinationResult Execute(KeyFragmentsCombinationRequest request)
        {
            // TODO: coordinate CombinationSystem (the fragments recipe),
            // ValidateSolarDoorAlignmentService.PersistedSymbolOrientationDegrees
            // (orientation check) and AddItemToInventoryService (the assembled key).
            throw new NotImplementedException();
        }
    }
}
