using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Combat
{
    public class WeaponPickup : MonoBehaviour
    {
        [SerializeField] Weapon weapon = null;
        [SerializeField] float respawnTime = 3f;
        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Player")
            {
                other.GetComponent<Fighter>().EquipWeapon(weapon);
                StartCoroutine(HideForSeconds(respawnTime));
            }
        }

        private IEnumerator HideForSeconds(float seconds)
        {
            HidePickUp();
            yield return new WaitForSeconds(seconds);
            ShowPickUp();
        }

        private void ShowPickUp()
        {
            GetComponent<SphereCollider>().enabled = true;
            transform.GetChild(0).gameObject.SetActive(true);
        }

        private void HidePickUp()
        {
            GetComponent<SphereCollider>().enabled = false;
            transform.GetChild(0).gameObject.SetActive(false);
        }
    }
}

