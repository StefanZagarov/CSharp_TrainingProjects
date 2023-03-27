using UnityEngine;
using UnityEngine.SceneManagement;

public class EndTrigger : MonoBehaviour
{
    private GameManager _gameManager;
    private CoinUI _coinUI;

    private void Start()
    {
        _gameManager = GetComponent<GameManager>();
        _coinUI = FindObjectOfType<CoinUI>(); //find object of type searched the component specified and calls the first object that it finds that has this component
    }

    private void OnCollisionEnter()
    {
        if (_coinUI.AllCoinsCollected())
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            _gameManager.CompleteLevel();
        }
        else
        {
            Debug.Log("Not all coins are collected!");
        }

    }
}