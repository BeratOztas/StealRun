using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Character : MonoBehaviour
{
    private Transform target;
    [SerializeField]
    private Transform[] objects;
    private int random;
    [SerializeField]
    private bool canChase;
    [SerializeField]
    private float ChaseDistance = 4f;
    [SerializeField]
    private float AttackDistance = 2f;
    [SerializeField]
    private float chase_After_Attack_Distance = 1f;
    [SerializeField]
    private float wait_Before_Attack = 2f;
    private float attackTimer;
    public float moveSpeed = 2f;
    public float maxSpeed = 12f;
    
    
    private NavMeshAgent agent;
    private CharacterAnimator characterAnim;

    private CharacterState characterState;
   
    private bool isCatched = false;

   
    
    
    public enum CharacterState {
        WAIT,
        CHASE,
        ATTACK,
        MISS
    }
    

     void Awake()
    {
        characterState = CharacterState.WAIT;
        target = GameObject.FindGameObjectWithTag("Player").transform;
        characterAnim = GetComponent<CharacterAnimator>();

    }
    
    void Start()
    {
        
        ActiveObject();
        agent = GetComponentInParent<NavMeshAgent>();
    }
    
     void Update()
    {
        if (canChase) {
            objects[random].gameObject.SetActive(false);
            characterAnim.React();
            
            
            
            if (Vector3.Distance(transform.position, target.position) >= ChaseDistance)
            {
                characterState = CharacterState.CHASE;
            }
        }

        if (characterState == CharacterState.MISS) {
            Miss();
        }
       
        if(characterState == CharacterState.CHASE) {
            Chase();
        }
        if(characterState == CharacterState.ATTACK) {
            Attack();
            if (!isCatched) { 
            PlayerManagement.Instance.CatchPlayer();
                isCatched = true;
            }
            characterState = CharacterState.WAIT;
        }

        
    }
    
    
    
    public void CanChase() {
        canChase = true;
    }
    public void SetCharacterStateMiss() {

        canChase = false;
        characterState = CharacterState.MISS;
        
    }
    void Miss() {
        
        agent.velocity = Vector3.zero;
        agent.isStopped = true;
        characterAnim.Miss(true);
        characterState = CharacterState.WAIT;

    }
    void Chase() {
            agent.isStopped = false;
            agent.SetDestination(target.position);        
            characterAnim.Run(true);
        

        if (Vector3.Distance(transform.position, target.position) <= AttackDistance)
            {

            //characterAnim.Run
            characterAnim.Run(false);

            characterState = CharacterState.ATTACK;
            }

    }
    void Attack() {
        agent.velocity = Vector3.zero;
        agent.isStopped = true;
        attackTimer += Time.deltaTime;
        if(attackTimer > wait_Before_Attack) {
            characterAnim.Attack();
            
            //CharacterAnimation.Instance.attackAnimation();
            // characterAnim.Attack();
            attackTimer = 0f;
            //characterState = CharacterState.WAIT;
            //Character Attack Sound
        }
        //if(Vector3.Distance(transform.position, target.position) > AttackDistance + chase_After_Attack_Distance) {
        //    characterState = CharacterState.CHASE;
        //}
    }

    void ActiveObject() {
         random = Random.Range(0, objects.Length);
        objects[random].gameObject.SetActive(true);
    }

    


}
