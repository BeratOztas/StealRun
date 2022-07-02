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
        //if (objectType == ObjectType.StaticObstacle && other.CompareTag("Player")) {

        //    var particle = ObjectPooler.Instance.GetPooledObject("Hit Effect");
        //    particle.transform.position = other.gameObject.transform.position + new Vector3(0f, 0.75f, 0.5f);
        //    particle.transform.rotation = gameObject.transform.rotation;
        //    particle.SetActive(true);
        //    particle.GetComponent<ParticleSystem>().Play();

        //    Invoke("FailedAction", 0f);

        //}
        //if(objectType == ObjectType.StaticObstacle && other.CompareTag("Character")) {
        //    if (!other.GetComponent<Character>().isTouched)
        //     {
        //        var particle = ObjectPooler.Instance.GetPooledObject("Hit Effect");
        //        particle.transform.rotation = gameObject.transform.rotation;
        //        particle.transform.position = other.transform.position + new Vector3(0f, 0.75f, 0.5f);
        //        particle.SetActive(true);
        //        other.GetComponent<Character>().isTouched = true;
        //        other.gameObject.SetActive(false);

        //    }


        //}
        //if (objectType == ObjectType.HorizontalObstacle && other.CompareTag("Player"))
        //{
        //    var particle = ObjectPooler.Instance.GetPooledObject("Hit Effect");
        //    particle.transform.position = other.gameObject.transform.position + new Vector3(0f, 0.75f, 0.5f);
        //    particle.transform.rotation = gameObject.transform.rotation;
        //    particle.SetActive(true);
        //    particle.GetComponent<ParticleSystem>().Play();

        //    Invoke("FailedAction", 0f);

        //}
        //if (objectType == ObjectType.HorizontalObstacle && other.CompareTag("Character"))
        //{
        //    var particle = ObjectPooler.Instance.GetPooledObject("Hit Effect");
        //    particle.transform.position = other.transform.position + new Vector3(0f, 0.75f, 0.5f);
        //    particle.transform.rotation = gameObject.transform.rotation;
        //    particle.SetActive(true);



        //}
       
    
    }

   


}
