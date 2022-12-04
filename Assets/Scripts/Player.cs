using System.Collections;
using System.Collections.Generic;
using EnumCollection;
using DreamCatcher.Audio;
using UnityEngine;



public class Player : MonoBehaviour
{

    #region  Fields
    private BoxCollider2D boxCollider;
    private Animator animator;
    [SerializeField] private float _speed;
    
    #endregion 

    #region Methods
    private void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
       if(Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
       {
            animator.SetTrigger("playerUp");
       } 
       if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
       {
            animator.SetTrigger("playerLeft");
       }
       if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
       {
            animator.SetTrigger("playerDown");
       }
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            animator.SetTrigger("playerRight");
        }

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
        if(x != 0 || y != 0)
        {
            AudioManager.Instance.PlaySoundEffect(SFX.Footsteps);
            animator.enabled = true;
        }else
        {
            AudioManager.Instance.StopSoundEffect(SFX.Footsteps);
            animator.enabled = false;
        }
    }

    #endregion

}

