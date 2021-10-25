using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.UI;
public class FollowMouse_ : MonoBehaviour
{

    public GameObject followObject;
    public Vector3 offset;
    //public RectTransform BasisObject;
    public Camera cam;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // MoveObject();
        followObject.transform.position = Input.mousePosition;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "StartButton")
        {
            Debug.Log("fhasjkfhdjkhfajhfdshjkashjfdaks");
        }
    }
}
