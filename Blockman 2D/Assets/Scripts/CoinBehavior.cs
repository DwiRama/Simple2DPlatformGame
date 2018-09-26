using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBehavior : MonoBehaviour {

    public int poin;
    public SpriteRenderer sprite;
    public AudioSource sfx;
    public ParticleSystem particle;
    
    bool getCoin;

    void Update()
    {
        if (getCoin)
        {
            if (!sfx.isPlaying)
            {
                this.gameObject.SetActive(false);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player") && !getCoin)
        {
            GameMaster._GM.GetCoin(poin);
            sprite.enabled = false;
            particle.Play();
            sfx.Play();
            getCoin = true;
        }
    }
}
