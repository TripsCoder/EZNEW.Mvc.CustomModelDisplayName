using EZNEW.Framework.ExpressionUtil;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EZNEW.Mvc.CustomModelDisplayName
{
    /// <summary>
    /// Display Manager
    /// </summary>
    public static class DisplayManager
    {
        static Dictionary<string, DisplayText> displayDic = new Dictionary<string, DisplayText>();

        #region Methods

        /// <summary>
        /// Add Display Name
        /// </summary>
        /// <param name="type">Model Type</param>
        /// <param name="propertyName">property name</param>
        /// <param name="displayName">display name</param>
        public static void Add(Type type, string propertyName, string displayName)
        {
            if (type == null)
            {
                return;
            }
            SetDisplay(type.FullName, propertyName, displayName);
        }

        /// <summary>
        /// Add Display Name
        /// </summary>
        /// <typeparam name="T">Model Type</typeparam>
        /// <param name="property">property</param>
        /// <param name="displayName">display name</param>
        public static void Add<T>(Expression<Func<T, dynamic>> property, string displayName)
        {
            Add(typeof(T), ExpressionHelper.GetExpressionText(property), displayName);
        }

        /// <summary>
        /// Set Display Name
        /// </summary>
        /// <param name="typeFullName">type full name</param>
        /// <param name="propertyName">property name</param>
        /// <param name="displayName">display name</param>
        static void SetDisplay(string typeFullName, string propertyName, string displayName)
        {
            if (string.IsNullOrWhiteSpace(typeFullName) || string.IsNullOrWhiteSpace(propertyName) || string.IsNullOrWhiteSpace(displayName))
            {
                return;
            }
            string displayKey = GetDisplayKey(typeFullName, propertyName);
            if (displayDic.ContainsKey(displayKey))
            {
                var nowDisplayText = displayDic[displayKey];
                if (nowDisplayText == null)
                {
                    nowDisplayText = new DisplayText();
                }
                nowDisplayText.DisplayName = displayName;
            }
            else
            {
                displayDic.Add(displayKey, new DisplayText()
                {
                    DisplayName = displayName
                });
            }
        }

        static string GetDisplayKey(string typeFullName, string propertyName)
        {
            string displayKey = string.Format("{0}_{1}", typeFullName, propertyName);
            return displayKey;
        }

        /// <summary>
        /// get display
        /// </summary>
        /// <param name="type">model type</param>
        /// <param name="propertyName">property name</param>
        /// <returns></returns>
        public static DisplayText GetDisplay(Type type, string propertyName)
        {
            if (type == null)
            {
                return null;
            }
            return GetDisplay(type.FullName, propertyName);
        }

        /// <summary>
        /// get display
        /// </summary>
        /// <param name="typeFullname">type full name</param>
        /// <param name="propertyName">property name</param>
        /// <returns></returns>
        public static DisplayText GetDisplay(string typeFullname, string propertyName)
        {
            string displayKey = GetDisplayKey(typeFullname, propertyName);
            if (displayDic.ContainsKey(displayKey))
            {
                return displayDic[displayKey];
            }
            return null;
        }

        public static Dictionary<string, DisplayText> GetAllDisplay()
        {
            return displayDic;
        }

        #endregion
    }
}
