using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightOnOff : MonoBehaviour
{
    public Light StarirLight;
    public AudioSource source;
    public AudioClip clip;
    void Start()
    {
        
    }
    // is Trigger 했을 때 통과 하면서 충돌 감지
    // 하는 함수 콜백 함수라고 함 스스로 호출 하기 때문
    private void OnTriggerEnter(Collider other) // 들어 갔을때
    {
        if (other.gameObject.tag == "Player")
        {
            StarirLight.enabled = true;
        }
    }
    // 콜라이더 범위에 들어 왔다가 빠져 나갔을때
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            StarirLight.enabled = false;
            source.PlayOneShot(clip,1.0f);
        }
    }

    void Update()
    {
        
    }
}
