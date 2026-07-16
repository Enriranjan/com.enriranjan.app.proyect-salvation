namespace EnriRanjan.App.ProyectSalvation
{
    /// <summary>
    /// Outcome of <see cref="UnlockZoneService.Execute"/>.
    /// </summary>
    public enum UnlockZoneResult
    {
        Unlocked = 0,

        /// <summary>The zone was already unlocked; nothing changed.</summary>
        AlreadyUnlocked,

        /// <summary>The zone cannot be unlocked yet (e.g. skipping a zone).</summary>
        NotAllowed
    }
}
