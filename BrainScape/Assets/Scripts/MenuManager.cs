using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Jouer()
    {
        GameObject.Find("EffetClick").GetComponent<AudioSource>().Play();
        SceneManager.LoadScene(1);
    }

    public void Options()
    {
        GameObject.Find("EffetClick").GetComponent<AudioSource>().Play();
        GameObject.Find("Canvas").transform.GetChild(3).gameObject.SetActive(true);
        GameObject.Find("Canvas").transform.GetChild(2).gameObject.SetActive(false);
    }

    public void Credits()
    {
        GameObject.Find("EffetClick").GetComponent<AudioSource>().Play();
        GameObject.Find("Canvas").transform.GetChild(4).gameObject.SetActive(true);
        GameObject.Find("Canvas").transform.GetChild(2).gameObject.SetActive(false);
    }

    public void Quitter()
    {
        GameObject.Find("EffetClick").GetComponent<AudioSource>().Play();
        Application.Quit();
    }

    public void Titre()
    {
        GameObject.Find("EffetClick").GetComponent<AudioSource>().Play();
        SceneManager.LoadScene(0);
    }

    public void Reprendre()
    {
        GameObject.Find("EffetClick").GetComponent<AudioSource>().Play();
        GameObject.Find("Main Camera").GetComponent<Pauseescape>().isPaused = false;
        Time.timeScale = 1;
        SceneManager.UnloadSceneAsync(gameObject.scene);
    }

    public void RetourPrinc()
    {
        GameObject.Find("EffetClick").GetComponent<AudioSource>().Play();
        GameObject.Find("Canvas").transform.GetChild(2).gameObject.SetActive(true);
        transform.parent.gameObject.SetActive(false);
    }
}
