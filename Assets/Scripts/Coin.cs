using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    //OntriggerEnter
    //Update player coin
    //Update UI text display
    private Player _player;


    private void Start()
    {
        _player = GameObject.FindWithTag("Player").GetComponent<Player>();

        if(_player == null) 
        {
            Debug.LogError("Player is NULL.");
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag is "Player") 
        {
            _player.CoinCollected();
            Debug.Log("Coin collected +1");
        }
        Destroy(this.gameObject);
    }
}
