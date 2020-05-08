using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

//Object Pool system to reduce massive instantiation of bullets from turrets.
public class BulletPoolSystem : MonoBehaviour
{
    [Serializable]
    public class bulletPool
    {
        public string poolName;
        public GameObject bullet;
        public int size;
    }

    public List<bulletPool> bulletPools;
    public Dictionary<string, Queue<GameObject>> bulletPoolDictionary;

    private void Start()
    {
        bulletPoolDictionary = new Dictionary<string, Queue<GameObject>>();

        foreach(bulletPool _bulletPool in bulletPools)
        {
            Queue<GameObject> bulletPoolQueue = new Queue<GameObject>();

            for (int x = 0; x < _bulletPool.size; x++)
            {
                GameObject theBullet = Instantiate(_bulletPool.bullet);
                theBullet.SetActive(false);
                bulletPoolQueue.Enqueue(theBullet);
            }

            bulletPoolDictionary.Add(_bulletPool.poolName, bulletPoolQueue);
        }
    }

    public GameObject GetFromPool(string bulletName)
    {
        GameObject bulletGet = bulletPoolDictionary[bulletName].Dequeue();
        bulletGet.SetActive(true);
        bulletPoolDictionary[bulletName].Enqueue(bulletGet);
        return bulletGet;
    }
}
