using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public class Timer_ : MonoBehaviour
{
    public float timeStart = 60;
    public Text textBox;
    // Start is called before the first frame update
    void Start()
    {
        textBox.text = timeStart.ToString("F2") + "s";
    }

    // Update is called once per frame
    void Update()
    {
        timeStart += Time.deltaTime;
        textBox.text = timeStart.ToString("F2") + "s";
    }
}
