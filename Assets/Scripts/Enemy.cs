using UnityEngine.UI;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float startSpeed = 10f;
    [HideInInspector]
    public float speed;
    public float startHealth = 100;
    private float health;
    public int worth = 35;
    public GameObject deadEffect;
    public Image healthBar;
    public float roundWeightAugment=0.04f;

    private void Start()
    {
        speed = startSpeed * (1f + (WaveSpawner.roundIndex * roundWeightAugment)); 
        health = startHealth * (1f + (WaveSpawner.roundIndex * roundWeightAugment)); 
        healthBar.fillAmount = health / startHealth;
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
        healthBar.fillAmount = health / startHealth;
        if (health <= 0)
        {
            Die();
        }
    }

    public void Slow(float pct)
    {
        speed = startSpeed * (1f - pct);
    }

    private void Die()
    {
        AudioManager.instance.Play("EnemyDie");
        WaveSpawner.enemiesAlive--;
        GameObject effect = (GameObject)Instantiate(deadEffect, transform.position, Quaternion.identity);
        Destroy(effect, 3f);
        PlayerStats.Money += worth;
        Destroy(gameObject);
    }
}
