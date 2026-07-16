using System.Collections.Generic;
using EnriRanjan.Interaction;

namespace EnriRanjan.App.ProyectSalvation
{
    /// <summary>
    /// Input of <see cref="ValidateKeyFragmentsCombinationService.Execute"/>:
    /// the fragments the player is assembling and the orientation they gave
    /// the solar symbol on the assembled key.
    /// </summary>
    public readonly struct KeyFragmentsCombinationRequest
    {
        /// <summary>The fragments the player is combining (expected: the three key fragments).</summary>
        public IReadOnlyList<ItemId> Fragments { get; }

        /// <summary>Orientation (degrees) the player gave the assembled solar symbol.</summary>
        public float SymbolOrientationDegrees { get; }

        public KeyFragmentsCombinationRequest(IReadOnlyList<ItemId> fragments, float symbolOrientationDegrees)
        {
            Fragments = fragments;
            SymbolOrientationDegrees = symbolOrientationDegrees;
        }
    }
}
