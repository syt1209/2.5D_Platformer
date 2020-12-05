using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    private bool _goingDown;
    [SerializeField] private GameObject _elevatorPanel;
    [SerializeField] private Transform _targetTopPos, _targetBottomPos;


    public void CallElevator()
    {
        _goingDown = true;
    }

    private void FixedUpdate()
    {
        if (_goingDown is true) 
        {
            transform.position = Vector3.MoveTowards(transform.position, _targetBottomPos.position, Time.deltaTime);
        }
    }
}
