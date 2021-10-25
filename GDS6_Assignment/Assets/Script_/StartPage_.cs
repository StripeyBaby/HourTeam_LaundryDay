using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class StartPage_ : MonoBehaviour
{
    public GameObject blackImage;
    public float readyTime;
    bool turnOnBlackImage = false;
    public AudioSource water;

    BlackImageFunction_ blackImage_;


    public GameObject NewImage;
    public GameObject NewImage2;

    void Start()
    {
        NewImage.SetActive(false);
        //turnOnBlackImage = true;
        NewImage2.SetActive(false);
        blackImage_ = blackImage.GetComponent<BlackImageFunction_>();

    }

    // Update is called once per frame
    void Update()
    {
        blackImage_.Switch(turnOnBlackImage);

        // blackImage_.Switch(false);

        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

        if (hit.collider != null)
        {
            Debug.Log("Target name" + hit.collider.name);
        }

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

    public void CreditPage()
    {
        turnOnBlackImage = true;
        Invoke("StartLoadingCreditScene", readyTime);
    }

    void StartLoadingCreditScene()
    {
        SceneManager.LoadScene("CreditScene");
    }

    void StartLoadingGame()
    {
        SceneManager.LoadScene("FinalLevelScene");
    }


    public void QuitTheGame()
    {
        Application.Quit();
    }

    public void ChangeImage()
    {
        NewImage.SetActive(true);
       
    }

    public void ChangeImage2()
    {
        NewImage2.SetActive(true);
    }
}
