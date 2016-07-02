using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Popup : MonoBehaviour {

    public GameObject video;
    MovieTexture movie;
    int poping = 0;

	// Use this for initialization
	void Start () {
        this.transform.localScale = new Vector3(0, 0, 1f);
        
        if (video != null) {
            RawImage image = video.GetComponent<RawImage>();
            movie = (MovieTexture) image.texture;
        }
    }
	

	// Update is called once per frame
	void Update () {
        if(poping == 1)
            this.transform.localScale = Vector3.Lerp(this.transform.localScale, new Vector3(1, 1, 1), 0.3f);

        if (poping == -1)
            this.transform.localScale = Vector3.Lerp(this.transform.localScale, new Vector3(0, 0, 0), 0.3f);
    }

    public void pop()
    {
        poping = 1;
        if(movie!=null)
            movie.Play();
        this.transform.localScale = new Vector3(0, 0, 1f);
    }

    public void unpop()
    {
        poping = -1;
    }
}
