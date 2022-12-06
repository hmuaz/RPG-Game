using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace RPG.UI
{
    public class DamageText : MonoBehaviour
    {
        [SerializeField] UnityEngine.UI.Text damageText = null;
        public void DestroyText()
        {
            Destroy(gameObject);
        }

        public void SetValue(float amount)
        {
            damageText.text = amount.ToString("F0");
        }
    }
}
