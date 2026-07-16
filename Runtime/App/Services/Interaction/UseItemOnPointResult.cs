using EnriRanjan.Interaction;

namespace EnriRanjan.App.ProyectSalvation
{
    /// <summary>
    /// Result of <see cref="UseItemOnPointService.Execute"/>. The view snaps
    /// the item in place, plays denial feedback or celebrates completion; the
    /// service only reports what happened.
    /// </summary>
    public readonly struct UseItemOnPointResult
    {
        /// <summary>True when the point accepted the item.</summary>
        public bool Accepted { get; }

        /// <summary>Why the placement was rejected; None when accepted.</summary>
        public SocketRejectionReason RejectionReason { get; }

        /// <summary>True when this placement filled every slot of the point.</summary>
        public bool PointCompleted { get; }

        private UseItemOnPointResult(bool accepted, SocketRejectionReason rejectionReason, bool pointCompleted)
        {
            Accepted = accepted;
            RejectionReason = rejectionReason;
            PointCompleted = pointCompleted;
        }

        public static UseItemOnPointResult AcceptedAt(bool pointCompleted)
        {
            return new UseItemOnPointResult(true, SocketRejectionReason.None, pointCompleted);
        }

        public static UseItemOnPointResult Rejected(SocketRejectionReason reason)
        {
            return new UseItemOnPointResult(false, reason, false);
        }
    }
}
