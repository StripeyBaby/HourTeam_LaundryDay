using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverFunction_ : MonoBehaviour
{

    public GameObject gameOverScreen;
    public float setGameOverTime;
    PauseMenu_ pM_;
    // Start is called before the first frame update
    public bool startDeadScene = false;

    private void Start()
    {
        pM_ = GetComponent<PauseMenu_>();
        gameOverScreen.SetActive(false);
    }
    private void Update()
    {
        if (startDeadScene == true)
        {
            pM_.lockFunction = true;
            Invoke("GameDeathScene", setGameOverTime);
        }
   
 
    }

   void GameDeathScene() 
    {
        gameOverScreen.SetActive(true);
    }

    public void ReStartFunction() 
    {
        SceneManager.LoadScene("SampleScene");
    }
}
