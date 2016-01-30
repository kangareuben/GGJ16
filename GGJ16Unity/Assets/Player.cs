using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    public bool isPlayer1;
    public float moveSpeed;

    public bool beatHit;

	// Use this for initialization
	void Start()
    {
        beatHit = false;
	}
	
	// Update is called once per frame
	void Update()
    {
        if (isPlayer1)
        {
            if(Input.GetKey(KeyCode.W))
            {
                Move(moveSpeed);
            }
            if(Input.GetKey(KeyCode.S))
            {
                Move(-moveSpeed);
            }
            if(Input.GetKeyDown(KeyCode.LeftShift))
            {
                StartCoroutine("BeatHit");
            }
        }
        else
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                Move(moveSpeed);
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                Move(-moveSpeed);
            }
            if (Input.GetKeyDown(KeyCode.RightShift))
            {
                StartCoroutine("BeatHit");
            }
        }
	}

    void Move(float amount)
    {
        Vector3 tempPos = transform.position;
        tempPos.y += amount;
        if(tempPos.y > 4)
        {
            tempPos.y = 4;
        }
        else if(tempPos.y < -4)
        {
            tempPos.y = -4;
        }
        transform.position = tempPos;
    }

    void OnTriggerEnter2D(Collider2D other)
    {

    }

    IEnumerator BeatHit()
    {
        beatHit = true;
        yield return new WaitForSeconds(.1f);
        beatHit = false;
    }
}
