namespace EnriRanjan.App.ProyectSalvation
{
    /// <summary>
    /// Result of <see cref="ValidatePlateLibraryOrderService.Execute"/>.
    /// </summary>
    public readonly struct PlateLibraryOrderResult
    {
        /// <summary>True when the order matches the motif synthesis from Zones 1-3.</summary>
        public bool IsCorrect { get; }

        /// <summary>Narrative id of the final recording / cliffhanger; null when incorrect.</summary>
        public string FinalNarrativeId { get; }

        public PlateLibraryOrderResult(bool isCorrect, string finalNarrativeId)
        {
            IsCorrect = isCorrect;
            FinalNarrativeId = finalNarrativeId;
        }
    }
}
