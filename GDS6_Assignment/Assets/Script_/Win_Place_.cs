using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win_Place_ : MonoBehaviour
{
    [Header("Function: ")]
    public bool needCompleteTask = false;
    public bool needBothCharacter = false;
    public bool needAllItems = false;
    public int numberMainObjectNeed;

    [Header("System: !mportant! Dont Touch It!!!!")]
    public HleathSystem hS;
    public bool isPlayer1 = false;
    public bool isPlayer2 = false;
    bool finished1;

    public int itemNumber;
    bool finished2;

    public int completeTask = 0;
    int finishTask;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
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
            }
        }
   
    }

    void AllItemCollections() 
    {
        if (finished2 != true)
        {
            if (itemNumber == numberMainObjectNeed)
            {
                //Debug.Log("You have all Item");
                finishTask++;
                finished2 = true;
            }
        }
      
    }

    void CompleteAllChallenge() 
    {
        if (finishTask == completeTask)
        {
            finishTask = completeTask;
            //Time.timeScale = 0;
            //hS.stopMoving = true;
        }
    }
}
