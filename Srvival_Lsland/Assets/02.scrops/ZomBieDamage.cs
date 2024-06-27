using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZomBieDamage : MonoBehaviour
{
    [Header("컴퍼넌트")]
    public Rigidbody rb;
    public CapsuleCollider capCol;
    public Animator animator;

    [Header("관련변수")]
    public string playerTag = "Player";
    public string bulletTag = "BULLET";
    public string Hitstr = "HitTirgger";
    public string dieStr = "DieTrigger";
    public int hitCont = 0;
    public bool IsDie = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        capCol = GetComponent<CapsuleCollider>();
        animator = GetComponent<Animator>();
    }
    private void OnCollisionEnter(Collision col)
    {    // col.gameObject.tag == "Player" >> 동적할당과 비교를 동시에 함
        if (col.gameObject.CompareTag(playerTag))
        {
            rb.mass = 8000f;
            rb.freezeRotation = false;
        }
        else if (col.gameObject.CompareTag(bulletTag))
        {
            Destroy(col.gameObject);
            //print("맞았나??");
            animator.SetTrigger(Hitstr);
            if (++hitCont == 5)
            {
                ZomBieDie();
            }
        }
    }
    private void OnCollisionExit(Collision col)
    {
        if (col.gameObject.CompareTag(playerTag))
        {
            rb.mass = 75f;
            rb.freezeRotation = true;
        }
    }
    void ZomBieDie()
    {
        animator.SetTrigger(dieStr);
        capCol.enabled = false;
        // 콜라이드 비활성화
        rb.isKinematic = true;
        IsDie = true;
    }
}
