using System;

namespace EnriRanjan.App.ProyectSalvation
{
    /// <summary>
    /// Zone 2 — "The solar condor door". Validates the light beam alignment
    /// achieved with the mirror against the relief. Beyond opening the door it
    /// persists the final orientation of the solar symbol, because the Zone 3
    /// key fragments puzzle depends on that value (explicit callback between
    /// zones). That persisted rule is what distinguishes this use case from a
    /// generic <see cref="UseItemOnPointService"/>.
    /// </summary>
    public sealed class ValidateSolarDoorAlignmentService
    {
        private UnlockZoneService _unlockZone;

        /// <summary>
        /// Final orientation of the solar symbol (degrees), persisted for the
        /// Zone 3 key fragments puzzle. Null while the door is unsolved.
        /// </summary>
        public float? PersistedSymbolOrientationDegrees { get; private set; }

        public void Install(UnlockZoneService unlockZone)
        {
            _unlockZone = unlockZone ?? throw new ArgumentNullException(nameof(unlockZone));
        }

        /// <summary>Returns true when the beam matches the relief and the door opens.</summary>
        public bool Execute(float symbolOrientationDegrees)
        {
            // TODO: validate the alignment against the relief configuration,
            // persist PersistedSymbolOrientationDegrees and coordinate
            // UnlockZoneService (Zone3) when the door opens.
            throw new NotImplementedException();
        }
    }
}
