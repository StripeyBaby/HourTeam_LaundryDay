using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckVerticalDis : MonoBehaviour
{


  public  Rigidbody2D boy;
    public Rigidbody2D girl;
    public float maxDis = 100;
    public float upForce = 20;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (boy.transform.position.y<girl.transform.position.y)
        {
            if (girl.transform.position.y - boy.transform.position.y >= maxDis)
            {
                Vector3 newVocity = boy.velocity;
                newVocity.y=0;
                newVocity.y +=upForce*10000*Time.deltaTime;
                // boy.isKinematic = true;
                boy.velocity = newVocity;
            }
            else
            {

              //  boy.isKinematic = false;

            }
        
        }
        else if (boy.transform.position.y > girl.transform.position.y)
        {
            if (-girl.transform.position.y + boy.transform.position.y >= maxDis)
            {
                Vector3 newVocity = girl.velocity;
                newVocity.y = 0;
                newVocity.y += upForce*10000 * Time.deltaTime;
                // girl.isKinematic = true;
                girl.velocity = newVocity;
            }
            else
            {

               // girl.isKinematic = false;

            }

        }
    }
}
