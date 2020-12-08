using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProjectileBar : MonoBehaviour
{
   public Image fill;
   public Slider slider;
   public Gradient gradient;// for change color of bar

   public void SetMaxProjectiles(int projectile)
   {
       slider.maxValue = projectile;
       slider.value = projectile;
       fill.color = gradient.Evaluate(1f);
   }

   public void SetProjectile(int projectile)
   {
       slider.value = projectile;
       fill.color = gradient.Evaluate(slider.normalizedValue);
   }
}
