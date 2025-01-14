using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public EnemyStatsSO enemyStats;
    public float speed;
    private Transform player;
    private bool shouldMove = true;

    private SpriteRenderer sRen;

    // Start is called before the first frame update
    void Start()
    {
        speed = enemyStats.baseSPD;
        player = GameObject.FindGameObjectWithTag("Player").transform;

        sRen = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(shouldMove && player != null)
        {
            //subtrating player position with enemy
            Vector3 direction = player.position - transform.position;

            //only need direction, not distance
            direction.Normalize();

            //move enemy toward player
            transform.Translate(direction * speed * Time.deltaTime);

            //flip sprite to face right direction
            sRen.flipX = direction.x > 0f;
        }
    }

    //void OnTriggerEnter2D(Collider2D other)
    //{
    //     Debug.Log("entered");
    //     if (other.CompareTag("Player"))
    //     {
    //         Debug.Log("Enemy touched the player!");
    //         shouldMove = false;
 
    //         //testing
    //         char letterToDrop = letterDropper.ChooseLetter();
    //         Debug.Log(letterToDrop);
    //         Vector3 currPos = transform.position;
    //         gameObject.SetActive(false);
 
    //         if (letterToDrop != ' ')
    //         {
    //             letterDisplay.SpawnLetter(letterToDrop, currPos);
    //         }
 
    //        Destroy(gameObject);
 
 
    //     }
    //     else
    //      {
    //            Debug.Log("boo");
    //      }
    // }

}
