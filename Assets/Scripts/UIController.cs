using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public static UIController instance;

    [SerializeField] public Text healthText;
    [SerializeField] public Slider healthSlider;
    [SerializeField] public Image deathScreen;

    private void Awake()
    {
        instance = this;
    }
}
