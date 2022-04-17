using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.U2D;
using Random = Unity.Mathematics.Random;

public class A_BulletRouge : MonoBehaviour
{
    [SerializeField] private AnimationCurve curve;
    private Vector2 velocity;
    // Start is called before the first frame update
    void Start()
    {
        float angle = UnityEngine.Random.Range(-25.5f, 25.5f);
        transform.rotation = Quaternion.Euler(new Vector3(0,0,angle));
        velocity = Vector2.right * -10;
        StartCoroutine(Target());
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        GetComponent<Rigidbody2D>().velocity = velocity;
        //transform.position += transform.right * -0.2f;
    }

    IEnumerator Target()
    {
        yield return new WaitForSeconds(0.5f);
        velocity = Vector2.zero;
        yield return new WaitForSeconds(0.3f);
        velocity = (GameObject.Find("Player").transform.position - transform.position).normalized * 10;
        //GetComponent<Rigidbody2D>().AddForce((GameObject.Find("Player").transform.position - transform.position) * 10);
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) other.gameObject.GetComponent<Player>().TakeDamage(1);
    }
}
