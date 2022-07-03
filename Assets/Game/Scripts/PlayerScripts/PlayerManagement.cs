using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerManagement :MonoSingleton<PlayerManagement>
{
    [SerializeField] private PlayerRunner playerRunner;
    [SerializeField] private GameObject character;
    [SerializeField] private GameObject player;

    private bool canWalk = true;
    [HideInInspector]
    public float speed = 10f;
    [HideInInspector]
    public int collectedLvlPhoneAmount = 0;
    private bool isStarted = false;

    void Start()
    {
        playerRunner.idleAnimation();
        speed = playerRunner.GetForwardSpeed();
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0)&& canWalk) {

            playerRunner.StartToWalk();
            isStarted = true;
            canWalk = false;
        }
        showSpeedUIProcess();


    }
    public void CanWalk()
    {
        canWalk = true;
    }

    public void addSpeed(float value) {

        collectedLvlPhoneAmount += 1;
        speed += value;
        playerRunner.SetForwardSpeed(speed);
        UIManager.Instance.SetCollectedPhone();
    }
   

    public void FailedLvl() {

        playerRunner.SetRunning(false);
        playerRunner.takeHitAnimation();
        
       
        UIManager.Instance.RestartButtonUI();
    }

    void PlayParticle() {
        var particle = ObjectPooler.Instance.GetPooledObject("Clouds");
        particle.transform.position = transform.position + new Vector3(0f, 0.75f, 0.5f);
        particle.transform.rotation = transform.rotation;
        particle.SetActive(true);

    }
    public void CatchPlayer() {
        playerRunner.SetRunning(false);
        playerRunner.takeHitAnimation();
        
       
       
        UIManager.Instance.RestartButtonUI();
    }

    public void StartToDance() {
        playerRunner.SetRunning(false);
        playerRunner.DanceAnimation();
        
        canWalk = false;
        UIManager.Instance.NextLvlUI();
    }

    void showSpeedUIProcess() {
        float forwardSpeed = playerRunner.GetForwardSpeed();
        UIManager.Instance.SetProgress(forwardSpeed);
    }

    public void CharacterReset()
    {
        
        isStarted = false;
        collectedLvlPhoneAmount = 0;
        playerRunner.SetForwardSpeed(3.5f);


        player.transform.localRotation = Quaternion.Euler(0, 0, 0);
        
        character.transform.position = new Vector3(0f, 0f, 0f);
        
        playerRunner.idleAnimation();
        showSpeedUIProcess();
        UIManager.Instance.TapToPlay();
        UIManager.Instance.SetCollectedPhone();
    }
















}
