using System;
using UnityEngine;
using UnityEngine.SceneManagement;

   
    public class LevelManager : MonoBehaviour
    {
        private static LevelManager instance;
        public static LevelManager Instance { get { return instance; } }

        [SerializeField] string[] levels;
         public string Level1;
        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }


        private void Start()
        {
            if (GetLevelStates(Level1) == LevelStates.Locked)
            {
                SetLevelStates(Level1, LevelStates.Unlocked);
            } 
        }

        public void MarkCurrentLevelComplete()
        {
            Scene currentScene = SceneManager.GetActiveScene();

            //Set the level status to complete
            LevelManager.Instance.SetLevelStates(currentScene.name, LevelStates.Completed);

            //Unlock the next level
            int currentSceneIndex = Array.FindIndex(levels, level => level == currentScene.name);
            int nextSceneIndex = currentSceneIndex + 1;
            if (nextSceneIndex < levels.Length)
            {
                SetLevelStates(levels[nextSceneIndex], LevelStates.Unlocked);
            }
        }

        //GetLevelStates lets us access the states of each levels. 
        public LevelStates GetLevelStates(string level)
        {
            LevelStates levelStates = (LevelStates)PlayerPrefs.GetInt(level, 0); //Second arg, 0 is used to specify that the very first time the game is open every levels are locked
            return levelStates;
        }

        //SetLevelStates is used to store the information of the level locked,unlocked,completed locally in our device
        public void SetLevelStates(string level, LevelStates levelStates)
        {
            PlayerPrefs.SetInt(level, (int)levelStates);
            Debug.Log("Setting Level: " + level + " Status: " + levelStates);
        }
    }


