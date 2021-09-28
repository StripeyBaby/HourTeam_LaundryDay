using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckVerticalDis : MonoBehaviour
{


    public Rigidbody2D boy;
    public Rigidbody2D girl;
    public float maxDis = 100;
    public float upForce = 20;
    public static float maxY;

    // Start is called before the first frame update
    void Start()
    {

    }

    public static bool couldTan1 = false;
    public static bool couldTan2 = false;

    // Update is called once per frame
    void Update()
    {
       // Debug.Log(couldTan1 + "----" + couldTan2);

        float boyY = transform.position.y;
        float girlY = transform.position.y;

        maxY = boyY > girlY ? boyY : girlY;


        if (boy.transform.position.y < girl.transform.position.y)
        {

            if (girl.transform.position.y - boy.transform.position.y >= maxDis)
            {
                if (Input.GetKeyDown(KeyCode.Space) &&  couldTan1 == false)
                {
                    boy.constraints = RigidbodyConstraints2D.FreezeRotation;
                    Vector3 newVocity = boy.velocity;
                    newVocity.y = 0;
                    newVocity.y = upForce * 10000 * 0.004f;
                    // boy.isKinematic = true;
                    boy.velocity = newVocity;
                }
                else
                {
                    Vector3 newVocity = boy.velocity;
                    newVocity.y = 0;
                   
                    boy.velocity = newVocity;
                    boy.constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
                }

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
                if (Input.GetKeyDown(KeyCode.Space) && (couldTan2  == false ))
                {
                    girl.constraints = RigidbodyConstraints2D.FreezeRotation;
                    Vector3 newVocity = girl.velocity;
                    newVocity.y = 0;
                    newVocity.y = upForce * 10000 *0.004f;
                    // girl.isKinematic = true;
                    girl.velocity = newVocity;
                }
                else
                {
                    Vector3 newVocity = girl.velocity;
                    newVocity.y = 0;
                    
                    girl.velocity = newVocity;
                    girl.constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation; ;

                }
            }
            else
            {

                // girl.isKinematic = false;

            }



        }

    }
}
