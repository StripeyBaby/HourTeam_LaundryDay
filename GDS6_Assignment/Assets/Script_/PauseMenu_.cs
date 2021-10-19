using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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

    [Header("Image :")]
    public GameObject option;
    public GameObject pauseImage;
    public GameObject puaseTextImage;
    public GameObject textImage;

    bool turnToOptions = false;

    [Header("Audio")]
    public AudioSource bgm;
    public Slider bgmSlider;
    public AudioSource effectmusic;
    public Slider effectSlider;

    //public bool stopMoving = false;
    //public HleathSystem healthSystem;

    // Update is called once per frame

    private void Start()
    {
        option.SetActive(false);
        pauseMenuUI.SetActive(false);
        pauseImage.SetActive(false);
        puaseTextImage.SetActive(false);
        textImage.SetActive(false);

        
        bgmSlider.value = bgm.volume;
      //  effectSlider.value = effectmusic.volume;
        //effectmusic.volume = PlayerPrefs.GetFloat("Effect Volume");
        // effectSlider.value = effectmusic.volume;

        //effectSlider.value = PlayerPrefs.GetFloat("Effect Slider");

        //bgm.volume = 1;
        //bgmSlider.value = 1;

       // effectSlider.value = PlayerPrefs.GetFloat("Effect Slider");
       // effectmusic.volume = PlayerPrefs.GetFloat("Effec Volume");
        bgm.volume = PlayerPrefs.GetFloat("BGM Volume");
        bgmSlider.value = PlayerPrefs.GetFloat("BGM Slider");
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
                    pauseImage.SetActive(true);
                    puaseTextImage.SetActive(true);
                    textImage.SetActive(true);
                    pauseImage.SetActive(false);
                    puaseTextImage.SetActive(false);
                    textImage.SetActive(false);

                    // hS.stopMoving = false;
                }
                else
                {
                    option.SetActive(false);
                    GameIsPaused = false;
                    Pause();
                    pM.lockMoving = true;
                    p2M.lockMoving = true;
                    pauseImage.SetActive(true);
                    puaseTextImage.SetActive(true);
                    textImage.SetActive(true);
                    
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

   
        PlayerPrefs.SetFloat("BGM Volume", bgm.volume);
        PlayerPrefs.SetFloat("BGM Slider", bgmSlider.value);

    }

    public void Resume()
    {
        //GameIsPaused = false;
        Time.timeScale = 1;

        pauseMenuUI.SetActive(false);
        pM.lockMoving = false;
        p2M.lockMoving = false;
        pauseImage.SetActive(false);
        puaseTextImage.SetActive(false);
        textImage.SetActive(false);

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
        option.SetActive(true);
        pauseImage.SetActive(false);
        puaseTextImage.SetActive(false);
        textImage.SetActive(false);
    }

    public void Return()
    {
        turnToOptions = false;
        option.SetActive(false);
        pauseImage.SetActive(true);
        puaseTextImage.SetActive(true);
        textImage.SetActive(true);
    }
    //float index
    public void MusicValue(float index) 
    {

        //index = PlayerPrefs.GetFloat("BGM Slider");
        //bgm.volume = index;
        bgm.volume = index;
        bgmSlider.value = index;
       // PlayerPrefs.SetFloat("BGM Volume", bgm.volume);


    }

    public void EffectMusicValue(float index)
    {
       // index = PlayerPrefs.GetFloat("Effect Slider");
        effectmusic.volume = index;
       // effectSlider.value = index;
       // PlayerPrefs.SetFloat("Effect Volume", effectmusic.volume);
       // PlayerPrefs.SetFloat("Effect Slider", index);
    }

    //public void LoadMenu() { Debug.Log("Go to the Menu"); }
    public void QuitGame() { Application.Quit(); }
}
