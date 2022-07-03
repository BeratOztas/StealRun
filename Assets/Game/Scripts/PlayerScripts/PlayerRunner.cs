using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class PlayerRunner :MonoBehaviour
{

    private NavMeshSurface navMeshSurface;
    [SerializeField] private SimpleAnimancer animancer;
    [SerializeField] private PlayerSwerve playerSwerve;
    [SerializeField] private Transform playerTransform;
    

    [Header("Animations")]
    //idle ,walk,run,stealleftside,stealrightside
    [SerializeField] private string idleAnimName = "Breathing Idle";
    [SerializeField] private float idleAnimSpeed = 1f;

    [SerializeField] private string walkingAnim_Name = "Walking";
    [SerializeField] private float walkingAnimSpeed = 0.5f;

    [SerializeField] private string runningAnim_Name = "Running";
    [SerializeField] private float runningAnim_Speed = 1f;

    [SerializeField] private string left_takingAnim_Name = "Left Taking Item";
    [SerializeField] private float left_takingAnim_Speed = 0.5f;

    [SerializeField] private string right_takingAnim_Name = "Right Taking Item";
    [SerializeField] private float right_takingAnim_Speed = 0.5f;

    [SerializeField] private string take_hitAnim_Name = "Take Hit";
    [SerializeField] private float take_hitAnim_Speed = 1f;

    [SerializeField] private string danceAnim_Name = "Chicken Dance";
    [SerializeField] private float danceAnim_Speed = 1f;

    

    [Space]
    public float forwardSpeed = 1f;

    [SerializeField] private float strafeSpeed = 1f;
    [SerializeField] private float clampLocalX = 2f;
    [SerializeField] private float runningSpeed = 8f;
    [SerializeField] private float maxRunningSpeed = 8f;
    [SerializeField] private float waitStealProgressTime = 0.3f;
    [SerializeField] private float damping = 2f;

    private Vector3 moveTemp;
    private Vector3 forwardTemp;

    [SerializeField] private bool enabled = true;
    [SerializeField] private bool running = false;
    
    private bool canSwerve = true;
    private bool canReduce = false;
    
    
    private float speedDV=0f;
    

    void Awake()
    {
        playerSwerve.OnSwerve += PlayerSwerve_OnSwerve;
        
    }
    
    
     void Update()
    {
   
        MoveForward();
        reduceSpeed();
        //Debug.Log("FORWARD SPEED" + forwardSpeed);
    }

    public void Init() {
        navMeshSurface = FindObjectOfType<NavMeshSurface>();
        navMeshSurface.BuildNavMesh();
        
    }

    void PlayerSwerve_OnSwerve(Vector2 direction)
    {
        if (running && canSwerve)
        {
            moveTemp= playerTransform.localPosition + Vector3.right * direction.x * strafeSpeed * Time.deltaTime;
            playerTransform.localPosition = Vector3.Slerp(playerTransform.localPosition, moveTemp, damping);
            ClampLocalPosition();
        }
    }

    void ClampLocalPosition()
    {
        Vector3 pos = playerTransform.localPosition;
        pos.x = Mathf.Clamp(pos.x, -clampLocalX, clampLocalX);
        playerTransform.localPosition = pos;
    }
    void MoveForward()
    {
        if (enabled && running)
        {
            forwardTemp = transform.position;
            forwardTemp.z += forwardSpeed * Time.deltaTime;
            transform.position = forwardTemp;
        }
    }
    public void StartToWalk() {
        if (enabled) {
            running = true;
            walkAnimation();
        }
    }
    public void StartToRun() {
        forwardSpeed = runningSpeed;
        canReduce = true;
    }
    
    void reduceSpeed() {
         if(canReduce)
         forwardSpeed = Mathf.SmoothDamp(forwardSpeed, runningSpeed, ref speedDV, 7f);

    }

    public void PlayAnimation(string animName,float animSpeed) {
        animancer.PlayAnimation(animName);
        animancer.SetStateSpeed(animSpeed);
    }

    public void idleAnimation() {
        PlayAnimation(idleAnimName, idleAnimSpeed);
    }
    public void walkAnimation() {
        PlayAnimation(walkingAnim_Name, walkingAnimSpeed);
    }
    public void runAnimation()
    {
        PlayAnimation(runningAnim_Name, runningAnim_Speed);
    }
    public void leftStealAnimation() {
        PlayAnimation(left_takingAnim_Name, left_takingAnim_Speed);
        StartCoroutine(waitStealProgress(waitStealProgressTime));
    }
    public void rightStealAnimation()
    {
        PlayAnimation(right_takingAnim_Name, right_takingAnim_Speed);
        StartCoroutine(waitStealProgress(waitStealProgressTime));
    }

    public void takeHitAnimation() {
        PlayAnimation(take_hitAnim_Name, take_hitAnim_Speed);
    }
    public void DanceAnimation() {
        PlayAnimation(danceAnim_Name, danceAnim_Speed);
    }

    IEnumerator waitStealProgress(float animSpeed) {
        
       
        yield return new WaitForSeconds(animSpeed);

        runAnimation();

    }
    public void SetEnabled(bool value)
    {
        enabled = value;
    }
    public void SetCanReduce(bool value) {
        canReduce = value;
    }
    public void SetSwerve(bool value)
    {
        canSwerve = value;
    }
    public float GetForwardSpeed()
    {
        return forwardSpeed;
    }

    public void SetRunning(bool value) {
        running = value;
    }
    public void SetForwardSpeed(float value)
    {
        if (value <= maxRunningSpeed)
            forwardSpeed = value;
        else if (value > maxRunningSpeed)
            forwardSpeed = maxRunningSpeed;
        
    }

    
}
