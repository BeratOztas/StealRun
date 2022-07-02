using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction :MonoSingleton<PlayerInteraction>
{
    [SerializeField] private PlayerRunner playerRunner;
    [SerializeField] private PlayerManagement playerManagement;
    [SerializeField] private GameObject hitEffect;
    

    public bool isLeftHand;


    
   
    private void OnTriggerEnter(Collider other)
    {
            if (other.CompareTag("CharacterCol") && isLeftHand)
            {
                playerRunner.leftStealAnimation();
                playerRunner.StartToRun();
                
                other.GetComponentInParent<Character>().CanChase();
            
            

            //other.gameObject.SetActive(false);
        }
            else if (other.CompareTag("CharacterCol") && !isLeftHand)
            {
                playerRunner.rightStealAnimation();
                playerRunner.StartToRun();
                
                other.GetComponentInParent<Character>().CanChase();
                
            

            // other.gameObject.SetActive(false);
        }
        
        
        if (other.CompareTag("StaticObs")) {
            //var particle = ObjectPooler.Instance.GetPooledObject("Hit Effect");
            //particle.transform.position = transform.position + new Vector3(0f, 0.75f, 0.5f);
            //particle.transform.rotation = transform.rotation;
            //particle.SetActive(true);
            //particle.GetComponent<ParticleSystem>().Play();
            Instantiate(hitEffect, transform.position + new Vector3(0f, 0.75f, 0.5f), transform.rotation);

            other.gameObject.SetActive(false);
                FailedAction();
        }
        if (other.CompareTag("HorizontalObs")) { 
            //var particle = ObjectPooler.Instance.GetPooledObject("Hit Effect");
            //    particle.transform.position = transform.position + new Vector3(0f, 0.75f, 0.5f);
            //    particle.transform.rotation = transform.rotation;
            //    particle.SetActive(true);
            //    particle.GetComponent<ParticleSystem>().Play();
            Instantiate(hitEffect, transform.position + new Vector3(0f, 0.75f, 0.5f), transform.rotation);
                other.gameObject.SetActive(false);
                FailedAction();
        }
        if (other.CompareTag("FinishLine")) {
            Invoke("FinishedAction", 0.5f);
        }


    }
   
    void FailedAction()
    {
        PlayerManagement.Instance.FailedLvl();
        //UIManager.Instance.RestartButtonUI();
    }
    void FinishedAction() {
        PlayerManagement.Instance.StartToDance();
        //UIManager.Instance.NextLvlUI();
    }

}//class
