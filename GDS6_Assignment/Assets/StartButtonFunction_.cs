using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButtonFunction_ : MonoBehaviour
{
    // Start is called before the first frame update
    public void CastRay()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity);
        if (hit.collider.tag == "StartButton")
        {
            Debug.Log("you fucking made it");
        }
    }
}
