using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColledableObjects : MonoBehaviour
{
    private PlayerRunner playerRunner;
    [SerializeField] private float afterStealSpeed = 0.5f;

    public ObjectType objectType;

    public enum ObjectType { 
        Character,
        Player,
        StaticObstacle,
        HorizontalObstacle,
        FinishLine
    }

    private void Start()
    {
        playerRunner = FindObjectOfType<PlayerRunner>();
    }


   void OnTriggerEnter(Collider other)
    {
        if (objectType == ObjectType.Character) {
            var particle = ObjectPooler.Instance.GetPooledObject("Steal Effect");
            particle.transform.position = other.transform.position + new Vector3(0f, 0.75f, 0.5f);
            particle.transform.rotation = gameObject.transform.rotation;
            particle.SetActive(true);
            particle.GetComponent<ParticleSystem>().Play();
            PlayerManagement.Instance.addSpeed(afterStealSpeed);
            gameObject.SetActive(false);
            
        }
       
       
    
    }

   


}
