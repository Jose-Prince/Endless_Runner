using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] int poolSize = 9;

    private List<GameObject> pool = new List<GameObject>();

    void Awake()
    {       
        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(bulletPrefab);
            obj.SetActive(false);
            pool.Add(obj);
        }   
    }

    public GameObject GetBullet()
    {
        foreach (GameObject obj in pool)
        {
            if (!obj.activeInHierarchy)
                return obj;
        }

        GameObject newObj = Instantiate(bulletPrefab);
        newObj.SetActive(false);
        pool.Add(newObj);

        return newObj;
    }
}
