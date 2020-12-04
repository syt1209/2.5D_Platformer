using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private CharacterController _controller;
    [SerializeField] private float _speed = 5f;
    [SerializeField] private float _gravity = 1.0f;
    [SerializeField] private float _jumpHeight = 20.0f;
    [SerializeField] private int _lives = 3;

    private float _yVelocity;
    private bool _canDoubleJump = false;
    [SerializeField] private int _coins = 0;
    [SerializeField] private bool _coinCollected = false;
    private UIManager _uiManager;

    // Start is called before the first frame update
    void Start()
    {
        _controller = GetComponent<CharacterController>();
        _uiManager = GameObject.Find("UI_Manager").GetComponent<UIManager>();

        if (_uiManager is null)
        {
            Debug.LogError("UIManager is NULL.");
        }

        _uiManager.UpdateLiveText(_lives);
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        UpdateCoin();
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

    public void CoinCollected()
    {
        _coinCollected = true;
    }

    private void UpdateCoin()
    {
        if (_coinCollected == true)
        {
            _coins += 1;
            _coinCollected = false;
        }

        _uiManager.UpdateCoinText(_coins);
    }

    public void Damage()
    {
        _lives--;

        _uiManager.UpdateLiveText(_lives);

        if (_lives < 1) 
        {
            SceneManager.LoadScene(0);
        }
    }
}
