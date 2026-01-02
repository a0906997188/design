using UnityEngine;
using UnityEngine.AI;
using TMPro;

public class NPCRun : MonoBehaviour
{
    NavMeshAgent agent;
    Animator anim;
    public float distination = 0;

    public TMP_Text HP_text;
    int HP;
    public int MaxHP = 100;
    public Transform blood;

    public float 攻擊時間 = 1.5f;
    private float 攻擊倒數 = 0f;
    public float 攻擊距離 = 1.2f;

    private bool isDying = false;

    public GameObject blade;

    敵人的巡邏 patrol;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        patrol = GetComponent<敵人的巡邏>();

        HP_text.text = MaxHP.ToString();
        HP = MaxHP;
        agent.stoppingDistance = 攻擊距離;
    }

    private void Update()
    {
        //if (isDying)
        //    return;

        //if (patrol != null && patrol.發現玩家 && patrol.玩家位置 != null)
        //{
        //    distination = Vector3.Distance(patrol.玩家位置.position, transform.position);
        //}
        //else
        //{
        //    anim.SetBool("isAttack", false);
        //    return;
        //}

        //if (攻擊倒數 > 0)
        //{
        //    攻擊倒數 -= Time.deltaTime;
        //}

        //if (distination >= 攻擊距離)
        //{
        //    anim.SetBool("isAttack", false);
        //    anim.SetBool("isWalk", true);
        //}
        //else
        //{
        //    anim.SetBool("isWalk", false);

        //    if (攻擊倒數 <= 0f)
        //    {
        //        anim.SetBool("isAttack", true);
        //        攻擊倒數 = 攻擊時間;
        //    }
        //}
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
                isDying = true;
                anim.SetBool("isDying", true);

                if (patrol != null)
                    patrol.enabled = false;

                GetComponent<Collider>().enabled = false;
                gameObject.tag = "Untagged";
                Destroy(gameObject, 3f);
            }
            else
            {
                anim.SetTrigger("isHit");
            }
        }
    }

    public void BladeHide()
    {
        if (blade != null)
            blade.GetComponent<Collider>().enabled = false;
    }

    public void BladeEnable()
    {
        if (blade != null)
            blade.GetComponent<Collider>().enabled = true;
    }
}
