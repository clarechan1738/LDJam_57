using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    private float timer = 60f;
    [SerializeField]
    private GameObject pauseMenu;

    private DialogueManager dialogueMgr;

    private void Awake()
    {
        dialogueMgr = FindAnyObjectByType<DialogueManager>();
        Time.timeScale = 1.0f;
        pauseMenu.SetActive(false);
    }

    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime * 1f;
        }

        if(Input.GetKeyDown(KeyCode.Escape) && Time.timeScale == 1 && !dialogueMgr.dialogueActive)
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0;
        }
        else if(Input.GetKeyDown(KeyCode.Escape) && Time.timeScale == 0)
        {
            pauseMenu.SetActive(false);
            Time.timeScale = 1;
        }
    }


    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Quit()
    {
        Application.Quit();
    }

}
