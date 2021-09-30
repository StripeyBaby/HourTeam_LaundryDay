using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraStartAnimation_ : MonoBehaviour
{

    public GameObject followCamera;
    CinemachineVirtualCamera followCamera_;


    public Transform aimvisualcamera;

  
    private CinemachineVirtualCamera ccb;
    [Range(0, 10f)]
    public float moveRate=0.1f;




    public bool startMoving = false;

    public PlayerMovement_ pM_;
    public Player2Movement_ p2M_;
    
    // Start is called before the first frame update
    void Start()
    {
       
        ccb = transform.GetComponent<CinemachineVirtualCamera>();
        followCamera_ = followCamera.GetComponent<CinemachineVirtualCamera>();
        followCamera_.enabled = false;

      //if (followCamera == null || aimvisualcamera == null)
      //{
      //    return;
      //}
       
    }


   
    // Update is called once per frame
    void Update()
    {
        if (startMoving == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, aimvisualcamera.position, moveRate);
            if (transform.position == aimvisualcamera.position)
            {
                transform.position = aimvisualcamera.position;
                ccb.enabled = true;
                followCamera_.enabled = true;
                Destroy(this.gameObject);
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
