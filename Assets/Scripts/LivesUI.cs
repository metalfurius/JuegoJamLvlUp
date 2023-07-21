using UnityEngine;
using TMPro;

public class LivesUI : MonoBehaviour
{
    public TextMeshProUGUI livesText;
    private void FixedUpdate() {
        livesText.text=PlayerStats.Lives.ToString();
    }
}
