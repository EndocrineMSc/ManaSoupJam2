using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DreamCatcher.Lives;


namespace DreamCatcher.Nightmares
{
    public class Nightmare : MonoBehaviour
    {
        #region Fields
        [SerializeField] protected GameObject _player;
        
        protected float distance;
        protected float angle;
        [SerializeField] protected float repellForce; //speed with which the enemy gets repelled when hitting the player

        protected Vector2 direction = new();
        #endregion

        #region Properties

        [SerializeField] protected float _speed;

        public float Speed
        {
            get { return _speed;}
            set { _speed = value; }
        }

        #endregion

        #region Public Functions


        #endregion

        #region Protected Functions

        protected virtual void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.name.Contains("Player"))
            {
                LifeManager.Instance.LoseLife();

                Rigidbody2D rigidbody = GetComponent<Rigidbody2D>();

                rigidbody.AddForce(new Vector2(-direction.x, -direction.y) * repellForce);
            }
        }

        protected virtual void Update()
        {
            distance = Vector2.Distance(transform.position, _player.transform.position);
            direction = _player.transform.position - transform.position;
            direction.Normalize();
            angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            transform.SetPositionAndRotation(Vector2.MoveTowards(transform.position, _player.transform.position, _speed * Time.deltaTime), Quaternion.Euler(Vector3.forward * angle));
        }

        #endregion
    }
}

