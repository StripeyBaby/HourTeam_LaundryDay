using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class CameraShake_ : MonoBehaviour
{
    // Start is called before the first frame update
    //  public IEnumerator Shake(float duration, float magnitude)
    //  {
    //      Vector3 originalPos = transform.localPosition;
    //      float elapsed = 0.0f;
    //      while (elapsed < duration)
    //      {
    //          float x = Random.Range(-1f, 1f) * magnitude;
    //          float y = Random.Range(-1f, 1f) * magnitude;
    //
    //          transform.localPosition = new Vector3(x, y, originalPos.z);
    //
    //          elapsed += Time.deltaTime;
    //
    //          yield return null;
    //      }
    //
    //
    //      transform.localPosition = originalPos;
    //  }
    public static CameraShake_ Instance { get; private set; }

    private CinemachineVirtualCamera cinemachineVirtualCamera;
    float shakeTimer;
    float shakeTimerTotal;
    float startingIntensity;
    private void Awake()
    {
        Instance = this;
       cinemachineVirtualCamera = GetComponent<CinemachineVirtualCamera>();
    }

    public void ShakeCamera(float intensity, float time)
    {
        CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin =
             cinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = intensity;

        startingIntensity = intensity;
        shakeTimerTotal = time;
        shakeTimer = time;
    }

    private void Update()
    {
        if (shakeTimer > 0)
        {
            shakeTimer -= Time.deltaTime;
            if (shakeTimer < 0f)
            {
                CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin =
             cinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

                cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = Mathf.Lerp(startingIntensity, 0f, 1 - (shakeTimer / shakeTimerTotal));

            }
        }
    }
}
