using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartPage_ : MonoBehaviour
{
    public GameObject blackImage;
    public float readyTime;
    bool turnOnBlackImage = false;
    public AudioSource water;

    BlackImageFunction_ blackImage_;
    void Start()
    {
        //turnOnBlackImage = true;
        blackImage_ = blackImage.GetComponent<BlackImageFunction_>();
       
    }

    // Update is called once per frame
    void Update()
    {
        blackImage_.Switch(turnOnBlackImage);

       // blackImage_.Switch(false);
        Debug.Log("Boollen:           " +turnOnBlackImage);
    }

    public void StartGame() 
    {
        turnOnBlackImage = true;
        //blackImage_.Switch(turnOnBlackImage);

        if (!water.isPlaying)
        {
            water.Play();
        }
       
        Invoke("StartLoadingGame", readyTime);

    }
    void StartLoadingGame() 
    {
        SceneManager.LoadScene("FinalLevelScene");
    }

    public void QuitTheGame() 
    {
        Application.Quit();
    }

}
