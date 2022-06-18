using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Odwo³ania")]
    [SerializeField] GameManagment backTime;
    [SerializeField] Animator playerAnimations;

    [Header("Parametry Gracza")]
    public float live;//Okreœla aktualn e ¿ycie gracza
    public float maxLive;//Okreœla Maksymalne ¿ycie Gracza
    List<float> lastLive = new List<float>();//Okreœla ostatnie zycie gracza w ciagu 5 sekund
    public int backTimes;//Okresla,o ile czasu gracz siê cofnie
    float timeToSaveLastState;//Okresal czas,po którym zostanie zapisana ostatni stan
    [SerializeField]List<Vector3> lastPosition = new List<Vector3>();//Okreœla osattnia pozycje w ciagu czasu okreœ³onego w Back Time.

    [Header("Strzelanie")]
    [SerializeField] Rigidbody originalBullet;//Okreœ³a Prefab Bulleta
    [SerializeField] Rigidbody bullets;//Bedzie to empty,który bêdzie mnia³w  sobie 3 Pociski
    [SerializeField]float coolDown, timeEndCoolDown;//I Okreœla aktualny czas,II Okreœla Cool  Down

    [Header("Do I Umiejêtnoœci: Cofania siê w czasie o 10 sekund")]
    public bool reversTime;//okreœla,czy cofanie sê w czasie jest w³¹czone
    public int pointReverserTime;//Okreœla,aktualn¹ iloœc punktów w generatorze
    public float timeReverseTime, timeToRegenerationReverseTime;//Pierwszy okreœla aktualny czas regeneracji I pola,drugi okreœla czas potrzebny do regeneracji pola

    [Header("Do II Umiejêtnoœci: przemieszczanie siê miedzy wimiarami")]
    public bool isOtherDimension;//okreœla,czy gracz jest w innym wymiarze
    public int pointToBeOtherDimension;//Okreœla,aktualn¹ iloœc punktów w generatorze
    public float timeGoOtherDimension, timeToregenerationGoOtherDimension;//Pierwszy okreœla aktualny czas regeneracji I pola,drugi okreœla czas potrzebny do regeneracji pola

    [SerializeField]float timeInOtherDimension, timeToEndInOtherDimension;//Pierwszy okreœla czas aktyualny bycia w innym wymairze,drugi okreœla maksymalny czas bycia

    [Header("Do III Umiejêtnoœci: Cofanai siê o 200 Lat")]
    public bool isReversTime;//Okresla,czy jest cofniêty w czasie
    public int pointBeReversTime;//Okreœla punkty umiejêtnoœci, ile ich jest
    public float timeBeReversTime, timeToBeReversTime;// I Okreœla aktualny czas odnoœnie zatwierzenia klejengo punktu umiejetnoœci, II Okres³¹ ten czas
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

        //To pozwala na dynamiczne cofniecie sie w czasie,bez...niedoci¹gniêæ
        SaveLastPosition();//Zapisuje ostatni¹ pozycje w danym czasie
        TimesReverses();//Cofa w czasie o dan¹ iloœc sekund.Jest na zewn¹trz,a nie w ifie ze wzgledu na unikniecia kolizji,¿e...cofnie nie w tym czasie co trzeba(przez czas animacji)
        
        if(isOtherDimension)//Je¿eli jest w innym wymarze
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
