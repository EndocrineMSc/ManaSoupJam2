using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DreamCatcher.Lives;
using UnityEditor.Experimental.GraphView;

namespace DreamCatcher.Nightmares
{
    public class Nightmare : MonoBehaviour
    {
        #region Fields
        GameObject _player;
        
        protected float _distance;
        protected float _minimumDistance = 2;
        protected float _angle;

        protected Vector2 _direction = new();

        protected bool _playerGotHit;

        protected Rigidbody2D _rigidbody;
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
            }
        }

        protected virtual void Update()
        {
            _distance = Vector2.Distance(transform.position, _player.transform.position);
            _direction = _player.transform.position - transform.position;
            _direction.Normalize();
            _angle = Mathf.Atan2(_direction.y, _direction.x) * Mathf.Rad2Deg;
            
            if (_distance > _minimumDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, _player.transform.position, _speed * Time.deltaTime);
            }
            else
            {
                //ToDo Attack Code
            }
        }

        protected virtual void Awake()
        {
            _player = GameObject.FindGameObjectWithTag("Player");
            _rigidbody = GetComponent<Rigidbody2D>();
        }
        #endregion

        #region IEnumerators


        #endregion
    }
}

