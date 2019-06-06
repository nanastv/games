using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MovePlayer : MonoBehaviour
{
    public GameObject player;
    Rigidbody rb;
    public GameObject bullet;
    GameObject clone;
    Rigidbody rbClone;
    int hp = 10;
    public Text txt;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        txt.text = "HP:" + hp;
    }

    void Update()
    {
        float moveVertical = Input.GetAxis("Vertical");
        rb.AddForce(transform.forward * moveVertical * 50f);

        float moveHorizontal = Input.GetAxis("Horizontal");
        transform.Rotate(0f, moveHorizontal* 5f,0f);

        if(Input.GetKeyDown("space")){
        	clone = Instantiate(bullet, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
        	rbClone = clone.GetComponent<Rigidbody>();
        	rbClone.AddForce(transform.forward * 300f);
        }
    }

    void OnCollisionEnter(Collision da)
    {	if(da.gameObject.tag == "Enemy"){
    		hp = hp - 1;
            txt.text = "HP:" + hp;
            if (hp == 0){
            SceneManager.LoadScene(1);
            }
  		}

    }
}
