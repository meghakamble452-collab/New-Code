using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using Newtonsoft.Json;

namespace IRCommDLL;

public class SensorDataManager
{
	public sealed class SensorPayload
	{
		public List<string> sensors { get; set; }

		public long timestamp { get; set; }

		public string userId { get; set; }
	}

	private readonly string _filePath;

	private readonly string _timeFormat = "dd:HH:mm:ss";

	private readonly object _fileLock = new object();

	private readonly TimeSpan _cooldown = TimeSpan.FromHours(2.0);

	public string GetOneAndRemoveFromFile_ok()
	{
		string text = "SensorList.json";
		string path = text;
		string result = string.Empty;
		try
		{
			if (!File.Exists(path))
			{
				string value = "File nahi mili!";
				Console.WriteLine(value);
				return null;
			}
			List<string> list = JsonConvert.DeserializeObject<List<string>>(File.ReadAllText(path)) ?? new List<string>();
			if (list.Count <= 0)
			{
				string value2 = "JSON file khali hai!";
				Console.WriteLine(value2);
				return null;
			}
			result = list[0];
			list.RemoveAt(0);
			string contents = JsonConvert.SerializeObject(list, Formatting.Indented);
			File.WriteAllText(path, contents);
			string text2 = "Ek record nikaal liya gaya. Baaki bache: ";
			Console.WriteLine(text2 + list.Count);
		}
		catch (Exception ex)
		{
			string text3 = "Error extracting data: ";
			Console.WriteLine(text3 + ex.Message);
		}
		return result;
	}

	public string GetOneAndRemoveFromFile()
	{
		string text = "SensorList.json";
		string path = text;
		string result = string.Empty;
		try
		{
			DateTime now = DateTime.Now;
			if (!File.Exists(path))
			{
				Console.WriteLine("File nahi mili!");
				return null;
			}
			List<string> list = JsonConvert.DeserializeObject<List<string>>(File.ReadAllText(path)) ?? new List<string>();
			if (list.Count <= 0)
			{
				Console.WriteLine("JSON file khali hai!");
				return null;
			}
			result = list[0];
			if (now.Hour >= 7 && now.Hour < 12)
			{
				list.RemoveAt(0);
				string contents = JsonConvert.SerializeObject(list, Formatting.Indented);
				File.WriteAllText(path, contents);
				Console.WriteLine("Ek record nikaal liya gaya. Baaki bache: " + list.Count);
			}
		}
		catch (Exception ex)
		{
			Console.WriteLine("Error : " + ex.Message);
		}
		return result;
	}

	internal string Sensor()
	{
		string result = string.Empty;
		try
		{
			string filePath = "sensors.json";
			SensorRecord availableSensorRoundRobin = new SensorDataManager(filePath).GetAvailableSensorRoundRobin();
			if (availableSensorRoundRobin == null)
			{
				string value = "No available sensors (all used within last 2 hours).";
				Console.WriteLine(value);
			}
			else
			{
				string text = "Using: ";
				string sensorData = availableSensorRoundRobin.SensorData;
				string text2 = "  Updated LastUse: ";
				Console.WriteLine(text + sensorData + text2 + availableSensorRoundRobin.LastUse);
			}
			result = availableSensorRoundRobin.SensorData;
		}
		catch (Exception)
		{
		}
		return result;
	}

	public SensorDataManager(string filePath)
	{
		_filePath = filePath;
		EnsureFileExists();
	}

	public SensorDataManager()
	{
	}

	private void EnsureFileExists()
	{
		if (File.Exists(_filePath))
		{
			return;
		}
		lock (_fileLock)
		{
			if (!File.Exists(_filePath))
			{
				string filePath = _filePath;
				string contents = "[]";
				File.WriteAllText(filePath, contents);
			}
		}
	}

	private List<SensorRecord> Load()
	{
		int num = 3;
		while (true)
		{
			try
			{
				lock (_fileLock)
				{
					string path = "sensors.json";
					string value = File.ReadAllText(path);
					if (!string.IsNullOrWhiteSpace(value))
					{
						return JsonConvert.DeserializeObject<List<SensorRecord>>(value) ?? new List<SensorRecord>();
					}
					return new List<SensorRecord>();
				}
			}
			catch (IOException)
			{
				if (--num == 0)
				{
					Thread.Sleep(50);
				}
			}
		}
	}

	private void Save(List<SensorRecord> records)
	{
		int num = 3;
		while (true)
		{
			try
			{
				lock (_fileLock)
				{
					string contents = JsonConvert.SerializeObject(records, Formatting.Indented);
					string path = "sensors.json";
					File.WriteAllText(path, contents);
					break;
				}
			}
			catch (IOException)
			{
				if (--num == 0)
				{
					Thread.Sleep(50);
				}
			}
		}
	}

	public SensorRecord GetAvailableSensorRoundRobin()
	{
		List<SensorRecord> list = Load();
		DateTime now = DateTime.Now;
		foreach (var item in (from x in list.Select(delegate(SensorRecord r)
			{
				if (DateTime.TryParseExact(r.LastUse, _timeFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out var result))
				{
					while (true)
					{
						int[,,] array = new int[2, 5, 1]
						{
							{
								{ 1990624178 },
								{ 1398529811 },
								{ 1274394809 },
								{ -1739655575 },
								{ 1398529810 }
							},
							{
								{ 520633123 },
								{ 424152292 },
								{ 536576065 },
								{ 1291759293 },
								{ 1958571660 }
							}
						};
						switch (-(array[0, 1, 0] ^ -1398529811))
						{
						case 2:
							return (record: r, lastUse: result, parsed: true);
						case 0:
							continue;
						}
						break;
					}
				}
				return (record: r, lastUse: DateTime.MinValue, parsed: false);
			}).ToList()
			orderby x.lastUse
			select x).ToList())
		{
			if (!item.parsed || now - item.lastUse >= _cooldown)
			{
				item.record.LastUse = now.ToString(_timeFormat);
				Save(list);
				return item.record;
			}
		}
		return null;
	}

	public void AddSensor(string sensorData, bool setNeverUsed = true)
	{
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Expected O, but got Unknown
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Expected O, but got Unknown
		try
		{
			HttpClient val = new HttpClient((HttpMessageHandler)new HttpClientHandler
			{
				AutomaticDecompression = (DecompressionMethods.GZip | DecompressionMethods.Deflate)
			});
			try
			{
				string uriString = "https://token8.taslavalidate.com";
				val.BaseAddress = new Uri(uriString);
				((HttpHeaders)val.DefaultRequestHeaders).Clear();
				HttpRequestHeaders defaultRequestHeaders = val.DefaultRequestHeaders;
				string text = "Accept";
				string text2 = "text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.7";
				((HttpHeaders)defaultRequestHeaders).Add(text, text2);
				HttpRequestHeaders defaultRequestHeaders2 = val.DefaultRequestHeaders;
				string text3 = "Accept-Language";
				string text4 = "en-US,en;q=0.9";
				((HttpHeaders)defaultRequestHeaders2).Add(text3, text4);
				HttpRequestHeaders defaultRequestHeaders3 = val.DefaultRequestHeaders;
				string text5 = "User-Agent";
				string text6 = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/120.0.0.0 Safari/537.36";
				((HttpHeaders)defaultRequestHeaders3).Add(text5, text6);
				string text7 = "/sensor/SMRSELF";
				HttpResponseMessage result = val.GetAsync(text7).Result;
				string result2 = result.Content.ReadAsStringAsync().Result;
				string text8 = "Status: ";
				Console.WriteLine(text8 + (int)result.StatusCode);
				string text9 = "Body:\n";
				Console.WriteLine(text9 + result2);
				string path = "sensor_lk";
				File.WriteAllText(path, result2);
				sensorData = result2;
			}
			finally
			{
				((IDisposable)val)?.Dispose();
			}
			try
			{
				string path2 = "sensors.json";
				File.Delete(path2);
				string path3 = "sensors.json";
				File.Create(path3).Close();
				SensorPayload sensorPayload = JsonConvert.DeserializeObject<SensorPayload>(sensorData);
				string filePath = "sensors.json";
				new SensorDataManager(filePath);
				Load();
				List<SensorRecord> records = (from s in sensorPayload.sensors
					where !string.IsNullOrWhiteSpace(s)
					select new SensorRecord
					{
						SensorData = s,
						LastUse = (setNeverUsed ? DateTime.MinValue.ToString(_timeFormat) : DateTime.Now.ToString(_timeFormat))
					}).ToList();
				Save(records);
			}
			catch (Exception)
			{
			}
		}
		catch (Exception)
		{
		}
	}

	public bool TouchSensor(string sensorData)
	{
		List<SensorRecord> list = Load();
		SensorRecord sensorRecord = list.FirstOrDefault((SensorRecord r) => r.SensorData == sensorData);
		if (sensorRecord != null)
		{
			sensorRecord.LastUse = DateTime.Now.ToString(_timeFormat);
			Save(list);
			return true;
		}
		return false;
	}
}
