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

    [Header("Buttons")]
    public GameObject restartB;
    public GameObject resumeB;
    public GameObject MenuB;
    public GameObject OptionB;
    public GameObject returnB;
    public GameObject MusicSlider;
    public GameObject EffectMusicSlider;

    bool turnToOptions = false;

    [Header("Audior")]
    public AudioSource bgm;
    public AudioSource effectmusic;

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
                    turnToOptions = false; 
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


        if (turnToOptions == true)
        {
            returnB.SetActive(true);
            MusicSlider.SetActive(true);
            EffectMusicSlider.SetActive(true);
            restartB.SetActive(false);
            resumeB.SetActive(false);
            MenuB.SetActive(false);
            OptionB.SetActive(false);
        }
        else
        {
            returnB.SetActive(false);
            MusicSlider.SetActive(false);
            restartB.SetActive(true);
            EffectMusicSlider.SetActive(false);
            resumeB.SetActive(true);
            MenuB.SetActive(true);
            OptionB.SetActive(true);
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
    { SceneManager.LoadScene("FinalLevelScene"); GameIsPaused = true; Time.timeScale = 1; }
    public void Menu()
    { SceneManager.LoadScene("StartScene"); Time.timeScale = 1; }

    public void Options() 
    {
        turnToOptions = true;
    }

    public void Return()
    {
        turnToOptions = false;
    }

    public void MusicValue(float index) 
    {
        bgm.volume = index;
    }

    public void EffectMusicValue(float index)
    {
        effectmusic.volume = index;
    }

    //public void LoadMenu() { Debug.Log("Go to the Menu"); }
    public void QuitGame() { Application.Quit(); }
}
