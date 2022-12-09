using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GameName.PlayerBehaviour
{
    public class PlayerController : MonoBehaviour
    {
        #region Fields

        private Vector3 moveDelta;
        private Vector3 playerScale;

        #endregion

        #region Private Functions

        private void Awake()
        {
            playerScale = transform.localScale;
        }
        
        private void FixedUpdate()
        {
            float x = Input.GetAxisRaw("Horizontal");
            float y = Input.GetAxisRaw("Vertical");

            moveDelta = new Vector3(x, y, 0);

            //Swap sprite direction, whether ur going right or left
            if (moveDelta.x > 0)
            {
                transform.localScale = new Vector3(playerScale.x, playerScale.y, playerScale.z);
            }
            else if (moveDelta.x < 0)
            {
                transform.localScale = new Vector3(-playerScale.x, playerScale.y, playerScale.z);
            }

            //movement
            transform.Translate(moveDelta * Time.deltaTime);

        }

        #endregion
    }
}

