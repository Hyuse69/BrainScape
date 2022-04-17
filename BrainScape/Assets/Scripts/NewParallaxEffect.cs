using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewParallaxEffect : MonoBehaviour
{
    [SerializeField] float parallaxEffect;
    [SerializeField] GameObject cam;
    [SerializeField] Transform startPos;
    [SerializeField] Transform endPos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Debug.Log(transform.position.x);
        if (transform.position.x < endPos.position.x)
        {
            transform.position = new Vector3(startPos.position.x,0,0);
        }
        transform.Translate(-parallaxEffect,0,0);
    }
}
