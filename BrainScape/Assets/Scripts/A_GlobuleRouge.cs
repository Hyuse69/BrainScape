using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class A_GlobuleRouge : MonoBehaviour
{
    [SerializeField] private SO_Ennemis enemyManager;
    private Sprite sprite;
    private float life;
    private float speed;
    private float degats;

    private bool up;
    private float time;
    private Animator animator;
    [SerializeField] private bool canShoot = true;

    [SerializeField] private AnimationCurve curve;
    // Start is called before the first frame update
    void Start()
    {
        sprite = enemyManager.sprite;
        life = enemyManager.life;
        speed = enemyManager.speed;
        degats = enemyManager.degats;
        animator = GetComponent<Animator>();
        StartCoroutine(Shooting());
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (time < 1) up = false;
        else if (time > 1) up = true;
        float upMultiplier = up ? 1 : -1;
        transform.position = new Vector3(7.5f, (curve.Evaluate(time % 1) * 8 - 4) * upMultiplier) ;
        time = (time + Time.fixedDeltaTime) % 2;
        //transform.right = (GameObject.Find("Player").transform.position - transform.position) * -1;
    }

    public void Shoot()
    {
        StartCoroutine(Shooting());
        Transform bullet = Instantiate(transform.GetChild(0), transform);
        bullet.gameObject.SetActive(true);
        bullet.SetParent(transform.parent);
    }

    private IEnumerator Shooting()
    {
        yield return new WaitForSeconds(3f);
        animator.SetTrigger("Shoot");
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<Player>().TakeDamage((int)degats);
        }
        
        if (other.gameObject.tag == "PlayerBullet")
        {
            life--;
            if (life <= 0)
            {
                //Death();
                Destroy(gameObject);
            }
            else
            {
                StartCoroutine(TakeHit());
            }
        }
    }

    private IEnumerator TakeHit()
    {
        SpriteRenderer[] spriteList = GetComponentsInChildren<SpriteRenderer>();
        foreach (SpriteRenderer spriteRenderer in spriteList)
        {
            spriteRenderer.color = Color.black;
        }
        yield return new WaitForSeconds(0.1f);
        foreach (SpriteRenderer spriteRenderer in spriteList)
        {
            spriteRenderer.color = Color.white;
        }
    }
}
