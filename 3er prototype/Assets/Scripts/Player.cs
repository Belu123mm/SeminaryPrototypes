using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour {
    public ViewPlayer view;//Pedimos un view
    IController controller;//Un controlador de teclado
    public float movementSpeed;
    public Camera cam;


    void Awake() {
        ModelPlayer _m = new ModelPlayer(GetComponent<Rigidbody>(),transform,cam,movementSpeed);//Creo un modelo,y le paso el transform que va a utilizar
        controller = new ControlMYK (_m, view);//Creo el controller del teclado y le paso el modelo y la vista que va a manejar
    }

    void Update() {
        controller.OnUpdate();
    }
}