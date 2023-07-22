using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool gameIsOver;
    public GameObject gameOverUI;
    public TextMeshProUGUI roundsCounter;
    private void Start() {
        gameIsOver=false;
    }
    
    private void FixedUpdate()
    {
        roundsCounter.text="ROUND "+PlayerStats.Rounds.ToString()+" IN:";
        if (gameIsOver)
        {
            return;
        }
        if (PlayerStats.Lives <= 0)
        {
            EndGame();
        }
    }

    private void EndGame()
    {
        gameIsOver = true;
        gameOverUI.SetActive(true);
    }
}
