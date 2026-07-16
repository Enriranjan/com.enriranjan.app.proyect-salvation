namespace EnriRanjan.App.ProyectSalvation
{
    /// <summary>
    /// Outcome of <see cref="PickUpItemService.Execute"/>. The view represents
    /// each case differently (attach to hand, backpack VFX, denial feedback...).
    /// </summary>
    public enum PickUpItemResult
    {
        /// <summary>The item is unknown to the catalog or lacks the Grabbable capability.</summary>
        NotGrabbable,

        /// <summary>The item stays in the player's hand for in-situ manipulation.</summary>
        HeldInHand,

        /// <summary>The item went into the backpack.</summary>
        StoredInBackpack,

        /// <summary>Storable item, but the backpack has no free slot; it stays in hand.</summary>
        InventoryFull
    }
}
