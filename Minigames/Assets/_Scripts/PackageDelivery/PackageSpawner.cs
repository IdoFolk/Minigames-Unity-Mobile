using UnityEngine;

public class PackageSpawner : MonoBehaviour
{
    [SerializeField] RectTransform SpawnAreaRectTrans;
    [SerializeField] float SpawnerTimer;
    private float NextSpawnTime = 0f;

    void Update()
    {
        if (MiniGameManager.IsPaused) return;
        if (Time.time < NextSpawnTime) return;

        PlacePackageOnRandomSpot();
        NextSpawnTime = Time.time + SpawnerTimer;
    }

    public void PlacePackageOnRandomSpot()
    {
        GameObject PooledPackage = PackagePooling.PoolingInstance.PullFromPackagePool();
        if (PooledPackage == null) return;
        PooledPackage.gameObject.transform.localPosition = new Vector2(Random.Range(SpawnAreaRectTrans.rect.xMin, SpawnAreaRectTrans.rect.xMax), Random.Range(SpawnAreaRectTrans.rect.yMin, SpawnAreaRectTrans.rect.yMax));
        PooledPackage.SetActive(true);
    }
}
