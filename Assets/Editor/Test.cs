using UnityEngine;
using System.Collections;
using NUnit.Framework;

public class SampleTest : MonoBehaviour {
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

	public void healthWatcher(float health_change)
	{
		Assert.That (2 + 2 == 42);
		Assert.True (false);
	}

	[Test]
	public void TestDestruction()
	{
		Damageable damageable = new Damageable();
		Assert.AreEqual (100.0f, damageable.currentHealth);

		damageable.zack(10.0f);
		Assert.AreEqual (90.0f, damageable.currentHealth);

		//damageable.onHealthChange.AddListener (healthWatcher);
		//damageable.Kill ();
		//damageable.zack ();
		//System.Threading.Thread.Sleep(2000);
		

	}
}
