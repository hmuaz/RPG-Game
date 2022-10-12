using UnityEngine;

namespace RPG.Combat
{
    public class Health : MonoBehaviour
    {
        bool isDead = false;

        public bool IsDead()
        {
            return isDead;
        }

        [SerializeField] float healthPoint = 100f;

        public void TakeDamage(float damage)
        {
            healthPoint = Mathf.Max(healthPoint - damage, 0);
            if(healthPoint == 0)
            {
                Die();
            }
        }

        private void Die()
        {
            if (isDead) return;
            GetComponent<Animator>().SetTrigger("die");
            isDead = true;
        }
    }
}
