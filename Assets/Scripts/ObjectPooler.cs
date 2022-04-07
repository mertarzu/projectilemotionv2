using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class ObjectPooler : MonoBehaviour
{
    public List<PooledObject> PooledObjects = new List<PooledObject>();
    [SerializeField] PooledObject ballPrefab;
    [SerializeField] int amountToPool;
    int additionAmountToPool = 8;
    int tempAmountToPool;


    private void Awake()
    {
        for (int i = 0; i < amountToPool; i++)
        {
            PooledObjects.Add(Create());
        }
    }
    

    public PooledObject Create()
    {
        PooledObject tempGameObject = GameObject.Instantiate(ballPrefab);
        tempGameObject.gameObject.SetActive(false);
        return tempGameObject;

    }

    public PooledObject GetPooledObject()
    {
        PooledObject result = PooledObjects.Where(i => i.IsPooledObjectTaken == false).FirstOrDefault();
        if (result == null && tempAmountToPool < additionAmountToPool)
        {
            AddPooledObject();
            result = PooledObjects.Where(i => i.IsPooledObjectTaken == false).FirstOrDefault();
            ++tempAmountToPool;
        }
        return result;
    }
    public void AddPooledObject()
    {
        PooledObjects.Add(Create());
    }
}
