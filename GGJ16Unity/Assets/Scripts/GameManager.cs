using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public GameObject[] multiplierImages;
    public GameObject[] thingsToMakeInvisible;

    GameObject[] beatLines;
    bool gameStarted;
    GameObject[] notes;
    GameObject[] players;

    public static int score = 0;
    public static int noteCount = 0;
    public static int multiplier;
    public GUIText scoreText;

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
            for(int i = 0; i < 4; i++)
            {
                if(i == 1)
                {
                    multiplierImages[i].GetComponent<SpriteRenderer>().enabled = true;
                }
                else
                {
                    multiplierImages[i].GetComponent<SpriteRenderer>().enabled = false;
                }
            }
        }
        else if(noteCount >= 10 && noteCount < 15)
        {
            multiplier = 3;
            for(int i = 0; i < 4; i++)
            {
                if(i == 2)
                {
                    multiplierImages[i].GetComponent<SpriteRenderer>().enabled = true;
                }
                else
                {
                    multiplierImages[i].GetComponent<SpriteRenderer>().enabled = false;
                }
            }
        }
        else if(noteCount >= 15 && noteCount < 20)
        {
            multiplier = 4;
            for(int i = 0; i < 4; i++)
            {
                if(i == 3)
                {
                    multiplierImages[i].GetComponent<SpriteRenderer>().enabled = true;
                }
                else
                {
                    multiplierImages[i].GetComponent<SpriteRenderer>().enabled = false;
                }
            }
        }
        else
        {
            for (int i = 0; i < 4; i++)
            {
                if (i == 0)
                {
                    multiplierImages[i].GetComponent<SpriteRenderer>().enabled = true;
                }
                else
                {
                    multiplierImages[i].GetComponent<SpriteRenderer>().enabled = false;
                }
            }
        }

        scoreText.GetComponent<GUIText>().text = score.ToString();
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
