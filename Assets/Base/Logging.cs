using UnityEngine;

using System;
using System.ComponentModel;

public class Logging {
	// Log all properties of an object to the debug log.
	static public void LogObject(string message, UnityEngine.Object obj)
	{
		string to_log = "ALL PROPERTIES (" + message + "):\n";
		
		foreach(PropertyDescriptor descriptor in TypeDescriptor.GetProperties(obj).Sort ())
		{
			try {
				string name=descriptor.Name;
				object value=descriptor.GetValue(obj);
				to_log += name + "=" + value + '\n';
			}
			catch (NotSupportedException) {
				// This fires a lot because of deprecated properties. Ignore them.
				// Debug.LogException(e);
			}
		}
		
		Debug.Log (to_log);
	}
}

