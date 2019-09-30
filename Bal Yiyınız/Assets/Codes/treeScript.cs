using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class treeScript : MonoBehaviour
{
    public GameObject tree;
    public float speed;
    public bool tree_statu = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(-speed * Time.deltaTime, 0, 0);
        float rnd = Random.Range(0, 2);

        //objeden yeni bir tane oluşuruluyor
        //tree.transform.localPosition = new Vector2(10.58f, -3.27f);
        //transform.position = transform.position + new Vector3(10.58f, -3.27f);
        //tree.SetActive(true);
        //Yeni bir ağaç gelecek

        if (tree_statu)
        {
            // transform.position = transform.position + new Vector3(10.56f, -3.27f);
            Invoke("dublacate_tree", 0);// sadece bir kere çalıştırmak istediğimiz metotlarda kullanılır
            tree_statu = false;
        }
    }
    private void dublacate_tree()
    {
        Instantiate(tree, new Vector3(10.56f, -3.27f, -1), Quaternion.identity);
        Invoke("hide_fnc", 2);
        
    }
    private void hide_fnc()
    {
        //tree.SetActive(false);
        Destroy(tree, 0);
    }
}
