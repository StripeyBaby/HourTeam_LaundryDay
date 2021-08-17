using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloth_ : MonoBehaviour
{
    [Header("Middle Place Input: ")]
    public GameObject middlePlace;


    [Header("Script : !mportant! Don't Touch !!!")]
    public Vector3 position;

    //bool isJump = false;
    public bool isflying = false;
    Rigidbody2D rd2_;
    //BoxCollider2D bC2_;

    bool noCollide = false;
    [Header("No Collider Time: ")]
    public float setTime = 10;
    float curTime;
    private void Start()
    {
        rd2_ = GetComponent<Rigidbody2D>();
        //bC2_ = GetComponent<BoxCollider2D>();
    }
    int testIndex;

    private void Update()
    {
      if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
      {

          //±‹√‚ø’Ã¯
          if (rd2_ == null)
          {
              this.transform.parent = null;
              rd2_ = gameObject.AddComponent<Rigidbody2D>();
              rd2_.AddForce(Vector2.up * 1000);
              rd2_.gravityScale = 2;
          }
      
      
      
          //rd2_.sleepMode = RigidbodySleepMode2D.StartAwake;
          // rd2_.bodyType = RigidbodyType2D.Dynamic;
          //rd2_.isKinematic = false;
      }
      
      if (noCollide == true)
      {
          curTime += Time.deltaTime;
          if (curTime >= setTime)
          {
              curTime = 0;
              noCollide = false;
          }
      }
    }


    public static List<Transform> allStaticCube = new List<Transform>();

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Flour")
        {
            isflying = false;
            rd2_.mass = 5;


           // PosManager.instance.allCube.Remove(transform.gameObject);

           // PosManager.instance.SetFalse();
           // for (int i = 0; i < PosManager.instance.allCube.Count - 1; i++)
           // {
           //     PosManager.instance.allAimPos[i].gameObject.SetActive(true);
           //
           //     
           //
           // }
        }

        if (collision.gameObject.tag == "Rope" && noCollide == false)
        {



            

            var a = collision.gameObject.GetComponent<EdgeCollider2D>().points;

            this.transform.parent = middlePlace.transform;
           // transform.position = middlePlace.transform.position;





            Vector3 lastPos = transform.position;

            this.transform.parent = middlePlace.transform;

            //float lastX = transform.localPosition.x;
            //transform.position = middlePlace.transform.position;
           // transform.localPosition = new Vector3(Random.Range(1f, 6f), 0, 0);


            //Debug.Log("111");

            //PosManager.instance.gameObject.SetActive(true);

            //int nowNum = PosManager.instance.allCube.Count;



            //for (int i = 0; i < nowNum-1; i++)
            //{
            //    PosManager.instance.allAimPos[i].gameObject.SetActive(true);

            //    if (PosManager.instance.switchState)
            //    {


            //        PosManager.instance.allAimPos[i].position = new Vector3(lastPos.x, transform.position.y, lastPos.z);
            //    }



            //}


            //PosManager.instance.allAimPos[nowNum - 1].GetComponent<SpriteRenderer>().sprite
            //   = transform.GetComponent<SpriteRenderer>().sprite;






            //PosManager.instance.RandomRotate();





            Destroy(rd2_);
            noCollide = true;

        }
    }



    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Flour")
        {
            isflying = true;
            //rd2_.sharedMaterial.friction = 0f;
            //rd2_.sharedMaterial.bounciness = 2;
            //rd2_.mass = 1;
        }

        if (collision.gameObject.CompareTag("Rope"))
        {
            this.transform.parent = null;
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "LaundryPlace")
        {
            Win_Place_ wP_ = other.GetComponent<Win_Place_>();
            wP_.itemCount++;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {


        if (other.tag == "LaundryPlace")
        {
            Win_Place_ wP_ = other.GetComponent<Win_Place_>();
            wP_.itemCount--;
        }
    }
}
