using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCol : MonoBehaviour
{
    private PlayerRunner playerRunner;
    

    
        void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                Debug.Log("Worked");
                playerRunner = other.GetComponentInParent<PlayerRunner>();
                playerRunner.forwardSpeed += 0.5f;
                gameObject.GetComponent<CharacterCol>().enabled = false;
                
            }
        }

    
}
