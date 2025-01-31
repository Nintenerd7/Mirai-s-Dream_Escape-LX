using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class AIMovement : MonoBehaviour
{
  

    public NavMeshAgent _agent;

    public Transform playerTarget;

    public LayerMask IsGround, IsPlayer;

    //patrolling
    public Vector3 WalkPoint;
    bool walkpointSet;
    public float range;
    //
    public Animator anim;
    //attacking 
    public float AttackCoolDown;
    bool HasAttacked;
    //

    public float ViewRange, AttackRange;
    public bool PlayerInView, AttackPlayer;
    //
     public PlayerHearts damage;
    //

    //AWAKE
    private void Awake()
    {
        playerTarget = GameObject.Find("MIRAI").transform;//this is how the player gets tracked
        _agent = GetComponent<NavMeshAgent>();
        
    }
    //

    //PRIVATE UPDATE
    private void Update()
    {
        //check if player is in range
        PlayerInView = Physics.CheckSphere(transform.position, ViewRange, IsPlayer );
        //
        AttackPlayer = Physics.CheckSphere(transform.position, AttackRange, IsPlayer);

        if (!PlayerInView && !AttackPlayer) Patrolling();//calls patrolling 
        if (PlayerInView && !AttackPlayer) ChaseTarget();//calls chase  

    }
    //



    //patrolling
    private void Patrolling()
    {
        if(!walkpointSet)FindWalkPoint();//calls find walk point
        if (walkpointSet)
        {
            _agent.SetDestination(WalkPoint);
        }

        Vector2 distanceToWalkPoint = transform.position - WalkPoint;

        //walkpoint reached
        if (distanceToWalkPoint.magnitude < 1f)
        {
            walkpointSet = false;
        }
        //
    }

    //calculate walk point
    private void FindWalkPoint()
    {
        float randomZ = Random.Range(-range, range);//calculates movement on Z axis 
        float randomX = Random.Range(-range, range);//calculates movement on X axis

        WalkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);//

        if (Physics.Raycast(WalkPoint, -transform.up, 2f, IsGround))
        {
            walkpointSet = true;
        }
      
    }

    //
    //Chase
    private void ChaseTarget()
    {
        _agent.SetDestination(playerTarget.position);
    }
    //
    private void OnTriggerEnter(Collider other)//box collider that detects the player in their personal space
    {
        if (other.tag == "Player")//if the box detects the player 
        {
            anim.SetBool("Run", false);
            anim.SetBool("Attack", true);
           damage.TakeDamage(1);//takes one heart 

        }
    }

        private void OnTriggerExit(Collider other)//box collider that detects the player in their personal space
    {
        if (other.tag == "Player")//if the box detects the player 
        {
            anim.SetBool("Run", true);
            anim.SetBool("Attack", false);
           damage.TakeDamage(1);//takes one heart 

        }
    }


}
