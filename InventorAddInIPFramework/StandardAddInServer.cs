using System;
using System.Runtime.InteropServices;
using Inventor;
using Microsoft.Win32;
using InvAddIn;
using IronPython.Hosting;
using IronPython.Runtime;

namespace InventorAddInIPFramework {
	/// <summary>
	/// This is the primary AddIn Server class that implements the ApplicationAddInServer interface
	/// that all Inventor AddIns are required to implement. The communication between Inventor and
	/// the AddIn is via the methods on this interface.
	/// </summary>
	[GuidAttribute("9d459f91-43b1-4fe0-a3a7-0534f97f60b1")]
	public class StandardAddInServer: Inventor.ApplicationAddInServer {

		// Inventor application object.
		private Inventor.Application m_inventorApplication;
        private CAddIn AddIn;

        public StandardAddInServer() {
		}

		#region ApplicationAddInServer Members

		public void Activate(Inventor.ApplicationAddInSite addInSiteObject, bool firstTime) {

			m_inventorApplication = addInSiteObject.Application;

            AddIn = new CAddIn();
            AddIn.AddInInstance.Activate(m_inventorApplication, firstTime);

            // TODO: Add ApplicationAddInServer.Activate implementation.
            // e.g. event initialization, command creation etc.
        }

		public void Deactivate() {
            // TODO: Add ApplicationAddInServer.Deactivate implementation
            AddIn.AddInInstance.Deactivate();

			// Release objects.
			Marshal.ReleaseComObject(m_inventorApplication);
			m_inventorApplication = null;

			GC.WaitForPendingFinalizers();
			GC.Collect();
		}

		public void ExecuteCommand(int commandID) {
			// Note:this method is now obsolete, you should use the 
			// ControlDefinition functionality for implementing commands.
		}

		public object Automation {
			// This property is provided to allow the AddIn to expose an API 
			// of its own to other programs. Typically, this  would be done by
			// implementing the AddIn's API interface in a class and returning 
			// that class object through this property.

			get {
				// TODO: Add ApplicationAddInServer.Automation getter implementation
				return null;
			}
		}

		#endregion

	}
}
