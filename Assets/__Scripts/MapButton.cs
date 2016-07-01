using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class MapButton : MonoBehaviour
{
    public GameObject tooltip; 

    bool showText = false;

    public void ChangeScene(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void ChangeScene(int n)
    {
        Application.LoadLevel(n);
    }

    public void ShowText()
    {
        Debug.Log("ENTER");
        tooltip.SetActive(true);
    }

    public void HideText()
    {
        tooltip.SetActive(false);
    }
}

