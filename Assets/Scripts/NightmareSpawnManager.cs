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
        [SerializeField] private Nightmare _nightmare4;
        [SerializeField] private Nightmare _nightmare5;

        private bool _moreSpawnsCooldown;
        private float _minimumSpawnCooldown = 2f;
        private float difficultyCooldown = 20;

        public static NightmareSpawnManager Instance { get; private set; }

        #endregion

        #region Properties

        private float _spawnTimer = 10;
       
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
            _nightmares = new Nightmare[] { _nightmare1, _nightmare2, _nightmare3, _nightmare4, _nightmare5 };
        }

        private void Update()
        {
            if(!_moreSpawnsCooldown)
            {
                _moreSpawnsCooldown = true;
                if (Instance.SpawnTimer > _minimumSpawnCooldown)
                {
                    Instance.IncreaseSpawnRate(0.5f);
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
