using System;
using UnityEngine;

public class CrosshairMovement : MonoBehaviour
{
    public Transform targetTransform;

    public Action onTargetDeath;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (targetTransform == null)
        {
            onTargetDeath();
            return;
        }
        transform.position = targetTransform.position;
    }

    public void RegisterOnTargetDeath(Action action)
    {
        onTargetDeath += action;
    }
    public void UnRegisterOnTargetDeath(Action action)
    {
        onTargetDeath -= action;
    }
}
