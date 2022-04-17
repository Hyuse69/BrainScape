using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class A_NerfsPtsFaible : MonoBehaviour
{
    private float life;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        life = transform.parent.gameObject.GetComponent<A_Nerfs>().life;
        if (transform.parent.gameObject.GetComponent<A_Nerfs>().listPosNerfs.Count == 0)
        {
            transform.position = new Vector3(transform.position.x, Random.Range(-0.25f, 0.25f), transform.position.z);
            transform.parent.gameObject.GetComponent<A_Nerfs>().listPosNerfs.Add(transform.position);
        }
        else
        {
            if (transform.parent.gameObject.GetComponent<A_Nerfs>().listPosNerfs.Count <= 1)
            {
                transform.position = new Vector3(transform.position.x, Random.Range(-0.25f, 0.25f), transform.position.z);
                while (Vector3.Distance(transform.position,transform.parent.gameObject.GetComponent<A_Nerfs>().listPosNerfs[0]) <= 0.05)
                {
                    transform.position = new Vector3(transform.position.x, Random.Range(-0.25f, 0.25f), transform.position.z);
                }
                transform.parent.gameObject.GetComponent<A_Nerfs>().listPosNerfs.Add(transform.position);
            }
            else
            {
                transform.position = new Vector3(transform.position.x, Random.Range(-0.25f, 0.25f), transform.position.z);
                while ((Vector3.Distance(transform.position,transform.parent.gameObject.GetComponent<A_Nerfs>().listPosNerfs[0]) <= 0.05) 
                       || (Vector3.Distance(transform.position,transform.parent.gameObject.GetComponent<A_Nerfs>().listPosNerfs[1]) <= 0.05))
                {
                    transform.position = new Vector3(transform.position.x, Random.Range(-0.25f, 0.25f), transform.position.z);
                }
            }
        }
        
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
            other.gameObject.GetComponent<Player>().TakeDamage((int)transform.parent.GetComponent<A_Nerfs>().degats);
        }
        
        if (other.gameObject.tag == "PlayerBullet")
        {
            transform.parent.gameObject.GetComponent<A_Nerfs>().life -= 1;

            if (transform.parent.gameObject.GetComponent<A_Nerfs>().life <= 0)
            {
                StartCoroutine(Death());
                if (transform.parent.childCount == 0)
                {
                    StartCoroutine(transform.parent.gameObject.GetComponent<A_Nerfs>().Death());
                }
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
        bool lastChild = (transform.parent.childCount == 1);
        var val = 0f;
        animator.SetTrigger("Dead");
        if(lastChild) transform.parent.gameObject.GetComponent<Animator>().SetTrigger("Dead");
        GetComponent<CircleCollider2D>().enabled = false;
        if(lastChild) transform.parent.GetComponent<BoxCollider2D>().enabled = false;
        yield return new WaitForSeconds(1f);
        if(lastChild) Destroy(transform.parent.gameObject);
        Destroy(gameObject);
    }
}
