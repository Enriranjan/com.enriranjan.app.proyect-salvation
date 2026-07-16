namespace EnriRanjan.App.ProyectSalvation
{
    /// <summary>
    /// Result of <see cref="GetPuzzleHintService.Execute"/>. The view resolves
    /// <see cref="HintContentKey"/> into the journal text.
    /// </summary>
    public readonly struct PuzzleHintResult
    {
        /// <summary>Zone whose main puzzle the hint belongs to.</summary>
        public ZoneId Zone { get; }

        /// <summary>Content key of the hint text; null when no hint is available.</summary>
        public string HintContentKey { get; }

        /// <summary>1-based level of the returned hint (1 = vague, 2 = direct).</summary>
        public int HintLevel { get; }

        public PuzzleHintResult(ZoneId zone, string hintContentKey, int hintLevel)
        {
            Zone = zone;
            HintContentKey = hintContentKey;
            HintLevel = hintLevel;
        }
    }
}
