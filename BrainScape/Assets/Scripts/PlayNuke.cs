using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayNuke : MonoBehaviour
{
    // Start is called before the first frame update

    public ParticleSystem Ps;
    public ParticleSystem Ps2;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void PlayAnim()
    {
        Ps.Play();
        Ps2.Play();
    }
}
