using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneControl_ : MonoBehaviour
{
    [Header("Black Image")]
    public GameObject blackImage;
    bool turnOnBlackImage = false;
    BlackImageFunction_ blackImage_;

    [Header("ColdingTime")]
    public float setColdTime;
    float coldTime;

    [Header("Camera")]
    public GameObject cameraAnime;
    CameraStartAnimation_ cameraAnime_;


    // Start is called before the first frame update
    void Start()
    {
        blackImage_ = blackImage.GetComponent<BlackImageFunction_>();
        cameraAnime_ = cameraAnime.GetComponent<CameraStartAnimation_>();
    }

    // Update is called once per frame
    void Update()
    {
        blackImage_.Switch(turnOnBlackImage);

        Debug.Log("Switch on :          "+turnOnBlackImage);

        if (blackImage_.alpha <= 0)
        {
            coldTime += Time.deltaTime;
        }

        if (coldTime >= setColdTime)
        {
            coldTime = setColdTime;
            cameraAnime_.startMoving = true;
        }
    }
}
