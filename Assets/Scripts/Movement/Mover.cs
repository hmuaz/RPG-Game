using RPG.Combat;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using RPG.Core;
using RPG.Saving;
using RPG.Attributes;


namespace RPG.Movement
{
    public class Mover : MonoBehaviour, IAction, ISaveable
    {
        [SerializeField] Transform target;
        [SerializeField] NavMeshAgent meshAgent;
        [SerializeField] Animator animator;

        [SerializeField] float maxSpeed = 6f;

        Health health;
        private void Awake()
        {
            health = GetComponent<Health>();
            meshAgent = GetComponent<NavMeshAgent>();
        }

        private void Start()
        {
            
        }
        void Update()
        {
            meshAgent.enabled = !health.IsDead();

            UpdateAnimator();
        }

        public void StartMoveAction(Vector3 destination, float speedFraction)
        {
            GetComponent<ActionScheduler>().StartAction(this);
            GetComponent<Fighter>().Cancel();
            MoveTo(destination, speedFraction);
        }

        public void MoveTo(Vector3 destination, float speedFraction)
        {
            meshAgent.isStopped = false;
            meshAgent.speed = maxSpeed * Mathf.Clamp01(speedFraction);
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


        //public object CaptureState()
        //{
        //    Dictionary<string, object> data = new Dictionary<string, object>();

        //    data["position"] = new SerializableVector3(transform.position);
        //    data["rotation"] = new SerializableVector3(transform.eulerAngles);


        //    return data;
        //}

        //public void RestoreState(object state)
        //{
        //    Dictionary<string, object> data = (Dictionary<string, object>)state;
        //    GetComponent<NavMeshAgent>().enabled = false;
        //    transform.position = ((SerializableVector3)data["position"]).ToVector();
        //    transform.position = ((SerializableVector3)data["rotation"]).ToVector();

        //    GetComponent<NavMeshAgent>().enabled = true;
        //}

        public object CaptureState()
        {
            return new SerializableVector3(transform.position);
        }

        public void RestoreState(object state)
        {
            SerializableVector3 position = (SerializableVector3)state;
            meshAgent.enabled = false;
            transform.position = position.ToVector();
            meshAgent.enabled = true;
            GetComponent<ActionScheduler>().CancelCurrentAction();
        }
    }
}

