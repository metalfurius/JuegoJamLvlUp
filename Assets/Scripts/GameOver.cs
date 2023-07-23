using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public TextMeshProUGUI roundsText;
    void OnEnable() {
        roundsText.text=PlayerStats.Rounds.ToString();
    }
    public void Retry(){
        AudioManager.instance.Play("Button");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void Menu(){
        AudioManager.instance.Play("Button");
        Debug.Log("Menu");
    }
}
