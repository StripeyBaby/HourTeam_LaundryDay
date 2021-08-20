using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement_ : MonoBehaviour
{

    [Header("Characters: ")]
    public GameObject character1;
    public GameObject character2;

    [Header("Hand: ")]
    public GameObject characterHand;
    // public Transform testposition;
    [Header("Cloth Number: ")]
    public GameObject[] cloth = new GameObject[10];
    // public CameraShake_ cameraShake;

    [Header("Attack Shake: ")]
    public float duration;
    public float magnitude;
    //string[] clothNum = new string[5] { "Cloth", "Cloth 2", "Cloth 3", "Cloth 4", "Cloth 5" };
    string clothNum = "Cloth";
    public float knockBackPower;

    [Header("Character Head ")]
    public GameObject characterHead;
    [Header("Head Size: !mportant! Must be same as in the transform of Scale of X value!!!")]
    public float headSize;
    Vector2 characterHeadScale;
    Vector2 characterHandScale;
    [Header("Feet Size: !mportant! Must be same as in the transform of Scale of X value!!!")]
    public GameObject characterFeet;
    Vector2 characterFeetScale;
    public float feetSize;

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
    bool isJump = false;
    bool isLadder = false;

    [Header("Player Keyboard Control: ")]
    public bool lockMoving = false;

    [Header("Scrpit: !mportant! Don't touch!!!")]
    public Rope_ rope;
    public GameObject middle;
    public GameObject spriteRender;
    public GameObject pivot;
    public float handScaleX, handScaleY;
    public float switchBodyDistance;
    public float gravityScale;


    Rigidbody2D rb2_;
    SpriteRenderer sr;
    HleathSystem healthSystem_;
    Player2Movement_ character2_;
    Animator feetAnimation_;

    //BoxCollider2D bC2;
    // Start is called before the first frame update
    void Start()
    {
        healthSystem_ = GetComponent<HleathSystem>();
        sr = spriteRender.GetComponent<SpriteRenderer>();
        sr.color = Color.white;
        rb2_ = GetComponent<Rigidbody2D>();
        character2_ = character2.GetComponent<Player2Movement_>();
        characterHeadScale = characterHead.transform.localScale;
        characterFeetScale = characterFeet.transform.localScale;
        feetAnimation_ = characterFeet.GetComponent<Animator>();
        
        speed = originalSpeed;

    }

    // Update is called once per frame
    void Update()
    {


       // characterHead.transform.position = pivot.transform.position;
        //Debug.Log(characterHead.transform.position);

        //CharacterMovingFunction1();
       // Debug.Log(isJump);
    }

    
    public void Player1AliveFunction() 
    {
       
      
            if (isHitted == true)
            {
                HitCoolTime();
            }
            else
            {
                CharacterMovingFunction1();
            }
        
  
    }
    private float locaEulerY=-180;

    private void CharacterMovingFunction1()
    {

        
        if (lockMoving == false)
        {
            float index; // transfer the gravity scale value;
            float dir = character2.transform.position.x - character1.transform.position.x;
            if (Input.GetKey(KeyCode.A))
            {

              locaEulerY= -180;

                characterHeadScale.x = headSize;
                characterFeetScale.x = feetSize;
                if (dir > 0)
                {
                    if (Vector3.Distance(character2.transform.position, character1.transform.position) > rope.ropeLength)
                        return;
                }

                //rb2.AddForce(-Vector2.right * speed);
                transform.Translate(-transform.right * Time.deltaTime * speed);

            }
            if (Input.GetKey(KeyCode.D))
            {
                locaEulerY = 0;
                characterHeadScale.x = -headSize;
                characterFeetScale.x = -feetSize;
                if (dir <= 0)
                {
                    if (Vector3.Distance(character2.transform.position, character1.transform.position) > rope.ropeLength)
                        return;
                }

                //rb2.AddForce(Vector2.right * speed);
                transform.Translate(transform.right * Time.deltaTime * speed);

            }
            
            if (isLadder == true)
            {
                index = 0;
                rb2_.gravityScale = 0;
                if (Input.GetKey(KeyCode.W))
                {
                    transform.Translate(transform.up * Time.deltaTime * speed);
                }
            
                if (Input.GetKey(KeyCode.S))
                {
                    transform.Translate(-transform.up * Time.deltaTime * speed);
                }
            
            }
            else
            {
              index = gravityScale;
              if (Input.GetKeyDown(KeyCode.W) && isJump == false)
              {
                  rb2_.AddForce(new Vector2(rb2_.velocity.x, jump * 1000));
                  isJump = true;
              }
            }

            rb2_.gravityScale = index;
            characterHead.transform.localScale = characterHeadScale;
            characterFeet.transform.localScale = characterFeetScale;
           //characterHead.transform.localEulerAngles = new Vector3(0,locaEulerY,0) ;


            CharacterHandDirection();
            CharacterFeetFunction();
        }

       

    }

    void CharacterHandDirection()
    {
        Vector3 dir = transform.position - middle.transform.position;
        dir = dir.normalized;

        if (dir.x > switchBodyDistance)
        {
            characterHandScale.x = handScaleX;
            characterHandScale.y = handScaleY;
        }
        else
        {
            characterHandScale.x = -handScaleX;
            characterHandScale.y = handScaleY;
        }

        characterHand.transform.localScale = characterHandScale;
    }

    void CharacterFeetFunction()
    {
        characterFeetScale.y = 0.5f;
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            //feetAnimation.SetTrigger("StartMoving");
            feetAnimation_.SetBool("Moving", true);
        }
        else
        {
            //feetAnimation.SetTrigger("StopMoving");
            feetAnimation_.SetBool("Moving", false);
        }


    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
       // for (int i = 0; i < cloth.Length; i++)
        //{
            if (collision.gameObject.tag == clothNum)
            {
               isJump = false;

            }
       //8/ }

        //if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Flour" || collision.gameObject.tag == "Player" || collision.gameObject.tag == "Bridge")
        //{
        //    isJump = false;
        //
        //   // Debug.Log("Getin here");
        //}

        //for (int i = 0; i < cloth.Length; i++)
        //{

        //    if (collision.gameObject.tag == clothNum[i])
        //    {
        //        Cloth_ cloth_ = collision.gameObject.GetComponent<Cloth_>();
        //        if (cloth_.isflying == false)
        //        {
        //            //float dirx_ = (character2.transform.position.x + character1.transform.position.x) / 2;
        //            //cloth[i].transform.position = new Vector2(dirx_, cloth[i].transform.position.y + 10);
        //            cloth[i].transform.position = middle.transform.position;
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
                collision.transform.position = middle.transform.position;
            }
        }

        if (collision.gameObject.tag == "DeathPool")
        {
            healthSystem_.lS_ = HleathSystem.LifeSituation.Deadth;
            lockMoving = true;
            character2_.lockMoving = true;
            // healthSystem_.stopMoving = true;
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
                    rb2_.velocity = new Vector2(0, 0);
                    rb2_.inertia = 0;
                    rb2_.AddForce(dir * knockBackPower, ForceMode2D.Impulse);

                    Invoke("ResetMaterial", 0.1f);

                    CameraShake_.Instance.ShakeCamera(5f, .1f);
                    isHitted = true;
                }
            }
        }

    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Flour" || collision.gameObject.tag == "Player" || collision.gameObject.tag == "Bridge")
        {
            isJump = false;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Flour")
        {
            isJump = true;

        }


    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "LaundryPlace")
        {
            Win_Place_ wP_ = other.GetComponent<Win_Place_>();
            wP_.isPlayer1 = true;
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
            wP_.isPlayer1 = false;
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
