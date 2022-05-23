using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LearnProgram : MonoBehaviour
{
  // Start is called before the first frame update
  void Start()
  {
    Student studentB = new Student(200, "Unity", "Engine", 4.0f);

    Debug.Log(studentB.GetStudentNumber());
    Debug.Log(studentB.GetStudentName());
    Debug.Log(studentB.GetGPA());
  }

  // Update is called once per frame
  void Update()
  {
    
  }
}

//public private protected

public struct Student
{
  public int studentNumber;
  public string firstName;
  public string lastName;
  public float gpa;

  public Student(int studentNumberValue, string firstNameValue, string lastNameValue, float gpaValue)
  {
    studentNumber = studentNumberValue;
    firstName = firstNameValue;
    lastName = lastNameValue;
    gpa = gpaValue;
  }

  public int GetStudentNumber()
  {
    return studentNumber;
  }

  public string GetStudentName()
  {
    return firstName + " " + lastName;
  }

  public float GetGPA()
  {
    return gpa;
  }
}