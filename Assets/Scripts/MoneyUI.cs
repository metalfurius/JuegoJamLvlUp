using UnityEngine;
using TMPro;

public class MoneyUI : MonoBehaviour
{
    public TextMeshProUGUI moneyText;
    private void FixedUpdate()
    {
        moneyText.text = "$" + PlayerStats.Money.ToString();
    }
}
