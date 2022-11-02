using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RPG.Attributes
{
    public class ExperienceDisplay : MonoBehaviour
    {
        Experience experience;
        private void Awake()
        {
            experience = GameObject.FindWithTag("Player").GetComponent<Experience>();
        }

        // Update is called once per frame
        void Update()
        {
            GetComponent<Text>().text = experience.GetExperiencePoints().ToString();
        }
    }
}

