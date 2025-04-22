using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using Unity.VisualScripting;

public class PlayerMeleeAttack : MonoBehaviour
{
    [SerializeField] private float attackRange = 1.5f;
    [SerializeField] private int attackPower = 10;
    [SerializeField] private LayerMask targetLayer;
    [SerializeField] private float attackCooldown = 0.5f;

    private bool isAttacking = false;

    private void PerformAttack()
    {
        Vector3 center = transform.position + transform.forward;
        Collider[] hits = Physics.OverlapSphere(center, attackRange, targetLayer);

        foreach (var hit in hits) 
        {
            if(hit.TryGetComponent(out IDamageable target))
            {
                target.TakeDamage(attackPower);
            }
        }
    }
}
