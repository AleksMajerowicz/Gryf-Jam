using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManagment : MonoBehaviour
{
    [SerializeField] Player player;
    [SerializeField] Image playerLiveBar;
    [SerializeField] Image[] pointReveserTime;
    [SerializeField] Image[] pointToBeTheOtherDimension;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //playerLiveBar.fillAmount = player.live / player.maxLive;
        SetPointsReversTime();
        SetPointsToBeOtherDiminsions();

    }

    void SetPointsReversTime()
    {
        if(player.pointReverserTime == 0)
        {
            for(int i = 0; i < pointReveserTime.Length; i++)
            {
                pointReveserTime[i].gameObject.SetActive(false);
            }
        }
        else if(player.pointReverserTime > 0 && player.pointReverserTime <= pointReveserTime.Length)
        {
            pointReveserTime[player.pointReverserTime - 1].gameObject.SetActive(true);
        }
    }

    void SetPointsToBeOtherDiminsions()
    {
        if (player.pointToBeOtherDimension == 0)
        {
            for (int i = 0; i < pointToBeTheOtherDimension.Length; i++)
            {
                pointToBeTheOtherDimension[i].gameObject.SetActive(false);
            }
        }
        else if (player.pointToBeOtherDimension > 0 && player.pointToBeOtherDimension <= pointToBeTheOtherDimension.Length)
        {
            pointToBeTheOtherDimension[player.pointToBeOtherDimension - 1].gameObject.SetActive(true);
        }
    }
}
