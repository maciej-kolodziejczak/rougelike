using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{
    public static PlayerHealthController instance;

    [SerializeField] int maxHealth;
    [SerializeField] int currentHealth;
    [SerializeField] GameObject dieEffect;

    private float invincibilityTime = 1f;
    private float invincibiltyCount;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        currentHealth = maxHealth;
        SetHealthUI();
    }

    private void Update()
    {
        if (invincibiltyCount > 0)
        {
            invincibiltyCount -= Time.deltaTime;

            if (invincibiltyCount <= 0)
            {
                SetPlayerAlpha();
            }
        }
    }

    public void Damage()
    {
        if (invincibiltyCount > 0)
        {
            return;
        }

        EnableInvincibility(invincibilityTime);

        currentHealth--;
        SetHealthUI();

        if (currentHealth <= 0)
        {
            Instantiate(dieEffect, transform.position, transform.rotation);
            UIController.instance.deathScreen.gameObject.SetActive(true);
            PlayerController.instance.gameObject.SetActive(false);
        }
    }

    public void EnableInvincibility(float count)
    {
        invincibiltyCount = count;
        SetPlayerAlpha(.5f);
    }

    public void Heal(int healAmount)
    {
        currentHealth += healAmount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        SetHealthUI();
    }

    private void SetHealthUI()
    {
        UIController.instance.healthSlider.maxValue = maxHealth;
        UIController.instance.healthSlider.value = currentHealth;
        UIController.instance.healthText.text = currentHealth.ToString() + " / " + maxHealth.ToString();
    }

    private void SetPlayerAlpha(float alpha = 1f)
    {
        var playerColor = PlayerController.instance.body.color;
        PlayerController.instance.body.color = new Color(playerColor.r, playerColor.g, playerColor.b, alpha);
    }
}
