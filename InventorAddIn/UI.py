# -*- coding: utf-8 -*-

import clr
clr.AddReference("Autodesk.Inventor.Interop")
clr.AddReference("System.Windows.Forms")

import Inventor as Inv
from Inventor import Application

class UI(object):

	def __init__(self, inventor_app):
		#self.app = Application #DEVELOP
		self.app = inventor_app

	def create(self):
		ui_manager = self.app.UserInterfaceManager
		cmd_manager = self.app.CommandManager

		
		ribbon = ui_manager.Ribbons.Item("ZeroDoc")
		tab = ribbon.RibbonTabs.Add("MyTab", "id_MyTab", "")
		panel = tab.RibbonPanels.Add("MyPanel", "id_MyPanel", "")

		btn = cmd_manager.ControlDefinitions.AddButtonDefinition("My Button", "id_MyButton", Inv.CommandTypesEnum.kQueryOnlyCmdType)
		#btn.OnExecute += self.OnExecute  # "System.OverflowException" возникло в Microsoft.Dynamic.dll

		panel.CommandControls.AddButton(btn, False)

	def OnExecute():
		System.Windows.Forms.MessageBox("On execute event raised")