using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextController : MonoBehaviour {
    private float fadetime = 0.015f;
    private float alfa = 0;
    private float red, green, blue;
    private bool fadeFlag = false;

    // Use this for initialization
    void Start () {
        //Panelの色を取得
        
        red = GetComponent<Text>().color.r;
        green = GetComponent<Text>().color.g;
        blue = GetComponent<Text>().color.b;
        
    }

    // Update is called once per frame
    void Update () {
        EffectTitle();
    }

    private void EffectTitle() {
        if (!fadeFlag) {
            GetComponent<Text>().color = new Color(red, green, blue, alfa);
            alfa -= fadetime;
            if (alfa <= 0) {
                fadeFlag = true;
            }
        } else if (fadeFlag) {
            GetComponent<Text>().color = new Color(red, green, blue, alfa);
            alfa += fadetime;
            if (alfa >= 1) {
                fadeFlag = false;
            }
        }
        
    }
}
