using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] Transform _targetA, _targetB;
    [SerializeField] float _movingSpeed = 1.0f;
    private bool _switching = false;
 
    // Start is called before the first frame update
    void Start()
    {
        transform.position = _targetA.transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MovePlatform();   
    }

    private void MovePlatform() 
    {
        var target_A_pos = _targetA.transform.position;
        var target_B_pos = _targetB.transform.position;

        if (_switching is false)
        {
            transform.position = Vector3.MoveTowards(transform.position, target_B_pos, _movingSpeed * Time.deltaTime);
        }
        else if (_switching is true)
        {
            transform.position = Vector3.MoveTowards(transform.position, target_A_pos, _movingSpeed * Time.deltaTime);
        }
        

        if (transform.position == target_B_pos)
        {
            _switching = true;
        }

        if (transform.position == target_A_pos)
        {
            _switching = false;
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
