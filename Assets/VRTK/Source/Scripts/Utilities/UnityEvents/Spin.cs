namespace VRTK.UnityEventHelper
{
    //https://www.youtube.com/watch?v=FOoaHiUFneM inspiration from this video
    using UnityEngine;
    using UnityEngine.Events;
    using System;

    [AddComponentMenu("VRTK/Scripts/Utilities/Unity Events/Spin")]
    public sealed class Spin : VRTK_UnityEvents<VRTK_InteractableObject>
    {
        [Serializable]
        public sealed class InteractableObjectEvent : UnityEvent<object, InteractableObjectEventArgs> { }

        public GameObject Spinner;
        public GameObject Chips;
        public GameObject Hotdogs;
        public InteractableObjectEvent OnTouch = new InteractableObjectEvent();
        private int spin = 0;
        float speed,slowdown;
        private int award = 0;
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
            speed = UnityEngine.Random.Range(2.000f,5.000f);
            slowdown = UnityEngine.Random.Range(0.003f,0.009f);
            spin = 1;
        }

        void Update(){
            if(spin == 1){
                Spinner.transform.Rotate(speed,0,0,Space.World);
                speed -= slowdown;
            }
            if(speed <= 0 && spin == 1){
                speed = 0;
                spin = 0;
                award = 1;
            }
            if(spin == 0 && award ==1){
                float degree = Spinner.transform.rotation.eulerAngles.z;
                if(degree<270&&degree>90){
                    Instantiate(Hotdogs,spawnPos.position,spawnPos.rotation);
                }
                else{
                    Instantiate(Chips,spawnPos.position,spawnPos.rotation);
                }
                award = 0;
            }
        }




    }
}