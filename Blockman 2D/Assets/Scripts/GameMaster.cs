using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class GameMaster : MonoBehaviour {

    public static GameMaster _GM;

    public PlayerMovement playerMovement;
    public Text coinsCollectText;
    public AudioSource music;
    public bool victory = false;
    public Image clearMessage;

    public SceneConnector SceneConnector;
    public string nextScene;

    public UnityEvent OnVictory;

    private int coinCounter;

    void Awake()
    {
        _GM = this;
        if (OnVictory == null)
            OnVictory = new UnityEvent();
    }

	public void GetCoin(int poin)
    {
        coinCounter += poin;
        UpdateCoinCounterText();
    }

    public void UpdateCoinCounterText()
    {
        coinsCollectText.text = "Coins: " + coinCounter;
    }
    
    public void Victory(AudioSource victoryMusic)
    {
        playerMovement.ToggleMovement(false);
        music.Stop();
        victoryMusic.Play();
        victory = true;
        clearMessage.enabled = true;
        OnVictory.Invoke();
    }

    public void LoadScene()
    {
        StartCoroutine(LoadingScene(5f));
    }

    IEnumerator LoadingScene(float waitTime = 0)
    {
        yield return new WaitForSeconds(waitTime);
        SceneConnector.LoadScene(nextScene);
        yield return null;
    }
}
