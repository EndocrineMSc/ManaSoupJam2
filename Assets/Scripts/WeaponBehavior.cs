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
            Debug.Log("Swing!");
            Vector2 mousePosition = Input.mousePosition;
            Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(mousePosition);

            // playerWeapon.transform.LookAt(mouseWorldPosition, Vector3.up);
            GetComponent<Renderer>().enabled = true;
            _attacking = true;

            StartCoroutine(SwingAnimation());
        }
    }

    #region IEnumerators

        private IEnumerator SwingAnimation()
        {
            yield return new WaitForSeconds(attackDuration);
            GetComponent<Renderer>().enabled = false;
            _attacking = false;
        }
        #endregion

}
