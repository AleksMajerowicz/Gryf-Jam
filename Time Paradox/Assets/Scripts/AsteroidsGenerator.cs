using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidsGenerator : MonoBehaviour
{
    [SerializeField] Player player;
    [SerializeField] Rigidbody [] Asteroids;
    [SerializeField] List<Rigidbody> dynamicList = new List<Rigidbody>();//W niej bêda aktualne istniejace Asteroide,co pzowoli na przywrócenie ich zapisanie ich pozycji

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
        if (timeGenerate >= timeToGenerate)
        {
            dynamicList.Add(Instantiate(Asteroids[Random.Range(0, Asteroids.Length)], new Vector3(Random.Range(-1.9f,1.9f), Random.Range(-1.9f,1.9f),player.transform.position.z + 20), new Quaternion(0, 0, 0, 1)));
            timeGenerate = 0;
        }
        timeGenerate += Time.deltaTime;
    }
}
