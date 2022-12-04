using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMotor : MonoBehaviour
{
    /*   public Transform lookAt;
     public float boundX = 0.15f;
     public float boundY = 0.05f;

    private void LateUpdate()
      {
          Vector3 delta = Vector3.zero;


          // Check if we are inside x-Axis Bounds
          float deltaX = lookAt.position.x - transform.position.x;
          if(deltaX > boundX || deltaX < -boundX)
          {
              if(transform.position.x < lookAt.position.x)
              {
                  delta.x = deltaX - boundX;
              }
              else
              {
                  delta.x = deltaX + boundX;
              }
          }
          // Check if we are inside Y-Axis Bounds
          float deltaY = lookAt.position.y - transform.position.y;
          if (deltaY > boundY || deltaY < -boundY)
          {
              if (transform.position.y < lookAt.position.y)
              {
                  delta.y = deltaY - boundY;
              }
              else
              {
                  delta.y = deltaY + boundY;
              }
          }

          transform.position += new Vector3(delta.x, delta.y, 0);
      }
     */

    public float FollowSpeed = 2f;
    public float yOffset = 1f;
    public Transform target;

    // Update is called once per frame
    void Update()
    {
        Vector3 newPos = new Vector3(target.position.x, target.position.y + yOffset, -10f);
        transform.position = Vector3.Slerp(transform.position, newPos, FollowSpeed * Time.deltaTime);
    }

}
