using UnityEngine;

public class PlayerInRoom : MonoBehaviour
{
    [SerializeField] private int _roomNumber;
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Player player))
        {
            player.RoomNumber = _roomNumber;
        }
    }
}
