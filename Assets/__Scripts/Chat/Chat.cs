﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;


public class Chat : MonoBehaviour {

    static public Chat S;

    public GameObject receiveBubble;
    public GameObject sendBubble;
    public GameObject amistad_bubble;
    public GameObject borrar_bubble;
    public GameObject alert_bubble;

    private GameObject content;

    private GameObject textchat;

    private List<GameObject> bubbles;

    public Dictionary<string,Color> colors;

    public List<Sprite> characters;
    public Sprite transparente;

	// Use this for initialization
	void Start () {
        S = this;
        this.content = GameObject.Find ("content");

        textchat = GameObject.Find ("textochat");
        fade_out_instant(this.content);
	}
	
	// Update is called once per frame
    private float msg_time = 0.025f;
    private float time_since_last_msg = 0;

    string text_to_show = "";
    string current_text = "";
    bool a = false;
	void Update () {
       time_since_last_msg += Time.deltaTime;
        if (time_since_last_msg > msg_time) {
            time_since_last_msg = 0;
            if (current_text.Length < text_to_show.Length) {
                addCharacter ();
            }
        }
	}

    void addCharacter(){
        this.current_text = text_to_show.Substring (0, current_text.Length+1);
        GameObject.Find ("texto_textochat").GetComponent<Text> ().text = current_text;

    }

    private int[] talkers = null;
    public void talk(int[] chars, string text){
        if (chars == null) {
            this.talkers = null;
            fade_out (this.content);
        }{
            if (this.talkers != chars) {
                this.talkers = chars;
                for(int i = 0; i<3; i++){
                    if(talkers[i] != -1)
                        //GameObject.Find("char_" + i).GetComponent<Image> ().sprite = this.transparente;
                    //else
                        GameObject.Find("char_" + i).GetComponent<Image> ().sprite = this.characters [talkers[i]]; 

                }

                fade_in (this.content);
            }

            this.text_to_show = text;
            this.current_text = "";
        }
    }

    public void pushBubbles(float height){
        foreach (GameObject go in bubbles) {
            go.GetComponent<Bubble>().moveTo(new Vector3 (go.transform.localPosition.x, go.transform.localPosition.y + height, go.transform.localPosition.z));
        }
    }

    public void fade_in(GameObject go){
        Graphic[] graphics = go.GetComponentsInChildren<Graphic>();

        for (int i = 0; i < graphics.Length; ++i)
        {
            if(graphics[i].GetComponent<Text>() != null || graphics[i].GetComponent<Image>() != null)
                if (i == 0 || i > 3)
                    graphics [i].CrossFadeAlpha (1f, 0.5f, false);
                 else if (this.talkers [i - 1] != -1) {
                    graphics [i].CrossFadeAlpha (1f, 0.5f, false);
                }else
                    graphics[i].CrossFadeAlpha(0f, 0.5f, false);
                
        }
    }

    public void fade_out(GameObject go){
        Graphic[] graphics = go.GetComponentsInChildren<Graphic>();

        for (int i = 0; i < graphics.Length; ++i)
        {
            graphics[i].CrossFadeAlpha(0f, 0.5f, false);
        }
    }

    public void fade_out_instant(GameObject go){
        Graphic[] graphics = go.GetComponentsInChildren<Graphic>();

        for (int i = 0; i < graphics.Length; ++i)
        {
            graphics[i].CrossFadeAlpha(0f, 0f, false);
        }
    }
}
