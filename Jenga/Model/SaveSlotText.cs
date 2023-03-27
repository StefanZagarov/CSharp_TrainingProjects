using System;

namespace Model
{
    public class SaveSlotText
    {
        public string SlotName { get; set; }
        public string SlotText { get; set; }

        public SaveSlotText(string slotName, string slotText)
        {
            SlotName = slotName;
            SlotText = slotText;
        }
    }
}