using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BallManager : MonoBehaviour {
    public GameObject[] ballPrehab;
    //ボール全体を管理するリスト
    public LinkedList<GameObject> ballList = new LinkedList<GameObject>();
    //消す為のリスト
    private List<GameObject> deleteList = new List<GameObject>();
   

	// Use this for initialization
	void Start () {
		 
	}

    public void createBall(float posX, float posY, int spriteId) {
        Vector3 pos = new Vector3(posX, posY, 0);
        addBall(Instantiate(ballPrehab[spriteId], pos, Quaternion.identity));
    }

    public void addBall(GameObject obj) {
        ballList.AddLast(obj);
    }

    //満杯かどうか
    public bool isFill(int count) {
        if (ballList.Count < count) {
            return false;
        }
        return true;
    }

    public void destroy() {
        int count = 0;
        foreach (GameObject ball in ballList) {
            if (ball.GetComponent<Ball>().IsAlive == false) {
                // ball.GetComponent<Ball>().destroy();
                //ballList.Remove(ball);
                deleteList.Add(ball);
            }
        }
        foreach (GameObject ball in deleteList) {
            
            ballList.Remove(ball);
            ball.GetComponent<Ball>().destroy();
            count++;
        }
        deleteList = new List<GameObject>();
        StartCoroutine(delaySeconds(count, 0.1f));

    }

    //後ですっきりさせたい
    public IEnumerator delaySeconds(int count, float time) {
        for (int i = 0; i < count; i++) {
            createBall(
                Random.Range(-2, 2),
                            7f,
                            Random.Range(0, ballPrehab.Length));
            yield return new WaitForSeconds(time);

        }
        
    }

    // Update is called once per frame
    void Update () {
        destroy();
		
	}
}
