using System.Collections;
using System.Collections.Generic;
using EnumCollection;
using DreamCatcher.Audio;
using UnityEngine;



public class Player : MonoBehaviour
{

    #region  Fields
    private BoxCollider2D boxCollider;
    [SerializeField] private float _speed;
    
    #endregion 

    #region Methods
    private void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void FixedUpdate()
    {
        UpdateMovement();
    }

    private void UpdateMovement()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        Vector3 moveDelta = new Vector3(x, y, 0);
        SpriteRenderer spriteRenderer= GetComponent<SpriteRenderer>();

        //Swap sprite direction, whether ur going right or left
        if (moveDelta.x > 0)
        {
            spriteRenderer.flipX = false;
            
        }
        else if (moveDelta.x < 0)
        {
            spriteRenderer.flipX = true;
            
        }

        //movement
        transform.Translate(moveDelta * Time.deltaTime * _speed);
        AudioManager.Instance.PlaySoundEffect(SFX.Footsteps);
    }

    #endregion

}

