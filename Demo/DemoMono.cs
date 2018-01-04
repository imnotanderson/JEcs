using UnityEngine;
using J.Demo;
using J.ECS;
using Event = J.Demo.Event;

public class DemoMono : MonoBehaviour
{
	private App app = new DemoApp();
	
	// Use this for initialization
	void Start ()
	{
		app.Init();
	}
	
	// Update is called once per frame
	void Update ()
	{
		app.SendMsg(Event.Upt);
	}
}
