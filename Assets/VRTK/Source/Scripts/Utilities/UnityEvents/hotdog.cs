namespace VRTK.UnityEventHelper
{
    //https://www.youtube.com/watch?v=FOoaHiUFneM inspiration from this video
    using UnityEngine;
    using UnityEngine.Events;
    using System;

    [AddComponentMenu("VRTK/Scripts/Utilities/Unity Events/hotdog")]
    public sealed class hotdog : VRTK_UnityEvents<VRTK_InteractableObject>
    {
        [Serializable]
        public sealed class InteractableObjectEvent : UnityEvent<object, InteractableObjectEventArgs> { }
        public GameObject Hotdogs;
        public InteractableObjectEvent OnTouch = new InteractableObjectEvent();
        public Transform spawnPos;

        protected override void AddListeners(VRTK_InteractableObject component)
        {

            component.InteractableObjectTouched += Touch;



        }

        protected override void RemoveListeners(VRTK_InteractableObject component)
        {

            component.InteractableObjectTouched -= Touch;


        }

        private void Touch(object o, InteractableObjectEventArgs e)
        {
            Instantiate(Hotdogs,spawnPos.position,spawnPos.rotation);
        }





    }
}