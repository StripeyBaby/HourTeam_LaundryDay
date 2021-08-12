using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheMiddlePosition_ : MonoBehaviour
{
    public Transform character1;
    public Transform character2;

    //public GameObject[] theItemPosition = new GameObject[4];

    public int numberItem = 0;
    public float posY_;
    float index;
    float chooseNum;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float heightIndex = (character1.position.y + character2.position.y) / 2;
        float height = heightIndex + 3;
        float posX_ = (character1.position.x + character2.position.x) / 2;
        transform.position = new Vector2(posX_, height);
    }
}
