using UnityEngine;
using TMPro;

namespace UI
{
    public class ColorReset : MonoBehaviour
    {
        public void ResetColor()
        {
            GetComponent<TMP_InputField>().image.color = Color.white;
        }
    }
}