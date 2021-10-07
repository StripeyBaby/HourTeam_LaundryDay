using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditSceneControl_ : MonoBehaviour
{

    public GameObject blackImage;
    bool turnOnBlackImage = false;


    public GameObject returnButton;
    public float readyTime;
    BlackImageFunction_ blackImage_;
    // Start is called before the first frame update
    void Start()
    {
        blackImage_ = blackImage.GetComponent<BlackImageFunction_>();
    }

    // Update is called once per frame
    void Update()
    {
        blackImage_.Switch(turnOnBlackImage);
    }

    public void Return() 
    {
        turnOnBlackImage = true;

        Invoke("StartLoadMenuPage", readyTime);
    }

    void StartLoadMenuPage() 
    {
        SceneManager.LoadScene("StartScene");
    }
}
