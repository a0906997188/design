using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField] private float 速度 = 5f;
    [SerializeField] private float 滑鼠靈敏度 = 200f;

    private float yaw = 0f; // 左右旋轉累積角度

    void Update()
    {
        // === 滑鼠左右旋轉 ===
        float mouseX = Input.GetAxis("Mouse X") * 滑鼠靈敏度 * Time.deltaTime;
        yaw += mouseX;
        transform.rotation = Quaternion.Euler(0, yaw, 0);

        // === 鍵盤移動（依照旋轉方向）===
        float moveZ = Input.GetAxis("Vertical");   // W / S
        float moveX = Input.GetAxis("Horizontal"); // A / D

        Vector3 move =( transform.forward * moveZ + transform.right * moveX).normalized;
        transform.position += move * 速度 * Time.deltaTime;
    }
}
