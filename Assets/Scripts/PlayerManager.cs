using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ferula.GameManagement
{
    public class PlayerManager : MonoBehaviour
    {
        [SerializeField] private bool _isAnt = false;
        [SerializeField] private float _direction = 1f;
        [SerializeField] private float _velocity = 1f;
        [SerializeField] private Vector3 _initialPosition;
        [SerializeField] private Vector3 _finalPosition;
        [SerializeField] private Animator _animator;
        [SerializeField] private bool _startAnimation = false;
        [SerializeField] private string _animationName;
        [SerializeField] private string _restartAnimationName;
        [SerializeField] private bool _isFirstScene=false;
        [SerializeField] private float _x = 0f;
        [SerializeField] private float _X = 0f;

        public void RestartPlayer()
        {
            gameObject.transform.position = _initialPosition;
            _startAnimation = false;
            _animator.SetTrigger(_restartAnimationName);
            
        }

        private void GetKey()
        {
            if (_isFirstScene)
            {
                _x = Input.GetAxisRaw("Horizontal");
                _X = Input.GetAxis("Horizontal");
            }
            else
            {
                _x = 0f;
            }
        }

        private void FixedUpdate()
        {
            GetKey();
            if(_startAnimation)
            {
                if (_isAnt)
                {
                    AntMovement();
                }
                else
                {
                    BilMovement();
                }
            }
            if(_isFirstScene && _isAnt)
            {
                transform.position += new Vector3(_x, 0.0f, 0.0f) * (Time.deltaTime * _velocity);
                _animator.SetFloat("Walk", _X);
            }
           
            
        }

        public void StartAnimation()
        {
            _startAnimation = true;
            _animator.SetTrigger(_animationName);
        }

        private void AntMovement()
        {
            if (gameObject.transform.position.x <= _finalPosition.x)
            {
                gameObject.transform.position += new Vector3(_direction, 0.0f, 0.0f) * (Time.deltaTime * _velocity);

            }
        }

        private void BilMovement()
        {
            if (gameObject.transform.position.x >= _finalPosition.x)
            {
                gameObject.transform.position += new Vector3(_direction, 0.0f, 0.0f) * (Time.deltaTime * _velocity);

            }
        }

    }
}
