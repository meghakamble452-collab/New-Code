using System.Collections.Generic;
using System.Linq;

namespace APP_FRAMEWORK;

public class LZSS_UP
{
	public class EncodeState
	{
		public int[] lchild = new int[1025];

		public int[] rchild = Enumerable.Repeat(1024, 1282).ToArray();

		public int[] parent = Enumerable.Repeat(1024, 1025).ToArray();

		public byte[] text_buf = Enumerable.Repeat(byte.MaxValue, 1059).ToArray();

		public int match_position;

		public int match_length;
	}

	private static void smethod_0(EncodeState encodeState_0, int int_0)
	{
		int num = 1;
		int num2 = 1025 + encodeState_0.text_buf[int_0];
		int[] rchild = encodeState_0.rchild;
		encodeState_0.lchild[int_0] = 1024;
		rchild[int_0] = 1024;
		encodeState_0.match_length = 0;
		while (true)
		{
			if (num >= 0)
			{
				if (encodeState_0.rchild[num2] == 1024)
				{
					encodeState_0.rchild[num2] = int_0;
					encodeState_0.parent[int_0] = num2;
					return;
				}
				num2 = encodeState_0.rchild[num2];
			}
			else
			{
				if (encodeState_0.lchild[num2] == 1024)
				{
					encodeState_0.lchild[num2] = int_0;
					encodeState_0.parent[int_0] = num2;
					return;
				}
				num2 = encodeState_0.lchild[num2];
			}
			int num3 = 0;
			for (num3 = 1; num3 < 34; num3++)
			{
				if ((num = encodeState_0.text_buf[int_0 + num3] - encodeState_0.text_buf[num2 + num3]) != 0)
				{
					break;
				}
			}
			if (num3 > encodeState_0.match_length)
			{
				encodeState_0.match_position = num2;
				if ((encodeState_0.match_length = num3) >= 34)
				{
					break;
				}
			}
		}
		encodeState_0.parent[int_0] = encodeState_0.parent[num2];
		encodeState_0.lchild[int_0] = encodeState_0.lchild[num2];
		encodeState_0.rchild[int_0] = encodeState_0.rchild[num2];
		encodeState_0.parent[encodeState_0.lchild[num2]] = int_0;
		encodeState_0.parent[encodeState_0.rchild[num2]] = int_0;
		if (encodeState_0.rchild[encodeState_0.parent[num2]] != num2)
		{
			encodeState_0.lchild[encodeState_0.parent[num2]] = int_0;
		}
		else
		{
			encodeState_0.rchild[encodeState_0.parent[num2]] = int_0;
		}
		encodeState_0.parent[num2] = 1024;
	}

	private static void smethod_1(EncodeState encodeState_0, int int_0)
	{
		if (encodeState_0.parent[int_0] == 1024)
		{
			return;
		}
		int num;
		if (encodeState_0.rchild[int_0] == 1024)
		{
			num = encodeState_0.lchild[int_0];
		}
		else if (encodeState_0.lchild[int_0] == 1024)
		{
			num = encodeState_0.rchild[int_0];
		}
		else
		{
			num = encodeState_0.lchild[int_0];
			if (encodeState_0.rchild[num] != 1024)
			{
				do
				{
					num = encodeState_0.rchild[num];
				}
				while (encodeState_0.rchild[num] != 1024);
				encodeState_0.rchild[encodeState_0.parent[num]] = encodeState_0.lchild[num];
				encodeState_0.parent[encodeState_0.lchild[num]] = encodeState_0.parent[num];
				encodeState_0.lchild[num] = encodeState_0.lchild[int_0];
				encodeState_0.parent[encodeState_0.lchild[int_0]] = num;
			}
			encodeState_0.rchild[num] = encodeState_0.rchild[int_0];
			encodeState_0.parent[encodeState_0.rchild[int_0]] = num;
		}
		encodeState_0.parent[num] = encodeState_0.parent[int_0];
		if (encodeState_0.rchild[encodeState_0.parent[int_0]] == int_0)
		{
			encodeState_0.rchild[encodeState_0.parent[int_0]] = num;
		}
		else
		{
			encodeState_0.lchild[encodeState_0.parent[int_0]] = num;
		}
		encodeState_0.parent[int_0] = 1024;
	}

	public static List<byte> Compress(List<byte> input)
	{
		List<byte> list = new List<byte>();
		EncodeState encodeState = new EncodeState();
		byte[] array = new byte[17];
		byte b = 1;
		array[0] = 0;
		int num = 1;
		int num2 = 0;
		int num3 = 990;
		int num4 = 0;
		int i;
		for (i = 0; i < 34; i++)
		{
			if (num4 >= input.Count)
			{
				break;
			}
			encodeState.text_buf[num3 + i] = input[num4++];
		}
		for (int j = 1; j <= 34; j++)
		{
			smethod_0(encodeState, num3 - j);
		}
		smethod_0(encodeState, num3);
		do
		{
			if (encodeState.match_length > i)
			{
				encodeState.match_length = i;
			}
			if (encodeState.match_length <= 2)
			{
				encodeState.match_length = 1;
				array[0] |= b;
				array[num++] = encodeState.text_buf[num3];
			}
			else
			{
				array[num++] = (byte)encodeState.match_position;
				int num5 = (encodeState.match_position & 0xFF00) >> 3;
				int num6 = (encodeState.match_length - 3) & 0x1F;
				array[num++] = (byte)(num5 | num6);
			}
			int k;
			if ((b <<= 1) == 0)
			{
				for (k = 0; k < num; k++)
				{
					list.Add(array[k]);
				}
				for (k = 0; k < array.Length; k++)
				{
					array[k] = 0;
				}
				b = 1;
				num = 1;
			}
			int match_length = encodeState.match_length;
			for (k = 0; k < match_length; k++)
			{
				if (num4 >= input.Count)
				{
					break;
				}
				smethod_1(encodeState, num2);
				byte b2 = input[num4++];
				encodeState.text_buf[num2] = b2;
				if (num2 < 33)
				{
					encodeState.text_buf[num2 + 1024] = b2;
				}
				num2 = (num2 + 1) & 0x3FF;
				num3 = (num3 + 1) & 0x3FF;
				smethod_0(encodeState, num3);
			}
			while (k++ < match_length)
			{
				smethod_1(encodeState, num2);
				num2 = (num2 + 1) & 0x3FF;
				num3 = (num3 + 1) & 0x3FF;
				if (--i > 0)
				{
					smethod_0(encodeState, num3);
				}
			}
		}
		while (i > 0);
		if (num > 1)
		{
			for (int l = 0; l < num; l++)
			{
				list.Add(array[l]);
			}
		}
		return list;
	}

	public static List<byte> Decompress(List<byte> input)
	{
		byte[] array = new byte[1024];
		int num = 0;
		List<byte> list = new List<byte>();
		int num2 = 990;
		byte b = 0;
		for (int i = 0; i < 990; i++)
		{
			array[i] = 0;
		}
		ushort num3 = 0;
		while (true)
		{
			if (((num3 >>= 1) & 0x100) == 0)
			{
				if (num >= input.Count)
				{
					break;
				}
				num3 = (ushort)(input[num++] | 0xFF00);
			}
			if ((num3 & 1) > 0)
			{
				if (num >= input.Count)
				{
					break;
				}
				b = input[num++];
				list.Add(b);
				array[num2++] = b;
				num2 &= 0x3FF;
				continue;
			}
			int num4 = 0;
			int num5 = 0;
			if (num >= input.Count)
			{
				break;
			}
			num4 = input[num++];
			if (num >= input.Count)
			{
				break;
			}
			num5 = input[num++];
			num4 |= (num5 & 0xE0) << 3;
			num5 = (num5 & 0x1F) + 2;
			for (int j = 0; j <= num5; j++)
			{
				b = array[(num4 + j) & 0x3FF];
				list.Add(b);
				array[num2++] = b;
				num2 &= 0x3FF;
			}
		}
		return list;
	}
}
