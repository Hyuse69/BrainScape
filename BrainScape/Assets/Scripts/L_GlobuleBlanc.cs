using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class L_GlobuleBlanc : MonoBehaviour
{
    [SerializeField] private SO_Ennemis enemyManager;
    private Sprite sprite;
    private float life;
    private float speed;
    private float degats;

    private bool up;
    //private float time;
    private Transform player;
    [SerializeField] private bool canShoot = true;
    private bool locked;
    private bool charging;
    private Animator animator;

    [SerializeField] private AnimationCurve curve;
    void Start()
    {
        sprite = enemyManager.sprite;
        life = enemyManager.life;
        speed = enemyManager.speed;
        degats = enemyManager.degats;
        player = GameObject.Find("Player").transform;
        animator = GetComponent<Animator>();
        
        StartCoroutine(LockOn());
    }

    void FixedUpdate()
    {
        if(!locked) transform.right = (player.position - transform.position) * -1; 
        if(charging) transform.Translate(transform.right * -0.3f);
    }

    private IEnumerator LockOn()
    {
        yield return new WaitForSeconds(1);
        animator.SetTrigger("Charge");
        locked = true;
    }

    public void Charge()
    {
        charging = true;
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
