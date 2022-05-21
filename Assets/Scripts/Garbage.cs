using UnityEngine;

/// <summary>
/// Çöp Prefableri üzerine attach edilerek kullanılabilir.
/// </summary>
public class Garbage : MonoBehaviour
{
    [Tooltip("Hangi NPC'nin garbage spawnerı tarafından oluşturuldu tespiti için gerekli")]
    public GarbageSpawner garbageSpawner;
}
