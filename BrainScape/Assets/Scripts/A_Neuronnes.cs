using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class A_Neuronnes : MonoBehaviour
{
    [SerializeField] private SO_Ennemis ennemisManager;

    private Sprite sprite;
    public float life;
    private float speed;
    private float degats;
    private Vector3 defilement;
    private Vector3 rotation;
    private int randomRotate;
    // Start is called before the first frame update
    void Start()
    {
        sprite = ennemisManager.sprite;
        life = ennemisManager.life;
        speed = ennemisManager.speed;
        degats = ennemisManager.degats;
        defilement = new Vector3((float) (speed * -0.01), 0, 0);
        randomRotate = UnityEngine.Random.Range(-3, 3);
        while (randomRotate == 0)
        {
            randomRotate = UnityEngine.Random.Range(-3, 3);
        }
        rotation = new Vector3(0, 0, randomRotate);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void FixedUpdate()
    {
        transform.Translate(defilement, Space.World);
        transform.Rotate(rotation);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            //other.gameObject.GetComponent<Player>().TakeDamage(degats);
            Explosion();
            Death();
            transform.parent.gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
        
        if (other.gameObject.tag == "Bullet")
        {
            transform.parent.gameObject.GetComponent<A_Nerfs>().life -= 1;

            if (transform.parent.gameObject.GetComponent<A_Nerfs>().life <= 0)
            {
                Explosion();
                Death();
            }
            else
            {
                TakeHit();
            }
        }
    }

    IEnumerator Explosion()
    {
        //code visuel
        transform.GetChild(0).gameObject.GetComponent<PolygonCollider2D>().enabled = true;
        transform.GetChild(1).gameObject.GetComponent<PolygonCollider2D>().enabled = true;
        yield return new WaitForSeconds(1);
        transform.GetChild(0).gameObject.GetComponent<PolygonCollider2D>().enabled = false;
        transform.GetChild(1).gameObject.GetComponent<PolygonCollider2D>().enabled = false;
        yield return null;
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
