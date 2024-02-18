using UnityEngine;
[System.Serializable]

public class Wave
{
    public string waveName;
    public int numberOfEnemies;
    public GameObject[] typeOfEnemies;
    public float spawnInterval;
}

public class WaveSpawner : MonoBehaviour
{
    public Wave[] wave;
    public Transform[] spawnPoints;

    private Wave currentWave;
    private int currentWaveNumber;

    private bool canSpawn = true;

    private void Update()
    {
        currentWave = wave[currentWaveNumber];
        SpawnWave();
    }

    void SpawnWave()
    {
        if (canSpawn)
        {
        GameObject randomEnemy = currentWave.typeOfEnemies[Random.Range(0,currentWave.typeOfEnemies.Length)];
        Transform randomPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
        Instantiate(randomEnemy, randomPoint.position, Quaternion.identity);
        currentWave.numberOfEnemies--;
            if (currentWave.numberOfEnemies == 0)
            {
                canSpawn = false;
            }
        }
    }



}
