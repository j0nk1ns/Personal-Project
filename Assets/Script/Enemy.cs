using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Rigidbody enemyRb;
    public float speed = 3.0f; 
    int MoveDist = 20;
    int AttackDist = 5;
    GameObject player; 

    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    void Update()
    {
        transform.LookAt(player.transform.position);

        if (Vector3.Distance(transform.position, player.transform.position) <= MoveDist)
        {
           Vector3 position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
           enemyRb.MovePosition(position);

            if (Vector3.Distance(transform.position, player.transform.position) <= AttackDist)
           {
              Debug.Log("attack");
           }
        }

        if (transform.position.y < -10)
        {
            Destroy(gameObject);
        }

    }
    void OnTriggerEnter(Collision other)
    {
        PlayerController player = other.gameObject.GetComponent<PlayerController>();

        if (player != null)
        {
            player.ChangeHealth(-1);
        }

    }


}
