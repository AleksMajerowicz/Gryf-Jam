using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagment : MonoBehaviour
{
    [SerializeField] Player player;
    [SerializeField] Rigidbody [] Asteroids;
    public List<Rigidbody> asteroidList = new List<Rigidbody>();//W niej bêda aktualne istniejace Asteroide,co pzowoli na przywrócenie ich zapisanie ich pozycji

    [SerializeField]float timeGenerate,timeDelete,timeToDelete, timeToGenerate;
    // Start is called before the first frame update
    void Start()
    {
        asteroidList.Add(Instantiate(Asteroids[Random.Range(0, Asteroids.Length)], new Vector3(Random.Range(-3f, 3f), Random.Range(-3f, 3f),20), new Quaternion(0, 0, 0, 1)));
        for (int i = 0; i < 100; i++)
        {
            GenerateAsteroids(i);
        }
    }

    // Update is called once per frame
    void Update()
    {
        RegeneratorTimerReverseTime();//Regeneruje Punkty Umiejêtnoœci Cofania sie w czasie o dan¹ iloœæ sekund
        RegeneratorTimerGoToTheOtherDimension();//Regeneruje punkty umiejenoœci bycia w innym wymiarzê
    }

    void GenerateAsteroids(int index)
    {
        asteroidList.Add(Instantiate(Asteroids[Random.Range(0, Asteroids.Length)], new Vector3(Random.Range(-3, 3), Random.Range(-3, 3), asteroidList[index].transform.position.z + 10), new Quaternion(0, 0, 0, 1)));

    }

    void RegeneratorTimerReverseTime()
    {
        if (player.timeReverseTime >= player.timeToRegenerationReverseTime && player.pointReverserTime < 10)
        {
            player.pointReverserTime += 1;
            player.timeReverseTime = 0;
        }
        player.timeReverseTime += Time.deltaTime;
    }

    void RegeneratorTimerGoToTheOtherDimension()
    {
        if (player.timeGoOtherDimension >= player.timeToregenerationGoOtherDimension && player.pointToBeOtherDimension < 10)
        {
            player.pointToBeOtherDimension += 1;
            player.timeGoOtherDimension = 0;
        }
        player.timeGoOtherDimension += Time.deltaTime;
    }
}
