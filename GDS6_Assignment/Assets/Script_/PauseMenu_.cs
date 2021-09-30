using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu_ : MonoBehaviour
{
    // Start is called before the first frame update
    public static bool GameIsPaused = true;
    public GameObject pauseMenuUI;
    public HleathSystem hS;
    public PlayerMovement_ pM;
    public Player2Movement_ p2M;
    public bool lockFunction = false;

    //public bool stopMoving = false;
    //public HleathSystem healthSystem;

    // Update is called once per frame

    private void Start()
    {
        pauseMenuUI.SetActive(false);
    }
    void Update()
    {
        //Debug.Log(GameIsPaused);
        if (lockFunction == false)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Debug.Log("Get it ");

                if (!GameIsPaused)
                {
                    //Resume();
                    GameIsPaused = true;
                    Resume();
                    pM.lockMoving = false;
                    p2M.lockMoving = false;
                    // hS.stopMoving = false;
                }
                else
                {

                    GameIsPaused = false;
                    Pause();
                    pM.lockMoving = true;
                    p2M.lockMoving = true;
                    // Pause();

                }
            }
        }
 

        //Debug.Log("gameisPaused : " + GameIsPaused);
    }

    public void Resume()
    {
        //GameIsPaused = false;
        Time.timeScale = 1;

        pauseMenuUI.SetActive(false);
        pM.lockMoving = false;
        p2M.lockMoving = false;

    }


    void Pause()
    {
        //GameIsPaused = true;
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0;
       
    }

    public void Restart()
    { SceneManager.LoadScene("FinalLevelScene"); GameIsPaused = true; }
    public void Menu()
    { SceneManager.LoadScene("MenuScene"); }


    //public void LoadMenu() { Debug.Log("Go to the Menu"); }
    public void QuitGame() { Application.Quit(); }
}
