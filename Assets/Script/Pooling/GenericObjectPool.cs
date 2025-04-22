using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public static class GenericObjectPool<T> where T : Component
{
    private static ObjectPool<T> pool;
    private static T prefab;

    public static void Intialize(T prefabToUse, int defaultCapacity = 10)
    {
        prefab = prefabToUse;

        if (pool == null)
        {
            pool = new ObjectPool<T>(
                createFunc: () => Object.Instantiate(prefab),
                actionOnGet: obj => obj.gameObject.SetActive(true),
                actionOnRelease: obj => obj.gameObject.SetActive(false),
                actionOnDestroy: obj => Object.Destroy(obj.gameObject),
                collectionCheck: false,
                defaultCapacity: defaultCapacity
                ) ;
        }
    }

    public static T Get()
    {
        return pool.Get();
    }

    public static void Release(T obj)
    {
        if (obj is IPoolable poolable)
        {
            poolable.OnReturnedToPool();
        }

        pool.Release(obj);
    }
}
