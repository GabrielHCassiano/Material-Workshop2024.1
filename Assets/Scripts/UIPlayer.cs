using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIPlayer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI coinsText;
    [SerializeField] private Slider lifeBar;

    private StatusPlayer statusPlayer;
    // Start is called before the first frame update
    void Start()
    {
        statusPlayer = GameObject.FindWithTag("Player").GetComponent<StatusPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        coinsText.text = statusPlayer.CoinsValue.ToString();
        lifeBar.value = (float) statusPlayer.LifeValue / statusPlayer.MaxLifeValue;
    }
}
