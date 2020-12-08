using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    private bool _goingDown = false;
    private float _speed = 1.0f;
    [SerializeField] private GameObject _elevatorPanel;
    [SerializeField] private Transform _targetTopPos, _targetBottomPos;


    public void CallElevator()
    {
        _goingDown = !_goingDown;
    }

    private void FixedUpdate()
    {
        if (_goingDown is true)
        {
            transform.position = Vector3.MoveTowards(transform.position, _targetBottomPos.position, _speed*Time.deltaTime);
        }
        else if (_goingDown is false)
        {
            transform.position = Vector3.MoveTowards(transform.position, _targetTopPos.position, _speed*Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") 
        {
            other.transform.parent = this.transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            other.transform.parent = null;
        }
    }
}
