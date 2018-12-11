using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameContoroller : MonoBehaviour {
    private GameObject ballList;
    [SerializeField]
    public int createCount = 30;

	// Use this for initialization
	void Start () {
        ballList = GameObject.Find("BallManager");
        StartCoroutine(startGame(createCount));
    }

    public IEnumerator startGame(int count) {
        for (int i = 0; i < count; i++) {
            ballList.GetComponent<BallManager>().createBall(
            Random.Range(-2, 2), 
                        7f, 
                        Random.Range(0, ballList.GetComponent<BallManager>().ballPrehab.Length));
            yield return new WaitForSeconds(0.1f);
        }
    }
	
	// Update is called once per frame
	void Update () {
	}
}
