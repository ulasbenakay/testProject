using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerScript : MonoBehaviour
{
    public GameObject flower;
    public float speed;
    public bool flower_statu = false;
    public bool flowerGhost_statu = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(-speed * Time.deltaTime, 0, 0);
        if (flower_statu && flowerGhost_statu==false )
        {

            Invoke("fnc_setting", 0);
            flower_statu = false;
        }else
        {
            Invoke("fnc_setting", 10);
            flowerGhost_statu = false;
        }

    }
    private void fnc_setting()
    {
        
        float rn1 = Random.Range(-3.5f, -3.5f);
        Instantiate(flower, new Vector3(10.0f, rn1, -1), Quaternion.identity);
        Destroy(flower, 0);
    }
}
