using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlMYK : IController {

    ModelPlayer _model;
    ViewPlayer _viewPlayer;


    public override void OnUpdate() {
        //Pongo los inputs
        throw new System.NotImplementedException();
    }

    public ControlMYK( ModelPlayer _m, ViewPlayer _v ) {
        _model = _m;//Guardo la referencia del modelo que me llego en mi variable privada
        _viewPlayer = _v; //Guardo la referencia de la vista que me llego en mi variable privada
        /*
        _viewPlayer.RepaintLife(_model.life);//Le digo cual es mi vida inicial
        _viewPlayer.myName.text = _model.ReturnName();//Le digo cual es el nombre de mi modelo
        _model.OnDamage += _viewPlayer.RepaintLife;//le agrego al delegate del modelo una funcion
        */
    }

}
