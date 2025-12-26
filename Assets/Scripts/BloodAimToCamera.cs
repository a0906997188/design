using UnityEngine;

public class BloodAimToCamera : MonoBehaviour
{
    public Transform CameraTransform;
    private void Start()
    {
        CameraTransform = Camera.main.transform;
    }
    private void LateUpdate()
    {
        if (CameraTransform != null)
        {
            transform.forward = CameraTransform.forward;
        }
    }
}
