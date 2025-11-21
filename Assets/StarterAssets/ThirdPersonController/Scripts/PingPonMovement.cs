using UnityEngine;

public class PingPongMovement : MonoBehaviour
{
    [Header("移動設定")]
    public Vector3 moveDirection = Vector3.right;  // 移動方向（可設定為 Vector3.up / Vector3.forward）
    public float distance = 3f;                    // 移動距離
    public float speed = 2f;                       // 速度

    private Vector3 startPos;                      // 初始位置

    void Start()
    {
        startPos = transform.position;  // 記錄初始位置
    }

    void Update()
    {
        // Mathf.PingPong(time * speed, distance) 會在 0 ~ distance 間來回
        float offset = Mathf.PingPong(Time.time * speed, distance);
        transform.position = startPos + moveDirection.normalized * offset;
    }
}
