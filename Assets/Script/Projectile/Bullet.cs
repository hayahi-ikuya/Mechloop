using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour, IPoolable
{
    [SerializeField] private float speed = 10f;
    [SerializeField] private float lifetime = 2f;

    private float timer;

    private void OnEnable()
    {
        timer = 0f;
    }

    private void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        timer += Time.deltaTime;

        if (timer >= lifetime)
        {
            GenericObjectPool<Bullet>.Release(this);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out IDamageable target))
        {
            target.TakeDamage(10);

            // エフェクトを出す (オプション)
            var effect = GenericObjectPool<HitEffect>.Get();
            effect.transform.position = transform.position;

            GenericObjectPool<Bullet>.Release(this);
        }
    }

    // プール返却時に自動的に初期化
    public void OnReturnedToPool()
    {
        timer = 0f;
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.identity;

        var Rigidbody = GetComponent<Rigidbody>();
        if (Rigidbody != null)
        {
            Rigidbody.velocity = Vector3.zero;
            Rigidbody.angularVelocity = Vector3.zero;
        }
    }
}
