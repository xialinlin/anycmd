using Anycmd.Xacml.Interfaces;
using System;
using System.Diagnostics;
using System.Xml;

// ReSharper disable once CheckNamespace
namespace Anycmd.Xacml.Runtime.Functions
{
    /// <summary>
    /// Function implementation, in order to check the function behavior use the value of the Id
    /// property to search the function in the specification document.
    /// </summary>
    public class XPathNodeCount : FunctionBase
    {
        #region IFunction Members

        /// <summary>
        /// The id of the function, used only for notification.
        /// </summary>
        public override string Id
        {
            get { return Consts.Schema1.InternalFunctions.AnyUriEqual; }
        }

        /// <summary>
        /// Evaluates the function.
        /// </summary>
        /// <param name="context">The evaluation context instance.</param>
        /// <param name="args">The function arguments.</param>
        /// <returns>The result value of the function evaluation.</returns>
        public override EvaluationValue Evaluate(EvaluationContext context, params IFunctionParameter[] args)
        {
            if (context == null) throw new ArgumentNullException("context");
            if (args == null) throw new ArgumentNullException("args");
            XmlDocument doc = context.ContextDocument.XmlDocument;

            if (context.ContextDocument.XmlNamespaceManager == null)
            {
                context.ContextDocument.AddNamespaces(context.PolicyDocument.Namespaces);
            }

            string xPath = GetStringArgument(args, 0);
            Debug.Assert(doc.DocumentElement != null, "doc.DocumentElement != null");
            XmlNodeList list = doc.DocumentElement.SelectNodes(xPath, context.ContextDocument.XmlNamespaceManager);
            Debug.Assert(list != null, "list != null");
            return new EvaluationValue(list.Count, DataTypeDescriptor.Integer);
        }

        /// <summary>
        /// The data type of the return value.
        /// </summary>
        public override IDataType Returns
        {
            get { return DataTypeDescriptor.Integer; }
        }

        /// <summary>
        /// Defines the data types for the function arguments.
        /// </summary>
        public override IDataType[] Arguments
        {
            get { return new IDataType[] { DataTypeDescriptor.String }; }
        }

        #endregion
    }
}
