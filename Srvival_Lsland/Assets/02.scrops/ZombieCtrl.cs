using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.AI;

public class ZombieCtrl : MonoBehaviour
{  // Attribute 어튜리 뷰트  >> 개발자가 쓰고 컴퓨터가 읽어서 실행
    [Header("Component")]
    public NavMeshAgent agent;      // 추적할 대상을 찾는 네비 컴퍼넌트
    public Transform Player;        // 거리를 재기 위해
    public Transform thisZomBie;
    public Animator animator;
    public ZomBieDamage damege;
    [Header("관련변수")]
    public float attackDist = 3.0f; // 공격 범위
    public float traceDist = 20f;   // 추적 범위
    

    void Start()
    {   // 자기 자신 게임 오브젝트 안에 있는 NavmeshAgent 컴퍼넌트 대입
        agent = this.gameObject.GetComponent<NavMeshAgent>();
        // C# 비주얼 스튜디오 >> agent = new NavMeshAgent();
        thisZomBie = transform;
        Player = GameObject.FindWithTag("Player").transform;
        //  하이라키안에 있는 게임오브젝트의 태그를 읽어서 가져온다.
        animator = GetComponent<Animator>();
        damege = GetComponent<ZomBieDamage>();
       
    }

    
    void Update()
    {   // 거리를 잰다. 
        if (damege.IsDie) return;
        float distance = Vector3.Distance(thisZomBie.position,
            Player.position);
        // 하위 로직으로 내려가지 않고 종료
        if (distance < attackDist)
        {
            agent.isStopped = true;
            animator.SetBool("IsAttack", true);
            Debug.Log("공격");
        }
        else if (distance <= traceDist)
        {
            animator.SetBool("IsAttack", false);
            animator.SetBool("IsTrace", true);
            agent.isStopped = false;
            agent.destination = Player.position;
            Debug.Log("추적 !!");
        }
        else
        {
            animator.SetBool("IsTrace", false);
            agent.isStopped = false;
            Debug.Log("추적 범위 벗어남 !");
        }
    }
}
