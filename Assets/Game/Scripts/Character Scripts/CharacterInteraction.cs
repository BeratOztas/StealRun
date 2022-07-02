using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInteraction : MonoBehaviour
{
    private bool isTouched = false;
    [SerializeField] private GameObject hitEffect;
    private Character character;
    

     void Awake()
    {
        character = GetComponent<Character>();
        
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("StaticObs")&&!isTouched)
        {

            Instantiate(hitEffect,  transform.position + new Vector3(0f, 0.75f, 0.5f), transform.rotation);
            isTouched = true;
            gameObject.SetActive(false);

            
        }
        if (other.CompareTag("HorizontalObs")&& !isTouched)
        {
            Instantiate(hitEffect, transform.position + new Vector3(0f, 0.75f, 0.5f), transform.rotation);
            isTouched = true;
            gameObject.SetActive(false);
        }
        if (other.CompareTag("EndMovementPoint")) {
            character.SetCharacterStateMiss();
           
        }
       

    }
    

}
