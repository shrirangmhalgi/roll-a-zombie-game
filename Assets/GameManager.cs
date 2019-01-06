using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    private int selectedZombiePosition; //to get the position of the zombie
    private int score = 0; //calculating the score
    private Rigidbody rb;

    public GameObject selectedZombie;  //public stuff is shown in the game engine
    public List<GameObject> zombies;   //these are the number of zombie objects present in your game..
    public Vector3 selectedSize;  //used to increase the size of the zombie
    public Vector3 defaultSize;  //this is the default size (1, 1, 1) -> (x, y, z)
    public Text scoreText;

	// Use this for initialization
	void Start () {
        SelectZombie(selectedZombie); //select the first zombie
        scoreText.text = "Score : " +score;
	}

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown("left"))
        {
            GetZombieLeft(); //moves the zombie to left...
        }

        if (Input.GetKeyDown("right"))
        {
            GetZombieRight(); //moves the zombie to right...
        }

        if (Input.GetKeyDown("up"))
        {
            PushUp();
        }

        if (Input.GetKeyDown("down"))
        {
            PushDown();
        }
	}

    void GetZombieLeft () {
        if(selectedZombiePosition == 0)
        {
            selectedZombiePosition = 3;
            SelectZombie(zombies[selectedZombiePosition]);
        }
        else
        {
            selectedZombiePosition--;
            SelectZombie(zombies[selectedZombiePosition]);
        }
    }

    void GetZombieRight()
    {
        if(selectedZombiePosition == 3)
        {
            selectedZombiePosition = 0;
            SelectZombie(zombies[selectedZombiePosition]);
        }
        else
        {
            selectedZombiePosition++;
            SelectZombie(zombies[selectedZombiePosition]);
        }
    }

    void PushUp()
    {
        rb = selectedZombie.GetComponent<Rigidbody>();
        rb.AddForce(0, 0, 10, ForceMode.Impulse);
    }

    void PushDown()
    {
        rb = selectedZombie.GetComponent<Rigidbody>();
        rb.AddForce(0, 0, -5, ForceMode.Impulse);
    }

    //this function is used to transform the selected zombie
    void SelectZombie(GameObject selectedZombie) {
        this.selectedZombie.transform.localScale = defaultSize;
        this.selectedZombie = selectedZombie;
        selectedZombie.transform.localScale = selectedSize; 
    }

    public void AddPoint()
    {
        score = score + 1;
        scoreText.text = "Score : " + score;
    }
}
