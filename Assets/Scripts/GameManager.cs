using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject spawnEnemy;
    [SerializeField] GameObject[] spawnPoints;
    [SerializeField] float timer;
    [SerializeField] float timeBetweenSpawns;

    public float speedMultiplier;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        speedMultiplier += Time.deltaTime * 0.1f;

        timer += Time.deltaTime;
        if (timer > timeBetweenSpawns)
        {
            timer = 0;
            int randNum = Random.Range(0, 3);
            Instantiate(spawnEnemy, spawnPoints[randNum].transform.position, Quaternion.identity);
        }    
    }
}
