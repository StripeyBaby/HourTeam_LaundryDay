using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;                        

public class CameraStartAnimation_ : MonoBehaviour
{

    public GameObject followCamera;
    CinemachineVirtualCamera followCamera_;

    public GameObject camera;
    public Transform aimvisualcamera;

  
    private CinemachineVirtualCamera ccb;
    [Range(0, 10f)]
    public float moveRate=0.1f;


    public GameObject skipImg;


    public bool startMoving = false;

    public PlayerMovement_ pM_;
    public Player2Movement_ p2M_;
    
    // Start is called before the first frame update
    void Start()
    {
       
        ccb = transform.GetComponent<CinemachineVirtualCamera>();
        followCamera_ = followCamera.GetComponent<CinemachineVirtualCamera>();
        followCamera_.enabled = false;
        skipImg.SetActive(false);
        //if (followCamera == null || aimvisualcamera == null)
        //{
        //    return;
        //}
        camera.transform.position = transform.position;

    }


   
    // Update is called once per frame
    void Update()
    {
      

       if (startMoving == true)
       {
         if (Input.GetKeyDown(KeyCode.Space))
         {
             transform.position = aimvisualcamera.position;
             skipImg.SetActive(false);
         }
      
           transform.position = Vector3.MoveTowards(transform.position, aimvisualcamera.position, moveRate);
      
           if (transform.position == aimvisualcamera.position)
           {
               transform.position = aimvisualcamera.position;
               ccb.enabled = true;
             followCamera_.enabled = true;
               skipImg.SetActive(false);
               Destroy(this.gameObject);
           }
           else
           {
               skipImg.SetActive(true);
           }
       }
       if (transform.position == aimvisualcamera.position)
       {
           pM_.lockControl = false;
           p2M_.lockControl = false;
       }
       else
       {
           pM_.lockControl = true;
           p2M_.lockControl = true;
      }
    }
}
