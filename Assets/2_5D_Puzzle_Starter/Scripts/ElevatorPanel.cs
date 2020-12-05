using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorPanel : MonoBehaviour
{
    [SerializeField] private Renderer _callButton;

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player") 
        {   
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("Change color to blue");
                _callButton.material.color = Color.green;
            }
        }
    }
}
