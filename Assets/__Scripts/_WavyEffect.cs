using UnityEngine;
using System.Collections;

public class _WavyEffect : MonoBehaviour {

    public enum movingState
    {
        ENSANCHANDO_BAJITO,
        VOLVIENDO_DE_BAJITO,
        INCREMENTANDO_ALTO,
        VOLVIENDO_DE_ALTO, 
        PARADO
    }

    float frecuency = 1f;
    movingState state = movingState.ENSANCHANDO_BAJITO;

    float height_percent = 1f;
    float width_percent = 1f;
    Vector3 pos;

    float width, height, realheight;
	void Start () {
        this.width = this.transform.localScale.x;
        this.height = this.transform.localScale.y;
        
        this.realheight = this.GetComponent<RectTransform>().sizeDelta.y;
        //move(this.transform.localPosition);
    }

    public void StopMoving()
    {
        this.state = movingState.PARADO;

       // this.transform.localScale = Vector3.Lerp(this.transform.localScale, new Vector3(this.width, this.height, 1f), 0.1f);
       // this.transform.localPosition = new Vector3(this.pos.x, this.pos.y + (this.realheight * this.transform.localScale.y) / 2, this.pos.z);
        this.width_percent = 1;
        this.height_percent = 1;
    }

    public void StartMoving()
    {
        this.state = movingState.ENSANCHANDO_BAJITO;
    }

    public void move(Vector3 position)
    {
        this.pos = position - new Vector3(0, (this.realheight * this.transform.localScale.y) / 2, 0);
        this.transform.localPosition = position;
    }
	
	// Update is called once per frame
	void Update () {
        switch (state)
        {
            case movingState.ENSANCHANDO_BAJITO:
                this.height_percent -= 0.01f;
                this.width_percent += 0.01f;

                
                if (this.height_percent <= 0.9)
                    this.state = movingState.VOLVIENDO_DE_BAJITO;
                break;
            case movingState.VOLVIENDO_DE_BAJITO:
                this.height_percent += 0.01f;
                this.width_percent -= 0.01f;
                if (this.height_percent >= 1.1f)
                    this.state = movingState.ENSANCHANDO_BAJITO;
                break;
            default:
                return;
                break;
        }

        this.transform.localScale = Vector3.Lerp(this.transform.localScale,new Vector3(this.width * width_percent, this.height * height_percent, 1f),0.1f);
        this.transform.localPosition = new Vector3(this.pos.x, this.pos.y + (this.realheight*this.transform.localScale.y) / 2, this.pos.z);
    }
}
