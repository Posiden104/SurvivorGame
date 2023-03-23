using UnityEngine;

public class RotationalMovement : MonoBehaviour
{
    private Transform centerPoint;
    [SerializeField]
    private float radius;
    [SerializeField]
    private float speed;

    // Start is called before the first frame update
    void Start()
    {
        transform.SetPositionAndRotation(transform.position + new Vector3(0, radius, 0), transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void FixedUpdate()
    {
        transform.RotateAround(centerPoint.position, Vector3.forward, -Time.deltaTime * speed);
    }

    public void Setup(Transform cpoint, float r, float s)
    {
        centerPoint = cpoint;
        radius = r;
        speed = s;
    }

    public void SetRotationPoint(Transform t)
    {
        centerPoint = t;
    }
}
