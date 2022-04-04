using UnityEngine;
using UnityEngine.UI;
using System.Collections;

//Score hud class;
[System.Serializable]
public class ScoreHUD
{
    public Text scoreText;          //Score display text;
    public Text highscoreText;      //Highscore display text;
    public Text coinsText;          //Coins display text;
}

public class HUD : MonoBehaviour
{
    //Score hud class;
    public ScoreHUD scoreHUD;

    private int score;
    private int highscore;
    private int coinsCount;
    private int coins;

    private int coinsAuxiliary = 0;

    public int GetScore() {
        return score;
    }

    public int GetCoins() {
        return coinsAuxiliary;
    }

    // Use this for initialization
    void Start () 
	{
        //Load high score from player prefs;
        LoadHighscore();
        //Load coins count from player prefs;
        LoadCoins();
	}

    //Add score function;
    public void AddScore(int value)
    {
        //Increase score by value;
        score += value;

        //Update score display text;
        scoreHUD.scoreText.text = score.ToString();
    }

    //Add coin function;
    public void AddCoin(int value, bool reward = false)
    {
        //Increase coins count by given value and update coins display text;
        coinsAuxiliary++;
        coinsCount += 1;
        GameManager.instance.data.stars++;
        scoreHUD.coinsText.text = GameManager.instance.data.stars.ToString();
        //If reward, save coins value;
        if (reward)
            SaveCoins();
    }

    //Function to add coins, collected by player in air;
    public void AddAirCoins(int value)
    {
        //Start adding coins routine;
        StartCoroutine(AddCoinsWithDelay(value));
    }

    IEnumerator AddCoinsWithDelay(int value)
    {
        //Calculate new coins value;
        coins = coinsCount + value;
        //Increase coins count by 1 every 0.1 sec till it reach new value;
        while (coinsCount < coins)
        {
            GameManager.instance.data.stars++;
            coinsCount += 1;
            scoreHUD.coinsText.text = GameManager.instance.data.stars.ToString();
            yield return new WaitForSeconds(0.1F);
        }
    }

    //Reset score function;
    //NECESITO LLAMAR A ESTA FUNCION CUANDO GANA LA PARTIDAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA
    public void ResetScore()
    {

        CheckHighScore();       //Check highscore;
        SaveHighscore();        //Save highscore    
        SaveCoins();            //Save coins;
        score = 0;              //Null score;

        //Update score display text;
        scoreHUD.scoreText.text = score.ToString();
    }

    //Load highscore function
    void LoadHighscore()
    {
        if (PlayerPrefs.HasKey("High"))
            highscore = PlayerPrefs.GetInt("High");

        scoreHUD.highscoreText.text = "Mayor puntaje: " + highscore;
    }

    //Load coins function
    void LoadCoins()
    {
        coinsCount = GameManager.instance.data.stars;
        scoreHUD.coinsText.text = coinsCount.ToString();
    }

    //Check high score function;
    void CheckHighScore()
    {
        if (score > highscore)
            highscore = score;
        scoreHUD.highscoreText.text = "Mayor puntaje: " + highscore;
    }

    //Save high score function;
    void SaveHighscore()
    {
        PlayerPrefs.SetInt("High", highscore);

        GameManager.instance.data.secondGameScore = highscore;
    }

    //Save coins function;
    void SaveCoins()
    {
        PlayerPrefs.SetInt("Coins", coinsCount);
    }

    //Coins count accesor
    public int CoinsCount()
    {
        return coinsCount;
    }

    public void ResetCoinsCount()
    {
        coinsCount = 0;
    }

    //Spend coins function. Decrease coins by value;
    public void DecreaseCoinsCount(int value)
    {
        coinsCount -= value;

        scoreHUD.coinsText.text = coinsCount.ToString();
    }
}