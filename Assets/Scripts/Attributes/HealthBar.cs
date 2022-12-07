using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RPG.Attributes
{
    public class HealthBar : MonoBehaviour
    {
        [SerializeField] RectTransform foreGroundRectTransform;
        [SerializeField] Health health;
        [SerializeField] Canvas canvas;

        void Update()
        {
            if (foreGroundRectTransform.localScale.x < 1 && foreGroundRectTransform.localScale.x > 0)
            {
                canvas.enabled = true;
            }
            else
            {
                canvas.enabled = false;
            }
            foreGroundRectTransform.localScale = new Vector3(health.GetFraction(), 1, 1);
        }
    }
}

