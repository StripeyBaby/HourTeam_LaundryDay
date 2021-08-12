using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlackImageFunction_ : MonoBehaviour
{
    public GameObject gb;
    Image image_;
    float alpha = 0;

 
    // Start is called before the first frame update
    void Start()
    {
        image_ = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(alpha);

       
    }
  
    public void Switch(bool index) 
   {
      //if (index != true)
      //{
      //    index = true;
      //}
      //else 
      //{
      //    index = false;
      //}
  
       if (index == true)
       {
           TurnBlack();
       }
       else
       {
           TurnWhite();
       }
   }
     void TurnBlack() 
    {
        gb.SetActive(true);
        image_.color = new Color(0, 0, 0, alpha);

        alpha += Time.deltaTime;

        if (alpha >= 1)
        {
            alpha = 1;
        }
    }

     void TurnWhite() 
    {
        image_.color = new Color(0, 0, 0, alpha);
        alpha -= Time.deltaTime;

        if (alpha <= 0)
        {
            alpha = 0;
            gb.SetActive(false);        
        }
    }
}
