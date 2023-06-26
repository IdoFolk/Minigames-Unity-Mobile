using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PackagePooling : MonoBehaviour
{
    [SerializeField] public GameObject PackagePrefab;
    [SerializeField] public int PackageCount;

    public static PackagePooling PoolingInstance;

    private List<GameObject> _packagePool = new List<GameObject>();


    private void Awake()
    {
        PoolingInstance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < PackageCount; i++)
        {
            GameObject gameObject = Instantiate(PackagePrefab, transform);
            gameObject.SetActive(false);
            _packagePool.Add(gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {

    }

    public GameObject PullFromPackagePool()
    {
        for (int i = 0; i < PackageCount; i++)
        {
            if (!_packagePool[i].activeInHierarchy)
            {
                return _packagePool[i];
            }
        }
        return null;
    }
}