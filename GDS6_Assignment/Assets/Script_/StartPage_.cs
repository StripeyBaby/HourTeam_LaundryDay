using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartPage_ : MonoBehaviour
{
    public GameObject blackImage;
    public float readyTime;
    bool turnOnBlackImage = false;

    BlackImageFunction_ blackImage_;
    void Start()
    {
        //turnOnBlackImage = true;
        blackImage_ = blackImage.GetComponent<BlackImageFunction_>();
        //blackImage_.Switch(false);
      //  blackImage_.TurnWhite();
    }

    // Update is called once per frame
    void Update()
    {  //
         blackImage_.Switch(turnOnBlackImage);
       //
        //Debug.Log(turnOnBlackImage);
    }

    public void StartGame() 
    {
        turnOnBlackImage = true;
        //blackImage_.Switch(turnOnBlackImage);
     

        Invoke("StartLoadingGame", readyTime);

    }
    void StartLoadingGame() 
    {
         SceneManager.LoadScene("SampleScene");
    }

}
