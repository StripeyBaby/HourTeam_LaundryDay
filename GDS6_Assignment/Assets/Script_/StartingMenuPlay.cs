using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartingMenuPlay : MonoBehaviour
{
    private AudioSource _audioSource;
    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }
    

    void OnMouseDown()
    {
        SceneManager.LoadScene("FinalLevelScene");

    }
}
