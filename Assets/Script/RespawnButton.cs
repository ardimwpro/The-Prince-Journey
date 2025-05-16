using UnityEngine;
using UnityEngine.UI; // Ini digunakan untuk akses UI
using UnityEngine.EventSystems;

public class RespawnButton : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        // Memanggil fungsi respawn saat tombol ditekan
        GameManager.Instance.RespawnPlayerAndResetObjects();
    }
}
