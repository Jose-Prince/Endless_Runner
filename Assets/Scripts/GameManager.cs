using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject spawnEnemy;
    [SerializeField] GameObject[] spawnPoints;
    [SerializeField] float timer;
    [SerializeField] float timeBetweenSpawns;
    [SerializeField] TextMeshProUGUI distanceUI;

    public float speedMultiplier;

    private float distance;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        distanceUI.text = "Distance: " + distance.ToString("F2");
        speedMultiplier += Time.deltaTime * 1.2f;

        timer += Time.deltaTime;

        distance += Time.deltaTime * 0.1f;
        if (timer > timeBetweenSpawns)
        {
            timer = 0;
            int randNum = Random.Range(0, 3);
            Instantiate(spawnEnemy, spawnPoints[randNum].transform.position, Quaternion.identity);
        }    
    }
}
