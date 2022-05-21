using UnityEngine;

/// <summary>
/// Player objesinin üzerine attach edilir.
/// Garbage etiketli objeleri toplar ve UI güncellemesi yapar
/// </summary>
public class Collector : MonoBehaviour
{
    private UIManager _uiManager;
    private int _collectedAmount;
    
    private void Start()
    {
        _uiManager = FindObjectOfType<UIManager>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Garbage"))
        {
            _collectedAmount++;
            _uiManager.UpdateCollectedUI(_collectedAmount);
            col.GetComponent<Garbage>().garbageSpawner.DecreaseProducedGarbage();
            Destroy(col.gameObject);
            Debug.Log("Çöp alındı");
        }
        else
        {
            Debug.LogError("Çöp olmayan bir objeyle temas oldu. Etiket mi eklemedin?");
        }
    }
}
