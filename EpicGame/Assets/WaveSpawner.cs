using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Wave
{
    public string waveName;
    public int noOfEnemies;
    public GameObject[] typeOfEnemies;
    public float spawnInterval;
}

public class WaveSpawner : MonoBehaviour
{
    public Wave[] waves;
    public Transform[] spawnPoints;
    public Animator animator;
    public Text waveName;

    private Wave currentWave;
    private int currentWaveIndex;
    private float nextSpawnTime;
    private bool canSpawn = true;
    private bool canAnimate = false;

    void Start()
    {
        StartNextWave();
    }

    void Update()
    {
        if (IsWaveComplete() && currentWaveIndex < waves.Length - 1)
        {
            StartNextWave();
        }
    }

    void StartNextWave()
    {
        currentWaveIndex++;
        currentWave = waves[currentWaveIndex];
        nextSpawnTime = Time.time;
        canSpawn = true;
        canAnimate = true;

        if (currentWaveIndex < waves.Length)
        {
            waveName.text = currentWave.waveName;
            animator.SetTrigger("WaveComplete");
        }
        else
        {
            Debug.Log("GameFinish");
        }
    }

    bool IsWaveComplete()
    {
        GameObject[] totalEnemies = GameObject.FindGameObjectsWithTag("Enemy");
        return totalEnemies.Length == 0 && Time.time > nextSpawnTime + currentWave.spawnInterval;
    }

    void SpawnEnemy()
    {
        if (canSpawn && nextSpawnTime < Time.time)
        {
            GameObject randomEnemy = currentWave.typeOfEnemies[Random.Range(0, currentWave.typeOfEnemies.Length)];
            Transform randomPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
            Instantiate(randomEnemy, randomPoint.position, Quaternion.identity);
            currentWave.noOfEnemies--;
            nextSpawnTime = Time.time + currentWave.spawnInterval;

            if (currentWave.noOfEnemies == 0)
            {
                canSpawn = false;
                canAnimate = true;
            }
        }
    }
}
