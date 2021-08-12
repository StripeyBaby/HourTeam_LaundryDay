using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloth_ : MonoBehaviour
{
    public GameObject middlePlace;
    // public GameObject[] position;
    // public GameObject player1;
    public Vector3 position;

    bool isJump = false;
    public bool isflying = false;
    Rigidbody2D rd2_;
    BoxCollider2D bC2_;

    bool noCollide = false;
    public float setTime = 10;
    float curTime;
    private void Start()
    {
        rd2_ = GetComponent<Rigidbody2D>();
        bC2_ = GetComponent<BoxCollider2D>();
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
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Flour")
        {
            isflying = false;
            rd2_.mass = 5;
        }

        if (collision.gameObject.tag == "Rope" && noCollide == false)
        {

            var a = collision.gameObject.GetComponent<EdgeCollider2D>().points;

            this.transform.parent = middlePlace.transform;
            transform.position = middlePlace.transform.position;
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
            wP_.itemNumber++;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {


        if (other.tag == "LaundryPlace")
        {
            Win_Place_ wP_ = other.GetComponent<Win_Place_>();
            wP_.itemNumber--;
        }
    }
}
