using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace ExpressionConsol
{
    public class WhereExpressionVisitor : ExpressionVisitor
    {
        private readonly StringBuilder _whereBuilder;
        private readonly IEnumerable<Type> types = new List<Type>() {
        typeof(IEnumerable),
        typeof(Enumerable)
        };
        public string WhereBuilder => _whereBuilder.Length > 0 ? $" WHERE {_whereBuilder}" : "";

        public WhereExpressionVisitor(Expression exp)
        {
            _whereBuilder = new StringBuilder(100);
            Visit(exp);
        }

        protected override Expression VisitMember(MemberExpression node)
        {
            _whereBuilder.Append(node.Member.Name);
            return node;
        }

        protected override Expression VisitConstant(ConstantExpression node)
        {
            _whereBuilder.Append(node.Value);
            return node;
        }
        protected override Expression VisitBinary(BinaryExpression node)
        {
            Visit(node.Left);

            _whereBuilder.Append(node.GetExpressionType());

            Visit(node.Right);

            return node;
        }

        protected override Expression VisitMethodCall(MethodCallExpression node)
        {
            var mustList = types.Contains(typeof(Enumerable)) || node.Method.DeclaringType.GetInterfaces().Contains(typeof(IEnumerable));
            var notString = node.Method.DeclaringType != typeof(string);
            if (node.Method.Name == "Contains" && mustList)
            {
                In(node);
            }
            else if (node.Method.Name == "Equals")
            {
                Equal(node);
            }
            else
            {
                Like(node);
            }

            return node;
        }

        private void In(MethodCallExpression node)
        {
            string paramter = string.Empty;
            string valueStr = string.Empty;
            bool build = false;
            foreach (var item in node.Arguments)
            {
                if (item is MemberExpression)
                {
                    build = true;
                    var temp = item as MemberExpression;
                    if (temp.Expression.NodeType == ExpressionType.Constant)
                    {
                        var c = temp.Expression as ConstantExpression;
                        var _dy = c.Value.GetType();
                        if (_dy.IsClass)
                        {
                            var field = _dy.GetFields().FirstOrDefault();
                            var d = field.GetValue(c.Value);
                            var ccdk = field.FieldType.GetInterfaces();
                            if (ccdk.Contains(typeof(IEnumerable)))
                            {
                                var wskl = d as IEnumerable;
                                foreach (var tm in wskl)
                                {
                                    valueStr += $"'{tm.ToString()}',";
                                }
                                valueStr = valueStr.Remove(valueStr.Length-1,1) ;
                            }
                        }
                    }
                    else if (temp.Expression.NodeType == ExpressionType.Parameter)
                    {
                        paramter = temp.Member.Name;
                    }
                }
            }

            if (build)
            {
                _whereBuilder.AppendFormat($" {paramter} IN ({valueStr})");
            }
        }

        private void Equal(MethodCallExpression node)
        {
            Visit(node.Object);
            _whereBuilder.AppendFormat(" =12345");
        }

        private void Like(MethodCallExpression node)
        {
            Visit(node.Object);
            _whereBuilder.Append($" LIKE ");
            switch (node.Method.Name)
            {
                case "StartsWith":
                    {
                        _whereBuilder.Append("'%");
                        Visit(node.Arguments[0]);
                        _whereBuilder.Append("'");
                    }
                    break;
                case "EndsWith":
                    {
                        _whereBuilder.Append("'");
                        Visit(node.Arguments[0]);
                        _whereBuilder.Append("%'");
                    }
                    break;
                case "Contains":
                    {
                        _whereBuilder.Append("'%");
                        Visit(node.Arguments[0]);
                        _whereBuilder.Append("%'");
                    }
                    break;
                default:
                    _whereBuilder.Append("'%%'");
                    break;
            }
        }


    }
}
