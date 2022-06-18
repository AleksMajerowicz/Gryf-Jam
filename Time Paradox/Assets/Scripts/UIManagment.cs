using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManagment : MonoBehaviour
{
    [SerializeField] Player player;
    [SerializeField] Image playerLiveBar;
    [SerializeField] Image[] pointReveserTime;
    [SerializeField] Image[] pointGoerToTheOtherDimension;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playerLiveBar.fillAmount = player.live / player.maxLive;


    }
}
