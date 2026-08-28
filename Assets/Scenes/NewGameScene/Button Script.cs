using UnityEngine;

public class ShipClassButton : MonoBehaviour
{
    public int shipClass;

    public void SelectShip()
    {
        GameState.setShipClass(shipClass);
    }
}
