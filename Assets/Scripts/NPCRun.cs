using UnityEngine;
using Unity.AI;
using UnityEngine.AI;
public class NPCRun : MonoBehaviour
{
    NavMeshAgent agent;
    Animator anim;
    public Transform target;
    public float ¶ZÂ÷ = 0;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        if (target != null)
        {
            agent.SetDestination(target.position);
            print(target.position);
        }
        ¶ZÂ÷ = Vector3.Distance(target.position, transform.position);
        if(¶ZÂ÷ >=0.5f)
        {
            anim.SetBool("isWalk", true);
        }
        else
        {
            anim.SetBool("isWalk", false);
        }


    }
}
