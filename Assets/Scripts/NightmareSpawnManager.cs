using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DreamCatcher.Nightmares.Spawners;


namespace DreamCatcher.Nightmares.SpawnerManager
{
    public class NightmareSpawnManager : MonoBehaviour
    {
        #region Fields
       
        private Nightmare[] _nightmares;

        [SerializeField] private Nightmare _nightmare1;
        [SerializeField] private Nightmare _nightmare2;
        [SerializeField] private Nightmare _nightmare3;

        private bool _moreSpawnsCooldown;
        private float minimumSpawnCooldown = 0.5f;
        [SerializeField] private float difficultyCooldown = 10;

        public static NightmareSpawnManager Instance { get; private set; }

        #endregion

        #region Properties

        [SerializeField] private float _spawnTimer = 10;
       
        public float SpawnTimer
        {
            get { return _spawnTimer; }
            private set { _spawnTimer = value; }
        }

        #endregion

        #region Public Functions

        public void IncreaseSpawnRate(float timerReduction)
        {
            _spawnTimer -= timerReduction;
        }

        public void SpawnNightmare(Transform spawner)
        {
            Vector2 spawnPosition = spawner.position;
            int randomNightmare = Random.Range(0, _nightmares.Length);

            Nightmare tempNightmare = _nightmares[randomNightmare];

            Instantiate(tempNightmare, spawnPosition, Quaternion.identity);
        }

        #endregion

        #region Private Functions

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
        }

        private void Start()
        {
            _nightmares = new Nightmare[] { _nightmare1, _nightmare2, _nightmare3 };
        }

        private void Update()
        {
            if(!_moreSpawnsCooldown)
            {
                _moreSpawnsCooldown = true;
                if (Instance.SpawnTimer > minimumSpawnCooldown)
                {
                    Instance.IncreaseSpawnRate(1);
                    StartCoroutine(MakeGameHarderTimer());
                }
                else
                {
                    _moreSpawnsCooldown = false;
                }
                
            }
        }
        #endregion

        #region IEnumerators

        private IEnumerator MakeGameHarderTimer()
        {
            yield return new WaitForSeconds(difficultyCooldown);
            _moreSpawnsCooldown = false;
        }
        #endregion
    }
}
