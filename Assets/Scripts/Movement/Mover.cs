using RPG.Combat;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using RPG.Core;

namespace RPG.Movement
{
    public class Mover : MonoBehaviour, IAction
    {
        [SerializeField] Transform target;
        [SerializeField] NavMeshAgent meshAgent;
        [SerializeField] Animator animator;

        Health health;

        private void Start()
        {
            health = GetComponent<Health>();
            meshAgent = GetComponent<NavMeshAgent>();
        }
        void Update()
        {
            meshAgent.enabled = !health.IsDead();

            UpdateAnimator();
        }

        public void StartMoveAction(Vector3 destination)
        {
            GetComponent<ActionScheduler>().StartAction(this);
            GetComponent<Fighter>().Cancel();
            MoveTo(destination);
        }

        public void MoveTo(Vector3 destination)
        {
            meshAgent.isStopped = false;
            meshAgent.destination = destination;
        }

        public void Cancel()
        {
            meshAgent.isStopped = true;
        }
        
        private void UpdateAnimator()
        {
            Vector3 velocity = meshAgent.velocity;
            Vector3 localVelocity = transform.InverseTransformDirection(velocity);
            float speed = localVelocity.z;
            animator.SetFloat("forwardSpeed", speed);
        }

        
    }
}

