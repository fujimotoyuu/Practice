using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    private GameObject selectManager;

    // Use this for initialization
    void Start () {
        selectManager = GameObject.Find("SelectManager");
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0)) {
            //クリック時
            onDragStart();
        } else if (Input.GetMouseButton(0)) {
            //ドラッグ実装
            onDragging();
        } else if (Input.GetMouseButtonUp(0)) {
            //ドラッグ終了
            onDragEnd();
        }
    }

    private void onDragStart() {
        selectManager.GetComponent<SelectManager>().onDragStart();
    }

    private void onDragging() {
        selectManager.GetComponent<SelectManager>().onDragging();
    }

    private void onDragEnd() {
        selectManager.GetComponent<SelectManager>().onDragEnd();
    }
}
