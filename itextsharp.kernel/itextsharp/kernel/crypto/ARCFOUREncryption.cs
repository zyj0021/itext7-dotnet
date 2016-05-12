/*
$Id: dba72f129db8a898277e84d252dbc1817c77b26d $

This file is part of the iText (R) project.
Copyright (c) 1998-2016 iText Group NV
Authors: Bruno Lowagie, Paulo Soares, et al.

This program is free software; you can redistribute it and/or modify
it under the terms of the GNU Affero General Public License version 3
as published by the Free Software Foundation with the addition of the
following permission added to Section 15 as permitted in Section 7(a):
FOR ANY PART OF THE COVERED WORK IN WHICH THE COPYRIGHT IS OWNED BY
ITEXT GROUP. ITEXT GROUP DISCLAIMS THE WARRANTY OF NON INFRINGEMENT
OF THIRD PARTY RIGHTS

This program is distributed in the hope that it will be useful, but
WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY
or FITNESS FOR A PARTICULAR PURPOSE.
See the GNU Affero General Public License for more details.
You should have received a copy of the GNU Affero General Public License
along with this program; if not, see http://www.gnu.org/licenses or write to
the Free Software Foundation, Inc., 51 Franklin Street, Fifth Floor,
Boston, MA, 02110-1301 USA, or download the license from the following URL:
http://itextpdf.com/terms-of-use/

The interactive user interfaces in modified source and object code versions
of this program must display Appropriate Legal Notices, as required under
Section 5 of the GNU Affero General Public License.

In accordance with Section 7(b) of the GNU Affero General Public License,
a covered work must retain the producer line in every PDF that is created
or manipulated using iText.

You can be released from the requirements of the license by purchasing
a commercial license. Buying such a license is mandatory as soon as you
develop commercial activities involving the iText software without
disclosing the source code of your own applications.
These activities include: offering paid services to customers as an ASP,
serving PDFs on the fly in a web application, shipping iText with a closed
source product.

For more information, please contact iText Software Corp. at this
address: sales@itextpdf.com
*/
namespace com.itextpdf.kernel.crypto
{
	public class ARCFOUREncryption
	{
		private byte[] state = new byte[256];

		private int x;

		private int y;

		/// <summary>Creates a new instance of ARCFOUREncryption</summary>
		public ARCFOUREncryption()
		{
		}

		public virtual void PrepareARCFOURKey(byte[] key)
		{
			PrepareARCFOURKey(key, 0, key.Length);
		}

		public virtual void PrepareARCFOURKey(byte[] key, int off, int len)
		{
			int index1 = 0;
			int index2 = 0;
			for (int k = 0; k < 256; ++k)
			{
				state[k] = (byte)k;
			}
			x = 0;
			y = 0;
			byte tmp;
			for (int k_1 = 0; k_1 < 256; ++k_1)
			{
				index2 = (key[index1 + off] + state[k_1] + index2) & 255;
				tmp = state[k_1];
				state[k_1] = state[index2];
				state[index2] = tmp;
				index1 = (index1 + 1) % len;
			}
		}

		public virtual void EncryptARCFOUR(byte[] dataIn, int off, int len, byte[] dataOut
			, int offOut)
		{
			int length = len + off;
			byte tmp;
			for (int k = off; k < length; ++k)
			{
				x = (x + 1) & 255;
				y = (state[x] + y) & 255;
				tmp = state[x];
				state[x] = state[y];
				state[y] = tmp;
				dataOut[k - off + offOut] = (byte)(dataIn[k] ^ state[(state[x] + state[y]) & 255]
					);
			}
		}

		public virtual void EncryptARCFOUR(byte[] data, int off, int len)
		{
			EncryptARCFOUR(data, off, len, data, off);
		}

		public virtual void EncryptARCFOUR(byte[] dataIn, byte[] dataOut)
		{
			EncryptARCFOUR(dataIn, 0, dataIn.Length, dataOut, 0);
		}

		public virtual void EncryptARCFOUR(byte[] data)
		{
			EncryptARCFOUR(data, 0, data.Length, data, 0);
		}
	}
}
