using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public GameObject[] thingsToMakeInvisible;

    GameObject[] beatLines;
    bool gameStarted;
    GameObject[] notes;
    GameObject[] players;

    public static int score=0;
    public static int noteCount = 0;
    public static int multiplier;

	// Use this for initialization
	void Start()
    {
        multiplier = 1;
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

        if(noteCount >= 5 && noteCount <10)
        {
            multiplier = 2;
        }
        if(noteCount >= 10 && noteCount < 15)
        {
            multiplier = 3;
        }
        if(noteCount >= 15 && noteCount < 20)
        {
            multiplier = 4;
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
