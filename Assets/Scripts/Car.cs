using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car
{
  private int speed;
  protected int wheel;
  public int door;

  public Car()
  {
    speed = 100;
    wheel = 4;
    door = 2;
  }

  public Car(int speedValue, int wheelValue, int doorValue)
  {
    speed = speedValue;
    wheel = wheelValue;
    door = doorValue;
  }

  public void StartCar()
  {
    Debug.Log("Start Car");
  }

  public void ChangeGear(string gear)
  {
    Debug.Log("Change gear to : " + gear);
  }

  public void Alarm()
  {
    Debug.Log("Something Happen");
  }

  public void SetSpeed(int speedValue)
  {
    speed = speedValue;
  }

  public int GetSpeed()
  {
    return speed;
  }
}

public class RacingCar : Car
{
  private bool hasTurbo;
  public RacingCar(bool hasTurboValue)
  {
    hasTurbo = hasTurboValue;
  }
  public void UseTurbo()
  {
    if (hasTurbo == true)
    {
      SetSpeed(GetSpeed() + 1000);
    }
  }
  public void SetWheel(int wheelValue)
  {
    wheel = wheelValue;
  }
}