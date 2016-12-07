using UnityEngine;
using UnityEditor;
using System.Collections;
using System.IO;
using System.Text;

public class Gradle : ScriptableObject {
	[MenuItem("Window/Gradle/Resolve")]
	public static void Refresh() {
		System.Diagnostics.Process process = new System.Diagnostics.Process();
		process.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
		process.StartInfo.WorkingDirectory = Application.dataPath + "/Plugins/Gradle";
		process.StartInfo.RedirectStandardOutput = true;
		process.StartInfo.RedirectStandardError = true;
		process.StartInfo.UseShellExecute = false;
		process.StartInfo.CreateNoWindow = true;

		switch (System.Environment.OSVersion.Platform) {
		case System.PlatformID.Unix:
		case System.PlatformID.MacOSX:
			process.StartInfo.FileName = "bash";
			process.StartInfo.Arguments = "gradlew export -PAPPLICATION_ID=" + PlayerSettings.bundleIdentifier;
			break;

		default:
			process.StartInfo.FileName = "gradlew.bat";
			process.StartInfo.Arguments = "export -PAPPLICATION_ID=" + PlayerSettings.bundleIdentifier;
			break;
		}

		if (process.Start ()) {
			var stdout = new StringBuilder ();
			var stderr = new StringBuilder ();

			while (!process.StandardOutput.EndOfStream) {
				string line = process.StandardOutput.ReadLine();
				stdout.AppendLine (line);
			}

			while (!process.StandardError.EndOfStream) {
				string line = process.StandardError.ReadLine();
				stderr.AppendLine (line);
			}

			process.WaitForExit ();

			if (process.ExitCode == 0) {
				stdout.Insert (0, "Gradle returns " + process.ExitCode + "\n");
				Debug.Log (stdout.ToString());

				AssetDatabase.Refresh ();
			} else {
				stderr.Insert (0, "Gradle returns " + process.ExitCode + ": ");
				Debug.LogError (stderr.ToString());
			}
		} else {
			Debug.LogError ("Gradle couldn't be started from: " + process.StartInfo.WorkingDirectory);
		}
	}
}
