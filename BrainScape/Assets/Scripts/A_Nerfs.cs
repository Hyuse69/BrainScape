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
    public float degats;

    private Vector3 defilement;
    private Quaternion randomRotate;
    public float scaleSizeY = 0.8f;
    public List<Vector3> listPosNerfs;
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
            other.gameObject.GetComponent<Player>().TakeDamage((int)degats);
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
