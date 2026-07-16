using System;

namespace EnriRanjan.App.ProyectSalvation
{
    /// <summary>
    /// The player asks the journal for a hint about the active puzzle. Returns
    /// the hint for the current hint level (first one vague, second one more
    /// direct) and advances that level. Works for the main puzzle of every
    /// zone; the active puzzle is derived from the current zone.
    /// </summary>
    public sealed class GetPuzzleHintService
    {
        private GetCurrentZoneService _getCurrentZone;

        public void Install(GetCurrentZoneService getCurrentZone)
        {
            _getCurrentZone = getCurrentZone ?? throw new ArgumentNullException(nameof(getCurrentZone));

            // TODO: inject the hint content source (hint keys per zone/level)
            // once it exists in the content configuration.
        }

        public PuzzleHintResult Execute()
        {
            // TODO: coordinate GetCurrentZoneService (which puzzle is active)
            // and the hint content source; return the hint for the current
            // level and advance the level for that puzzle.
            throw new NotImplementedException();
        }
    }
}
