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
        protected float _minimumDistance = 1f;
        protected float _angle;

        protected Vector2 _direction = new();

        protected bool _playerGotHit;

        protected Rigidbody2D _rigidbody;

        [SerializeField] protected int _health = 2;
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

        protected virtual void OnTriggerEnter2D(Collider2D collision)
        {
            Debug.Log("Collide");
            if (collision.gameObject.name.Contains("Player"))
            {               
                LifeManager.Instance.LoseLife();                            
            }

            if (collision.gameObject.name.Contains("Weapon"))
            {
                StartCoroutine(LoseHealth(1));
                Debug.Log("Hit");
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

        protected IEnumerator LoseHealth(int damage)
        {
            _health -= damage;

            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
            Color tempColor = spriteRenderer.color;
            spriteRenderer.color = Color.red;
            yield return new WaitForSeconds(0.1f);
            spriteRenderer.color = tempColor;

            if (_health <= 0)
            {
                Destroy(this);
            }
        }

        #endregion
    }
}

