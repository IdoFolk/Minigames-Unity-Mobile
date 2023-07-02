using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PackageSpawner : MonoBehaviour
{
    [SerializeField] RectTransform SpawnAreaRectTrans;
    [SerializeField] float SpawnerTimer;
    private float NextSpawnTime = 0f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(MiniGameManager.IsPaused) return;
        if(Time.time >= NextSpawnTime)
        {
            PlacePackageOnRandomSpot();
            NextSpawnTime = Time.time + SpawnerTimer;
        }
    }

    public void PlacePackageOnRandomSpot()
    {
        GameObject PooledPackage = PackagePooling.PoolingInstance.PullFromPackagePool();
        if (PooledPackage == null) return;
        PooledPackage.gameObject.transform.localPosition = new Vector2(Random.Range(SpawnAreaRectTrans.rect.xMin, SpawnAreaRectTrans.rect.xMax), Random.Range(SpawnAreaRectTrans.rect.yMin, SpawnAreaRectTrans.rect.yMax));
        PooledPackage.SetActive(true);
    }
}