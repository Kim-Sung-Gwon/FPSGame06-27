using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Contaerspack : MonoBehaviour
{
    public GameObject SparkPrefab;
    public AudioClip SparkClip;
    public AudioSource surce;

    void Start()
    {
        
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "BULLET")
        {
            Destroy(col.gameObject);
            surce.PlayOneShot(SparkClip, 1.0f);
            var spark = Instantiate(SparkPrefab,col.transform.
                position, Quaternion.identity);
            Destroy(spark, 2.0f);
        }
    }

    void Update()
    {
        
    }
}
