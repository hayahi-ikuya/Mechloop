using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable, IPoolable
{
    [SerializeField] private int maxHp = 30;
    private int currentHp;

    private void OnEnable()
    {
        currentHp = maxHp;
    }

    public void TakeDamage(int amount)
    {
        currentHp -= amount;
        Debug.Log($"{gameObject.name} took {amount} damage. Remaining HP: {maxHp}");

        if (currentHp <= 0)
        {
            GenericObjectPool<Enemy>.Release(this);
        }
    }

    public void OnReturnedToPool()
    {
        currentHp = maxHp;
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.identity;
    }
}