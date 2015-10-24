using UnityEngine;
using UnityEngine.Events;

using NUnit.Framework;
using NSubstitute;

// Test for Damageable class.
[TestFixture]
public class DamageableTest : UnityUnitTest {
	private TestableComponent<Damageable> sut;
	private DestroyDelegate mockDestroy;
	
	[SetUp]
	public void BuildSut() {
		sut = new TestableComponent<Damageable>();
		mockDestroy = Substitute.For<DestroyDelegate>();
		
		sut.component.Destroyer = mockDestroy;
	}
	
	[Test]
	public void ShouldSetDefaultHealth() {
		Assert.AreEqual(100.0f, sut.component.currentHealth);
	}
	
	[Test]
	public void ShouldUpdateCurrentHealthWhenDamaged() {
		Assert.AreEqual(100f, sut.component.currentHealth);
		sut.component.takeDamage(10f);
		Assert.AreEqual(90f, sut.component.currentHealth);
	}
	
	[Test]
	public void ShouldAnnounceDamage() {
		UnityAction<float> listener = Substitute.For<UnityAction<float>>();
		
		sut.component.onHealthChange.AddListener(listener);
		sut.component.takeDamage(10f);
		listener.Received<UnityAction<float>>().Invoke(90f);
	}
	
	[Test]
	public void ShouldAnnounceDeath() {
		UnityAction<GameObject> listener = Substitute.For<UnityAction<GameObject>>();
		
		sut.component.onDeath.AddListener(listener);
		sut.component.takeDamage(100f);
		listener.Received<UnityAction<GameObject>>().Invoke(sut.gameObject);
	}
	
	[Test]
	public void ShouldAnnounceDeathOnlyOnce() {
		UnityAction<GameObject> listener = Substitute.For<UnityAction<GameObject>>();
		
		sut.component.onDeath.AddListener(listener);
		sut.component.takeDamage(100f);
		sut.component.takeDamage(100f);
		listener.Received<UnityAction<GameObject>>().Invoke(sut.gameObject);
	}
	
	[Test]
	public void ShouldCallDestroyOnDeath() {
		sut.component.takeDamage(100f);
		mockDestroy.Received<DestroyDelegate>().Invoke(sut.gameObject);
	}
	
	[TearDown]
	public void TearDown() {
		TestableComponent<Damageable>.CleanUp();
	}
}