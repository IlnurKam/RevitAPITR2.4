using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevitAPITR2._4
{
    [Transaction(TransactionMode.Manual)]
    public class Main : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIApplication uiapp = commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Document doc = uidoc.Document;

            IList<FamilyInstance> fInstances = new FilteredElementCollector(doc, doc.ActiveView.Id)
            .OfCategory(BuildInCategory.OST_Column)
            .WhereElementIsNotElementType()
            .Cast<FamilyInstance>()
            .ToList();

            TaskDialog.Show("Column count", fInstances.Count.ToString());

            return Result.Succeeded;
        }
    }
}
