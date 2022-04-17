using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    private bool canShoot = true;
    [SerializeField] private int life;
    private bool canTakeDamage = true;

    public Transform lifeBar;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float x = Mathf.Clamp(Input.GetAxis("Horizontal") / 10 + transform.position.x, -8, 5.6f);
        float y = Mathf.Clamp(Input.GetAxis("Vertical") / 10 + transform.position.y, -4, 4);
        transform.position = new Vector3(x, y, 0);
        if (Input.GetKey(KeyCode.Space) && canShoot) StartCoroutine(WaitBeforeShooting());
    }

    private IEnumerator WaitBeforeShooting()
    {
        Transform bullet = Instantiate(transform.GetChild(0), transform);
        bullet.gameObject.SetActive(true);
        bullet.SetParent(transform.parent);
        canShoot = false;
        yield return new WaitForSeconds(0.2f);
        canShoot = true;
    }

    public void TakeDamage(int dmg)
    {
        if (!canTakeDamage) return;
        life-=dmg;
        Debug.Log(life);
        if (life <= 0)
        {
            //Death();
        }
        else
        {
            canTakeDamage = false;
            StartCoroutine(WaitBeforeTakingDamage());
            StartCoroutine(InvincibilityBlink());
        }

        for (int i = 0; i < lifeBar.childCount; i++)
        {
            if (i+1 > life) lifeBar.GetChild(i).gameObject.SetActive(false);
        }
    }

    private IEnumerator WaitBeforeTakingDamage()
    {
        yield return new WaitForSeconds(2);
        canTakeDamage = true;
    }

    private IEnumerator InvincibilityBlink()
    {
        bool red = false;
        SpriteRenderer ship = transform.GetChild(1).GetComponent<SpriteRenderer>();
        while (!canTakeDamage)
        {
            red = !red;
            ship.color = red?Color.red:Color.white;
            yield return new WaitForSeconds(0.2f);
        }
    }
}
