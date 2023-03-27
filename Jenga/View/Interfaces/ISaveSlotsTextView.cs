using System;
using System.Collections.Generic;
using UnityEngine;

namespace View.Interfaces
{
    public interface ISaveSlotsTextView
    {
        List<GameObject> GetSlots();
        void WriteSlotText(GameObject slot, string timeOfSave);
    }
}