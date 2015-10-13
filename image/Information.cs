using System;

namespace image
{
	public class Information
	{
		public Information (string name,string address, string number)
		{
			name = this.name;
			address = this.address; //= ValueType;
			number =this.number;
		}
		private string name;
		private string address;
		private string number;
		public string Name
		{
			get
			{
				return this.name;
			}
			set
			{
				this.name = value;
			}
		}
		public string Address
		{
			get
			{
				return this.address;
			}
			set
			{
				this.address = value;
			}
		}
		public string Number
		{
			get
			{
				return this.number;
			}
			set
			{
				this.number = value;
			}
		}

	}
}

