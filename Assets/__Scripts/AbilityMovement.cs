using UnityEngine;
using System.Collections;
using System;

public class AbilityMovement : MonoBehaviour {
    
    private float elapsedTime;
    public Action removed;

    // Use this for initialization
    void Start () {
        elapsedTime = 0f;

    }
	
	// Update is called once per frame
	void Update () {

        elapsedTime += (Time.deltaTime * 20);
        float newY = transform.localPosition.y + Time.deltaTime * 400;
        float newX = transform.localPosition.x + 10 * Mathf.Sin(elapsedTime);

        transform.localPosition = new Vector3(newX, newY, 0);

        Vector3 screenPosition = Camera.main.WorldToScreenPoint(this.transform.position);
        if(screenPosition.y > Screen.height)
        {
            if(removed != null)
            {
                removed();
            }
            Destroy(this.gameObject);
        }
	}
}
