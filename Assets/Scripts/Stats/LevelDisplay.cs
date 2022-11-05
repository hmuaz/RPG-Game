using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace RPG.Stats
{
    public class LevelDisplay : MonoBehaviour
    {
        

        void Update()
        {
            int level = GameObject.Find("Player").GetComponent<BaseStats>().GetLevel();

            GetComponent<Text>().text = level.ToString();
        }
    }
}

