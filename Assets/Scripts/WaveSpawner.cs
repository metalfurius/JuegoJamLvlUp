using System.Collections;
using UnityEngine;
using TMPro;

public class WaveSpawner : MonoBehaviour
{
    public Transform enemyPrefab;
    public Transform spawnPoint;
    public float timeBetweenWaves = 5f;
    private float countdown = 2f;
    private int waveIndex = 0;
    public float SpawnEnemyTime = 0.5f;
    public TextMeshProUGUI waveCountdownText;

    private void Update()
    {
        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
        }
        countdown -= Time.deltaTime;
        countdown=Mathf.Clamp(countdown,0f,Mathf.Infinity);

        
    }
    private void FixedUpdate() {
        waveCountdownText.text = string.Format("{0:00.00}",countdown);
    }

    IEnumerator SpawnWave()
    {
        waveIndex++;
        PlayerStats.Rounds++;
        for (int i = 0; i < waveIndex; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(SpawnEnemyTime);
        }
    }

    private void SpawnEnemy()
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
