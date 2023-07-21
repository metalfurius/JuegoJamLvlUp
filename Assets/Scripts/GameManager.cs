using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    bool gameEnded=false;
    private void FixedUpdate() {
        if(gameEnded){
            return;
        }
        if (PlayerStats.Lives<=0)
        {
            EndGame();
        }
    }

    private void EndGame()
    {
        gameEnded=true;
        Debug.Log("Game over");
    }
}
