using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Powerspell : MonoBehaviour {
    public ISpell spellInterface;
        
	void Start () {
        spellInterface.StartSpell(this);
	}
	
	// Update is called once per frame
	void Update () {
        spellInterface.SpellUpdate(this);
	}
}
