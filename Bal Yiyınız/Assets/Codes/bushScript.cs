using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bushScript : MonoBehaviour
{
    public GameObject bush;
    public float speed;
    public bool bush_statu = false;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(-speed * Time.deltaTime, 0, 0);
        if (bush_statu)
        {
            // transform.position = transform.position + new Vector3(10.56f, -3.27f);
            Invoke("dublacate_bush", 0);// sadece bir kere çalıştırmak istediğimiz metotlarda kullanılır
            bush_statu = false;
        }
    }
    private void dublacate_bush()
    {
        Instantiate(bush, new Vector3(10.56f, -3.27f, -1), Quaternion.identity);
        Invoke("hide_fnc", 2);

    }
    private void hide_fnc()
    {
        //lvy.SetActive(false); // nesne sahneden görünmez
        Destroy(bush, 0);
    }
}
