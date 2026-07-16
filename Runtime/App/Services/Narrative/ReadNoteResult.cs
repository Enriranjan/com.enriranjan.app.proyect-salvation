namespace EnriRanjan.App.ProyectSalvation
{
    /// <summary>
    /// Result of <see cref="ReadNoteService.Execute"/>. The view resolves
    /// <see cref="ContentKey"/> (localization key) into the actual text.
    /// </summary>
    public readonly struct ReadNoteResult
    {
        /// <summary>False when the item is not a readable note.</summary>
        public bool WasRead { get; }

        /// <summary>Content key of the note text; null when not read.</summary>
        public string ContentKey { get; }

        /// <summary>True the first time the note is read, false on re-reads.</summary>
        public bool FirstRead { get; }

        public ReadNoteResult(bool wasRead, string contentKey, bool firstRead)
        {
            WasRead = wasRead;
            ContentKey = contentKey;
            FirstRead = firstRead;
        }
    }
}
