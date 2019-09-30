using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lvyScript : MonoBehaviour
{
    public GameObject lvy;
    public float speed;
    public bool lvy_statu = false;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(-speed * Time.deltaTime, 0, 0);
        if (lvy_statu)
        {
            // transform.position = transform.position + new Vector3(10.56f, -3.27f);
            Invoke("dublacate_lvy", 0);// sadece bir kere çalıştırmak istediğimiz metotlarda kullanılır
            lvy_statu = false;
        }
    }
    private void dublacate_lvy()
    {
        Instantiate(lvy, new Vector3(9.75f, 3.43f, -1), Quaternion.identity);
        Invoke("hide_fnc", 2);

    }
    private void hide_fnc()
    {
        //lvy.SetActive(false); // nesne sahneden görünmez
        Destroy(lvy, 0);
    }
}
