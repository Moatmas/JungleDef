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
        public int countEnemy3;
        public Transform enemyPrefab1;
        public Transform enemyPrefab2;
        public Transform enemyPrefab3;
        public float timeBeforeNextWave;
        public float coef =1f;

    }


    private float delayEnemy1 = 0f;
    private float delayEnemy2 = 1f;
    private float delayEnemy3 = 0.5f;

    public Wave[] waves;
    private int waveIndex = 0;


    public Transform spawnPoint;

    private float countDown = 2f;
    public TextMeshProUGUI waveCountDownText;
   
    public PauseManager pauseManager;

    public int enemiesAlive;
    private int difficultyLevel;

    public TextMeshProUGUI waveText;
    public GameObject canvas;



    private void Start()
    {
        difficultyLevel = GameSettings.Difficulty;
        InvokeRepeating(nameof(CheckEnemiesAlive), 0.5f, 0.5f);
        countDown = waves[0].timeBeforeNextWave;
    }
    private void Update()
    {
        waveText.text = "Vague " + waveIndex + "/" + (waves.Length - 1) ;

        if (waveIndex >= waves.Length && enemiesAlive == 0)
        {
            Debug.Log("Toutes les vagues ont �t� compl�t�es !");
            pauseManager.Pause();
            canvas.SetActive(true);
            return;
        }

        if (countDown <= 0f)
        {
            if (waveIndex < waves.Length)
            {
                StartCoroutine(SpawnWave());
                if (waveIndex < waves.Length)
                {
                    countDown = waves[waveIndex].timeBeforeNextWave;
                }
            }
        }
        countDown -= Time.deltaTime;

        waveCountDownText.text = Mathf.Floor(countDown).ToString();
    }

    IEnumerator SpawnWave()
    {
        Wave currentWave = waves[waveIndex];
        waveIndex++;

        StartCoroutine(SpawnEnemyType(currentWave.countEnemy1, currentWave.enemyPrefab1, delayEnemy1, 0.3f, currentWave.coef));
        StartCoroutine(SpawnEnemyType(currentWave.countEnemy2, currentWave.enemyPrefab2, delayEnemy2, 0.4f, currentWave.coef));
        StartCoroutine(SpawnEnemyType(currentWave.countEnemy3, currentWave.enemyPrefab3, delayEnemy3, 0.6f, currentWave.coef));

        yield return null;
    }

    IEnumerator SpawnEnemyType(int count, Transform enemyPrefab, float initialDelay, float spawnInterval, float coef)
    {
        yield return new WaitForSeconds(initialDelay);

        for (int i = 0; i < count; i++)
        {
            SpawnEnemy(enemyPrefab, coef);
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    void SpawnEnemy(Transform enemyPrefab, float coef)
    {
        GameObject enemyInstance = Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation).gameObject;
        Enemy enemyScript = enemyInstance.GetComponent<Enemy>();
        if (enemyScript != null)
        {
            enemyScript.ApplyWaveCoef(coef, difficultyLevel);
        }
    }
    void CheckEnemiesAlive()
    {
        enemiesAlive = GameObject.FindGameObjectsWithTag("Enemy").Length;
    }

}
