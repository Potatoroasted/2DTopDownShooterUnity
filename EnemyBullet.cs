using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour {

    private Player playerScript;
    private Vector2 targetPosiiton;

    public float speed;
    public int damage;

    private void Start()
    {
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        targetPosiiton = playerScript.transform.position;
    }
    
    private void Update()
    {
        if (Vector2.Distance(transform.position, targetPosiiton) > .1f)
        {
            transform.position = Vector2.MoveTowards(transform.position, targetPosiiton, speed * Time.deltaTime);
        } else {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            playerScript.TakeDamage(damage);
            Destroy(gameObject);
        }
    }


}
