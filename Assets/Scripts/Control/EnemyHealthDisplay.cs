using RPG.Attributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using RPG.Combat;

namespace RPG.Control
{
    public class EnemyHealthDisplay : MonoBehaviour
    {
        Health health;
        
        

       

        
        private void Update()
        {
            health = GameObject.FindWithTag("Player").GetComponent<Fighter>().GetTarget();
            if (health == null)
            {
                GetComponent<Text>().text = "N/A";
            }
            else
            {
                GetComponent<Text>().text = health.GetHealthPoints().ToString("F0") + "/" + health.GetMaxHealthPoints().ToString("F0");
            }
        }


    }
}
