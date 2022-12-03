using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBehavior : MonoBehaviour
{
    [SerializeField] GameObject playerWeapon;
    [SerializeField] float attackDuration;

    // private Renderer renderer = null;
    private bool _attacking = false;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Renderer>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Left Mouse button click
        if(Input.GetButtonDown("Fire1") && !_attacking)
        {
            Vector2 mousePosition = Input.mousePosition;
            // Find the point in game we clicked at
            Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(mousePosition);

            // Rotate the weapon to point into clicked direction
            playerWeapon.transform.LookAt(mouseWorldPosition, Vector3.forward);

            // Do the attack 
            GetComponent<Renderer>().enabled = true;
            _attacking = true;
            StartCoroutine(SwingAnimation());
        }
    }

    #region IEnumerators

        // Do a single attack
        private IEnumerator SwingAnimation()
        {
            yield return new WaitForSeconds(attackDuration);
            GetComponent<Renderer>().enabled = false;
            _attacking = false;
        }
        #endregion

}
