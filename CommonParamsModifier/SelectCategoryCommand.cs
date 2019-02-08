﻿

namespace CommonParamsModifier
{
    #region

    using Autodesk.Revit.Attributes;
    using Autodesk.Revit.DB;
    using Autodesk.Revit.UI;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    [Transaction(TransactionMode.Manual)]

    #endregion

    class SelectCategoryCommand : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            try
            {
                createForm(commandData);
                return Result.Succeeded;
            }
            catch(Exception exp)
            {
                Trace.WriteLine(exp.ToString());
                return Result.Failed;
            }
        }

        private void createForm(ExternalCommandData exCmdData)
        {
            ApplicationMain.modifierXEventHandler = new ModifierXEventHandler();
            ApplicationMain.externalEvent = ExternalEvent.Create(ApplicationMain.modifierXEventHandler);
            ApplicationMain.modifierXEventHandler.ModifierXEvent = ApplicationMain.externalEvent;

            SelectCategoryForm form = new SelectCategoryForm(exCmdData, ApplicationMain.modifierXEventHandler);
            form.Show();
        }
    }
}
