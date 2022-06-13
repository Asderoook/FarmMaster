using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    private Vector3 offset;
    private Vector3 targetPos;

    void Start()
    {
        if (target != null)
        {
            offset = transform.position - target.position;
            targetPos = target.position + offset;
        }

    }

    void Update()
    {
        if (target != null)
        {
            targetPos = target.position + offset;
            transform.position = targetPos;
        }
    }

}
