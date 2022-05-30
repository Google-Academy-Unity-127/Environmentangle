using UnityEngine;
using UnityEngine.SceneManagement; 

/// <summary>
/// Player objesinin üzerine attach edilir.
/// Garbage etiketli objeleri toplar ve UI güncellemesi yapar
/// </summary>
public class Collector : MonoBehaviour
{
    private Scene _scene; // sahne tanitiyorum.
    private UIManager _uiManager;
    private int _collectedAmount;

    private void Awake() // tanittigim sahneyi cagiriyorum.
    {
        _scene = SceneManager.GetActiveScene(); // sahneyi caching ediyorum.
    }


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

        if (_collectedAmount >= 15) // topladigim nesneler 15 olduğunda sonraki sahneye gecmesini istiyorum.
        {
            SceneManager.LoadScene(_scene.buildIndex+1);
        }
    }
    public void StartLevel() // giris ekranindaki start butonu
    {
        SceneManager.LoadScene(_scene.buildIndex + 1);
    }

    public void Credits() // giris credits start butonu
    {
        SceneManager.LoadScene("Credits");
    }

    public void BackCredits() // credits'den main menuye donme butonu
    {
        SceneManager.LoadScene("StartGame");
    }

}
