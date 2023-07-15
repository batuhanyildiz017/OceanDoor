using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Shake : MonoBehaviour
{
    private CinemachineVirtualCamera cinecam;
    float shakeTimer;
    public static Shake Instance { get; private set; }
    private void Awake()
    {
        Instance = this;
        cinecam = GetComponent<CinemachineVirtualCamera>();
    }
    public void ShakeCamera(float intensity,float time)
    {
        CinemachineBasicMultiChannelPerlin cinecamper=
            cinecam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        cinecamper.m_AmplitudeGain = intensity;
        shakeTimer = time;
    }


    // Update is called once per frame
    void Update()
    {
        if (shakeTimer>0)
        {
            shakeTimer -= Time.deltaTime;
            if (shakeTimer<=0)
            {
                //Time over!
                CinemachineBasicMultiChannelPerlin cinecamper=
                    cinecam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
                cinecamper.m_AmplitudeGain = 0f;
            }
        }
    }
}
