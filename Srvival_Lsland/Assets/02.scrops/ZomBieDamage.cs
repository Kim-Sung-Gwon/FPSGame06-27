using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZomBieDamage : MonoBehaviour
{
    [Header("���۳�Ʈ")]
    public Rigidbody rb;
    public CapsuleCollider capCol;
    public Animator animator;

    [Header("���ú���")]
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
    {    // col.gameObject.tag == "Player" >> �����Ҵ�� �񱳸� ���ÿ� ��
        if (col.gameObject.CompareTag(playerTag))
        {
            rb.mass = 8000f;
            rb.freezeRotation = false;
        }
        else if (col.gameObject.CompareTag(bulletTag))
        {
            Destroy(col.gameObject);
            //print("�¾ҳ�??");
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
        // �ݶ��̵� ��Ȱ��ȭ
        rb.isKinematic = true;
        IsDie = true;
    }
}
