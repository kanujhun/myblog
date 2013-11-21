﻿using Contrib.Widgets.Models;
using Orchard.ContentManagement.Drivers;
using Orchard.ContentManagement.Handlers;
using Orchard.Environment.Extensions;

namespace Contrib.Widgets.Drivers {
    [OrchardFeature("Contrib.Widgets")]
    public class WidgetExPartDriver : ContentPartDriver<WidgetExPart> {
        protected override void Importing(WidgetExPart part, ImportContentContext context) {
            context.ImportAttribute(part.PartDefinition.Name, "HostId", s => part.Host = context.GetItemFromSession(s));
        }

        protected override void Exporting(WidgetExPart part, ExportContentContext context) {
            context.Element(part.PartDefinition.Name).SetAttributeValue("HostId", context.ContentManager.GetItemMetadata(part.Host).Identity.ToString());
        }
    }
}