using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LearnProgram : MonoBehaviour
{
  // Start is called before the first frame update
  void Start()
  {
    //Student studentB = new Student(200, "Unity", "Engine", 4.0f);

    //Debug.Log(studentB.GetStudentNumber());
    //Debug.Log(studentB.GetStudentName());
    //Debug.Log(studentB.GetGPA());

    Student student = new Student();
    student.processComplete += ProcessComplete1;
    student.StartProcess();

    //student.processComplete -= ProcessComplete1;
    //student.StartProcess();
  }

  private void ProcessComplete1(string name)
  {
    Debug.Log("Process complete by " + name);
  }

  private void ProcessComplete2()
  {
    Debug.Log("Process complete 2");
  }

  // Update is called once per frame
  void Update()
  {
    
  }
}

//public private protected

public struct Student
{
  public event Action<string> processComplete;

  public void StartProcess()
  {
    Debug.Log("Start Process");
    Debug.Log("Do something process...");
    OnProcessComplete();
  }

  private void OnProcessComplete()
  {
    processComplete?.Invoke("Bright");
  }

  //public int studentNumber;
  //public string firstName;
  //public string lastName;
  //public float gpa;

  //public Student(int studentNumberValue, string firstNameValue, string lastNameValue, float gpaValue)
  //{
  //  studentNumber = studentNumberValue;
  //  firstName = firstNameValue;
  //  lastName = lastNameValue;
  //  gpa = gpaValue;
  //}

  //public int GetStudentNumber()
  //{
  //  return studentNumber;
  //}

  //public string GetStudentName()
  //{
  //  return firstName + " " + lastName;
  //}

  //public float GetGPA()
  //{
  //  return gpa;
  //}
}