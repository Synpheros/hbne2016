using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GuiFunctions : MonoBehaviour
{

    public Slider coordinacionSlider;
    public Text coordinacionLevel;

    public Slider ritmoSlider;
    public Text ritmoLevel;

    public Slider concentracionSlider;
    public Text concentracionLevel;

    public Slider healthSlider;
    public Slider energySlider;

    public Text textDay;

    public GameObject[] time;

    private int timeSector;

	// Use this for initialization
	void Start () {
        coordinacionSlider.value = PlayerPrefs.GetFloat("coordinacionProgress");
        coordinacionLevel.text = PlayerPrefs.GetInt("coordinacionLevel").ToString();

        ritmoSlider.value = PlayerPrefs.GetFloat("ritmoProgress");
        ritmoLevel.text = PlayerPrefs.GetInt("ritmoLevel").ToString();

        concentracionSlider.value = PlayerPrefs.GetFloat("concentracionProgress");
        concentracionLevel.text = PlayerPrefs.GetInt("concentracionLevel").ToString();

        healthSlider.value = PlayerPrefs.GetFloat("health") == 0 ? 1 : PlayerPrefs.GetFloat("health");
        energySlider.value = PlayerPrefs.GetFloat("energy") == 0 ? 1 : PlayerPrefs.GetFloat("energy");

        textDay.text = PlayerPrefs.GetInt("textDay").ToString();

        timeSector = PlayerPrefs.GetInt("timeSector") - 1;
        for (int i = 0; i <= timeSector; i++)
        {
            time[i].SetActive(true);
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void aumentarCoordinacion()
    {
        if (coordinacionSlider.value + 0.1 > 1)
        {
            coordinacionSlider.value = 0;
            coordinacionLevel.text = "" + (int.Parse(coordinacionLevel.text) + 1);
            PlayerPrefs.SetInt("coordinacionLevel", int.Parse(coordinacionLevel.text));
        }
        coordinacionSlider.value += 0.1f;
        PlayerPrefs.SetFloat("coordinacionProgress", coordinacionSlider.value);
    }

    public void aumentarRitmo()
    {
        if (ritmoSlider.value + 0.1 > 1)
        {
            ritmoSlider.value = 0;
            ritmoLevel.text = "" + (int.Parse(ritmoLevel.text) + 1);
            PlayerPrefs.SetInt("ritmoLevel", int.Parse(ritmoLevel.text));
        }
        ritmoSlider.value += 0.1f;
        PlayerPrefs.SetFloat("ritmoProgress", ritmoSlider.value);
    }

    public void aumentarConcentracion()
    {
        if (concentracionSlider.value+0.1 > 1)
        {
            concentracionSlider.value = 0;
            concentracionLevel.text = "" + (int.Parse(concentracionLevel.text) + 1);
            PlayerPrefs.SetInt("concentracionLevel", int.Parse(concentracionLevel.text));
        }
        concentracionSlider.value += 0.1f;
        PlayerPrefs.SetFloat("concentracionProgress", concentracionSlider.value);
    }

    public void disminuirCoordinacion()
    {
        if (coordinacionSlider.value - 0.1f < 0)
        {
            coordinacionSlider.value = 1f;
            coordinacionLevel.text = "" + (int.Parse(coordinacionLevel.text) - 1);
            PlayerPrefs.SetInt("coordinacionLevel", int.Parse(coordinacionLevel.text));
        }
        coordinacionSlider.value -= 0.1f;
        PlayerPrefs.SetFloat("coordinacionProgress", coordinacionSlider.value);
    }

    public void disminuirRitmo()
    {
        if (ritmoSlider.value - 0.1f < 0)
        {
            ritmoSlider.value = 1f;
            ritmoLevel.text = "" + (int.Parse(ritmoLevel.text) - 1);
            PlayerPrefs.SetInt("ritmoLevel", int.Parse(ritmoLevel.text));
        }
        ritmoSlider.value -= 0.1f;
        PlayerPrefs.SetFloat("ritmoProgress", ritmoSlider.value);
    }

    public void disminuirConcentracion()
    {
        if (concentracionSlider.value-0.1f < 0)
        {
            concentracionSlider.value = 1f;
            concentracionLevel.text = "" + (int.Parse(concentracionLevel.text) - 1);
            PlayerPrefs.SetInt("concentracionLevel", int.Parse(concentracionLevel.text));
        }
        concentracionSlider.value -= 0.1f;
        PlayerPrefs.SetFloat("concentracionProgress", concentracionSlider.value);
    }

    public void aumentarSalud()
    {
        healthSlider.value += 0.1f;
        if (coordinacionSlider.value == 1)
        {
            healthSlider.value = 1;
        }
        PlayerPrefs.SetFloat("health", healthSlider.value);
    }

    public void aumentarEnergia()
    {
        energySlider.value += 0.1f;
        if (energySlider.value == 1)
        {
            energySlider.value = 1;
        }
        PlayerPrefs.SetFloat("energy", energySlider.value);
    }

    public void disminuirSalud()
    {
        healthSlider.value -= 0.05f;
        if (coordinacionSlider.value == 0)
        {
            healthSlider.value = 0.05f;
        }
        PlayerPrefs.SetFloat("health", healthSlider.value);
    }

    public void disminuirEnergia()
    {
        energySlider.value -= 0.05f;
        if (energySlider.value == 0)
        {
            energySlider.value = 0.05f;
        }
        PlayerPrefs.SetFloat("energy", energySlider.value);
    }

    public bool estaAgotado()
    {
        return energySlider.value == 0.05f;
    }

    private void aumentarDía()
    {
        textDay.text = "" + (int.Parse(textDay.text) + 1);
        PlayerPrefs.SetInt("textDay", int.Parse(textDay.text));
    }

    public void aumentarHora()
    {
        timeSector++;
        if (timeSector == time.Length)
        {
            timeSector = 0;
            for (int i = 0; i < time.Length; i++)
            {
                time[i].SetActive(false);
            }
            aumentarDía();
        }
        else
        {
            if (timeSector < 0)
            {
                timeSector = 0;
            }
            time[timeSector-1].SetActive(true);

        }

        PlayerPrefs.SetInt("timeSector", timeSector);
    }
}
