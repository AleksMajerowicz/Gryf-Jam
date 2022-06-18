using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagment : MonoBehaviour
{
    [SerializeField] Player player;
    [SerializeField] Rigidbody [] Asteroids;
    public List<Rigidbody> dynamicList = new List<Rigidbody>();//W niej bêda aktualne istniejace Asteroide,co pzowoli na przywrócenie ich zapisanie ich pozycji

    [SerializeField]float timeGenerate,timeDelete,timeToDelete, timeToGenerate;
    // Start is called before the first frame update
    void Start()
    {
        /*for(int i = 0; i < 20; i++)
        {
            Instantiate(Asteroids[Random.Range(0, Asteroids.Length)], new Vector3(Random.Range(-1.9f, 1.9f), Random.Range(-1.9f, 1.9f), player.transform.position.z + 20), new Quaternion(0, 0, 0, 1));
        }*/
    }

    // Update is called once per frame
    void Update()
    {
        GenerateAsteroids();
        DeleteAsteroids();

        RegeneratorTimerReverseTime();
        RegeneratorTimerGoToTheOtherDimension();
    }

    void GenerateAsteroids()
    {
        if (timeGenerate >= timeToGenerate)
        {
            dynamicList.Add(Instantiate(Asteroids[Random.Range(0, Asteroids.Length)], new Vector3(Random.Range(-1.9f, 1.9f), Random.Range(-1.9f, 1.9f), player.transform.position.z + 20), new Quaternion(0, 0, 0, 1)));
            timeGenerate = 0;
        }
        timeGenerate += Time.deltaTime;
    }

    void DeleteAsteroids()
    {
        if (timeDelete >= timeToDelete)
        {
            Destroy(dynamicList[0].gameObject);
            dynamicList.Remove(dynamicList[0]);
            timeDelete = 0;
            player.lastLive = player.live;
        }
        timeDelete += Time.deltaTime;
    }

    void RegeneratorTimerReverseTime()
    {
        if (player.timeReverseTime >= player.timeToRegenerationReverseTime && player.pointReverserTime >= 10)
        {
            player.pointReverserTime += 1;
            player.timeReverseTime = 0;
        }
        player.timeReverseTime += Time.deltaTime;
    }

    public void TimeRevers(int backTime)
    {
        timeDelete -= backTime;
        timeGenerate -= backTime;
    }

    void RegeneratorTimerGoToTheOtherDimension()
    {
        if (player.timeGoOtherDimension >= player.timeToregenerationGoOtherDimension && player.pointGoerOtherDimension >= 10)
        {
            player.pointGoerOtherDimension += 1;
            player.timeGoOtherDimension = 0;
        }
        player.timeGoOtherDimension += Time.deltaTime;
    }
}
