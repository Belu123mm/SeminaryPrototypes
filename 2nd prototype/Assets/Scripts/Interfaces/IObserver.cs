using UnityEngine;
using System.Collections;

public interface IObserver
{
    /// <summary>Esto es la accion de cada vez que se notifica al observer </summary>
    void OnNotify(string action);
}
