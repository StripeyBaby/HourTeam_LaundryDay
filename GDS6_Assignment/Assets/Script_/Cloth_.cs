using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloth_ : MonoBehaviour
{
    [Header("Middle Place Input: ")]
    public GameObject middlePlace;
    [Header("Cloth Flying Force")]
    public float flyingForce;

    [Header("Up and Down Distance:")]
    public float movingspeed;
    public float upDownDistance;
    public float maxUpDownDistance;
    public float movingFreq;
    bool isUp = false;
    [Header("Script : !mportant! Don't Touch !!!")]
    public Vector3 position;
    public PlayerMovement_ pM_;
    public float gravityScale;
    float curTime;
    bool hasbeenCollided;
    public int scoures = 1;

    public AudioSource pickedAudio;
    bool hasPlayed = false;
    //bool isJump = false;
    public bool isflying = false;
    Rigidbody2D rd2_;
    //BoxCollider2D bC2_;

    bool noCollide = false;
    [Header("No Collider Time: ")]
    public float setTime = 2;
    float pressTime;
    float pressTime2;

  
    private void Start()
    {
        rd2_ = GetComponent<Rigidbody2D>();
        //bC2_ = GetComponent<BoxCollider2D>();

        if (rd2_ == null)
        {
            return;
        }
    }
    int testIndex;
    

    private void Update()     ///他这里一起跳跃出现问题， 碰到绳子出现问题
    {
        //if (rd2_ == null)
        //{
        //    return;
        //}
        // if (Input.GetKeyDown(KeyCode.W) && Input.GetKeyDown(KeyCode.UpArrow))
        // {
        //     //避免空跳
        //     if (rd2_ == null)
        //     {
        //         this.transform.parent = null;
        //         rd2_ = gameObject.AddComponent<Rigidbody2D>();
        //         rd2_.AddForce(Vector2.up * 5000);
        //         rd2_.gravityScale = gravityScale;
        //     }
        // }
        // if (Input.GetKeyDown(KeyCode.I))
        // {
        //     hasbeenCollided = true;
        // }

   


       // Debug.Log(pM_.posIsSwitch);
        if (hasbeenCollided == false)
        {
            //rd2_.isKinematic = false;
            //rd2_.mass = 0;
            //rd2_.gravityScale = 0;
           
            Destroy(rd2_);
            upDownDistance -= movingFreq * Time.deltaTime;
            if (upDownDistance <= 0)
            {
                upDownDistance = maxUpDownDistance;
                isUp = !isUp;
            }

            if (isUp)
            {
                transform.Translate(transform.up * Time.deltaTime * movingspeed);
            }
            else
            {
                transform.Translate(-transform.up * Time.deltaTime * movingspeed);
            }
        }
        else //if(CheckVerticalDis.maxY<transform.position.y)
        {
            //rd2_ = gameObject.AddComponent<Rigidbody2D>();
            // rd2_.gravityScale = gravityScale;

            //rd2_.AddForce(new Vector2(-transform.position.x * flyingForce * 10, transform.position.y * flyingForce * 100));

            if (pM_.posIsSwitch == true)
            {
               //if (Input.GetKeyDown(KeyCode.W) && Input.GetKeyDown(KeyCode.UpArrow))
               //{
               //    if (rd2_ == null)
               //    {
               //        this.transform.parent = null;
               //        rd2_ = gameObject.AddComponent<Rigidbody2D>();
               //        rd2_.AddForce(transform.up * 5000);
               //        rd2_.gravityScale = gravityScale;
               //    }
               //}
                if (Input.GetKeyDown(KeyCode.W))
                {
                    if (rd2_ == null)
                    {
                       
                        this.transform.parent = null;
                        rd2_ = gameObject.AddComponent<Rigidbody2D>();
                        //var index = transform.position.normalized;
                        //rd2_.AddForce(new Vector2(index.x * flyingForce * 5000, index.y * flyingForce * 20000));
                        rd2_.gravityScale = gravityScale;
                       // rd2_.velocity = Vector2.zero;
                        rd2_.AddForce(Vector3.right* 5000);
                        rd2_.AddForce(Vector3.up * 20000);

                    }
                }

                if (Input.GetKeyDown(KeyCode.UpArrow))
                {
                    if (rd2_ == null)
                    {
                        this.transform.parent = null;
                        rd2_ = gameObject.AddComponent<Rigidbody2D>();
                        //var index = transform.position.normalized;
                        //rd2_.AddForce(new Vector2(-index.x * flyingForce * 5000, index.y * flyingForce * 20000));
                       // rd2_.velocity = Vector2.zero;
                        rd2_.gravityScale = gravityScale;
                        rd2_.AddForce(-Vector3.right * 5000);
                        rd2_.AddForce(Vector3.up * 20000);

                    }
                }
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.UpArrow))
                {
                    if (rd2_ == null)
                    {

                        this.transform.parent = null;
                        rd2_ = gameObject.AddComponent<Rigidbody2D>();
                        //var index = transform.position.normalized;
                        //rd2_.AddForce(new Vector2(index.x * flyingForce * 5000, index.y * flyingForce * 20000));
                        rd2_.gravityScale = gravityScale;
                        rd2_.AddForce(Vector3.right * 5000);
                        rd2_.AddForce(Vector3.up * 20000);


                    }
                }

                if (Input.GetKeyDown(KeyCode.W))
                {
                    if (rd2_ == null)
                    {
                        this.transform.parent = null;
                        rd2_ = gameObject.AddComponent<Rigidbody2D>();
                        //var index = transform.position.normalized;
                        //rd2_.AddForce(new Vector2(-index.x * flyingForce * 5000, index.y * flyingForce * 20000));
                        rd2_.gravityScale = gravityScale;
                        rd2_.AddForce(-Vector3.right * 5000);
                        rd2_.AddForce(Vector3.up * 20000);

                    }
                }
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

        //Debug.Log(transform.position.normalized);

    }


    public static List<Transform> allStaticCube = new List<Transform>();

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Player2")
        {
            hasbeenCollided = true;
            Debug.Log("get in here");

            if (hasPlayed == false)
            {
                pickedAudio.Play();
                hasPlayed = true;
            }
            
        }

        //if (collision.gameObject.tag == "Rope" && noCollide == false)
        //{
        //    var a = collision.gameObject.GetComponent<EdgeCollider2D>().points;
        //
        //    this.transform.parent = middlePlace.transform;
        //
        //    Vector3 lastPos = transform.position;
        //
        //    this.transform.parent = middlePlace.transform;
        //
        //    Destroy(rd2_);
        //    noCollide = true;
        //
        //}
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Flour" || collision.gameObject.tag == "Bridge")
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

        //if (collision.gameObject.tag == "Rope" && noCollide == false)
        //{


        //    var a = collision.gameObject.GetComponent<EdgeCollider2D>().points;

        //    this.transform.parent = middlePlace.transform;

        //    Vector3 lastPos = transform.position;

        //    this.transform.parent = middlePlace.transform;

        //    Destroy(rd2_);
        //    noCollide = true;
        //}
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Rope" && noCollide == false)
        {
            var a = other.gameObject.GetComponent<EdgeCollider2D>().points;

            this.transform.parent = middlePlace.transform;

            Vector3 lastPos = transform.position;

            this.transform.parent = middlePlace.transform;

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

        //if (collision.gameObject.CompareTag("Rope"))
        //{
        //    this.transform.parent = null;
        //    rd2_ = gameObject.AddComponent<Rigidbody2D>();
        //    rd2_.gravityScale = 8;
        //}

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "LaundryPlace")
        {
            Win_Place_ wP_ = other.GetComponent<Win_Place_>();
           /**/// wP_.itemCount++;
        }

        //if (other.tag == "Rope" && noCollide == false)
        //{
        //
        //
        //
        //
        //
        //    var a = other.gameObject.GetComponent<EdgeCollider2D>().points;
        //
        //    this.transform.parent = middlePlace.transform;
        //
        //    Vector3 lastPos = transform.position;
        //
        //    this.transform.parent = middlePlace.transform;
        //
        //    Destroy(rd2_);
        //    noCollide = true;
        //
        //}
    }
    private void OnTriggerExit2D(Collider2D other)
    {


        if (other.tag == "LaundryPlace")
        {
            Win_Place_ wP_ = other.GetComponent<Win_Place_>();
            //*//wP_.itemCount--;
        }
    }



    #region
    // if (Input.GetKey(KeyCode.W))
    // {
    //     pressTime += Time.deltaTime;
    //
    //     if (pressTime <= 0.5f)
    //     {
    //
    //         if (rd2_ == null)
    //         {
    //             this.transform.parent = null;
    //             rd2_ = gameObject.AddComponent<Rigidbody2D>();
    //             rd2_.AddForce(new Vector2(transform.position.x * flyingForce * 50, transform.position.y * flyingForce * 500));
    //             rd2_.gravityScale = gravityScale;
    //
    //         }
    //     }
    //     else
    //     {
    //         return;
    //     }
    //
    //   
    //
    // }
    //
    //
    // if (Input.GetKey(KeyCode.UpArrow))
    // {
    //     pressTime2 += Time.deltaTime;
    //     if (pressTime <= 0.5f)
    //     {
    //
    //
    //         if (rd2_ == null)
    //         {
    //             this.transform.parent = null;
    //             rd2_ = gameObject.AddComponent<Rigidbody2D>();
    //             rd2_.AddForce(new Vector2(-transform.position.x * flyingForce * 50, transform.position.y * flyingForce * 500));
    //             rd2_.gravityScale = gravityScale;
    //
    //         }
    //     }
    //     else
    //     {
    //         return;
    //     }
    //
    // }

    #endregion
}
