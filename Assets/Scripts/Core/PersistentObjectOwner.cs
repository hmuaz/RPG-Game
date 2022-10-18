using System;
using UnityEngine;

namespace RPG.Core
{
    public class PersistentObjectOwner : MonoBehaviour
    {
        [SerializeField] GameObject persistentObjectPrefab;

        static bool hasSpawned = false;

        private void Awake()
        {
            if (hasSpawned) return;

            SpawnPersistentObjects();
            hasSpawned = true;
        }

        private void SpawnPersistentObjects()
        {
            GameObject persistentPrefab = Instantiate(persistentObjectPrefab);
            DontDestroyOnLoad(persistentPrefab);
        }
    }
}
