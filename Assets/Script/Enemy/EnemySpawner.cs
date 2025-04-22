using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            var enemy = GenericObjectPool<Enemy>.Get();
            enemy.transform.position = new Vector3(Random.Range(-3,3),0, Random.Range(-3,3));
        }
    }
}
