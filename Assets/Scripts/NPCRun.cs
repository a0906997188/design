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
    public int HP = 100;
    public Transform blood;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        distination = Vector3.Distance(target.position, transform.position);

        if (target != null && distination >= 2)
        {
            agent.SetDestination(target.position);
        }
        
        if(distination >=1)
        {
            anim.SetBool("isWalk", true);
        }
        else
        {
            anim.SetBool("isWalk", false);
        }


    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Bullet"))
        {
            Destroy(other.gameObject);
            HP -= 10;
            HP_text.text =  HP.ToString();
            blood.localScale = new Vector3(HP / 100f, 1, 1);
            if (HP <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
