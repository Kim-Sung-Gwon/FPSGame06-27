using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCTRL : MonoBehaviour
{
    public float speed = 1500f;
    public Rigidbody rb;
    void Start()
    {
                   // Vector3.forward 글로벌 좌표
        rb.AddForce(transform.forward * speed);
        // 로컬 좌표로 스피드 만큼 나간다.
        Destroy(this.gameObject, 3.0f);
        // 자기자신의 오브젝트를 3초후에 메모리에서
        // 삭제한다
    }
}
