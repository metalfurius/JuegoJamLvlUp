using UnityEngine.UI;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float startSpeed = 10f;
    [HideInInspector]
    public float speed;
    public float startHealth = 100;
    private float health;
    public int startWorth = 35;
    public GameObject deadEffect;
    public Image healthBar;
    public float roundWeightAugment=0.04f;
    private int worth;

    private void Start()
    {
        worth=(int)Mathf.Round(startWorth*Random.Range(0.6f,1.2f));
        speed = startSpeed * (1f + (WaveSpawner.roundIndex * roundWeightAugment*Random.Range(0.8f,1.5f))); 
        health = startHealth * (1f + (WaveSpawner.roundIndex * roundWeightAugment*Random.Range(0.8f,1.5f))); 
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
