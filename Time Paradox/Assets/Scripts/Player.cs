using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Odwo�ania")]
    [SerializeField] GameManagment backTime;
    [SerializeField] Animator playerAnimations;

    [Header("Parametry Gracza")]
    public float live;//Okre�la aktualn e �ycie gracza
    public float maxLive;//Okre�la Maksymalne �ycie Gracza
    List<float> lastLive = new List<float>();//Okre�la ostatnie zycie gracza w ciagu 5 sekund
    public int backTimes;//Okresla,o ile czasu gracz si� cofnie
    float timeToSaveLastState;//Okresal czas,po kt�rym zostanie zapisana ostatni stan
    [SerializeField]List<Vector3> lastPosition = new List<Vector3>();//Okre�la osattnia pozycje w ciagu czasu okre��onego w Back Time.

    [Header("Strzelanie")]
    [SerializeField] Rigidbody originalBullet;//Okre��a Prefab Bulleta
    [SerializeField] Rigidbody bullets;//Bedzie to empty,kt�ry b�dzie mnia�w  sobie 3 Pociski
    [SerializeField]float coolDown, timeEndCoolDown;//I Okre�la aktualny czas,II Okre�la Cool  Down

    [Header("Do I Umiej�tno�ci: Cofania si� w czasie o 10 sekund")]
    public bool reversTime;//okre�la,czy cofanie s� w czasie jest w��czone
    public int pointReverserTime;//Okre�la,aktualn� ilo�c punkt�w w generatorze
    public float timeReverseTime, timeToRegenerationReverseTime;//Pierwszy okre�la aktualny czas regeneracji I pola,drugi okre�la czas potrzebny do regeneracji pola

    [Header("Do II Umiej�tno�ci: przemieszczanie si� miedzy wimiarami")]
    public bool isOtherDimension;//okre�la,czy gracz jest w innym wymiarze
    public int pointToBeOtherDimension;//Okre�la,aktualn� ilo�c punkt�w w generatorze
    public float timeGoOtherDimension, timeToregenerationGoOtherDimension;//Pierwszy okre�la aktualny czas regeneracji I pola,drugi okre�la czas potrzebny do regeneracji pola

    [SerializeField]float timeInOtherDimension, timeToEndInOtherDimension;//Pierwszy okre�la czas aktyualny bycia w innym wymairze,drugi okre�la maksymalny czas bycia

    [Header("Do III Umiej�tno�ci: Cofanai si� o 200 Lat")]
    public bool isReversTime;//Okresla,czy jest cofni�ty w czasie
    public int pointBeReversTime;//Okre�la punkty umiej�tno�ci, ile ich jest
    public float timeBeReversTime, timeToBeReversTime;// I Okre�la aktualny czas odno�nie zatwierzenia klejengo punktu umiejetno�ci, II Okres�� ten czas
    // Start is called before the first frame update
    void Start()
    {
        lastPosition.Add(transform.position);

        maxLive = 100;
        live = maxLive;
        reversTime = false;
        isOtherDimension = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && coolDown >= timeEndCoolDown)
        {
            if(bullets != null)
            {
                Destroy(bullets.gameObject);
            }
            Shoot();
        }
        coolDown += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.T) && pointReverserTime == 6 && isOtherDimension == false && isReversTime == false)
        {
            playerAnimations.SetBool("reverserTime", true);
            pointReverserTime = 0;
        }
        if(Input.GetKeyDown(KeyCode.R) && pointToBeOtherDimension == 6 && reversTime == false && isReversTime == false)
        {
            playerAnimations.SetBool("BeInOtherDimension", true);
            pointToBeOtherDimension = 0;
        }
        if(Input.GetKeyDown(KeyCode.U) && pointBeReversTime == 10 && reversTime == false && isOtherDimension == false)
        {
            playerAnimations.SetBool("BePast", true);
            pointBeReversTime = 0;
        }

        //To pozwala na dynamiczne cofniecie sie w czasie,bez...niedoci�gni��
        SaveLastPosition();//Zapisuje ostatni� pozycje w danym czasie
        TimesReverses();//Cofa w czasie o dan� ilo�c sekund.Jest na zewn�trz,a nie w ifie ze wzgledu na unikniecia kolizji,�e...cofnie nie w tym czasie co trzeba(przez czas animacji)
        
        if(isOtherDimension)//Je�eli jest w innym wymarze
        {
            TimeInOtherDimension();//To sprawdza ile w nim jest
        }
        else if(isReversTime)
        {

        }
    }

    void Shoot()
    {
        bullets = Instantiate(originalBullet, transform.position, transform.rotation);
        coolDown = 0;
    }

    void TimesReverses()
    {
        if (reversTime)
        {
            transform.position = lastPosition[lastPosition.Count -4];
            live = lastLive[lastLive.Count - 4];
            pointReverserTime = 0;
            reversTime = false;
        }
    }

    void SaveLastPosition()
    {
        if(timeToSaveLastState >= backTimes)
        {
            lastPosition.Add(transform.position);
            lastLive.Add(live);
            timeToSaveLastState = 0;
        }
        timeToSaveLastState += Time.deltaTime;
    }

    void TimeInOtherDimension()
    {
        if(timeInOtherDimension >= timeToEndInOtherDimension)
        {
            playerAnimations.SetBool("BeInOtherDimension", false);
        }
        timeInOtherDimension += Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(isOtherDimension == false)
        {
            if(other.CompareTag("Asteroid"))
            {
                live -= 50;
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
