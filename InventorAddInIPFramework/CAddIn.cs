using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IronPython.Hosting;
using Microsoft.Scripting.Hosting;

namespace InvAddIn {
	internal class CAddIn {
		public dynamic AddInInstance { get; private set; }
		string AddInFilePath = "./AddInMain.py";
		ScriptEngine engine;
		ScriptScope scope;
		ScriptSource source;

		public CAddIn() {
			InializeAddInInstance();
		}

		private void InializeAddInInstance() {
			engine = Python.CreateEngine();
			scope = engine.CreateScope();
			source = engine.CreateScriptSourceFromFile(AddInFilePath);
            source.Execute(scope);
            var variables = scope.GetVariableNames();
			AddInInstance = scope.GetVariable("AddInInstance");
		}
	}
}
