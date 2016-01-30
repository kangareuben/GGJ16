using UnityEngine;
using System.Collections;

public class BeatLine : MonoBehaviour
{
    public float moveSpeed;
    public GameObject player1;
    public GameObject player2;

	// Use this for initialization
	void Start()
    {
	
	}
	
	// Update is called once per frame
	void Update()
    {
        Vector3 tempPos = transform.position;
        tempPos.x -= moveSpeed;
        if (tempPos.x < -15)
        {
            Destroy(gameObject);
        }
        transform.position = tempPos;

        if(GetComponent<SpriteRenderer>().enabled && (player1.GetComponent<Player>().beatHit || player2.GetComponent<Player>().beatHit) && Mathf.Abs(transform.position.x - player1.transform.position.x) < .2)
        {
            GetComponent<AudioSource>().Play();
            GetComponent<SpriteRenderer>().enabled = false;
        }
    }
}
