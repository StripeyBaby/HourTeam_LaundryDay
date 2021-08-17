using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Movement_ : MonoBehaviour
{
    // Start is called before the first frame update

    [Header("Characters: ")]
    public GameObject character1;
    public GameObject character2;

    [Header("Hand: ")]
    public GameObject characterHand;
    // public Transform testposition;
    [Header("Check the distance: ")]
    public GameObject[] cloth = new GameObject[10];
   // public CameraShake_ cameraShake;
    


    [Header("Attak Shake: ")]
    public float duration;
    public float magnitude;

    //string[] clothNum = new string[6] { "Cloth", "Cloth 2", "Cloth 3", "Cloth 4", "Cloth 5", "Cloth 6" };
    string clothNum = "Cloth";
    public float knockBackPower;

    [Header("Character Head ")]
    public GameObject characterHead;
    [Header("Head Size: !mportant! Must be same as in the transform of Scale of X value!!!")]
    public float headSize;
    Vector2 characterHeadScale;
    Vector2 characterHandScale;

    [Header("Character Attributes")]
    public float originalSpeed;
    public float ladderSpeed;
    public float bridgeSpeed;
    public float jump;
    float speed;

    [Header("Attack States: ")]
    public bool stopHitting = false;
    public float setHitCoolTime;
    float hitCoolTime;
    bool isHitted = false;
    bool isJump2 = false;
    bool isLadder = false;

    [Header("Player Keyboard Control: ")]
    public bool lockMoving = false;

    [Header("Scrpit: !mportant! Don't touch!!!")]
    public Rope_ rope;
    public GameObject spriteRender;
    public GameObject pivot;
    public float handScaleX, handScaleY;

    PlayerMovement_ character1_;
    Rigidbody2D rb2;
    SpriteRenderer sr;
    HleathSystem healthSystem_;
    // Start is called before the first frame update
    void Start()
    {
        rb2 = GetComponent<Rigidbody2D>();
        healthSystem_ = GetComponent<HleathSystem>();
        characterHeadScale = characterHead.transform.localScale;
        sr = spriteRender.GetComponent<SpriteRenderer>();
        sr.color = Color.white;
        character1_ = character1.GetComponent<PlayerMovement_>();

        speed = originalSpeed;
    }

    // Update is called once per frame
    void Update()
    {

       // Debug.Log("Speed : " + speed);
     
     
    }


    public void Player2AliveFunction() 
    {
        
            if (isHitted == true)
            {
                HitCoolTime();
            }
            else
            {
                CharacterMovingFunction2();
            }
       

    }
    private void CharacterMovingFunction2()
    {


        if (lockMoving == false)
        {
            float dir = character2.transform.position.x - character1.transform.position.x;
            //float dir2 = character2.transform.position.y - character1.transform.position.y;
           // if (Vector3.Distance(character2.transform.position, character1.transform.position) > character1_.ropeLength)
            {
                
            }

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                characterHeadScale.x = -headSize;
                if (dir <= 0)
                {
                    if (Vector3.Distance(character2.transform.position, character1.transform.position) > rope.ropeLength)
                        return;
                }

                //rb2.AddForce(-Vector2.right * speed);
                transform.Translate(-transform.right * Time.deltaTime * speed);

            }

            if (Input.GetKey(KeyCode.RightArrow))
            {

                characterHeadScale.x = headSize;
                if (dir > 0)
                {
                    if (Vector3.Distance(character2.transform.position, character1.transform.position) > rope.ropeLength)
                        return;
                }

                //rb2.AddForce(Vector2.right * speed);
                transform.Translate(transform.right * Time.deltaTime * speed);

            }

            if (isLadder == true)
            {

                rb2.gravityScale = 0;
                if (Input.GetKey(KeyCode.UpArrow))
                {
                    transform.Translate(transform.up * Time.deltaTime * speed);
                }

                if (Input.GetKey(KeyCode.DownArrow))
                {
                    transform.Translate(-transform.up * Time.deltaTime * speed);
                }
            }
            else
            {
                rb2.gravityScale = 8;
                if (Input.GetKeyDown(KeyCode.UpArrow) && isJump2 == false)
                {
                    //rb2.AddForce(Vector2.up * jump);
                    rb2.AddForce(new Vector2(rb2.velocity.x, jump * 1000));
                    isJump2 = true;
                }
            }

         

            characterHead.transform.localScale = characterHeadScale;

            CharacterHandDirection();
        }

      
    }

    void CharacterHandDirection()
    {
        Vector3 dir = transform.position - character1_.middle.transform.position;
        dir = dir.normalized;

        if (dir.x > 0)
        {
            characterHandScale.x = -handScaleX;
            characterHandScale.y = handScaleY;
        }
        else
        {
            characterHandScale.x = handScaleX;
            characterHandScale.y = handScaleY;

        }

        characterHand.transform.localScale = characterHandScale;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        //for (int i = 0; i < cloth.Length; i++)
        //{
        //    if (collision.gameObject.tag == clothNum[i])
        //    {
        //        isJump2 = false;

        //    }
        //}
        if (collision.gameObject.tag == clothNum)
        {
            isJump2 = false;

        }

        if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Flour" || collision.gameObject.tag == "Player" || collision.gameObject.tag == "Bridge")
        {
            // Debug.Log("U have get in here");
            isJump2 = false;
            //isJump2 = false;
            //   canGoingDown = false;


        }

        if (collision.gameObject.tag == "DeathPool") 
        {
            healthSystem_.lS_ = HleathSystem.LifeSituation.Deadth;
            lockMoving = true;
            character1_.lockMoving = true;
            //healthSystem_.stopMoving = true;
        }

        if (stopHitting == false)
        {
            if (collision.gameObject.CompareTag("Enemy"))
            {
                if (!isHitted)
                {
                    Enemy_ enemyDamage_ = collision.gameObject.GetComponent<Enemy_>();
                    healthSystem_.Damage(enemyDamage_.damage);
                    ContactPoint2D contactPoint = collision.GetContact(0);
                    Vector2 playerPosition = transform.position;
                    Vector2 dir = contactPoint.point - playerPosition;
                    dir = -dir.normalized;
                    sr.color = Color.red;

                    rb2.velocity = new Vector2(0, 0);
                    rb2.inertia = 0;
                    rb2.AddForce(dir * knockBackPower, ForceMode2D.Impulse);

                    Invoke("ResetMaterial", 0.1f);

                    CameraShake_.Instance.ShakeCamera(5f, .1f);
                    isHitted = true;
                }
            }
        }


        // if (collision.gameObject.CompareTag("Bridge"))
        // {
        //     speed = bridgeSpeed;
        // }


        //for (int i = 0; i < cloth.Length; i++)
        //{

        //    if (collision.gameObject.tag == clothNum[i])
        //    {
        //        Cloth_ cloth_ = collision.gameObject.GetComponent<Cloth_>();
        //        if (cloth_.isflying == false)
        //        {
        //            //float dirx_ = (character2.transform.position.x + character1.transform.position.x) / 2;
        //            //cloth[i].transform.position = new Vector2(dirx_, cloth[i].transform.position.y + 10);
        //            cloth[i].transform.position = character1_.middle.transform.position;
        //        }

        //        //float diry_ = Mathf.Abs(transform.position.y - character2.position.y);
        //    }
        //}


        if (collision.gameObject.tag == "Cloth")
        {
            Cloth_ cloth_ = collision.gameObject.GetComponent<Cloth_>();
            if (cloth_.isflying == false)
            {
                //float dirx_ = (character2.transform.position.x + character1.transform.position.x) / 2;
                //cloth[i].transform.position = new Vector2(dirx_, cloth[i].transform.position.y + 10);
                collision.transform.position = character1_.middle.transform.position;
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Flour")
        {
            // Debug.Log("U have get in here");
            isJump2 = true;
            // isJump2 = true;
            // canGoingDown = true;

        }

     


    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "LaundryPlace")
        {
            Win_Place_ wP_ = other.GetComponent<Win_Place_>();
            wP_.isPlayer2 = true;
        }

        if (other.CompareTag("Ladder"))
        {
            isLadder = true;
            speed = ladderSpeed;
        }

        if (other.CompareTag("Bridge"))
        {
            speed = bridgeSpeed;
        }

    
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "LaundryPlace")
        {
            Win_Place_ wP_ = other.GetComponent<Win_Place_>();
            wP_.isPlayer2 = false;
        }

        if (other.CompareTag("Ladder"))
        {
            isLadder = false;
            speed = originalSpeed;
        }

        if (other.CompareTag("Bridge"))
        {
            speed = originalSpeed;
        }
    }

    void ResetMaterial()
    {
        sr.color = Color.white;

    }

    void HitCoolTime()
    {
        hitCoolTime += Time.deltaTime;
        if (hitCoolTime >= setHitCoolTime)
        {
            hitCoolTime = 0;
            isHitted = false;
        }
    }
}
