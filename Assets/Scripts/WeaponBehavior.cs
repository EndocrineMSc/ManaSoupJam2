using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    [SerializeField] GameObject playerWeapon;

    // Start is called before the first frame update
    void Start()
    {
                playerWeapon.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePosition = Input.mousePosition;
        Camera.main.ScreenToWorldPoint(mousePosition);

        playerWeapon.transform.rotate();
    }

}
