using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using NEXUS;

namespace IRCommDLL;

internal class IRComm : IDisposable, mCOMM
{
	private clsMain class9_0;

	private bool disposed;

	private readonly object disposeLock = new object();

	public static byte[] byte_0;

	public static byte[] byte_1;

	public static byte[] byte_2;

	public static byte[] byte_3;

	public static string AppName;

	public static string ExeName;

	internal IRComm()
	{
		class9_0 = new clsMain();
	}

	internal void SetCon(string str)
	{
		clsMain.DataBase_String = str;
	}

	internal void SetData(string key, string value)
	{
		ThrowIfDisposed();
		class9_0.SetData(key, value);
	}

	internal string GetData(string key)
	{
		ThrowIfDisposed();
		return class9_0.GetData(key);
	}

	internal void SetSpare(string str, string str1)
	{
		ThrowIfDisposed();
	}

	internal string isLV(string userID, string pwd, ref string errMessage)
	{
		ThrowIfDisposed();
		if (errMessage.Contains("Histry_"))
		{
			return class9_0.isLV_Print(userID, pwd, ref errMessage);
		}
		return class9_0.isLV(userID, pwd, ref errMessage);
	}

	internal bool PerformB(Control cntrl, Rectangle rect, string strName, string userDetails, string iDetails, string tCntrlName, ref string txnID, bool isConfirmReq, bool isBConfirmReq, bool isP, int SlotID, UpdateTStatus updtStatus, string fir, CancellationToken token)
	{
		return class9_0.PerformB(cntrl, rect, strName, userDetails, iDetails, tCntrlName, ref txnID, isConfirmReq, isBConfirmReq, isP, SlotID, updtStatus, fir, token);
	}

	internal bool GetTBSN(string strF, string strT, DateTime dateTime_0, ref List<string> stn)
	{
		ThrowIfDisposed();
		return class9_0.GetTBSN(strF, strT, dateTime_0, ref stn);
	}

	internal string GetF(string strF, string strT, string strTrn, string cls)
	{
		ThrowIfDisposed();
		return class9_0.GetF(strF, strT, strTrn, cls);
	}

	internal List<string> GetPType()
	{
		ThrowIfDisposed();
		return class9_0.GetPType();
	}

	internal Dictionary<string, string> GetNet()
	{
		ThrowIfDisposed();
		return class9_0.GetNet();
	}

	internal Dictionary<string, string> GetD()
	{
		ThrowIfDisposed();
		return class9_0.GetD();
	}

	protected virtual void Dispose(bool disposing)
	{
		if (disposed)
		{
			return;
		}
		lock (disposeLock)
		{
			if (disposed)
			{
				return;
			}
			if (disposing)
			{
				try
				{
					class9_0?.Dispose();
				}
				catch
				{
				}
				finally
				{
					class9_0 = null;
				}
			}
			disposed = true;
		}
	}

	public void Dispose()
	{
		class9_0.Dispose();
		GC.SuppressFinalize(this);
	}

	void IDisposable.Dispose()
	{
		Dispose();
	}

	private void ThrowIfDisposed()
	{
		if (disposed)
		{
			string objectName = "IRComm";
			throw new ObjectDisposedException(objectName);
		}
	}

	void mCOMM.SetCon(string str)
	{
		SetCon(str);
	}

	void mCOMM.SetData(string key, string value)
	{
		SetData(key, value);
	}

	string mCOMM.GetData(string key)
	{
		return GetData(key);
	}

	void mCOMM.SetSpare(string str, string str2)
	{
		SetSpare(str, str2);
	}

	string mCOMM.isLV(string userID, string pwd, ref string errMessage)
	{
		return isLV(userID, pwd, ref errMessage);
	}

	bool mCOMM.PerformB(Control cntrl, Rectangle rect, string strName, string userDetails, string iDetails, string tCntrlName, ref string txnID, bool isConfirmReq, bool isBConfirmReq, bool isP, int SlotID, UpdateTStatus updtStatus, string fir, CancellationToken token)
	{
		return PerformB(cntrl, rect, strName, userDetails, iDetails, tCntrlName, ref txnID, isConfirmReq, isBConfirmReq, isP, SlotID, updtStatus, fir, token);
	}

	bool mCOMM.GetTBSN(string strF, string strT, DateTime dt, ref List<string> stn)
	{
		return GetTBSN(strF, strT, dt, ref stn);
	}

	string mCOMM.GetF(string strF, string strT, string strTrn, string cls)
	{
		return GetF(strF, strT, strTrn, cls);
	}

	List<string> mCOMM.GetPType()
	{
		return GetPType();
	}

	Dictionary<string, string> mCOMM.GetNet()
	{
		return GetNet();
	}

	Dictionary<string, string> mCOMM.GetD()
	{
		return GetD();
	}

	static IRComm()
	{
		string appName = "Nget";
		AppName = appName;
		string exeName = "Nget.exe";
		ExeName = exeName;
	}
}
