using System.Collections.Generic;
using Avalonia.Collections;
using Avalonia.Controls;
using Avalonia.Controls.Templates;
using Avalonia.VisualTree;
using WDE.Common.Avalonia.Utils;
using WDE.Common.Managers;
using WDE.Common.Windows;

namespace WoWDatabaseEditorCore.Avalonia.Docking
{
    public class PersistentDockDataTemplate : IRecyclingDataTemplate
    {
        private Dictionary<IDocument, IControl> documents = new();
        private Dictionary<ITool, IControl> tools = new();
        
        public bool Match(object data)
        {
            return data is AvaloniaDocumentDockWrapper || data is AvaloniaToolDockWrapper;
        }

        public IControl Build(object data, IControl? existing)
        {
            if (data is AvaloniaDocumentDockWrapper documentDockWrapper)
            {
                if (documents.TryGetValue(documentDockWrapper.ViewModel, out var view))
                {
                    var parent = view.VisualParent;
                    ((AvaloniaList<IVisual>) parent?.VisualChildren)?.Remove(view);
                    return view;
                }
                
                if (ViewBind.TryResolve(documentDockWrapper.ViewModel, out var documentView))
                {
                    documents[documentDockWrapper.ViewModel] = documentView as IControl;
                    documents[documentDockWrapper.ViewModel].DataContext = documentDockWrapper.ViewModel;
                    return documentView as IControl;
                }
            }
            else if (data is AvaloniaToolDockWrapper toolDockWrapper)
            {
                if (tools.TryGetValue(toolDockWrapper.ViewModel, out var view))
                {
                    var parent = view.VisualParent;
                    ((AvaloniaList<IVisual>) parent?.VisualChildren)?.Remove(view);
                    return view;
                }
                
                if (ViewBind.TryResolve(toolDockWrapper.ViewModel, out var documentView))
                {
                    tools[toolDockWrapper.ViewModel] = documentView as IControl;
                    tools[toolDockWrapper.ViewModel].DataContext = toolDockWrapper.ViewModel;
                    return documentView as IControl;
                }
            }

            return null;
        }

        public IControl Build(object data)
        {
            return Build(data, null);
        }
    }
}