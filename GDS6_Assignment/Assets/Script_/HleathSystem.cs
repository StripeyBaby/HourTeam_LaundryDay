using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HleathSystem : MonoBehaviour
{

    public enum LifeSituation
    {
        Alive,
        Deadth
    }

    public LifeSituation lS_ = LifeSituation.Alive;

    [Header("UI:")]
    public Slider slider;
    //public Gradient gradient;
    public Image fill;
    public Image boarder;
    float imageAlpha = 1f;
    float setTime = 5f;
    float currentTime = 0f;
    bool turnOnHealthBar = false;

    //Image fill_;
    //Image boarder_;


    [Header("Player Hp: ")]
    public int playerMaxHleath = 100;
    public int currentHealth;


    [Header("Script: !mportant! (Do not move it!!!))")]
    public PlayerMovement_ player1;
    public Player2Movement_ player2;
    public GameOverFunction_ gameOver;
    PlayerMovement_ player1_;
    Player2Movement_ player2_;

    public PauseMenu_ pM;
    public Win_Place_ wP;


    public bool startDeadScene = false;
    //public bool stopMoving = false;


    
    

    private void Start()
    {
        currentHealth = playerMaxHleath;
        player1_ = player1.GetComponent<PlayerMovement_>();
        player2_ = player2.GetComponent<Player2Movement_>();
        // fill_ = fill.GetComponent<Image>();
        // boarder_ = boarder.GetComponent<Image>();

        fill.enabled = false;
        boarder.enabled = false;
        turnOnHealthBar = false;
    }

    private void Update()
    {
         HealthUIAlphaChange();
        //PlayerHealthDisplay();
        DeathCheck();

        if (lS_ == LifeSituation.Alive)
        {
            AliveFunction();


        }
        else
        {

            gameOver.startDeadScene = true;
            Deathfunction();
        }



    }

    private void FixedUpdate()
    {
      
    }


    public void Damage(int damage) 
    {
        currentHealth -= damage;
        SetHealth(currentHealth);
        turnOnHealthBar = true;
        fill.enabled = true;
        boarder.enabled = true;
      
    }

    public void SetMaxHealth(int health) 
    {
        slider.maxValue = health;
        slider.value = health;

      
       // gradient.Evaluate(1f);
    }
    public void SetHealth(int health)
    {
        slider.value = health;
        switch (slider.value)
        {
            case float n when (n <= 100 && n > 70):

                fill.color = Color.green;
                break;
            case float n when (n <= 70 && n > 20):

                fill.color = Color.yellow;
                break;
            case float n when (n <= 20 && n > 0):

                fill.color = Color.red;
                break;
            default:
                break;
        }
        //fill.color = gradient.Evaluate(slider.normalizedValue);
    }

    void HealthUIAlphaChange()
    {

        if (turnOnHealthBar == true)
        {
            currentTime += Time.deltaTime;

            if (currentTime >= setTime)
            {
               
                    imageAlpha = 0;
                    fill.enabled = false;
                    boarder.enabled = false;
                    turnOnHealthBar = false;
                    currentTime = 0;
                

            }
        }

    }

    void DeathCheck() 
    {
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            lS_ = LifeSituation.Deadth;
            player1.lockMoving = true;
            player2.lockMoving = true;

        }
    }

    void Deathfunction() 
    {
        gameObject.SetActive(false);
        //Time.timeScale = 0;
      
       
    }

    void AliveFunction() 
    {
            player1_.Player1AliveFunction();
            player2_.Player2AliveFunction();
    }

  
}
