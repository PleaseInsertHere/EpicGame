using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawner : MonoBehaviour
{

    public GameObject Enemy;
    public float Radius = 1;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) SpawnObjectAtRandom();
    }

    void SpawnObjectAtRandom()
    {
        Vector3 randomPos = Random.insideUnitCircle * Radius;

        Instantiate(Enemy, randomPos, Quaternion.identity);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;

        Gizmos.DrawWireSphere(this.transform.position, Radius);
    }
}
