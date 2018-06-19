using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "VisualSpell")]
public class vSpell : ScriptableObject {
    public string spellName;
    public ParticleSystem particle;
    public Mesh mesh;
    public bool triggered;
    public int damage;
    public int mana;
    //En teoria habria un time, pero no se por que lo puse      Ya se por que xd
    public int spellcd;
	// Use this for initialization
	public void StartVisual (Powerspell pw) {
		if ( mesh ) {
            pw.GetComponent<MeshFilter>().sharedMesh = mesh;
        }
        if ( particle ) {
            Instantiate(particle,pw.transform.position,Quaternion.identity,pw.transform);
        }
    }
	
	// Update is called once per frame
	void UpdateVisual () {
		
	}
}
