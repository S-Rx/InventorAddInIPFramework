using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inventor;

namespace Common
{
    public delegate void OnExecuteHandlerDelegate(NameValueMap context);

    public class Button
    {
        public Inventor.ButtonDefinition Definition {get; private set;}
        public event OnExecuteHandlerDelegate OnExecute;


        public Button(Inventor.Application App,
            string DisplayName, string InternalName, Inventor.CommandTypesEnum Classification,
            string ClientId = "", string DescriptionText = "", string ToolTipText = "",
            IPictureDisp StandardIcon = null, IPictureDisp LargeIcon = null,
            Inventor.ButtonDisplayEnum ButtonDisplay = ButtonDisplayEnum.kNoTextWithIcon)
        {
            Definition = App.CommandManager.ControlDefinitions.AddButtonDefinition(
                DisplayName: DisplayName,
                InternalName: InternalName,
                Classification: Classification,
                ClientId: ClientId,
                DescriptionText: DescriptionText,
                ToolTipText: ToolTipText,
                StandardIcon: StandardIcon,
                LargeIcon: LargeIcon,
                ButtonDisplay: ButtonDisplay);

            Definition.OnExecute += OnExecuteHandler;

        }

        public void OnExecuteHandler(NameValueMap context)
        {
            OnExecute?.Invoke(context);
        }
    }
}
