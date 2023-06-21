using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterAI : MonoBehaviour
{
    public NavMeshAgent monster;

    public Transform[] moveSpots;
    public int randomSpot;

    public Transform player;

    public LayerMask whatIsGround, whatIsPlayer;

    Animator animator;

    private SceneLoader sceneLoader;

    public Camera jumpscareCam;
    public AudioSource playerSound;
    public AudioSource monsterScream;
    public AudioSource monsterFootsteps;
    public AudioSource monsterChase;

    //Variables pour l'état du monstre
    public float sightRange;
    public bool playerInSightRange;

    public FadeScreen fade;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        monster = GetComponent<NavMeshAgent>();
        sceneLoader = GameObject.FindGameObjectWithTag("SceneLoader").GetComponent<SceneLoader>();
        jumpscareCam.enabled = false;
        randomSpot = Random.Range(0, moveSpots.Length);
    }

    private void Update()
    {
        //Check si le joueur est dans la vision du monstre
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        if (!jumpscareCam.enabled)
        {
            if (!playerInSightRange) Patroling();
            else Chasing();
            monsterFootsteps.enabled = true;
        }
        else monsterFootsteps.enabled = false;
    }

    private void Patroling()
    {
        monsterFootsteps.pitch = 1f;
        monsterChase.enabled = false;
        animator.SetBool("isChasing", false);
        animator.SetBool("isMoving", true);
        monster.SetDestination(moveSpots[randomSpot].position);
        if (Vector3.Distance(transform.position, moveSpots[randomSpot].position) < 0.2f) randomSpot = Random.Range(0, moveSpots.Length);
    }

    private void Chasing()
    {
        monsterChase.enabled = true;
        monsterFootsteps.pitch = 1.6f;
        animator.SetBool("isChasing", true);
        animator.SetBool("isMoving", true);
        monster.SetDestination(player.position);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            animator.SetBool("isKilling", true);
            
            player.gameObject.SetActive(false);
            jumpscareCam.enabled = true;
            jumpscareCam.GetComponent<AudioListener>().enabled = true;
            playerSound.gameObject.SetActive(false);
            monsterScream.Play();

            StartCoroutine(death());
        }
    }

    private IEnumerator death()
    {
        yield return new WaitForSeconds(1.5f);
        sceneLoader.LoadScene("Menu", fade);
    }
}