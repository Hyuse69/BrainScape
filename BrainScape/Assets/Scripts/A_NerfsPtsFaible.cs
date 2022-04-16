using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class A_NerfsPtsFaible : MonoBehaviour
{
    private float life;
    // Start is called before the first frame update
    void Start()
    {
        life = transform.parent.gameObject.GetComponent<A_Nerfs>().life;
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
            //other.gameObject.GetComponent<Player>().TakeDamage(degats);
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            transform.parent.gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
        
        if (other.gameObject.tag == "Bullet")
        {
            transform.parent.gameObject.GetComponent<A_Nerfs>().life -= 1;

            if (transform.parent.gameObject.GetComponent<A_Nerfs>().life <= 0)
            {
                Death();
                if (transform.parent.childCount == 0)
                {
                    transform.parent.gameObject.GetComponent<A_Nerfs>().Death();
                }
            }
            else
            {
                TakeHit();
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
        float timeRemain = 2;

        while (timeRemain > 0)
        {
            timeRemain -= Time.deltaTime;
            gameObject.GetComponent<Material>().SetFloat("DissolveAmount",Mathf.Abs((timeRemain - 2)/2));
        }
        Destroy(gameObject);

        yield return null;
    }
}
