using DreamCatcher.Nightmares.Spawners;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EnumCollection;

namespace DreamCatcher.WinCondtion
{
    public class WinConditionManager : MonoBehaviour
    {
        #region Fields

        private GameObject[] _spawnerObjects;
        private List<NPC> _spawnerList = new List<NPC>();
        private int needToBeCleaned;

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
        }

        #endregion
    }
}
