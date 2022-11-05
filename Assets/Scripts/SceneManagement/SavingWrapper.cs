using RPG.Saving;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPG.SceneManagement;

namespace RPG.SceneManagement
{
    public class SavingWrapper : MonoBehaviour
    {
        const string defaultSaveFile = "save";
        [SerializeField] float fadeInTime = 1f;
        Fader fader;
        private void Awake()
        {
            StartCoroutine(LoadLastScene());
        }
        private IEnumerator LoadLastScene()
        {
            Fader fader = FindObjectOfType<Fader>();

            fader.FadeOutImmediate();

            yield return GetComponent<SavingSystem>().LoadLastScene(defaultSaveFile);

            yield return fader.FadeIn(fadeInTime);

        }
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.L))
            {
                Load();
            }

            if (Input.GetKeyDown(KeyCode.S))
            {
                Save();
            }
            if (Input.GetKeyDown(KeyCode.Delete))
            {
                Delete();
            }
        }

        public void Save()
        {
            GetComponent<SavingSystem>().Save(defaultSaveFile);
        }

        public void Load()
        {
            GetComponent<SavingSystem>().Load(defaultSaveFile);
        }

        public void Delete()
        {
            GetComponent<SavingSystem>().Delete(defaultSaveFile);
        }

    }
}

