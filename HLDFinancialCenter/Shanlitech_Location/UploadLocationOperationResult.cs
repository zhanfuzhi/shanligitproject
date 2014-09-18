using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shanlitech_Location
{
    public class UploadLocationOperationResult:IAsyncResult
    {
        #region IAsyncResult 成员

        public object AsyncState
        {
            get { throw new NotImplementedException(); }
        }

        public System.Threading.WaitHandle AsyncWaitHandle
        {
            get { throw new NotImplementedException(); }
        }

        public bool CompletedSynchronously
        {
            get { throw new NotImplementedException(); }
        }

        public bool IsCompleted
        {
            get { throw new NotImplementedException(); }
        }

        #endregion
    }
}
