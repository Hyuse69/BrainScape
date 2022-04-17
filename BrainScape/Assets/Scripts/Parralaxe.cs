using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parralaxe : MonoBehaviour
{
    [SerializeField] private GameObject cam;
    [SerializeField] private float parralaxeEffect;
    private float lenght, startPos;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position.x;
        lenght = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float temp = (cam.transform.position.x * (1-parralaxeEffect));
        float dist = (cam.transform.position.x * parralaxeEffect);

        transform.position = new Vector3(startPos + dist, transform.position.y, transform.position.z);
        if (temp > startPos + lenght)
        {
            startPos += lenght;
        }
        else if (temp < startPos - lenght)
        {
            startPos -= lenght;
        }
    }
}
