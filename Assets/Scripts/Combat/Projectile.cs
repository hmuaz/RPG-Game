using RPG.Core;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    [SerializeField] GameObject hitEffect = null;

    Health target;
    float damage = 0;

    void Start()
    {
        transform.LookAt(GetAimLocation());
        if (hitEffect == null) return;
    }

    void Update()
    {
        if (target == null) return;
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }

    public void SetTarget(Health pTarget, float pDamage)
    {
        target = pTarget;
        damage = pDamage;
    }

    private Vector3 GetAimLocation()
    {
        CapsuleCollider targetCollider = target.GetComponent<CapsuleCollider>();
        if (targetCollider == null)
        {
            return target.transform.position;
        }
        return target.transform.position + Vector3.up * ((targetCollider.height * 3) / 4);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Health>() != target) return;
        if (target.IsDead()) return;
        target.TakeDamage(damage);
        Destroy(gameObject);
        if (hitEffect == null) return;
        Instantiate(hitEffect, GetAimLocation(), transform.rotation);

    }
}
