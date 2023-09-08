using UnityEngine;

public class DistanceToPlayer : MonoBehaviour
{
    public float GetDistance()
    {
        return Vector3.Distance(transform.position, GameManager.Instance.GetPlayer().transform.position);
    }
}
