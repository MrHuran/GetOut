using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterAI : MonoBehaviour
{
    public NavMeshAgent monster;

    public Transform player;

    public LayerMask whatIsGround, whatIsPlayer;

    Animator animator;

    //Variables pour la patrouille
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    //Variables pour l'état du monstre
    public float sightRange;
    public bool playerInSightRange;

    //Variable pour checker si le monstre se déplace ou non
    Vector3 prevPos;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        player = GameObject.Find("VR Rig").transform;
        monster = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        //Check si le joueur est dans la vision du monstre
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);

        if (!playerInSightRange) Patroling();
        else Chasing();
    }

    private void Patroling()
    {
        // Si le monstre ne sait pas où aller, alors il cherche un endroit où aller
        if (!walkPointSet)
        {
            animator.SetBool("isMoving", false);
            animator.SetBool("isChasing", false);
            SearchWalkPoint();
        }
        else
        {
            animator.SetBool("isMoving", true);
            animator.SetBool("isChasing", false);
            monster.SetDestination(walkPoint);
            //Si le monstre est bloqué (ne bouge pas), alors il cherche un autre endroit où aller
            if (transform.position == prevPos)
            {
                Debug.Log("Le monstre est bloqué");
                animator.SetBool("isMoving", false);
                animator.SetBool("isChasing", false);
                SearchWalkPoint();
            }
        }

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        //WalkPoint atteint
        if (distanceToWalkPoint.magnitude < 1f) walkPointSet = false;

        prevPos = transform.position;
    }

    private void SearchWalkPoint()
    {
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.y + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround)) walkPointSet = true;
    }

    private void Chasing()
    {
        animator.SetBool("isChasing", true);
        animator.SetBool("isMoving", true);
        monster.SetDestination(player.position);
        walkPointSet = false;
    }
}