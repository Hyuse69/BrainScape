using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float x = Mathf.Clamp(Input.GetAxis("Horizontal") / 10 + transform.position.x, -8, 8);
        float y = Mathf.Clamp(Input.GetAxis("Vertical") / 10 + transform.position.y, -4, 4);
        transform.position = new Vector3(x, y, 0);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Transform bullet = Instantiate(transform.GetChild(0), transform);
            bullet.gameObject.SetActive(true);
            bullet.SetParent(transform.parent);
        }
    }
}
