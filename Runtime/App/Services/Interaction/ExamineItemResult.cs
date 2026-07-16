using System;
using System.Collections.Generic;
using EnriRanjan.Interaction;

namespace EnriRanjan.App.ProyectSalvation
{
    public enum ExamineOutcome
    {
        /// <summary>The item is unknown to the catalog or lacks the Examinable capability.</summary>
        NotExaminable = 0,

        /// <summary>Examinable, but this item has nothing configured to reveal.</summary>
        NothingRevealed,

        /// <summary>The examination revealed something (items and/or a narrative entry).</summary>
        Revealed
    }

    /// <summary>
    /// Result of <see cref="ExamineItemService.Execute"/>. Only the fields
    /// relevant to <see cref="Outcome"/> are populated; the view decides how
    /// to present each revealed element.
    /// </summary>
    public readonly struct ExamineItemResult
    {
        public ExamineOutcome Outcome { get; }

        /// <summary>Items uncovered by the examination; empty unless Revealed.</summary>
        public IReadOnlyList<ItemId> RevealedItems { get; }

        /// <summary>Narrative entry fired by examining the item, or null.</summary>
        public string NarrativeId { get; }

        private ExamineItemResult(ExamineOutcome outcome, IReadOnlyList<ItemId> revealedItems, string narrativeId)
        {
            Outcome = outcome;
            RevealedItems = revealedItems ?? Array.Empty<ItemId>();
            NarrativeId = narrativeId;
        }

        public static ExamineItemResult NotExaminable()
        {
            return new ExamineItemResult(ExamineOutcome.NotExaminable, null, null);
        }

        public static ExamineItemResult NothingRevealed()
        {
            return new ExamineItemResult(ExamineOutcome.NothingRevealed, null, null);
        }

        public static ExamineItemResult Revealed(IReadOnlyList<ItemId> revealedItems, string narrativeId = null)
        {
            return new ExamineItemResult(ExamineOutcome.Revealed, revealedItems, narrativeId);
        }
    }
}
