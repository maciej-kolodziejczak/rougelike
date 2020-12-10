using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    [SerializeField] int healAmount = 1;
    [SerializeField] float collectTimeout = .5f;

    private void Update()
    {
        if (collectTimeout > 0)
        {
            collectTimeout -= Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && collectTimeout <= 0)
        {
            PlayerHealthController.instance.Heal(healAmount);
            AudioManager.Instance.PlaySfx(7);
            Destroy(gameObject);
        }
    }
}
