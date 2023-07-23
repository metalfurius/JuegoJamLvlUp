using System.Collections;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static int Money;
    public static int Lives;
    public static int Rounds;
    private void Start()
    {
        Lives = Random.Range(1,11);
        Money = Random.Range(200,400);
        Rounds=0;
    }
}
