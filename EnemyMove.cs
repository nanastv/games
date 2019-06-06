using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EnemyMove : MonoBehaviour
{
    NavMeshAgent enemy;
    public Transform Raspologenie;
    public Text ttxx;
    static int score = 0;

    void Start()
    {
        enemy = GetComponent<NavMeshAgent>();
        ttxx.text = "Score:" + score;
    }

    void Update()
    {
        enemy.SetDestination(Raspologenie.position);
    }

    void OnCollisionEnter(Collision net)
    {	if(net.gameObject.tag == "Bullet"){
    		Destroy(gameObject);
            score = score + 1;
            ttxx.text = "Score:" + score;
            if(score == 4) {
            SceneManager.LoadScene(0);
            }
    	}

    }
}
