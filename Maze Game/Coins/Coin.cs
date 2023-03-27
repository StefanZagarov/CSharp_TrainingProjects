using UnityEngine;

public class Coin : MonoBehaviour
{
    private CoinUI _coinUI;

    private void Start()
    {
        _coinUI = FindObjectOfType<CoinUI>(); //bridge to make AddCoin work
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.isTrigger) return;
        if (other.CompareTag("Player")) //C# says == is inefficient
        {
            _coinUI.AddCoin();
            Destroy(gameObject);
        }
    }
}
