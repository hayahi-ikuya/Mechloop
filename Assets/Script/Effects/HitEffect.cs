using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitEffect : MonoBehaviour
{
    [SerializeField] private float effectDuration = 0.5f;

    private float timer;

    private void OnEnable()
    {
        timer = 0f;
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer > effectDuration)
        {
            GenericObjectPool<HitEffect>.Release(this);
        }
    }

    public void OnReturnedToPool()
    {
        timer = 0f;
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.identity;

        // エフェクト再生中ならリセット
        if (TryGetComponent(out ParticleSystem ps))
        {
            ps.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
        }
    }
}
