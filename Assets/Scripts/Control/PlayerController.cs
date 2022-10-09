using UnityEngine;
using RPG.Movement;
using RPG.Combat;
using System;

namespace RPG.Control
{
    public class PlayerController : MonoBehaviour
    {
        void Start()
        {
        }

        // Update is called once per frame
        void Update()
        {
            InteractWithCombat();
            InteractWithMovement();
        }

        private void InteractWithCombat()
        {
            RaycastHit[] hits = Physics.RaycastAll(GetMouseRay());
            foreach (RaycastHit hit in hits)
            {
                CombatTarget target = hit.transform.GetComponent<CombatTarget>();
                if (target == null) continue;

                if (Input.GetMouseButtonDown(0))
                {
                    GetComponent<Fighter>().Attack(target);
                }
            }

        }

        

        private void InteractWithMovement()
        {
            if (Input.GetMouseButton(0))
            {
                MoveToCursor();
            }
        }

        private void MoveToCursor()
        {
            RaycastHit hit;

            bool hashit = Physics.Raycast(GetMouseRay(), out hit);
            Debug.Log(hashit);
            if (hashit)
            {
                GetComponent<Mover>().MoveTo(hit.point);
            }

        }

        private Ray GetMouseRay()
        {
            
            return FindObjectOfType<Camera>().ScreenPointToRay(Input.mousePosition);
        }
    }
}
