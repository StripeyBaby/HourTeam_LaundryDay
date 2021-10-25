using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.UI;
public class FollowMouse_ : MonoBehaviour
{

    //// public GameObject followObject;
    //public Vector3 offset;
    //public RectTransform BasisObject;
    //public Camera cam;
    public StartPage_ startPage;

    public GameObject NewImage;
    public GameObject NewImage2;
    public GameObject NewImage3;

    // Start is called before the first frame update
    void Start()
    {
        NewImage.SetActive(false);
        NewImage2.SetActive(false);
        NewImage3.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
      

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity);

        Debug.DrawRay(ray.origin, ray.direction * 5000, Color.red);

        if (hit.collider.name == "Hit 1")
        {
            NewImage.SetActive(true);
            if (Input.GetMouseButtonDown(0))
            {
                startPage.StartGame();
            }
        }
        else
        {
            NewImage.SetActive(false);
        }

        if (hit.collider.name == "Hit 2")
        {
 
 
            NewImage2.SetActive(true);
            if (Input.GetMouseButtonDown(0))
            {
                startPage.CreditPage();
            }
        }
        else
        {
            NewImage2.SetActive(false);
        }

        if (hit.collider.name == "Hit 3")
        {


            NewImage3.SetActive(true);
            if (Input.GetMouseButtonDown(0))
            {
                startPage.QuitTheGame();
            }
        }
        else
        {
            NewImage3.SetActive(false);
        }


        if (hit.collider.name == "Rest")
        {
            NewImage.SetActive(false);
            NewImage2.SetActive(false);
            NewImage3.SetActive(false);
        }

  
     
       
        // MoveObject();
      ///  followObject.transform.position = Input.mousePosition;
    }

   
}
