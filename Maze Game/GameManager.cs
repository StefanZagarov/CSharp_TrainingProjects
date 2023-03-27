using UnityEngine;
using UnityEngine.AI;

public class GameManager : MonoBehaviour
{
    private GameObject completeLevelUI;
    ///to add: when the player dies make a game over screen appear

    public void CompleteLevel()
    {
        completeLevelUI.SetActive(true);
    }    
}