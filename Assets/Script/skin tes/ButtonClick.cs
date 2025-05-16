using UnityEngine;
using UnityEngine.UI;

public class ButtonClick : MonoBehaviour
{
    public PlayerManager playerManager;
    public Toggle toggle;

    private Player playerScript;

    private void Start()
    {
        playerScript = FindObjectOfType<Player>();

        // Menghubungkan event OnValueChanged dari Toggle dengan method ToggleObject
        toggle.onValueChanged.AddListener(ToggleObject);
    }

    private void ToggleObject(bool isOn)
    {
        if (isOn)
        {
            // Memanggil metode Run jika Toggle diaktifkan
            playerScript.Run();
        }
        else
        {
            // Memanggil metode StopRun jika Toggle dinonaktifkan
            playerScript.StopRun();
        }
    }
}
