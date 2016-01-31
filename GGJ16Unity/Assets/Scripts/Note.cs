using UnityEngine;
using System.Collections;

public class Note : MonoBehaviour
{
    public bool canMove;
    public float moveSpeed;

	// Use this for initialization
	void Start()
    {

	}
	
	// Update is called once per frame
	void Update()
    {
        if (canMove)
        {
            Vector3 tempPos = transform.position;
            tempPos.x -= moveSpeed;

            if (tempPos.x < -10)
            {
                if (GetComponent<SpriteRenderer>().enabled == true)
                {
                    GameManager.multiplier = 1;
                    GameManager.noteCount = 0;
                }
            }
            if (tempPos.x < -30)
            {
                
                Destroy(gameObject);
            }
            transform.position = tempPos;
        }
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            GetComponent<AudioSource>().Play();
            GetComponent<SpriteRenderer>().enabled = false;
            GameManager.score += (10*GameManager.multiplier);  
            GameManager.noteCount++;
        }
    }
}
