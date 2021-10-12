using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutSubscriberClass : MonoBehaviour {
    



    private void ReflectMessage()
    {
        Debug.Log("This is from the other class");
        
    }


    //Destroy this script
    private void DestroyComponent()
    {
        Destroy(this, 4.0f);
    }


    private void Start()
    {
        //You cannot just assign a function to the event. It should be added to invocation list or removed, instead of just being 'called'. 
        // e.g. DelegateExample.UpdateInfoEvent = ReflectMessage; wont work due to protection
        DelegateExample.UpdateInfoEvent += ReflectMessage;
        //Antoher Expample
        DelegateExample.ValueRoundingEvent += DelegateExamplesOnValueRoundingEvent;
       
        
        DestroyComponent();
    }

    private int DelegateExamplesOnValueRoundingEvent (float valuetoberounded)
    {
        return Mathf.RoundToInt(valuetoberounded);
    }

    //On destroy it removes the delegate from the invocation list 
    private void OnDestroy()
    {
        DelegateExample.UpdateInfoEvent -= ReflectMessage;
        DelegateExample.ValueRoundingEvent -= DelegateExamplesOnValueRoundingEvent;
    }
}
