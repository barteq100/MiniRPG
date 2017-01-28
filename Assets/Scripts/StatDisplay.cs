using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class StatDisplay: MonoBehaviour
  {
  Text HP;
  Text Str;
  Text Agi;

  void Awake()
  {
    GameObject hp = transform.FindChild("HP").gameObject;
    HP = hp.GetComponent<Text>();
    GameObject str = transform.FindChild("Strength").gameObject;
    Str = str.GetComponent<Text>();
    GameObject agi = transform.FindChild("Agility").gameObject;
    Agi = agi.GetComponent<Text>();
  }

  void Start()
  {
    HP.text = "Max HP: " + PlayerController.Health.ToString();
    Str.text = "Strength: " + PlayerController.Strength.ToString();
    Agi.text = "Agility: " + PlayerController.Agility.ToString();
  }

  void Update()
  {
    HP.text = "Max HP: " + PlayerController.Health.ToString();
    Str.text = "Strength: " + PlayerController.Strength.ToString();
    Agi.text = "Agility: " + PlayerController.Agility.ToString();
  }

  }

