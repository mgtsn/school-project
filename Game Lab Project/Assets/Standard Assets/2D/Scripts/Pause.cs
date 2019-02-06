using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{

	public bool paused = false;
	public GameObject PauseMenu;

    // Start is called before the first frame update
    void Start()
    {
		PauseMenu.SetActive(false);
    }

    private void PauseGame()
    {
        if (paused)
        {
            paused = false;
            PauseMenu.SetActive(false);
            Time.timeScale = 1;
        } else {
            paused = true;
            PauseMenu.SetActive(true);
            Time.timeScale = 0f;

        }


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Pause")) 
        {
            PauseGame();
        }
    }


    public void Resume()
    {

        PauseGame();
    }


    public void MainMenu()
    {

        SceneManager.LoadScene("Main Menu");

    }

    public void Quit()
    {

        Application.Quit();

    }

}
