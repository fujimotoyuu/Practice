using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SelectManager : MonoBehaviour {
    //選択されたボールを管理するリスト
    public List<GameObject> selectList = new List<GameObject>();
    private GameObject firstBall;
    private GameObject lastBall;
    private string currentName;
    private GameObject line;


    // Use this for initialization
    void Start () {
        line = GameObject.Find("LineRenderer");
	}

    public void addList(GameObject obj) {
        selectList.Add(obj);
    }


    public void onDragStart() {

        //マウスの座標で当たっているオブジェクトの情報を取得
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        //何か座標を取得した場合
        if (hit.collider != null) {
            GameObject hitObj = hit.collider.gameObject;
            string ballName = hitObj.name;
            //当たっているオブジェクトがBallかどうかの確認
            if (ballName.StartsWith("ball")) {
                selectList = new List<GameObject>();
                firstBall = hitObj;
                currentName = hitObj.name;
                lastBall = hitObj;
                addList(hitObj);
                line.GetComponent<DrawLine>().drawLine(selectList.Count, 0.2f, 0.2f, hitObj);
                Debug.Log("atatta");
            }
            
        }
    }

    public void onDragging() {
        //マウスの座標で当たっているオブジェクトの情報を取得
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        //何か座標を取得した場合
        if (hit.collider != null) {
            GameObject hitObj = hit.collider.gameObject;
            string ballName = hitObj.name;
            //1つ前のオブジェクトと現在のオブジェクトの種類の確認と、ボタンが押し続けている間ずっと呼び出される処理になっているので、最後のなめと一致していたらスキップさせる。
            if (selectList.Count >= 2 && (selectList[selectList.Count - 2] == hitObj)) {
                Debug.Log("attaa");
                //lastBall = hitObj;
                selectList.RemoveAt(selectList.Count - 1);
                line.GetComponent<DrawLine>().lRend.positionCount = selectList.Count;
            } else if (currentName == ballName && lastBall != hitObj) {
                float distance = Vector2.Distance(hitObj.transform.position, lastBall.transform.position);
                if (distance < 1.5f) {
                    lastBall = hitObj;
                    addList(hitObj);
                    line.GetComponent<DrawLine>().drawLine(selectList.Count, 0.2f, 0.2f, hitObj);
                }
            }

        }
    }

    public void onDragEnd() {
        if (selectList.Count > 1) {
            ballDied();
        }
        firstBall = null;
        lastBall = null;
        line.GetComponent<DrawLine>().deleteLine();
    }

    private void ballDied() {
        foreach (GameObject ball in selectList) {
            ball.GetComponent<Ball>().IsAlive = false;
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
