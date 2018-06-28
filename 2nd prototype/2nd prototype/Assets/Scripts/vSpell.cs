using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "VisualSpell")]
public class vSpell : ScriptableObject {
    public string spellName;
    public ParticleSystem particle;
    public GameObject mesh;
    public bool triggered;
    public int damage;
    public int mana;
    public int spellID;
    //En teoria habria un time, pero no se por que lo puse      Ya se por que xd
    //Este time es cuanto tarda el hechizo en morir
    public int spellcd;
	// Use this for initialization
	public void StartVisual (Powerspell pw) {
        if ( mesh ) {
            GameObject m = Instantiate(mesh, pw.transform.position, Quaternion.identity, pw.transform);
            if ( spellID == 3 ) m.transform.forward = pw.transform.right;
            else m.transform.forward = pw.transform.forward;//Hay algo raro en esto 
            pw.animMesh = m.GetComponent<Animator>();
        }
        if ( particle ) {
            Instantiate(particle,pw.transform.position,Quaternion.identity,pw.transform);
        }
    }
	
	// Update is called once per frame
	void UpdateVisual () {
		
	}
}
