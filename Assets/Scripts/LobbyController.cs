using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LobbyController : MonoBehaviour
{
   
        [SerializeField] private GameObject LevelSelection;
        [SerializeField] private Button buttonPlay;
        [SerializeField] private Button buttonQuit;
        private void Awake()
        {
            buttonPlay.onClick.AddListener(PlayGame);
            buttonQuit.onClick.AddListener(QuitGame);
        }

        private void QuitGame()
        {
            Application.Quit();
        }

        private void PlayGame()
        {
            LevelSelection.SetActive(true);
        }
    }

