using UnityEngine;

public class CrosshairMovement : MonoBehaviour
{
    public Transform targetTransform;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (targetTransform == null)
            return;
        transform.position = targetTransform.position;
    }
}
