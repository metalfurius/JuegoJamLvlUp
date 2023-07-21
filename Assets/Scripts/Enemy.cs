using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float startSpeed=10f;
    [HideInInspector]
    public float speed;
    public float health = 100;
    public int worth = 35;
    public GameObject deadEffect;
    
    private void Start() {
        speed=startSpeed;
    }
    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0)
        {
            Die();
        }
    }

    public void Slow(float pct)
    {
        speed=startSpeed*(1f-pct);
    }

    private void Die()
    {
        GameObject effect = (GameObject)Instantiate(deadEffect, transform.position, Quaternion.identity);
        Destroy(effect, 3f);
        PlayerStats.Money += worth;
        Destroy(gameObject);
    }
}
