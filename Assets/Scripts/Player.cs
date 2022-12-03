using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Player : MonoBehaviour
{
    private BoxCollider2D boxCollider;

    private Vector3 moveDelta;

    private void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void FixedUpdate()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        
        // Reset moveDelta 
        moveDelta = Vector3.zero;

        moveDelta = new Vector3(x, y, 0);

        //Swap sprite direction, whether ur going right or left
        if (moveDelta.x > 0)
        {
            transform.localScale =new Vector3(2, 2, 2);
        }
        else if (moveDelta.x < 0)
        {
            transform.localScale = new Vector3(-2, 2, 2);
        }

        //movement
        transform.Translate(moveDelta * Time.deltaTime);

    }

    

}
