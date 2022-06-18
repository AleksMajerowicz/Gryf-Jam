using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] GameManagment backTime;

    public float live;//Okreœla aktualn e ¿ycie gracza
    public float maxLive;//Okreœla Maksymalne ¿ycie Gracza
    public float lastLive;//Okreœla ostatnie zycie gracza w ciagu 5 sekund

    public bool reversTime;//okreœla,czy cofanie sê w czasie jest w³¹czone
    public int pointReverserTime;//Okreœla,aktualn¹ iloœc punktów w generatorze
    public float timeReverseTime, timeToRegenerationReverseTime;//Pierwszy okreœla aktualny czas regeneracji I pola,drugi okreœla czas potrzebny do regeneracji pola

    public bool isOtherDimension;//okreœla,czy gracz jest w innym wymiarze
    public int pointGoerOtherDimension;//Okreœla,aktualn¹ iloœc punktów w generatorze
    public float timeGoOtherDimension, timeToregenerationGoOtherDimension;//Pierwszy okreœla aktualny czas regeneracji I pola,drugi okreœla czas potrzebny do regeneracji pola

    [SerializeField]float time, timeInOtherDimension;//Pierwszy okreœla czas aktyualny bycia w innym wymairze,drugi okreœla maksymalny czas bycia
    // Start is called before the first frame update
    void Start()
    {
        maxLive = 100;
        live = maxLive;
        reversTime = false;
        isOtherDimension = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.T))
        {
            //Odpalenie Animacji cofania siê w czasie
        }
        if(Input.GetKeyDown(KeyCode.R))
        {
            //Odpalenie Animacji wejœcia do Innego Wymiaru
            pointGoerOtherDimension = 0;
        }
        //To pozwala na dynamiczne cofniecie sie w czasie,bez...niedoci¹gniêæ
        TimesReverses();
        
        if(isOtherDimension)
        {
            TimeInOtherDimension();
        }
    }

    void TimesReverses()
    {
        if (reversTime && transform.position.z > backTime.dynamicList[0].transform.position.z)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, backTime.dynamicList[0].transform.position.z - 10);
            live = lastLive;
            backTime.TimeRevers(5);
            pointReverserTime = 0;
            reversTime = false;
        }
    }

    void TimeInOtherDimension()
    {
        if(time >= timeInOtherDimension)
        {
            //aktywacja animacji powrotu do rzeczywistoœci
        }
        time += Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(isOtherDimension == false)
        {
            if(other.CompareTag("Asteroid"))
            {
                live = 0;
            }
            if(other.CompareTag("gogga"))
            {
                live -= 25;
            }
            if(other.CompareTag("goga-tower"))
            {
                live -= 50;
            }
        }
    }
}
