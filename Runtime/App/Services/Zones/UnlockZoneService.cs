using System;

namespace EnriRanjan.App.ProyectSalvation
{
    /// <summary>
    /// Unlocks the next zone as the consequence of solving the current zone's
    /// main puzzle. Called by the puzzle validation services, never directly
    /// by the views.
    /// </summary>
    public sealed class UnlockZoneService
    {
        public void Install()
        {
            // TODO: inject the zone progression state holder once its home is
            // decided (dedicated progression system vs. app-level state).
        }

        public UnlockZoneResult Execute(ZoneId zoneToUnlock)
        {
            // TODO: coordinate the zone progression state; report the outcome
            // so the view can open paths, change music, etc.
            throw new NotImplementedException();
        }
    }
}
