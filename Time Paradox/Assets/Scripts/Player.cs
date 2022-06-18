using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] GameManagment backTime;

    public float live;//Okre�la aktualn e �ycie gracza
    public float maxLive;//Okre�la Maksymalne �ycie Gracza
    public float lastLive;//Okre�la ostatnie zycie gracza w ciagu 5 sekund

    public bool reversTime;//okre�la,czy cofanie s� w czasie jest w��czone
    public int pointReverserTime;//Okre�la,aktualn� ilo�c punkt�w w generatorze
    public float timeReverseTime, timeToRegenerationReverseTime;//Pierwszy okre�la aktualny czas regeneracji I pola,drugi okre�la czas potrzebny do regeneracji pola

    public bool isOtherDimension;//okre�la,czy gracz jest w innym wymiarze
    public int pointGoerOtherDimension;//Okre�la,aktualn� ilo�c punkt�w w generatorze
    public float timeGoOtherDimension, timeToregenerationGoOtherDimension;//Pierwszy okre�la aktualny czas regeneracji I pola,drugi okre�la czas potrzebny do regeneracji pola

    [SerializeField]float time, timeInOtherDimension;//Pierwszy okre�la czas aktyualny bycia w innym wymairze,drugi okre�la maksymalny czas bycia
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
            //Odpalenie Animacji cofania si� w czasie
        }
        if(Input.GetKeyDown(KeyCode.R))
        {
            //Odpalenie Animacji wej�cia do Innego Wymiaru
            pointGoerOtherDimension = 0;
        }
        //To pozwala na dynamiczne cofniecie sie w czasie,bez...niedoci�gni��
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
            //aktywacja animacji powrotu do rzeczywisto�ci
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
