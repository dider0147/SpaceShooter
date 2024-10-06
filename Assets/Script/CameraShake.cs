using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public Transform CameraMain;
    private float currentShakeDuration;
    //private float ShakeDuration;
    private Vector3 initialPos;
    private void OnEnable()
    {
        initialPos = CameraMain.transform.position;
    }
    private void Update()
    {
        CameraShakeIt();
    }
    private void CameraShakeIt()
    {
        if (currentShakeDuration > 0)
        {
            CameraMain.localPosition = initialPos + Random.insideUnitSphere * 0.2f;
            currentShakeDuration -= Time.unscaledDeltaTime;
        }
        else
        {
            currentShakeDuration = 0;
            CameraMain.localPosition = initialPos;
        }
    }
    public void TimeShakeDuration(float duration)
    {
        currentShakeDuration = duration;
    }

}
