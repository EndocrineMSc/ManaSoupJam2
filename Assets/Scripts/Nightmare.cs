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
        
        // Why is this a field? Only used locally
        protected float _distance;
        protected float _minimumDistance = 1f;
        protected float _angle;


        protected Vector2 _direction = new();

        protected bool _gotHit = false;
        protected bool _playerGotHit;

        protected Rigidbody2D _rigidbody;

        [SerializeField] protected int _health = 2;
        [SerializeField] protected float _speed;
        [SerializeField] protected float attackReach;
        [SerializeField] float iFrameSeconds;
        [SerializeField] AttackBehavior myAttack;
        #endregion

        #region Properties


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
            if (collision.gameObject.name.Contains("Player"))
            {               
                LifeManager.Instance.LoseLife();                            
            }

            if (collision.gameObject.name.Contains("Weapon") && !_gotHit)
            {
                // Cast the collision object to "Weapon" and extract the damage. Or reference statically (ugly)
                int damage = 1;
                StartCoroutine(LoseHealth(damage));
            }
        }

        protected virtual void Update()
        {
            Debug.DrawLine(myAttack.transform.position, _player.transform.position, Color.red, 40f);

            _distance = Vector2.Distance(transform.position, _player.transform.position);
            _direction = _player.transform.position - transform.position;
            Vector2 normDirection = _direction;
            normDirection.Normalize();
            _angle = Mathf.Atan2(normDirection.y, normDirection.x) * Mathf.Rad2Deg;
            
            if (_distance > _minimumDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, _player.transform.position, _speed * Time.deltaTime);
            }
            else if (_distance <= attackReach)
            {
                myAttack.attack(_player);
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

            if (_health <= 0)
            {
                Destroy(gameObject);
            }

            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
            Color tempColor = spriteRenderer.color;
            spriteRenderer.color = Color.red;
            _gotHit = true;
            yield return new WaitForSeconds(iFrameSeconds);
            spriteRenderer.color = tempColor;
            _gotHit = false;

        }

        #endregion
    }
}

