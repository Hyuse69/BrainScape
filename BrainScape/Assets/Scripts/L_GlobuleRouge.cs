using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L_GlobuleRouge : MonoBehaviour
{
    [SerializeField] private SO_Ennemis enemyManager;
    private Sprite sprite;
    private float life;
    private float speed;
    private float degats;

    private bool up;
    private float time;
    [SerializeField] private bool canShoot = true;

    [SerializeField] private AnimationCurve curve;
    // Start is called before the first frame update
    void Start()
    {
        sprite = enemyManager.sprite;
        life = enemyManager.life;
        speed = enemyManager.speed;
        degats = enemyManager.degats;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (time < 1) up = false;
        else if (time > 1) up = true;
        float upMultiplier = up ? 1 : -1;
        transform.position = new Vector3(7.5f, (curve.Evaluate(time % 1) * 8 - 4) * upMultiplier) ;
        time = (time + Time.fixedDeltaTime) % 2;
        if (canShoot) StartCoroutine(Shoot());
        transform.right = (GameObject.Find("Player").transform.position - transform.position) * -1;
    }

    private IEnumerator Shoot()
    {
        Transform bullet = Instantiate(transform.GetChild(0), transform);
        bullet.gameObject.SetActive(true);
        bullet.SetParent(transform.parent);
        canShoot = false;
        yield return new WaitForSeconds(0.5f);
        canShoot = true;
    }
}
