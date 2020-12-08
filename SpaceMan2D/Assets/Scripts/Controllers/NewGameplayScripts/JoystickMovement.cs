using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JoystickMovement : MonoBehaviour
{
   public static JoystickMovement Instance //singlton
   {
       get
       {
           if(instance == null)
           {
               instance = FindObjectOfType<JoystickMovement>();
               if(instance == null)
               {
                   var instanceContainer = new GameObject("JoystickMovement");
                   instance = instanceContainer.AddComponent<JoystickMovement>();
               }
           }
           return instance;
       }
   }
   private static JoystickMovement instance;

   public GameObject smallStick;
   public GameObject bgStick;
   Vector3 stickFirstPosition;
   Vector3 joystickFirstPosition;
   public Vector3 joyVec;
   float stickRadius;
   
   void Awake()
   {
       stickRadius = bgStick.gameObject.GetComponent<RectTransform>().sizeDelta.y / 2;
       joystickFirstPosition = bgStick.transform.position;
   }
   public void PointDown()
   {
       bgStick.transform.position = Input.mousePosition;
       smallStick.transform.position = Input.mousePosition;
       stickFirstPosition = Input.mousePosition;
   }
   public void Drag(BaseEventData baseEventData)
   {
       PointerEventData pointerEventData = baseEventData as PointerEventData;

       Vector3 DragPosition = pointerEventData.position;
       
       joyVec = (DragPosition - stickFirstPosition).normalized;

       float stickDistance = Vector3.Distance(DragPosition, stickFirstPosition);
       if(stickDistance < stickRadius)
       {
           smallStick.transform.position = stickFirstPosition + joyVec * stickDistance;
       }
       else
       {
           smallStick.transform.position = stickFirstPosition + joyVec * stickRadius;
       }

   }
   public void Drop()
   {
       joyVec = Vector3.zero;
       bgStick.transform.position = joystickFirstPosition;
       smallStick.transform.position = joystickFirstPosition;
   }
}
