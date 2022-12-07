using UnityEngine;
using RPG.Attributes;
using UnityEngine.Events;

namespace RPG.Combat
{
    public class Projectile : MonoBehaviour
    {
        [SerializeField] float speed = 5f;
        [SerializeField] GameObject hitEffect = null;
        [SerializeField] float maxLifeTime = 10f;
        [SerializeField] float lifeAfterImpact = 2f;
        [SerializeField] GameObject[] destroyOnHit = null;
        [SerializeField] UnityEvent onHit;

        Health target;
        float damage = 0;
        GameObject instigator = null;

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

        public void SetTarget(GameObject pInstigator, Health pTarget, float pDamage)
        {
            target = pTarget;
            damage = pDamage;
            instigator = pInstigator;

            Destroy(gameObject, maxLifeTime);
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

            target.TakeDamage(instigator, damage);

            speed = 0;

            onHit.Invoke();

            if (hitEffect != null)
            {
                Instantiate(hitEffect, GetAimLocation(), transform.rotation);
            }

            foreach (var obj in destroyOnHit)
            {
                Destroy(obj);
            }

            Destroy(gameObject, lifeAfterImpact);


        }



    }

}