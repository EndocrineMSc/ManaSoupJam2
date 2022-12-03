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

        #endregion

        #region Private Functions

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
                cooldownActive = true;
                _spawnerManager.SpawnNightmare(this);
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
