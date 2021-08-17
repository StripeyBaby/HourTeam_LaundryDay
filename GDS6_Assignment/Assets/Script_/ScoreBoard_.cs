using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard_ : MonoBehaviour
{
    public GameObject[] emptyStar = new GameObject[4];
    public GameObject[] star = new GameObject[4];
    bool[] isPress = new bool[4];

    Image[] emptyStar_;
    Image[] star_;
    // Start is called before the first frame update
    void Start()
    {
        //  for (int i = 0; i < emptyStar.Length; i++)
        //  {
        //      for (int j = 0; j < emptyStar_.Length; j++)
        //      {
        //          emptyStar_[j] = emptyStar[i].GetComponent<Image>();
        //      }
        // 
        //  }
        //
        //  for (int i = 0; i < star.Length; i++)
        //  {
        //      for (int j = 0; j < star_.Length; j++)
        //      {
        //          star_[j] = star[i].GetComponent<Image>();
        //      }
        //
        //  }

        //for (int j = 0; j < star.Length; j++)
        //{
        //    star_[j] = star[j].GetComponent<Image>();
        //}
      
    }

    // Update is called once per frame
    void Update()
    {
     

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (isPress[0] != true)
            {
                isPress[0] = true;
            }
            else
            {
                isPress[0] = false;
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (isPress[1] != true)
            {
                isPress[1] = true;
            }
            else
            {
                isPress[1] = false;
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (isPress[2] != true)
            {
                isPress[2] = true;
            }
            else
            {
                isPress[2] = false;
            }
        }

        for (int i = 0; i < star.Length; i++)
        {
            for (int j = 0; j < emptyStar.Length; j++)
            {
                if (isPress[0])
                {
                    star[i - 2].SetActive(true);
                    Debug.Log("Fuck");
                }
                else
                {
                    star[i - 2].SetActive(false);
                }
               // if (isPress[1])
               // {
               //     star[i - 1].SetActive(true);
               //     Debug.Log("shit");
               // }
               // else
               // {
               //     star[i - 1].SetActive(false);
               // }
               // if (isPress[2])
               // {
               //     star[1-i].SetActive(true);
               //     Debug.Log("Yes");
               // }
               // else
               // {
               //     star[1-i].SetActive(false);
               // }
            }

        }



        // for (int i = 0; i < star.Length; i++)
        // {
        //     if (isPress[0])
        //     {
        //         star_[i - 2].enabled = true;
        //         star[i - 2].transform.position = new Vector2(emptyStar[i - 2].transform.position.x, emptyStar[i - 2].transform.position.y);
        //     }
        //     if (Input.GetKeyDown(KeyCode.Alpha2))
        //     {
        //         star_[i - 1].enabled = true;
        //         star[i - 1].transform.position = new Vector2(emptyStar[i - 1].transform.position.x, emptyStar[i - 1].transform.position.y);
        //     }
        //     if (Input.GetKeyDown(KeyCode.Alpha3))
        //     {
        //         star_[i].enabled = true;
        //         star[i].transform.position = new Vector2(emptyStar[i].transform.position.x, emptyStar[i].transform.position.y);
        //     }
        //
        // }

    }
}
