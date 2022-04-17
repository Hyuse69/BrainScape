using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = System.Random;

public class Spawner : MonoBehaviour
{
    public List<GameObject> LogicMobs;
    public List<GameObject> ArtistMobs;
    public Animator bg;

    private bool logic;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawn());
        StartCoroutine(ChangeBackground());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator Spawn()
    {
        List<GameObject> list = logic ? LogicMobs : ArtistMobs;
        var enemy = Instantiate(list[UnityEngine.Random.Range(0, 2)], new Vector3(transform.position.x, UnityEngine.Random.Range(-4f, 4f)), quaternion.Euler(Vector3.zero));
        //Manager.manager.enemies.Add(enemy);
        yield return new WaitForSeconds(1.7f);
        StartCoroutine(Spawn());
    }

    private IEnumerator ChangeBackground()
    {
        yield return new WaitForSeconds(10);
        logic = !logic;
        bg.SetTrigger(logic? "SwitchToLogic" : "SwitchToCrea");
        StartCoroutine(ChangeBackground());
    }
}
