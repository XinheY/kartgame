using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using Mirror;

namespace UnityStandardAssets.Vehicles.Car
{
    [RequireComponent(typeof (CarController))]
    public class CarUserControl : NetworkBehaviour
    {
        private CarController m_Car; // the car controller we want to use


        private void Awake()
        {
            // get the car controller
            m_Car = GetComponent<CarController>();
        }


        private void FixedUpdate()
        {
            if(isLocalPlayer){
            // pass the input to the car!
            float h = CrossPlatformInputManager.GetAxis("Horizontal");
            float v = CrossPlatformInputManager.GetAxis("Vertical");
#if !MOBILE_INPUT
            float handbrake = CrossPlatformInputManager.GetAxis("Jump");
            m_Car.MoveCar(h, v, v, handbrake);
#else
            m_Car.MoveCar(h, v, v, 0f);
#endif
            }
        }
    }
}
