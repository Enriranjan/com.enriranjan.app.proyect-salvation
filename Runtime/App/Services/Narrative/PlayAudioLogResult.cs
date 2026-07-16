namespace EnriRanjan.App.ProyectSalvation
{
    /// <summary>
    /// Result of <see cref="PlayAudioLogService.Execute"/>. The view resolves
    /// <see cref="ContentKey"/> (audio clip key) into the actual clip.
    /// </summary>
    public readonly struct PlayAudioLogResult
    {
        /// <summary>False when the item is not a playable audio log.</summary>
        public bool Started { get; }

        /// <summary>Content key of the recording; null when not started.</summary>
        public string ContentKey { get; }

        /// <summary>True the first time the log plays, false on replays.</summary>
        public bool FirstPlay { get; }

        public PlayAudioLogResult(bool started, string contentKey, bool firstPlay)
        {
            Started = started;
            ContentKey = contentKey;
            FirstPlay = firstPlay;
        }
    }
}
