using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System;

[Serializable]
public class Award
{
    public Sprite awardImage;
    public string awardText;
}

public class FortuneWheelManager : MonoBehaviour
{
    private bool _isStarted;
    private float[] _sectorsAngles;
    private float _finalAngle;
    private float _startAngle = 0;
    private float _currentLerpRotationTime;
    public Button TurnButton;
    public GameObject Circle; 			// Rotatable Object with rewards
    //public Text CoinsDeltaText; 		// Pop-up text with wasted or rewarded coins amount
    //public Text CurrentCoinsText; 		// Pop-up text with wasted or rewarded coins amount
    public int TurnCost = 300;			// How much coins user waste when turn whe wheel
    public int CurrentCoinsAmount = 1000;	// Started coins amount. In your project it can be set up from CoinsManager or from PlayerPrefs and so on
    public int PreviousCoinsAmount;		// For wasted coins animation

    //public Sprite[] awardsImages;
    public Award[] awards;
    public Image winImage;
    public GameObject winPanel;
    public Text winText;
    public ActualizeItems spinActualizeItems;

    private void Awake()
    {
        PreviousCoinsAmount = CurrentCoinsAmount;
        //CurrentCoinsText.text = CurrentCoinsAmount.ToString();
    }

    public void TurnWheel()
    {
        // Player has enough money to turn the wheel
        if (CurrentCoinsAmount >= TurnCost)
        {
            _currentLerpRotationTime = 0f;

            // Fill the necessary angles (for example if you want to have 12 sectors you need to fill the angles with 30 degrees step)
            _sectorsAngles = new float[] { 30, 60, 90, 120, 150, 180, 210, 240, 270, 300, 330, 360 };

            int fullCircles = 5;
            float randomFinalAngle = _sectorsAngles[UnityEngine.Random.Range(0, _sectorsAngles.Length)];

            // Here we set up how many circles our wheel should rotate before stop
            _finalAngle = -(fullCircles * 360 + randomFinalAngle);
            _isStarted = true;

            PreviousCoinsAmount = CurrentCoinsAmount;

            // Decrease money for the turn
            CurrentCoinsAmount -= TurnCost;

            // Show wasted coins
            //CoinsDeltaText.text = "-" + TurnCost;
            //CoinsDeltaText.gameObject.SetActive(true);

            // Animate coins
            StartCoroutine(HideCoinsDelta());
            StartCoroutine(UpdateCoinsAmount());
        }
    }

    private void GiveAwardByAngle()
    {
        // Here you can set up rewards for every sector of wheel
        switch ((int)_startAngle)
        {
            case 0:
                Debug.Log("Gana a petro");
                GameManager.instance.data.haveCharacterEleven = true;
                winText.text = awards[5].awardText;
                winImage.sprite = awards[5].awardImage;
                //GameManager.instance.data.haveCharacterEight = true;      //Linea que desbloquea a petro
                break;
            case -330:
                Debug.Log("Gana a petro");
                GameManager.instance.data.haveCharacterEleven = true;
                winText.text = awards[5].awardText;
                winImage.sprite = awards[5].awardImage;
                //GameManager.instance.data.haveCharacterEight = true;      //Linea que desbloquea a petro
                break;
            case -300:
                Debug.Log("Gana 100 estrellas");
                winText.text = awards[1].awardText;
                winImage.sprite = awards[1].awardImage;
                RewardCoins(100);
                break;
            case -270:
                Debug.Log("Gana poder congela x 2");
                winText.text = awards[4].awardText;
                winImage.sprite = awards[4].awardImage;
                GameManager.instance.data.cantityOfPowerUpsTwo += 2;
                break;
            case -240:
                Debug.Log("Gana poder congela x 2");
                winText.text = awards[4].awardText;
                winImage.sprite = awards[4].awardImage;
                GameManager.instance.data.cantityOfPowerUpsTwo += 2;
                break;
            case -210:
                Debug.Log("Corazones x1");
                winText.text = awards[3].awardText;
                winImage.sprite = awards[3].awardImage;
                GameManager.instance.data.hearts++;
                break;
            case -180:
                Debug.Log("Gana poder defensa x 2");
                winText.text = awards[6].awardText;
                winImage.sprite = awards[6].awardImage;
                GameManager.instance.data.cantityOfPowerUpsThree += 2;
                break;
            case -150:
                Debug.Log("Gana poder defensa x 2");
                winText.text = awards[6].awardText;
                winImage.sprite = awards[6].awardImage;
                GameManager.instance.data.cantityOfPowerUpsThree += 2;
                break;
            case -120:
                Debug.Log("Gana 1000 estrellas");
                winText.text = awards[2].awardText;
                RewardCoins(1000);
                winImage.sprite = awards[2].awardImage;
                break;
            case -90:
                Debug.Log("Gana poder ataque x 2");
                winText.text = awards[0].awardText;
                winImage.sprite = awards[0].awardImage;
                GameManager.instance.data.cantityOfPowerUpsOne += 2;
                break;
            case -60:
                Debug.Log("Gana poder ataque x 2");
                winText.text = awards[0].awardText;
                winImage.sprite = awards[0].awardImage;
                GameManager.instance.data.cantityOfPowerUpsOne += 2;
                break;
            case -30:
                Debug.Log("Corazones x10");
                winText.text = awards[3].awardText;
                winImage.sprite = awards[3].awardImage;
                GameManager.instance.data.hearts += 10;
                break;
            default:
                Debug.Log("Gana poder defensa x 2");
                winText.text = awards[6].awardText;
                winImage.sprite = awards[6].awardImage;
                GameManager.instance.data.cantityOfPowerUpsThree += 2;
                break;
        }

        winPanel.SetActive(true);
        spinActualizeItems.ActualizeDatas();
        //ActualizeItems.instance.ActualizeDatas();
        GameManager.instance.ActualizeData();
        Debug.Log((int)_startAngle);
    }

    void Update()
    {
        // Make turn button non interactable if user has not enough money for the turn
        if (_isStarted || CurrentCoinsAmount < TurnCost)
        {
            TurnButton.interactable = false;
            TurnButton.GetComponent<Image>().color = new Color(255, 255, 255, 0.5f);
        }
        else
        {
            TurnButton.interactable = true;
            //TurnButton.GetComponent<Image>().color = new Color(255, 255, 255, 1);
        }

        if (!_isStarted)
            return;

        float maxLerpRotationTime = 4f;

        // increment timer once per frame
        _currentLerpRotationTime += Time.deltaTime;
        if (_currentLerpRotationTime > maxLerpRotationTime || Circle.transform.eulerAngles.z == _finalAngle)
        {
            _currentLerpRotationTime = maxLerpRotationTime;
            _isStarted = false;
            _startAngle = _finalAngle % 360;

            GiveAwardByAngle();
            StartCoroutine(HideCoinsDelta());
        }

        // Calculate current position using linear interpolation
        float t = _currentLerpRotationTime / maxLerpRotationTime;

        // This formulae allows to speed up at start and speed down at the end of rotation.
        // Try to change this values to customize the speed
        t = t * t * t * (t * (6f * t - 15f) + 10f);

        float angle = Mathf.Lerp(_startAngle, _finalAngle, t);
        Circle.transform.eulerAngles = new Vector3(0, 0, angle);
    }

    private void RewardCoins(int awardCoins)
    {
        GameManager.instance.data.stars += awardCoins;
        GameManager.instance.data.starsObtained += awardCoins;
        CurrentCoinsAmount = GameManager.instance.data.stars;
        GameManager.instance.ActualizeData();
        //CoinsDeltaText.text = "+" + awardCoins;
        //CoinsDeltaText.gameObject.SetActive(true);
        GameManager.instance.SaveChanges();
        StartCoroutine(UpdateCoinsAmount());
    }

    private IEnumerator HideCoinsDelta()
    {
        yield return new WaitForSeconds(1f);
        //CoinsDeltaText.gameObject.SetActive(false);
    }

    private IEnumerator UpdateCoinsAmount()
    {
        // Animation for increasing and decreasing of coins amount
        const float seconds = 0.5f;
        float elapsedTime = 0;

        while (elapsedTime < seconds)
        {
            //CurrentCoinsText.text = Mathf.Floor(Mathf.Lerp(PreviousCoinsAmount, CurrentCoinsAmount, (elapsedTime / seconds))).ToString();
            elapsedTime += Time.deltaTime;

            yield return new WaitForEndOfFrame();
        }

        PreviousCoinsAmount = CurrentCoinsAmount;
        //CurrentCoinsText.text = CurrentCoinsAmount.ToString();
    }

    public void DesactiveWinPanel()
    {
        winPanel.SetActive(false);
    }
}