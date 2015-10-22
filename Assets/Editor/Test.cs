using UnityEngine;
using System.Collections;
using NUnit.Framework;

public class MyTest : MonoBehaviour {
	
	public class SampleTest
	{
		[Test]
		public void TestThatSucceeds()
		{
			Assert.That(2 + 2 == 4);
		}

		[Test]
		public void TestThatFails()
		{
			Assert.That (2 + 2 == 42);
		}
	}
}
