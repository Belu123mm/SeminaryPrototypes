using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aim : MonoBehaviour, IObservable {
    public string status;
    public List<IObserver> allObservers = new List<IObserver>();

    // Use this for initialization
    void Start() {
        Normal();
        print(allObservers.Count);
    }
    public void Combat() {
        status = "combat";
        print("combat");
        Notify();
    }
    public void Normal() {
        status = "normal";
        print("normal");
        Notify();
    }
    public void Subscribe( IObserver observer ) {
        print(observer);
        if ( !allObservers.Contains(observer) )
            allObservers.Add(observer);
    }

    public void Unsubscribe( IObserver observer ) {
        if ( allObservers.Contains(observer) )
            allObservers.Remove(observer);
    }
    public void Notify() {
        foreach ( var obs in allObservers ) {
            obs.OnNotify(status);
        }
    }
}
