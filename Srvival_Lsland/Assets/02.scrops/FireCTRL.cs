using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireCTRL : MonoBehaviour
{
    [Header("컴퍼넌트들")]
    // 총알 오브젝트
    public GameObject bulletPrefab;
    public Transform FirePos;
    // 발사 위치
    public Animation fireAni;
    public AudioSource source;
    public AudioClip fireclip;
    public ParticleSystem muzzleFlash;
    [Header("각종 변수들")]
    private float fireTime;
    public HandCtrl handCtrl;
    public int bulletCount = 0;
    bool isReload = false;
    // Start is called before the first frame update
    void Start()
    {
        handCtrl = this.gameObject.GetComponent<HandCtrl>();
        fireTime = Time.time;
        muzzleFlash.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        #region 한발씩 발사하는 로직
        // 마우스 왼족 버튼 눌렀을 때 0
        // 1 은  오른쪽 2는 마우스 휠버튼
        //if (Input.GetMouseButtonDown(0))
        //    Fire();
        #endregion
        #region 총알 발사를 연사로 하는 로직
        if (Input.GetMouseButton(0))
        {
            if (Time.time - fireTime > 0.1f)
            {
                if(!handCtrl.isRun && !isReload)
                Fire();
                fireTime = Time.time;
                
            }
        }
        #endregion
        #region 마우스 왼쪽 버튼을 띄었을 때
        //if (Input.GetMouseButtonUp(0))
        //{
        //    muzzleFlash.Stop();
        //}
        #endregion
    }
    void Fire() // 총알 발사 함수
    {
        ++bulletCount;
        // 오브젝트 생성 함수
        Instantiate(bulletPrefab, FirePos.position,
            FirePos.rotation);
        source.PlayOneShot(fireclip,1.0f);
        fireAni.Play("fire");
        muzzleFlash.Play();
        Invoke("MuzzleFlashDisable",0.03f);
        // 메서드 명 string 값  , 시간
        // 원하는 시간 간격 만큼 메서드를 호출
        if (bulletCount == 10)
        {
            // 스타 코루틴
            // 게임 중 개발자가 원하는 프레임을 만들려고 할 때 사용
            StartCoroutine(Reload());
            // 아래 Reload() 호출
        }
    }
    IEnumerator Reload()
    {   
        isReload = true;
        fireAni.Play("pump1"); // 리로드 애니메이션 재생
                               // 0.8초 후에
        yield return new WaitForSeconds(0.5f);
        bulletCount = 0;
        isReload = false;
    }
    void MuzzleFlashDisable()
    {
        muzzleFlash.Stop();
    }
}
