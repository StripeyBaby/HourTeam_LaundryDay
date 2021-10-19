using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win_Place_ : MonoBehaviour
{
    [Header("Function: ")]
    public bool needCompleteTask = false;
    public bool needBothCharacter = false;
    public bool needAllItems = false;
    public int HowMnayCloth;

    [Header("Win Screen:  ")]
    public GameObject winScreen;

    [Header("System: !mportant! Dont Touch It!!!!")]
    public GameObject player1;
    PlayerMovement_ player1_;
    public GameObject player2;
    Player2Movement_ player2_;
    public GameObject pauseMenu;
    PauseMenu_ pauseMenu_;
    public GameObject blackImage;
    public float setTime;
    float time;

    public HleathSystem hS;
    public bool isPlayer1 = false;
    public bool isPlayer2 = false;
    bool finished1;

     int itemCount;
    bool finished2;

    int completeTask = 0;
    int finishTask;
    bool accomplish = false;

    public GameObject cloths;
    Cloth_ cloth_;

    // Start is called before the first frame update
    void Start()
    {
        if (needCompleteTask == true)
        {
            completeTask++;
        }  if (needBothCharacter == true)
        {
            completeTask++;
        }  if (needAllItems == true)
        {
            completeTask++;
        }
        winScreen.SetActive(false);
        cloth_ = cloths.GetComponent<Cloth_>();
        player1_ = player1.GetComponent<PlayerMovement_>();
        player2_ = player2.GetComponent<Player2Movement_>();
        pauseMenu_ = pauseMenu.GetComponent<PauseMenu_>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            accomplish = true;
        }
        //Debug.Log(isPlayer1 + "          " + "          " + isPlayer2);
        if (needBothCharacter == true)
        {
            BothCharacterGetIn();
        }
   

        if (needAllItems == true)
        {
            AllItemCollections();
        }
    

        if (needCompleteTask == true)
        {
            CompleteAllChallenge();
        }

        //  Debug.Log("How many Complete Task : " + completeTask);
       // Debug.Log("Cloth Numbers :                 "+itemCount);
    }

    void BothCharacterGetIn() 
    {
        if (finished1 != true)
        {
            if (isPlayer2 == true && isPlayer1 == true)
            {
                // Debug.Log("Get In to it");
                finishTask++;
                finished1 = true;
                Debug.Log("Two players ware in");
            }
        }
   
    }

    void AllItemCollections() 
    {
        if (finished2 != true)
        {
            if (itemCount == HowMnayCloth)
            {
                //Debug.Log("You have all Item");
                finishTask++;
                finished2 = true;
            }
        }
      
    }

    void CompleteAllChallenge() 
    {
        if (finished1 == true && finished2 == true)
        {
            accomplish = true;
        }
       // accomplish == true ||
        if (accomplish == true)
        {
           
            player1_.lockMoving = true;
            player2_.lockMoving = true;
            pauseMenu_.lockFunction = true;
            //blackImage.SetActive(true);

            if (time >= setTime)
            {
                time = setTime;
                winScreen.SetActive(true);
             
            }
            else
            {
                time += Time.deltaTime;
                Debug.Log(time);
            }

          
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Cloth")
        {
            itemCount += cloth_.scoures;
        }

        if (other.tag == "Player")
        {
            isPlayer1 = true;
            Debug.Log("Yes player 1");
        }

        if (other.tag == "Player2")
        {
            isPlayer2 = true;
            Debug.Log("Yes player 2");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Cloth")
        {
            itemCount -= cloth_.scoures;
        }

        if (other.tag == "Player")
        {
            isPlayer1 = false;
        }

        if (other.tag == "Player2")
        {
            isPlayer2 = false;
        }
    }
}
