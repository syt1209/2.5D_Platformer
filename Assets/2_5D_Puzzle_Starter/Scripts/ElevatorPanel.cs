using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorPanel : MonoBehaviour
{
    [SerializeField] private Renderer _callButton;
    [SerializeField] private int _coinTarget = 8;
    [SerializeField] private GameObject _elevator;
    private bool _elevatorCalled = false;
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player") 
        {   
            if (Input.GetKeyDown(KeyCode.E) && other.GetComponent<Player>().CoinCollected() > (_coinTarget-1))
            {
                if (_elevatorCalled is true)
                {
                    _callButton.material.color = Color.red;
                }
                else
                {
                    _callButton.material.color = Color.green;
                    _elevatorCalled = true;
                }
                
                _elevator.GetComponent<Elevator>().CallElevator();
            }
        }
    }
}
