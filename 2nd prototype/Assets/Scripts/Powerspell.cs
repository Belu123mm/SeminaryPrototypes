using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Powerspell : MonoBehaviour {
    public ISpell spellInterface;
    public vSpell spellView;
        
	void Start () {
        spellInterface.StartSpell(this);
        spellView.StartVisual(this);
        
        print(spellInterface);
        print(spellView.spellName);
        
	}
	
	// Update is called once per frame
	void Update () {
        spellInterface.SpellUpdate(this.gameObject);
	}
}
