using System;
using System.Collections.Generic;
using JetBrains.Annotations;

namespace Controller.DialogsSystem
{
    [UsedImplicitly]
    public class DialogSystem
    {
        private readonly Dictionary<Type, IDialog> dialogsByTypes = new();

        private IDialog currentlyOpenDialog;
        
        public DialogSystem(params IDialog[] dialogs)
        {
            foreach (var dialog in dialogs)
            {
                var type = dialog.GetType();
                dialogsByTypes.Add(type, dialog);
            }
        }
        
        public TDialog ShowDialog<TDialog>() where TDialog : class, IDialog
        {
            if (currentlyOpenDialog != null)
            {
                Hide();
            }
            
            var type = typeof(TDialog);
            if (dialogsByTypes.TryGetValue(type, out currentlyOpenDialog))
            {
                currentlyOpenDialog.Show();
                return (TDialog)currentlyOpenDialog;
            }

            return null;
        }

        public void Hide()
        {
            currentlyOpenDialog?.Hide();
            currentlyOpenDialog = null;
        }
    }
}
