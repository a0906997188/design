using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField] private float �t�� = 5f;
    [SerializeField] private float �ƹ��F�ӫ� = 200f;

    private float yaw = 0f; // ���k����ֿn����

    void Update()
    {
        // === �ƹ����k���� ===
        float mouseX = Input.GetAxis("Mouse X") * �ƹ��F�ӫ� * Time.deltaTime;
        yaw += mouseX;
        transform.rotation = Quaternion.Euler(0, yaw, 0);

        // === ��L���ʡ]�̷ӱ����V�^===
        float moveZ = Input.GetAxis("Vertical");   // W / S
        float moveX = Input.GetAxis("Horizontal"); // A / D

        Vector3 move =( transform.forward * moveZ + transform.right * moveX).normalized;
        transform.position += move * �t�� * Time.deltaTime;
    }
}
