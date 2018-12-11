using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLine : MonoBehaviour {
    public LineRenderer lRend;

    // Use this for initialization
    void Start () {
        lRend = GameObject.Find("LineRenderer").GetComponent<LineRenderer>();
    }

    //線を描く
    public void drawLine(int vertexCount, float startWidth, float endWidth, GameObject obj) {
        lRend.positionCount = vertexCount;
        lRend.startWidth = startWidth;
        lRend.endWidth = endWidth;
        lRend.SetPosition(vertexCount-1, new Vector3(obj.transform.position.x, obj.transform.position.y, obj.transform.position.z - 1.0f));
    }

    public void deleteLine() {
        lRend.positionCount = 0;
    }
}
