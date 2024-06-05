using UnityEngine;
using System.Collections;
using TMPro;

public class WaveSpawner : MonoBehaviour
{
    [System.Serializable]
    public class Wave
    {
        public int countEnemy1;
        public int countEnemy2;
        public Transform enemyPrefab1;
        public Transform enemyPrefab2;
    }

    public Wave[] waves;
    public Transform spawnPoint;
    public float timeBetweenWaves = 10f;
    private float countDown = 2f;
    public TextMeshProUGUI waveCountDownText;
    private int waveIndex = 0;
    public PauseManager pauseManager;

    public int enemiesAlive;

    private void Start()
    {
        enemiesAlive = 0;
    }
    private void Update()
    {
        if (waveIndex >= waves.Length && enemiesAlive == 0)
        {
            Debug.Log("Toutes les vagues ont été complétées !");
            pauseManager.Pause();
            return;
        }

        if (countDown <= 0f)
        {
            if (waveIndex < waves.Length)
            {
                StartCoroutine(SpawnWave());
                countDown = timeBetweenWaves;
            }
        }
        countDown -= Time.deltaTime;

        waveCountDownText.text = Mathf.Floor(countDown).ToString();
    }

    IEnumerator SpawnWave()
    {
        Wave currentWave = waves[waveIndex];
        waveIndex++;

        for (int i = 0; i < currentWave.countEnemy1; i++)
        {
            SpawnEnemy(currentWave.enemyPrefab1);
            yield return new WaitForSeconds(0.3f);
        }

        for (int i = 0; i < currentWave.countEnemy2; i++)
        {
            SpawnEnemy(currentWave.enemyPrefab2);
            yield return new WaitForSeconds(0.3f);
        }
    }

    void SpawnEnemy(Transform enemyPrefab)
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
