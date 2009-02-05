#region Disclaimer / License
// Copyright (C) 2008, Kenneth Skovhede
// http://www.hexad.dk, opensource@hexad.dk
// 
// This library is free software; you can redistribute it and/or
// modify it under the terms of the GNU Lesser General Public
// License as published by the Free Software Foundation; either
// version 2.1 of the License, or (at your option) any later version.
// 
// This library is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
// Lesser General Public License for more details.
// 
// You should have received a copy of the GNU Lesser General Public
// License along with this library; if not, write to the Free Software
// Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301  USA
// 
#endregion
using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace System.Windows.Forms.Wizard
{
    public class WizardControl : UserControl, IWizardControl
    {
        protected string m_title;
        protected string m_helpText;
        protected Image m_image;
        protected bool m_fullSize;

        protected bool m_autoFillValues = true;
        protected bool m_valuesAutoLoaded = false;

        protected IWizardForm m_owner;
        protected Dictionary<string, object> m_settings;

        protected event PageChangeHandler PageEnter;
        protected event PageChangeHandler PageLeave;
        protected event PageChangeHandler PageDisplay;

        //Windows forms designer support
        private WizardControl()
        {
        }

        public WizardControl(string title, string helptext)
            : this(title, helptext, null)
        {
        }

        public WizardControl(string title, string helptext, Image image)
            : this(title, helptext, image, false)
        {
        }

        public WizardControl(string title, string helptext, Image image, bool fullsize)
        {
            m_title = title;
            m_helpText = helptext;
            m_image = image;
            m_fullSize = fullsize;
        }

        #region IWizardControl Members

        public virtual Control Control
        {
            get { return this; }
        }

        public virtual string Title
        {
            get { return m_title; }
        }

        public virtual string HelpText
        {
            get { return m_helpText; }
        }

        public virtual Image Image
        {
            get { return m_image; }
        }

        public virtual bool FullSize
        {
            get { return m_fullSize; }
        }

        void IWizardControl.Display(IWizardForm owner, PageChangedArgs args)
        {
            if (PageDisplay != null)
                PageDisplay(owner, args);
        }

        void IWizardControl.Enter(IWizardForm owner, PageChangedArgs args)
        {
            m_owner = args.Owner;
            m_settings = args.Settings;

            if (m_autoFillValues)
                m_valuesAutoLoaded = LoadDialogSettings();

            if (PageEnter != null)
                PageEnter(owner, args);
        }

        void IWizardControl.Leave(IWizardForm owner, PageChangedArgs args)
        {
            if (PageLeave != null)
                PageLeave(owner, args);

            if (m_autoFillValues)
                SaveDialogSettings();
        }

        #endregion

        protected Control[] FindAllControls()
        {
            Dictionary<Control, object> visited = new Dictionary<Control, object>();
            List<Control> items = new List<Control>();
            List<Control> result = new List<Control>();

            foreach (Control c in this.Controls)
                items.Add(c);

            while (items.Count > 0)
            {
                Control c = items[0];
                items.RemoveAt(0);

                if (visited.ContainsKey(c))
                    continue;
                else
                    visited.Add(c, null);

                //Filter out display items
                if (!(c is Label || c is Button || c is GroupBox || c is Panel))
                    result.Add(c);

                foreach (Control cx in c.Controls)
                    items.Add(cx);
            }

            return result.ToArray();
        }

        /// <summary>
        /// Loads previously saved settings
        /// </summary>
        /// <returns>True if there were settings loaded, false otherwise. Use this flag to detect if the control should get default values.</returns>
        protected virtual bool LoadDialogSettings()
        {
            string prefix = this.GetType().FullName + ".";
            bool anyloaded = false;

            foreach(Control c in FindAllControls())
            {
                if (m_settings.ContainsKey(prefix + c.Name))
                {
                    anyloaded = true;

                    if (c is CheckBox)
                        ((CheckBox)c).Checked = (bool)m_settings[prefix + c.Name];
                    else if (c is TextBox)
                        c.Text = (string)m_settings[prefix + c.Name];
                    else if (c is ComboBox)
                    {
                        if (((ComboBox)c).DropDownStyle == ComboBoxStyle.DropDownList)
                            ((ComboBox)c).SelectedIndex = (int)m_settings[prefix + c.Name];
                        else
                            c.Text = (string)m_settings[prefix + c.Name];
                    }
                    else if (c is RadioButton)
                        ((RadioButton)c).Checked = (bool)m_settings[prefix + c.Name];
                    else if (c is NumericUpDown)
                        ((NumericUpDown)c).Value = (decimal)m_settings[prefix + c.Name];
                    else if (c is DateTimePicker)
                        ((DateTimePicker)c).Value = (DateTime)m_settings[prefix + c.Name];
                    else
                    {
                        //Default to "Value" if it exists, otherwise use "Text"
                        System.Reflection.PropertyInfo pi = c.GetType().GetProperty("Value");
                        if (pi == null)
                            c.Text = (string)m_settings[prefix + c.Name];
                        else
                            pi.SetValue(c, m_settings[prefix + c.Name], null);
                    }
                }
            }

            return anyloaded;
        }

        protected virtual void SaveDialogSettings()
        {
            string prefix = this.GetType().FullName + ".";

            foreach (Control c in FindAllControls())
                if (c is CheckBox)
                    m_settings[prefix + c.Name] = ((CheckBox)c).Checked;
                else if (c is TextBox)
                    m_settings[prefix + c.Name] = c.Text;
                else if (c is ComboBox)
                {
                    if (((ComboBox)c).DropDownStyle == ComboBoxStyle.DropDownList)
                        m_settings[prefix + c.Name] = ((ComboBox)c).SelectedIndex;
                    else
                        m_settings[prefix + c.Name] = c.Text;
                }
                else if (c is RadioButton)
                    m_settings[prefix + c.Name] = ((RadioButton)c).Checked;
                else if (c is NumericUpDown) 
                    m_settings[prefix + c.Name] = ((NumericUpDown)c).Value;
                else if (c is DateTimePicker)
                    m_settings[prefix + c.Name] = ((DateTimePicker)c).Value;
                else
                {
                    //Default to "Value" if it exists, otherwise use "Text"
                    System.Reflection.PropertyInfo pi = c.GetType().GetProperty("Value");
                    if (pi == null)
                        m_settings[prefix + c.Name] = c.Text;
                    else
                        m_settings[prefix + c.Name] = pi.GetValue(c, null);

                }
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // WizardControl
            // 
            this.Name = "WizardControl";
            this.Size = new System.Drawing.Size(506, 242);
            this.ResumeLayout(false);

        }
    }
}
