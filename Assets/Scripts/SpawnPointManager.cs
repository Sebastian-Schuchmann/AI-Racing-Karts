using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPointManager : MonoBehaviour
{
    public Transform[] spawnPoints;

    public Vector3 SelectRandomSpawnpoint()
    {
        int rnd = Random.Range(0, spawnPoints.Length);
        return spawnPoints[rnd].position;
    }
}
