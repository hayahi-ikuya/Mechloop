using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInitializer : MonoBehaviour
{
    [SerializeField] private Enemy enemyPrefab;
    [SerializeField] private Bullet bulletPrefab;
    [SerializeField] private HitEffect hitEffectPrefab;

    private void Awake()
    {
        GenericObjectPool<Enemy>.Intialize(enemyPrefab, 20);
        GenericObjectPool<Bullet>.Intialize(bulletPrefab, 20);
        GenericObjectPool<HitEffect>.Intialize(hitEffectPrefab, 10);
    }
}
