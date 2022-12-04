using System.Collections;
using System.Collections.Generic;
using EnumCollection;
using DreamCatcher.Audio;
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
        resetAttack();
    }

    void resetAttack()
    {
        _attacking = false;
        GetComponent<Renderer>().enabled = false;
        GetComponent<Collider2D>().enabled = false;
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
            GetComponent<Collider2D>().enabled = true;
            _attacking = true;
            StartCoroutine(AttackAnimation());
           
        }
    }

    #region IEnumerators

        // Do a single attack
        private IEnumerator AttackAnimation()
        {
        AudioManager.Instance.PlaySoundEffect(SFX.PlayerHitSound2);
        yield return new WaitForSeconds(attackDuration);
        resetAttack();
        AudioManager.Instance.StopSoundEffect(SFX.PlayerHitSound2);
        }

    
    #endregion

}
