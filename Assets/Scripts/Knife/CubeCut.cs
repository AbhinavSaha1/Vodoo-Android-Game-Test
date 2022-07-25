using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeCut : MonoBehaviour
{
	[SerializeField]
	private static float _slicedCubeForce;

	public static bool Cut(Transform victim, Vector3 _pos)
	{

		Vector3 pos = new Vector3(_pos.x, victim.position.y, victim.position.z);
		Vector3 victimScale = victim.localScale;
		float distance = Vector3.Distance(victim.position, pos);
		if (distance >= victimScale.x / 2) return false;

		Vector3 leftPoint = victim.position - Vector3.left * victimScale.x / 2;
		Vector3 rightPoint = victim.position + Vector3.left * victimScale.x / 2;
		Material mat = victim.GetComponent<MeshRenderer>().material;
		Destroy(victim.gameObject);

		GameObject rightSideObj = GameObject.CreatePrimitive(PrimitiveType.Cube);
		rightSideObj.transform.position = (rightPoint + pos) / 2;
		float rightWidth = Vector3.Distance(pos, rightPoint);
		rightSideObj.transform.localScale = new Vector3(rightWidth, victimScale.y, victimScale.z);
		rightSideObj.AddComponent<Rigidbody>().mass = 100f;
		rightSideObj.GetComponent<MeshRenderer>().material = mat;
		rightSideObj.GetComponent<Rigidbody>().AddForce(Vector3.left * 800, ForceMode.Impulse);
		Destroy(rightSideObj, 10);

		GameObject leftSideObj = GameObject.CreatePrimitive(PrimitiveType.Cube);
		leftSideObj.transform.position = (leftPoint + pos) / 2;
		float leftWidth = Vector3.Distance(pos, leftPoint);
		leftSideObj.transform.localScale = new Vector3(leftWidth, victimScale.y , victimScale.z);
		leftSideObj.AddComponent<Rigidbody>().mass = 100f;
		leftSideObj.GetComponent<MeshRenderer>().material = mat;
		leftSideObj.GetComponent<Rigidbody>().AddForce(Vector3.right * 900, ForceMode.Impulse);
		Destroy(leftSideObj, 10);

		return true;
	}
}
