using System;
using System.Collections.Generic;
using System.Collections;
using EnumCollection;
using DreamCatcher.Audio;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;

namespace DreamCatcher
{
    //The GameManager is a Singleton that is always present,
    //even when loading new Scenes
    //Just put an empty GameObject in the Scene, name it GameManager
    //and attach this script as a component
    public class GameManager : MonoBehaviour
    {
        #region Fields

        public static GameManager Instance { get; private set; }

        //Drag and Drop the respective Canvases to these
        [SerializeField] private GameObject _menuScreen;
        [SerializeField] private GameObject _creditsScreen;
        [SerializeField] private GameObject _settingsScreen;    

        #endregion

        #region Properties

        //allows for getting the GameState by other scripts
        //setting only over SwitchState outside of GameManager
        private GameState _state;
        public GameState State
        {
            get { return _state; }
            private set { _state = value; }
        }

        #endregion

        #region Public Functions

        //State Machine using the GameState enum of EnumCollections
        //EnumCollections is a separate Script that needs to be present
        //in the project
        public void SwitchState(GameState state)
        {
            Instance._state = state;
            switch (state)
            {
                case (GameState.MainMenu):
                    Scene _scene = SceneManager.GetActiveScene();
                    string _sceneName = _scene.name;

                    if (_sceneName != "MainMenu")
                    {
                        SceneManager.LoadSceneAsync("MainMenu");
                    }
                    AudioManager.Instance.FadeInGameTrack(Track.MainMenu);
                    AudioManager.Instance.FadeOutGameTrack(Track.CreditsMusic);
                    AudioManager.Instance.FadeOutGameTrack(Track.GameTrack);

                    CloseAllCanvases();
                    Instance._menuScreen.SetActive(true);                 
                    break;

                case (GameState.Credits):
                    CloseAllCanvases();
                    Instance._creditsScreen.SetActive(true);
                    AudioManager.Instance.FadeOutGameTrack(Track.MainMenu);
                    AudioManager.Instance.FadeInGameTrack(Track.CreditsMusic);
                    break; 

                case (GameState.Settings):
                    CloseAllCanvases();
                    Instance._settingsScreen.SetActive(true);
                    break;   

                case (GameState.Intro):
                    CloseAllCanvases();
                    SceneManager.LoadSceneAsync("Intro");
                    break;


                case (GameState.Starting):
                    //PlayGameTrack is a Method in the AudioManager
                    //It plays the Track that is referenced by using a
                    //Track enum in EnumCollection
                    SceneManager.LoadSceneAsync("LevelOne");
                    AudioManager.Instance.FadeOutGameTrack(Track.MainMenu);
                    AudioManager.Instance.FadeInGameTrack(Track.GameTrack);
                    break;

                case (GameState.Victory):
                    SceneManager.LoadSceneAsync("Victory");
                    AudioManager.Instance.PlaySoundEffect(SFX.Victory);
                    break;

                case (GameState.GameOver):
                    SceneManager.LoadSceneAsync("GameOver");
                    AudioManager.Instance.PlaySoundEffect(SFX.Gameover);
                    break;

                case (GameState.NewGame):
                    AudioManager.Instance.StopAllSoundEffects();
                    Instance.SwitchState(GameState.MainMenu);
                    break;

                case (GameState.Quit):
#if UNITY_EDITOR
                    EditorApplication.ExitPlaymode();
#endif  
                    Application.Quit();
                    break;
            }
        }

        #endregion

        #region Private Functions

        //closes all canvases, meant for state-changes in SwitchState()
        private void CloseAllCanvases()
        {
            Instance._menuScreen.SetActive(false);
            Instance._creditsScreen.SetActive(false);
            Instance._settingsScreen.SetActive(false);
        }

        //Awake, so that it runs before the Start Functions of other
        //scripts that need to reference "Instance" in Start
        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(this);
            }
            else
            {
                Instance = this;
            }

            DontDestroyOnLoad(this);                 
        }

        private void Start()
        {
            //starts the game in the main menu
            Instance.SwitchState(GameState.MainMenu);
        }

        #endregion

    }
}