using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class WinAndReturnMenuFunction_ : MonoBehaviour
{
  //  public GameObject youWinText;
    public GameObject returnButton;
    public GameObject blackImage;
    public SceneControl_ cSC;

    BlackImageFunction_ blackImage_;
    bool turnOnBlack = false;
    float readyTime = 2f;
    // Start is called before the first frame update
    void Start()
    {
        blackImage_ = blackImage.GetComponent<BlackImageFunction_>();
    }

    // Update is called once per frame
    void Update()
    {
        blackImage_.Switch(turnOnBlack);
    }

    public void ReturnToMenu() 
    {
        cSC.turnItOff = true;
        turnOnBlack = true;
        Invoke("StartLoadingScene", readyTime);
    }

    void StartLoadingScene() 
    {
        SceneManager.LoadScene("StartScene");
    }
}
