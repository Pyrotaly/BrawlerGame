using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace HealthBarTest
{
   public class TestHealthBar : MonoBehaviour
    {
        public Slider slider;
        public Gradient gradient;
        public Image fill;

        public float TestingX;

        public void Awake()
        {
            TestingX = slider.maxValue;
        }

        public void SetMaxHealth(int health)
        {
            slider.maxValue = health;
            slider.value = health; //slider starts at maximum health at start

            fill.color = gradient.Evaluate(1f);
        }
        public void SetHealth(int health)
        {
            slider.value = health;
            fill.color = gradient.Evaluate(slider.normalizedValue);
        }
    }
}