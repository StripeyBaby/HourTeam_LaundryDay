using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PosManager : MonoBehaviour
{

    public List<GameObject> allCube=new List<GameObject>();

    public static PosManager instance;
    public bool switchState = false;

    public List<Transform> allAimPos = new List<Transform>();




    // Start is called before the first frame update
    void Start()
    {

        allAimPos = transform.GetComponentsInChildren<Transform>().ToList();
        allAimPos.RemoveAt(0);


        foreach (Transform item in allAimPos)
        {
            item.gameObject.SetActive(false);
        }
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void RandomRotate()
    {

        foreach (Transform item in allAimPos)
        {
            Vector3 rotateEuler = item.localEulerAngles;
            rotateEuler.z = Random.Range(0f,360f);

            item.localEulerAngles = rotateEuler;
        }
    }


    public void SetFalse()
    {
        foreach (Transform item in allAimPos)
        {
            item.gameObject.SetActive(false);
        }
    }
}
