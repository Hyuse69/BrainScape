using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    public static Manager manager;
    
    public int score;
    public List<GameObject> enemies;

    public List<GameObject> heads;
    public Animator headAnimator;
    public GameObject head;
    public RectTransform brainMask;

    public GameObject win;
    public GameObject lose;
    // Start is called before the first frame update
    void Start()
    {
        manager = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddScore(int mobScore)
    {
        score += mobScore;
        UpdateScore();
        AnimateHead(Mathf.FloorToInt(score/100));
    }

    private void UpdateScore()
    {
        var width = brainMask.sizeDelta.x;
        brainMask.sizeDelta = new Vector2(width, score * 0.6f / 3 + 20);
    }

    private void AnimateHead(int nb)
    {
        //if (nb == 1) headAnimator.SetTrigger("Hit01");
        //if (nb == 2) headAnimator.SetTrigger("Hit02");
        if(nb >= 3)
        {
            headAnimator.gameObject.SetActive(true);
            head.SetActive(false);
            headAnimator.SetTrigger("Death");
            win.SetActive(true);
            DestroyAll();
            return;
        }

        
        foreach (GameObject head in heads)
        {
            if(head == heads[nb])
            {
                Debug.Log(head);
                head.SetActive(true);
            }
            else head.SetActive(false);
        }
    }

    public void DestroyAll()
    {
        foreach (GameObject enemy in enemies)
        {
            if(enemy) Destroy(enemy);
        }
        Destroy(gameObject);
    }
}
