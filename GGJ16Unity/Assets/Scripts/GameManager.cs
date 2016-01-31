using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public GameObject[] thingsToMakeInvisible;

    GameObject[] beatLines;
    bool gameStarted;
    GameObject[] notes;
    GameObject[] players;

	// Use this for initialization
	void Start()
    {
        beatLines = GameObject.FindGameObjectsWithTag("BeatLine");
        gameStarted = false;
        notes = GameObject.FindGameObjectsWithTag("Note");
        players = GameObject.FindGameObjectsWithTag("Player");
	}
	
	// Update is called once per frame
	void Update()
    {
	    if(!gameStarted && Input.GetKeyDown(KeyCode.Space))
        {
            StartGame();
        }
	}

    void StartGame()
    {
        foreach(GameObject g in beatLines)
        {
            g.GetComponent<BeatLine>().canMove = true;
        }
        foreach (GameObject g in notes)
        {
            g.GetComponent<Note>().canMove = true;
        }
        foreach (GameObject g in players)
        {
            g.GetComponent<Player>().canMove = true;
        }

        if(thingsToMakeInvisible.Length != 0)
        {
            foreach(GameObject g in thingsToMakeInvisible)
            {
                g.GetComponent<SpriteRenderer>().enabled = false;
            }
        }
    }
}
