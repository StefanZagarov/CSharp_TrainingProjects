using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    //Populate the inventory grid with buttons

    [SerializeField] private List<GameObject> _objectsList = new List<GameObject>();
    [SerializeField] private GameObject _buttonPrefab;
    [SerializeField] private Transform _buttonParent; //better way to assign it to the grid

    private void Awake()
    {
        PopulateInventoryGrid();
    }
    private void PopulateInventoryGrid()
    {
        foreach (GameObject obj in _objectsList)
        {
            GameObject buttonInstance = Instantiate(_buttonPrefab, _buttonParent);

            buttonInstance.GetComponent<ItemButton>().SetObject(obj);
        }
    }
}