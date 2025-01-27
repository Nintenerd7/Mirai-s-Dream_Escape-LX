using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyAi : MonoBehaviour
{
    // Start is called before the first frame update    public NavMeshAgent _agent;

    public Transform playerTarget;

    public LayerMask IsGround, IsPlayer;

    //patrolling
    public Vector3 WalkPoint;
    bool walkpointSet;
    public float range;
    //

    //attacking 
    public float AttackCoolDown;
    bool HasAttacked;
    public GameObject Projectile;
    public Transform FirePoint;
    //

    //states
    public float ViewRange, AttackRange;
    public bool PlayerInView, AttackPlayer;
    //

    //taking player damage 
    public HeartSystem Damage;
    //

    //AWAKE
    private void Awake()
    {
        playerTarget = GameObject.Find("FIRST PERSON MOVEMENT,COMBAT,HUD").transform;
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

    private void ShootBullet()
    {
        //enemy shoots out a bullet to attack the player. 
        Rigidbody rb = Instantiate(Projectile, FirePoint.position, Quaternion.identity).GetComponent<Rigidbody>();
        rb.AddForce(FirePoint.forward * 5f, ForceMode.Impulse);
        //
    }
    private void OnTriggerEnter(Collider other)
    {
       // if (other.tag == "Player")
        //Damage.TakeHeart();
    }
}
