using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class L_NerfsPtsFaible : MonoBehaviour
{
    private float life;

    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        //GetComponent<SpriteRenderer>().material = Instantiate<Material>(GetComponent <SpriteRenderer>().material);
        animator = GetComponent<Animator>();
        life = transform.parent.gameObject.GetComponent<L_Nerfs>().life;
        transform.position = new Vector3(transform.position.x, Random.Range(-0.3f, 0.3f), transform.position.z);
        transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y / 15, transform.localScale.z);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<Player>().TakeDamage((int)transform.parent.gameObject.GetComponent<L_Nerfs>().degats);
        }
        
        if (other.gameObject.tag == "PlayerBullet")
        {
            transform.parent.gameObject.GetComponent<L_Nerfs>().life -= 1;

            if (transform.parent.gameObject.GetComponent<L_Nerfs>().life <= 0)
            {
                StartCoroutine(Death());
                transform.parent.gameObject.GetComponent<L_Nerfs>().Death();
            }
            else
            {
                StartCoroutine(TakeHit());
            }
        }
    }

    IEnumerator TakeHit()
    {
        gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        yield return new WaitForSeconds(1);
        gameObject.GetComponent<SpriteRenderer>().color = Color.white;
        yield return null;
    }

    IEnumerator Death()
    {
        var val = 0f;
        animator.SetTrigger("Dead");
        transform.parent.gameObject.GetComponent<Animator>().SetTrigger("Dead");
        GetComponent<CircleCollider2D>().enabled = false;
        transform.parent.GetComponent<BoxCollider2D>().enabled = false;
        yield return new WaitForSeconds(1f);
        Destroy(transform.parent.gameObject);
        Destroy(gameObject);

        yield return null;
       
    }
}
