using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private CharacterController _controller;
    [SerializeField] private float _speed = 5f;
    [SerializeField] private float _gravity = 1.0f;
    [SerializeField] private float _jumpHeight = 20.0f;
    private float _yVelocity;
    private bool _canDoubleJump = false;

    // Start is called before the first frame update
    void Start()
    {
        _controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {

        Vector3 direction = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
        Vector3 velocity = _speed * direction;
        
        if (_controller.isGrounded == true)
        {
            if (Input.GetKeyDown(KeyCode.Space)) 
            {
                _yVelocity = _jumpHeight;
                _canDoubleJump = true;
            }
        }
        else
        {
            if(_canDoubleJump==true && Input.GetKeyDown(KeyCode.Space))
            {
                _yVelocity += _jumpHeight;
                _canDoubleJump = false;
            }
            _yVelocity -= _gravity;
        }

        velocity.y = _yVelocity;
        
        _controller.Move(velocity * Time.deltaTime);
    }
}
