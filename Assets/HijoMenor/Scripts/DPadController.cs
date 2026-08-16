using UnityEngine;
using UnityEngine.EventSystems;

public class DPadController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public MovementController player;
    public string direccion;

    private bool isHeld = false;

    void Update()
    {
        if (isHeld && player != null)
        {
            player.SetDireccion(direccion);
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isHeld = true;
        if (player != null)
            player.SetDireccion(direccion);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isHeld = false;
    }
}
