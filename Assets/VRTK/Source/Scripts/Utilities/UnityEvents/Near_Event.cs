namespace VRTK.UnityEventHelper
{
    using UnityEngine;
    using UnityEngine.Events;
    using System;

    [AddComponentMenu("VRTK/Scripts/Utilities/Unity Events/Near_Event")]
    public sealed class Near_Event : VRTK_UnityEvents<VRTK_InteractableObject>
    {
        [Serializable]
        public sealed class InteractableObjectEvent : UnityEvent<object, InteractableObjectEventArgs> { }

        public InteractableObjectEvent OnTouch = new InteractableObjectEvent();
        public InteractableObjectEvent OnNearUntouch = new InteractableObjectEvent();
        private int near = 0;

        protected override void AddListeners(VRTK_InteractableObject component)
        {

            component.InteractableObjectTouched += Touch;
            component.InteractableObjectNearUntouched += NearUnTouch;



        }

        protected override void RemoveListeners(VRTK_InteractableObject component)
        {

            component.InteractableObjectTouched -= Touch;
            component.InteractableObjectNearUntouched -= NearUnTouch;


        }

        private void Touch(object o, InteractableObjectEventArgs e)
        {
            if(near == 0){
                OnTouch.Invoke(o, e);
                near = 1;
                
                Debug.Log("Near: " +near);
            }
        }


        private void NearUnTouch(object o, InteractableObjectEventArgs e)
        {
            if(near == 1){
                OnNearUntouch.Invoke(o, e);
                near = 0;
                
                Debug.Log("Away: " +near);
            }
            
            
        }


    }
}