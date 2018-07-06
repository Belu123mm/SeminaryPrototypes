using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleController : MonoBehaviour {
    public Transform avatar;
    public Transform gem;
    public List<ParticleSystem> particles;
    List<ParticleSystem> usedParticles;
    public LayerMask mask;


    public void JumpSmoke() {
        RaycastHit hit;
        Vector3 origin = avatar.position;
        Vector3 direction = Vector3.down;
        if ( Physics.Raycast(origin,direction, out hit, 100, mask) ) {
            ParticleSystem p = Instantiate(particles [ 2 ],hit.point + Vector3.up * 0.2f, Quaternion.identity);
        Destroy(p.gameObject, 5);
        }
    }
    public void HitSparks() {
        ParticleSystem p = Instantiate(particles [ 1 ], avatar.position, Quaternion.identity, avatar.transform);
        Destroy(p.gameObject, 5);

    }
    public void StaffShine() {
        ParticleSystem p  = Instantiate(particles [ 0 ], gem.position, Quaternion.identity, gem.transform);
        Destroy(p.gameObject, 5);
    }
    public void DeathThings() {
        ParticleSystem p = Instantiate(particles [ 3 ], gem.position, Quaternion.identity, gem.transform);
    }


}
