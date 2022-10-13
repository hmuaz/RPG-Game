using UnityEngine;
using RPG.Combat;
using RPG.Movement;
using RPG.Core;

namespace RPG.Control
{
    public class AIController: MonoBehaviour
    {
        [SerializeField] float chaseDistance = 5f;
        [SerializeField] float suspicionTime = 3f;

        Fighter fighter;
        Health health;
        Mover mover;
        GameObject player;


        Vector3 guardPosition;
        float timeSiceLastSawPlayer = Mathf.Infinity;

        private void Start()
        {
            fighter = GetComponent<Fighter>();
            health = GetComponent<Health>();
            player = GameObject.FindWithTag("Player");
            mover = GetComponent<Mover>();
            guardPosition = transform.position;
        }
        private void Update()
        {
            if (health.IsDead()) return;

            GameObject player = GameObject.FindWithTag("Player");
            if (InAttackRangeOfPlayer()  && fighter.CanAttack(player))
            {
                timeSiceLastSawPlayer = 0;
                AttackBehaivor();
            }
            else if (timeSiceLastSawPlayer < suspicionTime)
            {
                SuspicionBehaivor();
            }
            else
            {
                GuardBehaivor();
            }

            timeSiceLastSawPlayer += Time.deltaTime;

        }

        private void GuardBehaivor()
        {
            mover.StartMoveAction(guardPosition);
            fighter.Cancel();
        }

        private void SuspicionBehaivor()
        {
            GetComponent<ActionScheduler>().CancelCurrentAction();
        }

        private void AttackBehaivor()
        {
            fighter.Attack(player);
        }

        private bool InAttackRangeOfPlayer()
        {
            float distanceToPlayer = Vector3.Distance(player.transform.position, transform.position);
            return distanceToPlayer <= chaseDistance;
        }

        //Called by Unity.
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(transform.position, chaseDistance);
        }
    }
}
