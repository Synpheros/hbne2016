using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Training : MonoBehaviour {

    private static Image hiddenOption = null;

    public bool isHome = false;

    public Sprite trainingSprite;
    public GameObject ability;
    private RectTransform playerTransform;
    private static float srcX, srcY;
    private static Sprite srcSprite;
    private static bool resting = true;

    // Use this for initialization
    void Start ()
    {
        GameObject player = GameObject.Find("Player");

        _WavyEffect wavyEffect = player.GetComponent<_WavyEffect>();
        if (wavyEffect != null)
        {
            wavyEffect.StopMoving();
        }
        srcSprite = null;
        srcX = srcY = 0;
    }
	
	// Update is called once per frame
	void Update () {

	}

    public void startTraining()
    {
        resting = false;
        GameObject player = GameObject.Find("Player");
        playerTransform = player.GetComponent<RectTransform>();
        if (srcX == 0)
        {
            srcX = playerTransform.localPosition.x;
            srcY = playerTransform.localPosition.y;
        }

        _WavyEffect wavyEffect = player.GetComponent<_WavyEffect>();
        if (!isHome) {
            wavyEffect.StartMoving(); 
        }
        RectTransform thisTransform = this.gameObject.GetComponent<RectTransform>();
        wavyEffect.move(new Vector3(thisTransform.localPosition.x,
            thisTransform.localPosition.y + (isHome ? 0 : playerTransform.rect.height * .4f),
            thisTransform.localPosition.z));

        if (srcSprite == null)
        {
            srcSprite = player.GetComponent<Image>().sprite;
        }
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

    public void stopTraining()
    {
        resting = true;
        GameObject player = GameObject.Find("Player");
        playerTransform = player.GetComponent<RectTransform>();

        _WavyEffect wavyEffect = player.GetComponent<_WavyEffect>();

        RectTransform thisTransform = this.gameObject.GetComponent<RectTransform>();
        wavyEffect.StopMoving();
        playerTransform.localPosition = new Vector3(srcX, srcY, 0);
        if (srcSprite != null)
        {
            player.GetComponent<Image>().sprite = srcSprite;
        }

        if (hiddenOption != null)
        {
            hiddenOption.color = new Color(1, 1, 1, 1);
            hiddenOption = null;
        }
    }

    void instantiateAbility()
    {
        if(resting)
        {
            return;
        }
        GameObject currentAbility = GameObject.Instantiate(ability);
        RectTransform abilityTransform = currentAbility.GetComponent<RectTransform>();
        currentAbility.GetComponent<AbilityMovement>().removed = instantiateAbility;

        GameObject canvas = GameObject.Find("Canvas");
        abilityTransform.SetParent(canvas.GetComponent<RectTransform>());

        abilityTransform.localPosition = new Vector3(playerTransform.localPosition.x, playerTransform.localPosition.y, 0);

    }
}
