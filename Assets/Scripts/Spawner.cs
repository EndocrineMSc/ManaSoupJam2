using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DreamCatcher.Nightmares.SpawnerManager;

namespace DreamCatcher.Nightmares.Spawners
{
    public class Spawner : MonoBehaviour
    {
        #region Fields

        private NightmareSpawnManager _spawnerManager;
        private bool cooldownActive;
        private Transform _spawnPosition;
        private Spawner _instance;

        #endregion

        #region Private Functions

        private void Awake()
        {
            _instance = this;
            _spawnPosition = _instance.transform;
        }

        // Start is called before the first frame update
        void Start()
        {
            _spawnerManager = NightmareSpawnManager.Instance;
        }

        // Update is called once per frame
        void Update()
        {
            if(!cooldownActive)
            {
                Debug.Log(_spawnerManager);
                Debug.Log(_spawnPosition);
                cooldownActive = true;
                NightmareSpawnManager.Instance.SpawnNightmare(_spawnPosition);
                float timer = _spawnerManager.SpawnTimer;
                StartCoroutine(TimerClock(timer));
            }
        }

        #endregion

        #region IEnumerators

        private IEnumerator TimerClock(float timer)
        {
            yield return new WaitForSeconds(timer);
            cooldownActive = false;
        }

        #endregion
    }
}
