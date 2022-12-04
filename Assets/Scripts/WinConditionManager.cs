using DreamCatcher.Nightmares.Spawners;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EnumCollection;
using TMPro;

namespace DreamCatcher.WinCondtion
{
    public class WinConditionManager : MonoBehaviour
    {
        #region Fields

        private GameObject[] _spawnerObjects;
        private List<NPC> _spawnerList = new List<NPC>();
        private int needToBeCleaned;
        [SerializeField] private TextMeshProUGUI _counter;
        private int remainingDreamers;

        #endregion

        #region Private Functions

        // Start is called before the first frame update
        void Start()
        {
            _spawnerObjects = GameObject.FindGameObjectsWithTag("Spawner");

            foreach (GameObject obj in _spawnerObjects)
            {
                NPC temp = obj.GetComponentInParent<NPC>();
                _spawnerList.Add(temp);
            }

            needToBeCleaned = _spawnerList.Count;
            remainingDreamers = needToBeCleaned;
        }

        // Update is called once per frame
        void Update()
        {
            int currentlyCleaned = 0;
            foreach (NPC npc in _spawnerList)
            {
                if (npc.IsCleaned)
                {
                    currentlyCleaned++;
                }
            }

            if (currentlyCleaned == needToBeCleaned)
            {
                GameManager.Instance.SwitchState(GameState.Victory);
            }

            remainingDreamers = needToBeCleaned - currentlyCleaned;

            _counter.text = "Remaining Dreamers: " + remainingDreamers;
        }

        #endregion
    }
}
