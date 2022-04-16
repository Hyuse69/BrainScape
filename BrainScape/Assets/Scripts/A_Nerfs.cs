using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class A_Nerfs : MonoBehaviour
{
    [SerializeField] private SO_Ennemis ennemisManager;

    private Sprite sprite;
    public float life;
    private float speed;
    private float degats;

    private Vector3 defilement;
    private Quaternion randomRotate;
    private float scaleSizeY = 15;
    // Start is called before the first frame update
    void Start()
    {
        sprite = ennemisManager.sprite;
        life = ennemisManager.life;
        speed = ennemisManager.speed;
        degats = ennemisManager.degats;
        randomRotate = Quaternion.Euler(new Vector3(0, 0, Random.Range(-45f, 45f)));
        defilement = new Vector3((float) (speed * -0.01), 0, 0);
        
        //fin du code
        transform.localScale = new Vector3(0.5f,scaleSizeY,1);
        transform.rotation = randomRotate;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        transform.Translate(defilement, Space.World);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            //other.gameObject.GetComponent<Player>().TakeDamage(degats);
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            transform.GetChild(0).gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
    }
    
    public IEnumerator Death()
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
