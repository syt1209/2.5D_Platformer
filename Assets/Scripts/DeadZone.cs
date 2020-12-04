using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZone : MonoBehaviour
{
    [SerializeField]
    private GameObject _respawnPos;

    // Start is called before the first frame update
    void Start()
    {
        _respawnPos = GameObject.Find("Respawn_pos");
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Player") 
        {
            Player player = other.GetComponent<Player>();
            if (player != null)
            { 
                player.Damage();
            }

            CharacterController cc = other.GetComponent<CharacterController>();

            if (cc != null) 
            {
                cc.enabled = false;
                StartCoroutine(CCEnableRoutine(cc));
            }

            other.transform.position = _respawnPos.transform.position;
        }

        IEnumerator CCEnableRoutine (CharacterController controller)
        {
            yield return new WaitForSeconds(0.1f);
            controller.enabled = true;
        }

       

    }
}
