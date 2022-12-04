using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using EnumCollection;
using DreamCatcher;
using UnityEngine;

namespace DreamCatcher.Audio
{
    //this script is intended as a singleton
    public class AudioManager : MonoBehaviour
    {
        #region Fields

        public static AudioManager Instance { get; private set; }

        private List<AudioSource> _gameTracks = new();
        private List<AudioSource> _soundEffects = new();

        [SerializeField] private GameObject _gameTracksObject;
        [SerializeField] private GameObject _soundEffectsObject;

        #endregion

        #region Public Functions

        //Fades music in or out depending on whether it is already
        //playing or not. Uses the enum Track to get a specific
        //Track according to the enum from the Track-List
        //Order in List will be according to order in GameObject
        public void FadeGameTrack(Track track)
        {
            AudioSource audioSource = _gameTracks[(int)track];

            if (!audioSource.isPlaying || audioSource.volume == 0)
            {
                audioSource.volume = 0;
                StartCoroutine(StartFade(audioSource, 3f, 1f));
            }
            else
            {
                StartCoroutine(StartFade(audioSource, 3f, 0f));
            }
        }

        //Plays a Sound Effect according to the enum index
        //if it isn't playing already
        public void PlaySoundEffect(SFX sfx)
        {
            AudioSource audioSource = _soundEffects[(int)sfx];

            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }

        public void StopSoundEffect(SFX sfx)
        {
            AudioSource audioSource = _soundEffects[(int)sfx];
            if (audioSource.isPlaying)
            {
                audioSource.Stop();
            }

        }

        #endregion

        #region Private Functions

        private void Awake()
        {
            // If there is an instance, and it's not this one, delete this one

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
            _gameTracks = _gameTracksObject.GetComponents<AudioSource>().ToList<AudioSource>();
            _soundEffects = _soundEffectsObject.GetComponents<AudioSource>().ToList<AudioSource>();
        }

        #endregion

        #region IEnumerators

        private IEnumerator StartFade(AudioSource audioSource, float duration, float targetVolume)
        {
            float currentTime = 0;
            float start = audioSource.volume;

            while (currentTime < duration)
            {
                currentTime += Time.deltaTime;
                audioSource.volume = Mathf.Lerp(start, targetVolume, currentTime / duration);
                yield return null;
            }
        }

        #endregion
    }
}