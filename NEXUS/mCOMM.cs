using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace NEXUS;

[EditorBrowsable(EditorBrowsableState.Never)]
[DesignTimeVisible(false)]
[Browsable(false)]
public interface mCOMM : IDisposable
{
	void SetCon(string str);

	void SetData(string key, string value);

	string GetData(string key);

	void SetSpare(string str, string str2);

	string isLV(string userID, string pwd, ref string errMessage);

	bool PerformB(Control cntrl, Rectangle rect, string strName, string userDetails, string iDetails, string tCntrlName, ref string txnID, bool isConfirmReq, bool isBConfirmReq, bool isP, int SlotID, UpdateTStatus updtStatus, string fir, CancellationToken token);

	bool GetTBSN(string strF, string strT, DateTime dt, ref List<string> stn);

	string GetF(string strF, string strT, string strTrn, string cls);

	List<string> GetPType();

	Dictionary<string, string> GetNet();

	Dictionary<string, string> GetD();
}
