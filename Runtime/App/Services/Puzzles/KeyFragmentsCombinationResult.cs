namespace EnriRanjan.App.ProyectSalvation
{
    /// <summary>
    /// Outcome of <see cref="ValidateKeyFragmentsCombinationService.Execute"/>.
    /// The view reacts differently to each failure so the player can tell
    /// "wrong pieces" from "right pieces, wrong orientation".
    /// </summary>
    public enum KeyFragmentsCombinationResult
    {
        /// <summary>The pieces are not the three key fragments.</summary>
        WrongFragments = 0,

        /// <summary>Right fragments, but their orientation does not match the solar symbol persisted in Zone 2.</summary>
        WrongOrientation,

        /// <summary>The key is assembled.</summary>
        KeyAssembled
    }
}
