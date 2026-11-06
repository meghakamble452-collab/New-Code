using System;

namespace NativeCSharpJWTToken;

internal class JavaUUID
{
	public struct Uuid : IEquatable<Uuid>
	{
		private readonly long leastSignificantBits;

		private readonly long mostSignificantBits;

		public long LeastSignificantBits => leastSignificantBits;

		public long MostSignificantBits => mostSignificantBits;

		public Uuid(long mostSignificantBits, long leastSignificantBits)
		{
			this.mostSignificantBits = mostSignificantBits;
			this.leastSignificantBits = leastSignificantBits;
		}

		public override bool Equals(object obj)
		{
			if (obj != null && obj is Uuid uuid)
			{
				return Equals(uuid);
			}
			return false;
		}

		public bool Equals(Uuid uuid)
		{
			if (mostSignificantBits == uuid.mostSignificantBits)
			{
				while (true)
				{
					int[,,,] array = new int[2, 5, 1, 1]
					{
						{
							{ { -37014812 } },
							{ { 2048448803 } },
							{ { 931597309 } },
							{ { 976015682 } },
							{ { 2042583901 } }
						},
						{
							{ { -1869203613 } },
							{ { -1368209503 } },
							{ { 1662132413 } },
							{ { -37014813 } },
							{ { 448078120 } }
						}
					};
					switch (-array[0, 0, 0, 0])
					{
					case 37014812:
						return leastSignificantBits == uuid.leastSignificantBits;
					case 37014811:
						continue;
					}
					break;
				}
			}
			return false;
		}

		bool IEquatable<Uuid>.Equals(Uuid uuid)
		{
			return Equals(uuid);
		}

		public override int GetHashCode()
		{
			return ((Guid)this).GetHashCode();
		}

		public override string ToString()
		{
			return ((Guid)this).ToString();
		}

		public static bool operator ==(Uuid a, Uuid b)
		{
			return a.Equals(b);
		}

		public static bool operator !=(Uuid a, Uuid b)
		{
			return !a.Equals(b);
		}

		public static explicit operator Guid(Uuid uuid)
		{
			if (uuid == default(Uuid))
			{
				return default(Guid);
			}
			byte[] bytes = BitConverter.GetBytes(uuid.mostSignificantBits);
			byte[] bytes2 = BitConverter.GetBytes(uuid.leastSignificantBits);
			return new Guid(new byte[16]
			{
				bytes[4],
				bytes[5],
				bytes[6],
				bytes[7],
				bytes[2],
				bytes[3],
				bytes[0],
				bytes[1],
				bytes2[7],
				bytes2[6],
				bytes2[5],
				bytes2[4],
				bytes2[3],
				bytes2[2],
				bytes2[1],
				bytes2[0]
			});
		}

		public static implicit operator Uuid(Guid value)
		{
			if (value == default(Guid))
			{
				return default(Uuid);
			}
			byte[] array = value.ToByteArray();
			byte[] value2 = new byte[16]
			{
				array[6],
				array[7],
				array[4],
				array[5],
				array[0],
				array[1],
				array[2],
				array[3],
				array[15],
				array[14],
				array[13],
				array[12],
				array[11],
				array[10],
				array[9],
				array[8]
			};
			return new Uuid(BitConverter.ToInt64(value2, 0), BitConverter.ToInt64(value2, 8));
		}

		public static Uuid FromString(string input)
		{
			return Guid.Parse(input);
		}
	}
}
