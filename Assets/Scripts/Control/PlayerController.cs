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
            if(InteractWithCombat()) return;
            if(InteractWithMovement()) return;
            print("dalga");
        }

        private bool InteractWithCombat()
        {
            RaycastHit[] hits = Physics.RaycastAll(GetMouseRay());
            foreach (RaycastHit hit in hits)
            {
                CombatTarget target = hit.transform.GetComponent<CombatTarget>();
                Fighter fighter = GetComponent<Fighter>();
                if (!fighter.CanAttack(target)) continue;
                Debug.Log("þþ");
                if (Input.GetMouseButtonDown(0))
                {
                    GetComponent<Fighter>().Attack(target);
                }
                return true;
            }
            return false;
        }

        

        private bool InteractWithMovement()
        {
            RaycastHit hit;

            bool hashit = Physics.Raycast(GetMouseRay(), out hit);
            if (hashit)
            {
                if (Input.GetMouseButton(0))
                {
                    GetComponent<Mover>().StartMoveAction(hit.point);
                }
                return true;
            }
            return false;
        }

        
        

        private Ray GetMouseRay()
        {
            
            return FindObjectOfType<Camera>().ScreenPointToRay(Input.mousePosition);
        }
    }
}
