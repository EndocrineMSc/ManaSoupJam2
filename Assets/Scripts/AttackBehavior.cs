using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBehavior : MonoBehaviour
{

     [SerializeField] GameObject enemyWeapon;
    [SerializeField] float attackDuration;
    private bool _attacking = false;

    // Start is called before the first frame update

    void resetAttack()
    {
        _attacking = false;
        GetComponent<Renderer>().enabled = true;
        GetComponent<Collider2D>().enabled = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        resetAttack();
        // Debug.Log(enemyWeapon.transform.position);
    }

    void Update()
    {
        Debug.DrawLine(enemyWeapon.transform.position, Vector3.zero,Color.red, 40f);
    }

    public void attack(GameObject player)
    {
        if(!_attacking)
        {
            enemyWeapon.transform.LookAt(player.transform, Vector3.forward);
            
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
        yield return new WaitForSeconds(attackDuration);
        resetAttack();
    }
    #endregion
}
