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
        SceneManager.LoadSceneAsync("SceneLoadingLevel",LoadSceneMode.Additive);
    }

    public void Options()
    {
        GameObject.Find("Canvas").transform.GetChild(3).gameObject.SetActive(true);
        GameObject.Find("Canvas").transform.GetChild(2).gameObject.SetActive(false);
    }

    public void Credits()
    {
        GameObject.Find("Canvas").transform.GetChild(4).gameObject.SetActive(true);
        GameObject.Find("Canvas").transform.GetChild(2).gameObject.SetActive(false);
    }

    public void Quitter()
    {
        Application.Quit();
    }

    public void Titre()
    {
        SceneManager.LoadScene(0);
    }

    public void Reprendre()
    {
        //GameObject.Find("Player").GetComponent<Player>().isPaused = false;
        Time.timeScale = 1;
        SceneManager.UnloadSceneAsync(gameObject.scene);
    }

    public void RetourPrinc()
    {
        GameObject.Find("Canvas").transform.GetChild(2).gameObject.SetActive(true);
        transform.parent.gameObject.SetActive(false);
    }
}
