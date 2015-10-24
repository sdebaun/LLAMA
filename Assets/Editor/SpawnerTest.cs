using UnityEngine;
using UnityEngine.Events;

using NUnit.Framework;
using NSubstitute;

[TestFixture]
public class SpawnerTest : UnityUnitTest {
	[SetUp]
	public void SetUp() {

	}

	[Test]
	public void SpawnObject() {
		Debug.LogError ("ZACK");
		GameObject gameObject = Spawner<WumpusController>.SpawnControlledObject();
		WumpusController controller = gameObject.GetComponent<WumpusController>();
		controller.Spawn ();
	}

}