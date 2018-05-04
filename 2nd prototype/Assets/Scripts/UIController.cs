using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {

    public Canvas canvas;
    public GameObject season;
    public List<GameObject> seasonIcons;

	// Use this for initialization
	void Start () {
        canvas = FindObjectOfType<Canvas>();
        season = canvas.transform.GetChild(0).gameObject;
        for ( int i = 0; i < season.transform.childCount; i++ ) {
            seasonIcons.Add(season.transform.GetChild(i).gameObject);
        }
	}
	public void SetUI(int id) {
        foreach ( var icon in seasonIcons ) {
            icon.SetActive(false);
        }
        if ( seasonIcons [ id ] ) {
            //seasonIcons [ id ].SetActive(!seasonIcons [ id ].activeInHierarchy); esto puede servir para combinar poderes. 
            //Luego de usarlos, se apagan todos. Habria que hacer un sistema para acumularlos y sobrecargar el sistema y asi
            //Necesitamos un timer, cosa de limitar los disparos 
            seasonIcons [ id ].SetActive(true);
        }

    }
}
