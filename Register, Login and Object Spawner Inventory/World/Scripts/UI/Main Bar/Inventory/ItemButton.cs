using UnityEngine;
using TMPro;

public class ItemButton : MonoBehaviour
{
    //Button that holds an item(object prefab)

    private GameObject _gameObject;
    private ObjectSpawner _objectSpawner;

    private void Start()
    {
        _objectSpawner = FindObjectOfType<ObjectSpawner>(); //more performance effecient to set it to a field than to be called in SpawnItem every time an object is instantiated
    }

    public void SetObject(GameObject obj)
    {
        _gameObject = obj;
        gameObject.name = obj.name;
        gameObject.GetComponentInChildren<TextMeshProUGUI>().text = obj.name;
    }

    public void SpawnItem()
    {
        _objectSpawner.InstantiateObject(_gameObject);
    }
}