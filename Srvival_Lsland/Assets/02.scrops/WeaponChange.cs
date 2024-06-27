using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponChange : MonoBehaviour
{
    public SkinnedMeshRenderer spas12;
    public MeshRenderer[] Ak47;
    public MeshRenderer[] M4A1;
    public Animation ComBatsg;
    void Start()
    {

        
    }

    void Update()
    {
        // Alpha1 = 키보드 숫자 1
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
           WeaponChange1();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            WeaponChange2();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
           WeaponChange3();
        }
    }
    private void WeaponChange1()
    {
        ComBatsg.Play("draw");
        for (int i = 0; i < Ak47.Length; i++)
            Ak47[i].enabled = true;  // 메쉬랜드러 활성화
        spas12.enabled = false;       // 스키니 메쉬 렌더러 비활성화
        for (int i = 0; i < M4A1.Length; i++)
            M4A1[i].enabled = false;
    }
    private void WeaponChange3()
    {
        ComBatsg.Play("draw");
        for (int i = 0; i < Ak47.Length; i++)
            Ak47[i].enabled = false;  // 메쉬랜드러 활성화
        spas12.enabled = true;       // 스키니 메쉬 렌더러 비활성화
        for (int i = 0; i < M4A1.Length; i++)
            M4A1[i].enabled = false;
    }

    private void WeaponChange2()
    {
        ComBatsg.Play("draw");
        for (int i = 0; i < Ak47.Length; i++)
            Ak47[i].enabled = false;  // 메쉬랜드러 활성화
        spas12.enabled = false;       // 스키니 메쉬 렌더러 비활성화
        for (int i = 0; i < M4A1.Length; i++)
            M4A1[i].enabled = true;
    }

 
}
