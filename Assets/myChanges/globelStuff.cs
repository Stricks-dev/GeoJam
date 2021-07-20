using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class globelStuff : MonoBehaviour
{
    
    public Animator DeathScreen;
    public static globelStuff instance;
    public int menuIndex;
    public bool isPaused;
    public GameObject PauseMenu;
    private void Awake()
    {
        instance = this;
        if (PauseMenu != null)
        {
            PauseMenu.SetActive(false);
        }
    }
    private void Start()
    {
        isPaused = false;
    }
    private void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex != menuIndex)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (isPaused)
                {
                    Time.timeScale = 1f;
                    PauseMenu.SetActive(false);
                    isPaused = false;
                }
                else
                {
                    isPaused = true;
                    PauseMenu.SetActive(true);
                    Time.timeScale = 0f;
                }
            }
        }
    }
    private void Instance_onDeath(object sender, System.EventArgs e)
    {
        
        DeathScreen.SetTrigger("ON");
    }
    public void loadScene(int index)
    {
        SceneManager.LoadSceneAsync(index);
    }
    public void loadMainMenu()
    {
        SceneManager.LoadSceneAsync(menuIndex);
    }
    public void Reload()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
    }
    public void openURL(string URL)
    {
        Application.OpenURL(URL);
    }
}
