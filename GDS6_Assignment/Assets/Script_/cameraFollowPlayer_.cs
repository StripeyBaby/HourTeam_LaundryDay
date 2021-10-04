using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollowPlayer_ : MonoBehaviour
{

    public float cameraSpeed;
    public float yOffset;
    public float cameraDistoScreen;

    public GameObject target;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPos = new Vector3(target.transform.position.x, target.transform.position.y + yOffset, -cameraDistoScreen);
        transform.position = Vector3.Slerp(transform.position, newPos,cameraSpeed*Time.deltaTime);
    }
}
