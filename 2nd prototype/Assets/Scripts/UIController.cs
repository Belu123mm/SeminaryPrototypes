using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {

    public Canvas canvas;
    public GameObject season;
    public List<GameObject> seasonIcons;
    public Slider hp;
    public Slider mana;
    public Slider stamina;

    // Use this for initialization
    void Awake() {
        canvas = FindObjectOfType<Canvas>();
        season = canvas.transform.GetChild(0).gameObject;
        for ( int i = 0; i < season.transform.childCount; i++ ) {
            seasonIcons.Add(season.transform.GetChild(i).gameObject);
        }
        hp = canvas.transform.GetChild(1).GetChild(0).GetComponent<Slider>() ;
        mana = canvas.transform.GetChild(2).GetChild(0).GetComponent<Slider>();
        stamina = canvas.transform.GetChild(3).GetChild(0).GetComponent<Slider>();

    }
    public void SetSeason( int id ) {
        foreach ( var icon in seasonIcons ) {
            icon.SetActive(false);
        }
        if ( seasonIcons [ id ] ) {
            seasonIcons [ id ].SetActive(true);
        }
    }
    public void SetHP( int value ) {
        hp.value = value;
    }
    public void SetMana ( int value ) {
        mana.value = value;
    }
    public void SetStamina( int value ) {
        stamina.value = value;
    }
    public void SetMaxHp(int maxHp ) {
        hp.maxValue = maxHp;
    }
    public void SetMaxMana( int maxMana ) {
        mana.maxValue = maxMana;
    }
    public void SetMaxStamina( int MaxStamina ) {
        stamina.maxValue = MaxStamina;
    }
}
