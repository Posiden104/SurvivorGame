using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrownMovement : MonoBehaviour
{
    public Vector3 target;
    public float travelTime;
    public Action OnTargetReached;


    private float timeElapsed;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log($"{timeElapsed} - {travelTime}");
        transform.position = Vector3.Lerp(transform.position, target, Time.deltaTime);
        timeElapsed += Time.deltaTime;

        if(timeElapsed >= travelTime)
        {
            OnTargetReached?.Invoke();
            timeElapsed = 0;
        }
    }

    public void RegisterOnTargetReached(Action act)
    {
        OnTargetReached += act;
    }

    public void UnRegisterOnTargetReached(Action act)
    {
        OnTargetReached -= act;
    }
}
