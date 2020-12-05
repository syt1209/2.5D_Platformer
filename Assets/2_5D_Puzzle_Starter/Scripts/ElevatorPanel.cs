using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorPanel : MonoBehaviour
{
    [SerializeField] private Renderer _callButton;
    [SerializeField] private int _coinTarget = 8;
    private Player _player;
    private void Start()
    {
        _player = GameObject.Find("Player").GetComponent<Player>();

        if (_player == null)
        {
            Debug.LogError("Player is NULL.");
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player") 
        {   
            if (Input.GetKeyDown(KeyCode.E) && _player.CoinCollected() == _coinTarget)
            {
                Debug.Log("Change color to blue");
                _callButton.material.color = Color.green;
            }
        }
    }
}
