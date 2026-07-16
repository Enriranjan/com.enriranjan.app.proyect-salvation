using System;
using System.Collections.Generic;
using EnriRanjan.Interaction;
using EnriRanjan.Narrative;

namespace EnriRanjan.App.ProyectSalvation
{
    /// <summary>
    /// Zone 4 — climax, "The library plates". Validates the plate order the
    /// player proposes against the synthesis of motifs seen in Zones 1, 2 and
    /// 3 (there is no new clue in the scene, it relies on the player's
    /// memory). When correct it fires the final recording / cliffhanger.
    /// </summary>
    public sealed class ValidatePlateLibraryOrderService
    {
        private SocketSystem _socketSystem;
        private NarrativeSystem _narrativeSystem;

        public void Install(SocketSystem socketSystem, NarrativeSystem narrativeSystem)
        {
            _socketSystem = socketSystem ?? throw new ArgumentNullException(nameof(socketSystem));
            _narrativeSystem = narrativeSystem ?? throw new ArgumentNullException(nameof(narrativeSystem));
        }

        public PlateLibraryOrderResult Execute(IReadOnlyList<ItemId> proposedOrder)
        {
            // TODO: coordinate SocketSystem (read the plates placed on the
            // shelf) and, when the order matches the Zones 1-3 motif synthesis,
            // NarrativeSystem (fire the final recording / cliffhanger).
            throw new NotImplementedException();
        }
    }
}
