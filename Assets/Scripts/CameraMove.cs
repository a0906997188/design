using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField] private float ��¦�t�� = 7f;     // �@��t��
    [SerializeField] private float �[�t���v = 2f;     // Shift �[�t����
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

        Vector3 move = (transform.forward * moveZ + transform.right * moveX).normalized;

        // === Shift �[�t ===
        float ��e�t�� = ��¦�t��;
        if (Input.GetKey(KeyCode.LeftShift))
        {
            ��e�t�� *= �[�t���v; // ���� Shift �N�[�t
        }
        else
        {
            ��e�t�� = ��¦�t��; // �S���� Shift �N��_��¦�t��
        }

            // === ���� ===
            transform.position += move * ��e�t�� * Time.deltaTime;
    }
}
