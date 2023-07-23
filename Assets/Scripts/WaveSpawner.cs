using System.Collections;
using UnityEngine;
using TMPro;

public class WaveSpawner : MonoBehaviour
{
    public static int enemiesAlive = 0;
    public Wave waves;
    public Transform spawnPoint;
    public float timeBetweenWaves = 5f;
    private float countdown = 2f;
    private int waveIndex = 0;
    public static int roundIndex = 0;
    public TextMeshProUGUI waveCountdownText;
    public WeightedRandomSelection random; // Asigna aquí el componente "WeightedRandomSelection"

    private void Update()
    {
        if (enemiesAlive > 0)
        {
            return;
        }

        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
            return;
        }

        countdown -= Time.deltaTime;
        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);
        waveCountdownText.text = string.Format("{0:00.00}", countdown);
    }

    IEnumerator SpawnWave()
    {
        AudioManager.instance.Play("RoundStart");
        PlayerStats.Rounds++;
        Wave wave = waves;

        for (int i = 0; i < wave.count; i++)
        {
            GameObject enemy = random.GetRandomWeightedElement(); // Obtiene un enemigo aleatorio con peso
            SpawnEnemy(enemy);
            yield return new WaitForSeconds(1f / wave.rate);
        }

        waveIndex++;
        roundIndex = waveIndex;
    }

    private void SpawnEnemy(GameObject enemy)
    {
        Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
        enemiesAlive++;
    }
}
