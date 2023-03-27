using UnityEngine;
using System.Collections.Generic;

public class MenuCanvas : MonoBehaviour
{
    //Script will close opened window when a new one is being openend

    [SerializeField] private List<GameObject> _menuPanels = new List<GameObject>();

    public void ClosePreviousPanel()
    {
        foreach (GameObject panel in _menuPanels)
        {
            if (panel.activeSelf)
            {
                panel.SetActive(false);
            }
        }
    }
}