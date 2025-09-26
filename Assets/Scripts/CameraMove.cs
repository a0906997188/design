using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField] private float 基礎速度 = 7f;     // 一般速度
    [SerializeField] private float 加速倍率 = 2f;     // Shift 加速倍數
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

        Vector3 move = (transform.forward * moveZ + transform.right * moveX).normalized;

        // === Shift 加速 ===
        float 當前速度 = 基礎速度;
        if (Input.GetKey(KeyCode.LeftShift))
        {
            當前速度 *= 加速倍率; // 按住 Shift 就加速
        }
        else
        {
            當前速度 = 基礎速度; // 沒有按 Shift 就恢復基礎速度
        }

            // === 移動 ===
            transform.position += move * 當前速度 * Time.deltaTime;
    }
}
