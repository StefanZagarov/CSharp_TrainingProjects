using TMPro;
using UnityEngine;

public class CoinUI : MonoBehaviour
{
    private TMP_Text _coinsCollected;
    private int _collectedCoins;
    private int _coinsOnLevel;

    private void Start()
    {
        _coinsCollected = GetComponent<TMP_Text>(); //assigns the component TextMeshPro to the field, eliminating the need to do it manually on eveny object this script is set on
        _coinsOnLevel = FindObjectsOfType<Coin>().Length;
        _coinsCollected.text = _collectedCoins.ToString() + $" / {_coinsOnLevel}";
    }

    public void AddCoin()
    {
        _collectedCoins++;
        _coinsCollected.text = _collectedCoins.ToString() + $" / {_coinsOnLevel}";
    }

    public bool AllCoinsCollected()
    {
        if (_collectedCoins == _coinsOnLevel)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}