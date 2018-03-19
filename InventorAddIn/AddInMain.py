import System
import clr

clr.AddReference("Autodesk.Inventor.Interop")
clr.AddReference("System.Windows.Forms")

from Inventor import Application
from UI import UI


class InventorAddIn(object):
	def __init__(self, *args, **kwargs):
		pass

	def Activate(self, inventor_app, first_time):
		#System.Windows.Forms.MessageBox.Show("Hello from Activate method {0}".format(inventor_app.UserName))
		ui = UI(inventor_app)
		ui.create()
		
	def Deactivate(self):
		#System.Windows.Forms.MessageBox.Show("Hello from Deactivate method")
		pass


AddInInstance = InventorAddIn()