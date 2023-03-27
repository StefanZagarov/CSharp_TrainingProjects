using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventorySearch : MonoBehaviour
{
    [SerializeField] private TMP_InputField _searchField;
    private GameObject _grid;

    private void Start()
    {
        _grid = GameObject.Find("Items Button Grid");
    }

    public void SearchForItem()
    {
        if (string.IsNullOrEmpty(_searchField.text))
        {
            foreach (Button button in _grid.GetComponentsInChildren<Button>(true))
            {
                button.gameObject.SetActive(true);
            }
        }
        else
        {
            foreach (Button button in _grid.GetComponentsInChildren<Button>(true))
            {
                if (!button.name.ToLower().Contains(_searchField.text.ToLower()))
                {
                    button.gameObject.SetActive(false);
                }
                else
                {
                    button.gameObject.SetActive(true);
                }
            }
        }
    }
}