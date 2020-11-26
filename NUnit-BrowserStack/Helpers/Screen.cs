using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingleTest.Helpers
{
    abstract class Screen
    {
        public Screen(CaptureHelpers captureHelper)
        {
            CaptureHelper = captureHelper;
        }

        public CaptureHelpers CaptureHelper { get; set; }

        /// <summary>
        /// Validate the title of the screen you're on
        /// </summary>
        abstract public void ValidateTitle();
        
        /// <summary>
        /// Capture data on the screen
        /// </summary>
        abstract public void CaptureData(int value = 1);

        /// <summary>
        /// Submit the screen
        /// </summary>
        abstract public void Submit();
    }
}
