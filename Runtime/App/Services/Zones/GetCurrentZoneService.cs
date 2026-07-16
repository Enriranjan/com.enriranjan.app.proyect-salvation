using System;

namespace EnriRanjan.App.ProyectSalvation
{
    /// <summary>
    /// Tells which zone the player is currently in, for the views that need it
    /// (UI, music, journal hints...). Read-only counterpart of
    /// <see cref="UnlockZoneService"/>.
    /// </summary>
    public sealed class GetCurrentZoneService
    {
        public void Install()
        {
            // TODO: inject the zone progression state holder once its home is
            // decided (dedicated progression system vs. app-level state).
        }

        public ZoneId Execute()
        {
            // TODO: query the zone progression state.
            throw new NotImplementedException();
        }
    }
}
