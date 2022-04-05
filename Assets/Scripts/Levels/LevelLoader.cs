using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


[RequireComponent(typeof(Button))]    
public class LevelLoader : MonoBehaviour
    {
        private Button button;
        public string LevelName;

        private void Awake()
        {
            button = GetComponent<Button>();
        button.onClick.AddListener(onClick);
        }

    private void onClick()
    {
        LevelStates levelStates = LevelManager.Instance.GetLevelStates(LevelName);
        switch (levelStates)
        {
            case LevelStates.Locked:
                Debug.Log("Cannot Play this level till you Unlock it ");
                break;

             case LevelStates.Unlocked:
              SceneManager.LoadScene(LevelName);
                break;
            
            case LevelStates.Completed:
             SceneManager.LoadScene(LevelName);
                break;
        }
        
    }
}
