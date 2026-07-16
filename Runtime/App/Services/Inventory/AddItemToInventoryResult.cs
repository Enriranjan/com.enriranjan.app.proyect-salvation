namespace EnriRanjan.App.ProyectSalvation
{
    /// <summary>
    /// Outcome of <see cref="AddItemToInventoryService.Execute"/>. Controllers
    /// decide the feedback for each case; the service only reports what happened.
    /// </summary>
    public enum AddItemToInventoryResult
    {
        Stored,

        /// <summary>The item is unknown to the catalog or lacks the Storable capability.</summary>
        NotStorable,

        InventoryFull
    }
}
