using TMPro;
using UnityEngine;

/// <summary>
/// Canvas altındaki UI işlemleri bu class altındaki propertylerde ilgili methodlar çağırılarak yapılır.
/// </summary>
public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI collectedText;

    private void Start() => ResetCollectedUI();

    private void ResetCollectedUI() => collectedText.text = "-";

    public void UpdateCollectedUI(int amount) => collectedText.text = amount.ToString();
}
