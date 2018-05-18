using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public interface ICamera {
        void LoadData( CinemachineFreeLook fl, Transform f ,Transform l);
        void OnLateUpdate();

    void LoadTop( float height, float radius, float screenY, float deadWidth, float deadHeight );
    void LoadMid( float height, float radius, float screenY, float deadWidth, float deadHeight );
    void LoadBottom( float height, float radius, float screenY, float deadWidth, float deadHeight );
}
