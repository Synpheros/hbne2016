using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Training : MonoBehaviour {

    private static Image hiddenOption = null;

    public bool isHome = false;

    public Sprite trainingSprite;
    public GameObject ability;
    private RectTransform playerTransform;

    // Use this for initialization
    void Start ()
    {
        GameObject player = GameObject.Find("Player");

        _WavyEffect wavyEffect = player.GetComponent<_WavyEffect>();
        if (wavyEffect != null)
        {
            wavyEffect.StopMoving();
        }

    }
	
	// Update is called once per frame
	void Update () {
	}

    public void startTraining()
    {
        GameObject player = GameObject.Find("Player");
        playerTransform = player.GetComponent<RectTransform>();

        _WavyEffect wavyEffect = player.GetComponent<_WavyEffect>();
        if (!isHome) {
            wavyEffect.StartMoving(); 
        }
        RectTransform thisTransform = this.gameObject.GetComponent<RectTransform>();
        wavyEffect.move(new Vector3(thisTransform.localPosition.x,
            thisTransform.localPosition.y + (isHome ? 0 : playerTransform.rect.height * .4f),
            thisTransform.localPosition.z));

        if (trainingSprite != null)
        {
            player.GetComponent<Image>().sprite = trainingSprite;
        }

        instantiateAbility();

        if (!isHome)
        {
            if (hiddenOption != null)
            {
                hiddenOption.color = new Color(1, 1, 1, 1);

            }
            Image thisImage = this.gameObject.GetComponent<Image>();
            hiddenOption = thisImage;
            hiddenOption.color = new Color(1, 1, 1, 0);
        }
    }

    void instantiateAbility()
    {

        GameObject currentAbility = GameObject.Instantiate(ability);
        RectTransform abilityTransform = currentAbility.GetComponent<RectTransform>();
        currentAbility.GetComponent<AbilityMovement>().removed = instantiateAbility;

        GameObject canvas = GameObject.Find("Canvas");
        abilityTransform.SetParent(canvas.GetComponent<RectTransform>());

        abilityTransform.localPosition = new Vector3(playerTransform.localPosition.x, playerTransform.localPosition.y, 0);

    }
}
