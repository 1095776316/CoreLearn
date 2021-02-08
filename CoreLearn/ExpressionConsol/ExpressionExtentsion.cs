using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace ExpressionConsol
{
    public static class ExpressionExtentsion
    {
        public static string GetExpressionType(this BinaryExpression node)
        {
            string nodeType = null;
            switch (node.NodeType)
            {
                case ExpressionType.Equal:
                    nodeType = " = ";
                    break;
                case ExpressionType.AndAlso:
                    nodeType = " and ";
                    break;
                case ExpressionType.OrElse:
                    nodeType = " or ";
                    break;
                case ExpressionType.LessThan:
                    nodeType = " < ";
                    break;
                case ExpressionType.GreaterThan:
                    nodeType = " > ";
                    break;
                case ExpressionType.Not:
                    nodeType = " <> ";
                    break;
                case ExpressionType.NotEqual:
                    nodeType = " and ";
                    break;
                default:
                    nodeType = " and ";
                    break;
            }
            //if (node.Right.NodeType == ExpressionType.Constant && ((ConstantExpression)node.Right).Value == null)
            //{
            //    switch (node.NodeType)
            //    {
            //        case ExpressionType.Equal:
            //            nodeType = " IS ";
            //            break;
            //        case ExpressionType.NotEqual:
            //            nodeType = " IS NOT ";
            //            break;
            //    }
            //}

            return !string.IsNullOrEmpty(nodeType) ? nodeType : "";
        }
    }
}
