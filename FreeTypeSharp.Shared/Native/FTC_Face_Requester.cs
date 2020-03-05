using System;

namespace FreeTypeSharp.Native
{
	public delegate FT_Error FTC_Face_Requester(IntPtr faceId, IntPtr library, IntPtr requestData, out IntPtr aface);
}