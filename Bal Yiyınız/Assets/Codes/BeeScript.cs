using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BeeScript : MonoBehaviour
{
    // açılışta gelen panel kontrolü
    public GameObject startPanel;
    // sahnede bulunan taxt nesnesi üretiliyor
    public Text distanceText;
    public Text numberText, maximumFlowerText,maximumdistanceText;
    public float speed, upSpeed;
    public float distance;
    public int number;
    void Start()
    {
        Time.timeScale = 0;
        maximumFlowerText.text = ""+PlayerPrefs.GetInt("flower_max", 0);
        maximumdistanceText.text= "" + PlayerPrefs.GetInt("distance_max", 0);
    }

    // Update is called once per frame                          
    void Update()
    {
        distance += 1 * Time.deltaTime;
        distanceText.text = "" + (int) distance+" m";
        
        transform.Translate(speed * Time.deltaTime, 0, 0);
        // boşluk tuşuna basıldığında yapılacak işlemler
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * upSpeed);
        }
        foreach (Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Began)
            {
                GetComponent<Rigidbody2D>().AddForce(Vector2.up * upSpeed);
            }
        }
  
    }

    private void OnTriggerEnter2D (Collider2D obj)
    {
        if (obj.gameObject.tag == "tree ghost tag")
        {
            Debug.Log("tree ghost tag :" + obj.gameObject.name);
            obj.gameObject.transform.root.gameObject.GetComponent<treeScript>().tree_statu=true;
        }
        if (obj.gameObject.tag == "Ivy ghost tag")
        {
            Debug.Log("Ivy ghost tag :" + obj.gameObject.name);
            obj.gameObject.transform.root.gameObject.GetComponent<lvyScript>().lvy_statu = true;
        }
        if (obj.gameObject.tag == "bush ghost tag")
        {
            Debug.Log("bush ghost tag :" + obj.gameObject.name);
            obj.gameObject.transform.root.gameObject.GetComponent<bushScript>().bush_statu = true;
        }
      
        if (obj.gameObject.tag == "flower tag")
        {
            Debug.Log("flower tag" + obj.gameObject.name);
            obj.gameObject.transform.root.gameObject.GetComponent<FlowerScript>().flower_statu = true;
            number++;
            numberText.text = "" + number + "";
        }
        if (obj.gameObject.tag == "flower ghost tag")
        {
            Debug.Log("flower ghost tag :" + obj.gameObject.name);
            obj.gameObject.transform.root.gameObject.GetComponent<FlowerScript>().flowerGhost_statu = true;
        }
    }
    private void OnCollisionEnter2D(Collision2D obj)
    {
        if(obj.gameObject.tag=="tree tag" )
        {
            //Debug.Log("tree tag :" + obj.gameObject.name);
            gameOver();
        }
        if (obj.gameObject.tag == "bush tag")
        {
            gameOver();
        }
        if (obj.gameObject.tag == "lvy tag")
        {
            gameOver();
        }
       
    }
    public void gameStart()
    {
        Debug.Log("start btn call");
        startPanel.SetActive(false);
        Time.timeScale = 1;
    }
  

    private void gameOver()
    {
        int flower_max = PlayerPrefs.GetInt("flower_max", 0);
        int distance_max = PlayerPrefs.GetInt("distance_max", 0);
        if (number>flower_max)
        {
            PlayerPrefs.SetInt("flower_max", number);
        }
        if (distance>distance_max )
        {
            PlayerPrefs.SetInt("distance_max",(int) distance);
        }
        Time.timeScale = 0;
    }
}

