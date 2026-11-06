using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Security.Principal;
using System.Text;

namespace NEXUS;

public static class PrefetchCleaner
{
	public static string RunPrefetchCleanup(out int exitCode, int timeoutMs = 120000)
	{
		exitCode = -1;
		string text = "\r\n# Prefetch-Cleanup.ps1  (Run as Administrator)\r\n$prefetch = \"C:\\Windows\\Prefetch\"\r\n$log = \"$env:ProgramData\\prefetch_cleanup_$(Get-Date -Format 'yyyyMMdd_HHmmss').log\"\r\n\r\nfunction Write-Log($msg){ $line = \"[{0}] {1}\" -f (Get-Date), $msg; $line | Tee-Object -FilePath $log -Append }\r\n\r\n# Admin check\r\nif (-not ([Security.Principal.WindowsPrincipal] [Security.Principal.WindowsIdentity]::GetCurrent()\r\n    ).IsInRole([Security.Principal.WindowsBuiltinRole]::Administrator)) {\r\n    Write-Host \"Please run as Administrator.\"\r\n    exit 1\r\n}\r\n\r\nWrite-Log \"Starting Prefetch cleanup\"\r\n# Try stopping SysMain (Superfetch)\r\ntry {\r\n    Stop-Service SysMain -ErrorAction Stop\r\n    Write-Log \"Stopped SysMain service\"\r\n} catch { Write-Log \"SysMain stop skipped: $($_.Exception.Message)\" }\r\n\r\n# Take ownership if needed (rare)\r\ntry {\r\n    takeown /F $prefetch /A /R /D Y | Out-Null\r\n    icacls  $prefetch /grant Administrators:F /T | Out-Null\r\n    Write-Log \"Ownership/ACL ensured\"\r\n} catch { Write-Log \"Ownership/ACL step failed: $($_.Exception.Message)\" }\r\n\r\n# Delete files\r\ntry {\r\n    Get-ChildItem $prefetch -Recurse -Force -ErrorAction SilentlyContinue |\r\n        Remove-Item -Force -Recurse -ErrorAction SilentlyContinue\r\n    Write-Log \"Prefetch contents removed\"\r\n} catch { Write-Log \"Delete error: $($_.Exception.Message)\" }\r\n\r\n# Start service back\r\ntry {\r\n    Start-Service SysMain -ErrorAction Stop\r\n    Write-Log \"Started SysMain service\"\r\n} catch { Write-Log \"SysMain start skipped: $($_.Exception.Message)\" }\r\n\r\nWrite-Log \"Completed Prefetch cleanup. Log: $log\"\r\nWrite-Host \"Done. Log saved to $log\"\r\n";
		string contents = text;
		string tempPath = Path.GetTempPath();
		string text2 = "Prefetch-Cleanup-";
		Guid guid = Guid.NewGuid();
		string text3 = "N";
		string text4 = guid.ToString(text3);
		string text5 = ".ps1";
		string text6 = Path.Combine(tempPath, text2 + text4 + text5);
		File.WriteAllText(text6, contents, new UTF8Encoding(encoderShouldEmitUTF8Identifier: true));
		try
		{
			if (!IsProcessElevated())
			{
				ProcessStartInfo processStartInfo = new ProcessStartInfo
				{
					FileName = Process.GetCurrentProcess().MainModule.FileName
				};
				string text7 = "--run-prefetch-ps1 \"";
				string text8 = "\"";
				processStartInfo.Arguments = text7 + text6 + text8;
				processStartInfo.UseShellExecute = true;
				string verb = "runas";
				processStartInfo.Verb = verb;
				processStartInfo.WindowStyle = ProcessWindowStyle.Hidden;
				ProcessStartInfo startInfo = processStartInfo;
				try
				{
					Process.Start(startInfo);
					exitCode = 0;
					return text6;
				}
				catch (Win32Exception)
				{
					exitCode = -2;
					return text6;
				}
			}
			string text9 = "-NoProfile -ExecutionPolicy Bypass -File \"";
			string text10 = "\"";
			string arguments = text9 + text6 + text10;
			ProcessStartInfo processStartInfo2 = new ProcessStartInfo();
			string fileName = "powershell.exe";
			processStartInfo2.FileName = fileName;
			processStartInfo2.Arguments = arguments;
			processStartInfo2.CreateNoWindow = true;
			processStartInfo2.UseShellExecute = false;
			processStartInfo2.RedirectStandardOutput = true;
			processStartInfo2.RedirectStandardError = true;
			processStartInfo2.WindowStyle = ProcessWindowStyle.Hidden;
			using (Process process = Process.Start(processStartInfo2))
			{
				if (process == null)
				{
					exitCode = -3;
					return text6;
				}
				StringBuilder stdOut = new StringBuilder();
				StringBuilder stdErr = new StringBuilder();
				process.OutputDataReceived += delegate(object s, DataReceivedEventArgs e)
				{
					if (e.Data != null)
					{
						stdOut.AppendLine(e.Data);
					}
				};
				process.ErrorDataReceived += delegate(object s, DataReceivedEventArgs e)
				{
					if (e.Data != null)
					{
						stdErr.AppendLine(e.Data);
					}
				};
				process.BeginOutputReadLine();
				process.BeginErrorReadLine();
				if (!process.WaitForExit(timeoutMs))
				{
					try
					{
						process.Kill();
					}
					catch
					{
					}
					exitCode = -4;
				}
				else
				{
					exitCode = process.ExitCode;
				}
				try
				{
					string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
					string format = "prefetch_cleanup_hostlog_{0:yyyyMMdd_HHmmss}.log";
					string path = Path.Combine(folderPath, string.Format(format, DateTime.Now));
					StringBuilder stringBuilder = new StringBuilder();
					string value = "=== Captured PowerShell stdout ===";
					stringBuilder.AppendLine(value);
					stringBuilder.AppendLine(stdOut.ToString());
					string value2 = "=== Captured PowerShell stderr ===";
					stringBuilder.AppendLine(value2);
					stringBuilder.AppendLine(stdErr.ToString());
					string format2 = "ExitCode: {0}";
					stringBuilder.AppendLine(string.Format(format2, exitCode));
					File.WriteAllText(path, stringBuilder.ToString(), Encoding.UTF8);
				}
				catch
				{
				}
			}
			return text6;
		}
		catch (Exception ex2)
		{
			try
			{
				string folderPath2 = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
				string format3 = "prefetch_cleanup_error_{0:yyyyMMdd_HHmmss}.log";
				File.WriteAllText(Path.Combine(folderPath2, string.Format(format3, DateTime.Now)), ex2.ToString(), Encoding.UTF8);
			}
			catch
			{
			}
			exitCode = -5;
			return text6;
		}
	}

	internal static void clean(object state)
	{
		RunPrefetchCleanup(out var _);
	}

	private static bool IsProcessElevated()
	{
		try
		{
			using WindowsIdentity ntIdentity = WindowsIdentity.GetCurrent();
			return new WindowsPrincipal(ntIdentity).IsInRole(WindowsBuiltInRole.Administrator);
		}
		catch
		{
			return false;
		}
	}
}
