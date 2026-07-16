using System;

namespace EnriRanjan.App.ProyectSalvation
{
    /// <summary>
    /// The player pulls the field journal out of its bag (or puts it back).
    /// The journal is the hint surface of the demo; the view owns the gesture
    /// and the physical journal object, this use case only tracks its state.
    /// </summary>
    public sealed class ToggleJournalService
    {
        public void Install()
        {
            // TODO: inject the journal/hint state holder once it exists (the
            // open/closed flag may simply live in this service).
        }

        /// <summary>Returns the journal state after the toggle.</summary>
        public JournalState Execute()
        {
            // TODO: flip and report the journal open/closed state.
            throw new NotImplementedException();
        }
    }
}
