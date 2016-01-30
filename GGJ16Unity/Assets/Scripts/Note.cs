using UnityEngine;
using System.Collections;

public class Note : MonoBehaviour
{
    public float moveSpeed;

	// Use this for initialization
	void Start()
    {
	
	}
	
	// Update is called once per frame
	void Update()
    {
        Vector3 tempPos = transform.position;
        tempPos.x -= moveSpeed;
        if(tempPos.x < -15)
        {
            Destroy(gameObject);
        }
        transform.position = tempPos;
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            GetComponent<AudioSource>().Play();
            GetComponent<SpriteRenderer>().enabled = false;
        }
    }
}
