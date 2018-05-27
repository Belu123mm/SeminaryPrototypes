using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour {
    public ViewPlayer view;//Pedimos un view
    IController controller;//Un controlador de teclado
    public float movementSpeed;


    void Awake() {
        ModelPlayer _m = new ModelPlayer(GetComponent<Rigidbody>(),transform,FindObjectOfType<Camera>(),movementSpeed);//Creo un modelo,y le paso el transform que va a utilizar
        controller = new ControlMYK (_m, view);//Creo el controller del teclado y le paso el modelo y la vista que va a manejar
    }

    void Update() {
        //Al tener una abstraccion y que ambos controlladores lo utilizen puedo sustituir entre ambos sin ningun problema
        controller.OnUpdate();
    }
}