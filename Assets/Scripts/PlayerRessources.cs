using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerRessources : MonoBehaviour
{
    public static PlayerRessources instance;

    [SerializeField]
    float maxOxygen;
    float oxygen;
    public Slider oxygenSlider;

    [SerializeField]
    Text vitaminText;
    [SerializeField]
    Text calciumText;
    [SerializeField]
    Text proteinsText;

    [SerializeField]
    float vitamins;
    [SerializeField]
    float calcium;
    [SerializeField]
    float proteins;

    float score;
    [SerializeField]
    Text scoreText;
    [SerializeField]
    GameObject gameOverPanel;

    // Use this for initialization
    void Start ()
    {
        PlayerRessources.instance = this;

        oxygen = maxOxygen;
        oxygenSlider.maxValue = maxOxygen;
        oxygenSlider.value = oxygen;

        vitaminText.text = vitamins.ToString();
        calciumText.text = calcium.ToString();
        proteinsText.text = proteins.ToString();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void looseOxygen(float damages)
    {
        oxygen -= damages;
        oxygenSlider.value = oxygen;
        if (oxygen <= 0)
            oxygenSlider.gameObject.transform.Find("Fill Area").gameObject.SetActive(false);
    }

    public bool payVitamins(float price)
    {
        if (vitamins > price)
        {
            vitamins -= price;
            vitaminText.text = vitamins.ToString();
            return (true);
        }
        return (false);
    }

    public bool payProteins(float price)
    {
        if (proteins > price)
        {
            proteins -= price;
            proteinsText.text = proteins.ToString();
            return (true);
        }
        return (false);
    }

    public bool payCalcium(float price)
    {
        if (calcium > price)
        {
            calcium -= price;
            calciumText.text = calcium.ToString();
            return (true);
        }
        return (false);
    }

    public bool payRessources(float vitaminPrice, float proteinPrice, float calciumPrice)
    {
        if (vitamins >= vitaminPrice && calcium >= calciumPrice && proteins >= proteinPrice)
        {
            vitamins -= vitaminPrice;
            vitaminText.text = vitamins.ToString();
            calcium -= calciumPrice;
            calciumText.text = calcium.ToString();
            proteins -= proteinPrice;
            proteinsText.text = proteins.ToString();
            return (true);
        }
        return (false);
    }

    public void addRessource(float vitaminPrice, float proteinPrice, float calciumPrice)
    {
        vitamins += vitaminPrice;
        proteins += proteinPrice;
        calcium += calciumPrice;
        score++;
        if (calciumText && proteinsText && vitaminText && scoreText)
        {
            calciumText.text = calcium.ToString();
            proteinsText.text = proteins.ToString();
            vitaminText.text = vitamins.ToString();
            scoreText.text = "You killed " + score + " enemies";
        }
    }

    public void gameOver()
    {
        Time.timeScale = 0;
        gameOverPanel.SetActive(true);
    }

    public void restartLevel()
    {
        Time.timeScale = 1;
        Application.LoadLevel(Application.loadedLevel);
    }
}