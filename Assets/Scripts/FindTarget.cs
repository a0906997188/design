using UnityEngine;

public class FindTarget : MonoBehaviour
{
    public Transform 最近的敵人;
    public Vector3 敵人座標;
    public float 最近距離 = float.MaxValue;
    public GameObject 最終目標;



    private void Update()
    {
        GameObject[] 敵人列表 = GameObject.FindGameObjectsWithTag("Enemy");
        最近距離 = 10f;
        foreach (GameObject 敵人 in 敵人列表)
        {
            float 距離 = Vector3.Distance(transform.position, 敵人.transform.position);
            if (距離 < 最近距離)
            {
                最近距離 = 距離;
                最近的敵人 = 敵人.transform;
                敵人座標 = 敵人.transform.position;
                敵人座標.y = 1.2f;
                最終目標.transform.position = 敵人座標;
            }
        }
        if(敵人列表.Length == 0)
        {
            最終目標.transform.localPosition = new Vector3(0,1.6f,5.1f);
        }



    }
}
