using UnityEngine;
using Unity.AI;
using UnityEngine.AI;
using TMPro;

public class NPCRun : MonoBehaviour
{
    NavMeshAgent agent;
    Animator anim;
    public Transform target;
    public float distination = 0;

    public TMP_Text HP_text;
    int HP;
    public int MaxHP = 100;
    public Transform blood;

    public float 攻擊時間 = 1.5f; // 攻擊間隔秒數
    private float 攻擊倒數 = 0f;  // 倒數計時器
    public float 攻擊距離 = 1.2f;

    private bool isDying = false;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        HP_text.text = MaxHP.ToString();
        HP = MaxHP;
        agent.stoppingDistance = 攻擊距離;

        target = GameObject.FindWithTag("Player").transform;
    }

    private void Update()
    {
        if(target!=null)
        distination = Vector3.Distance(target.position, transform.position);

        // 跑步
        if (target != null && distination >= 攻擊距離 && !isDying)
        {
            agent.SetDestination(target.position);
        }

        // 攻擊冷卻計時（每幀倒數）
        if (攻擊倒數 > 0)
        {
            攻擊倒數 -= Time.deltaTime;
        }

        // 判斷是否攻擊或走路
        if (distination >= 攻擊距離 && !isDying)
        {
            anim.SetBool("isAttack", false);
            anim.SetBool("isWalk", true);
        }
        else
        {
            anim.SetBool("isWalk", false);

            // 攻擊冷卻完成才能攻擊
            if (攻擊倒數 <= 0f)
            {
                anim.SetBool("isAttack", true);

                // 重設攻擊冷卻時間
                攻擊倒數 = 攻擊時間;

                // >>> 在這裡做“造成傷害”的事情 <<<
                // 例如： player.TakeDamage(10);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet") && !isDying)
        {
            Destroy(other.gameObject);
            HP -= 10;
            HP_text.text = HP.ToString();
            blood.localScale = new Vector3((float)HP / (float)MaxHP, 1, 1);

            if (HP <= 0)
            {
                anim.SetBool("isDying", true);
                isDying = true;
                gameObject.GetComponent<Collider>().enabled = false;
                gameObject.tag = "Untagged";
                Destroy(gameObject, 3f);
            }
            else
            {
                anim.SetTrigger("isHit");
            }
        }
    }

    public GameObject blade;
    public void BladeHide()
    {
        blade.GetComponent<Collider>().enabled = false;
    }
    public void BladeEnable()
    {
        blade.GetComponent<Collider>().enabled = true;
    }
}
