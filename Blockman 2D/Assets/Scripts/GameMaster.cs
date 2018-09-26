using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMaster : MonoBehaviour {

    public static GameMaster _GM;

    public PlayerMovement playerMovement;
    public Text coinsCollectText;
    public AudioSource music;
    public bool victory = false;
    public Image clearMessage;

    private int coinCounter;

    void Awake()
    {
        _GM = this;
    }

	public void GetCoin(int poin)
    {
        coinCounter += poin;
        UpdateCoinCounterText();
    }

    public void Victory(AudioSource victoryMusic)
    {
        playerMovement.ToggleMovement(false);
        music.Stop();
        victoryMusic.Play();
        victory = true;
        clearMessage.enabled = true;
    }

    public void UpdateCoinCounterText()
    {
        coinsCollectText.text = "Coins: " + coinCounter;
    }
}
