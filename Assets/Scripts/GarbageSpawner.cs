using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Npc Üzerine Attach Edilerek Kullanılabilir.
/// İlgili Propertyler Editör üzerinden ayarlanabilir.
/// </summary>
public class GarbageSpawner : MonoBehaviour
{
    [Tooltip("Maksimum üretilecek çöp sayısı")]
    public int maxGarbageAmount;
    [Tooltip("Çöp üretme aralığı")]
    public float garbageSpawnRepeatTime;
    [Tooltip("Çöp üretme başlangıç süresi")]
    public float garbageFirstSpawnTime;
    [Tooltip("Çöp Prefab Listesi")]
    public List<Garbage> garbagePrefabList;

    private int _producedGarbageCount;
    
    private void Start()
    {
        InvokeRepeating(nameof(SpawnRandomGarbage), garbageFirstSpawnTime, garbageSpawnRepeatTime);
    }
    
    /// <summary>
    /// Prefab listesinden rastgele bir çöpü belirtilen aralıkta maksimum sayıya ulaşana kadar üretir.
    /// </summary>
    public void SpawnRandomGarbage()
    {
        if(_producedGarbageCount == maxGarbageAmount)
            return;

        _producedGarbageCount++;
        var randomGarbageValue = Random.Range(0, garbagePrefabList.Count);
        var garbage = Instantiate(garbagePrefabList[randomGarbageValue], transform.position, Quaternion.identity);
        garbage.transform.SetParent(null);
        garbage.garbageSpawner = this;
        
        Debug.Log($"{garbage.gameObject.name} üretildi.");
    }
    
    /// <summary>
    /// Çöp toplandığında toplam üretilen çöp miktarını düşür.
    /// </summary>
    public void DecreaseProducedGarbage() => _producedGarbageCount--;
}
